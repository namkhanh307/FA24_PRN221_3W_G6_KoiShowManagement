using KoiShowManagement.Repositories.Models;
using KoiShowManagement.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace PharmaceuticalManagement_NguyenVietNamKhanh.Pages
{
    public class LoginModel : PageModel
    {
        private readonly UserService _userService;
        public LoginModel(UserService userService)
        {
            _userService = userService;
        }

            //public void OnGet()
            //{
            //}

            //public async Task OnPost()
            //{
            //    string? userName = Request.Form["txtUserName"];
            //    string? password = Request.Form["txtPassword"];
            //    if (userName != null && password != null)
            //    {
            //        User? user = await _userService.Login(userName, password);
            //        if (user != null && (user.Role.RoleName.Equals("Examiner") || user.Role.RoleName.Equals("Manager")))
            //        {
            //            string? role= user.Role.RoleName.ToString() ?? "";
            //            HttpContext.Session.SetString("Role", role);
            //            Response.Redirect("/RegistrationPages");
            //        }
            //        else
            //            Response.Redirect("/Error");
            //    }

            //}

        //public void OnGetLogout()
        //{
        //    Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
        //    Response.Headers["Pragma"] = "no-cache";
        //    Response.Headers["Expires"] = "-1"; 
        //    HttpContext.Session.Clear();
        //    HttpContext.Session.Remove("Role");
        //    Response.Redirect("Login");
        //}
        [TempData]
        public string ErrorMessage { get; set; }
        public string ReturnUrl { get; set; }
        [BindProperty, Required]
        public string Username { get; set; }
        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }
        public void OnGet(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                ReturnUrl = returnUrl;
            }
            else
            {
                ReturnUrl = Url.Content("~/");
            }
        }


        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                ReturnUrl = returnUrl;
            }
            else
            {
                ReturnUrl = Url.Content("~/");
            }

            if (ModelState.IsValid)
            {
                // Replace this with your user verification logic
                var user = await _userService.Login(Username, Password);

                if (user != null)
                {
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, Username),
                new Claim(ClaimTypes.Role, user.Role.RoleName) // Assuming user has a role
            };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                    return LocalRedirect(returnUrl); // Ensures safe redirection
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return Page(); // Re-display login page if login fails
        }


    }
}
