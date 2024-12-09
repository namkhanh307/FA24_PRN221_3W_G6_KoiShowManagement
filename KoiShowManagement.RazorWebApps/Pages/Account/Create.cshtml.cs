using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiShowManagement.Repositories.Models;
using KoiShowManagement.Services;

namespace KoiShowManagement.RazorWebApps.Pages.Account
{
    public class CreateModel : PageModel
    {
        private readonly UserService _userService;
        private readonly RoleService _roleService;
        public CreateModel(UserService userService, RoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        public async Task<IActionResult> OnGet()
        {
        ViewData["RoleId"] = new SelectList(await _roleService.GetAllAsync(), "RoleId", "RoleName");
            return Page();
        }

        [BindProperty]
        public User User { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await PopulateData();
                return Page();
            }
            int check = _userService.Check(User.Username);
            if (check > 0)
            {
                ModelState.AddModelError("User.Username", "Username already exists.");
                await PopulateData();
                return Page();
            }
            await _userService.Create(User);

            return RedirectToPage("./Index");
        }
        private async Task PopulateData()
        {
            ViewData["RoleId"] = new SelectList(await _roleService.GetAllAsync(), "RoleId", "RoleName");

        }
    }
}
