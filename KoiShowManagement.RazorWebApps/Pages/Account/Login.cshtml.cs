using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using KoiShowManagement.Services;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Logging;

namespace FA24_PRN221_3W_G6_KoiShowManagement.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly UserService _userService;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(UserService userService, ILogger<LoginModel> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [BindProperty]
        public LoginInput Input { get; set; }
        public string ErrorMessage { get; set; }

        public class LoginInput
        {
            [Required(ErrorMessage = "Input your username")]
            public string Username { get; set; }

            [Required(ErrorMessage = "Input your password")]
            public string Password { get; set; }
        }

        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                _logger.LogInformation($"Attempting login for user: {Input.Username}");

                var user = await _userService.Login(Input.Username, Input.Password);

                if (user == null)
                {
                    ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng";
                    return Page();
                }

                _logger.LogInformation($"User found: {user.Username}");

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim("UserId", user.UserId.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    claimsPrincipal,
                    new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(24)
                    });

                _logger.LogInformation($"Authentication successful for user: {user.Username}");

                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Login error: {ex.Message}");
                ErrorMessage = "Đã xảy ra lỗi trong quá trình đăng nhập";
                return Page();
            }
        }
    }
}
