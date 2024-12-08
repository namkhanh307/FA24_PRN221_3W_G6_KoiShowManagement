using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Models;
using KoiShowManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service;

namespace Page.Pages.PointOnProgressings
{
    public class CreateModel : PageModel
    {
        //private readonly Repo.Models.FA24_SE1702_PRN221_G6_KoiShowManagementContext _context;
        private readonly PointOnProgressingService _pointOnprocessingService;
        private readonly RegistrationService _registrationService;
        private readonly UserService _userService;
        private readonly CompetitionCategoryService _ccService;    
        public CreateModel(PointOnProgressingService pointOnProgressingService, RegistrationService registrationService, UserService userService, CompetitionCategoryService ccService)
        {
            _pointOnprocessingService = pointOnProgressingService;
            _registrationService = registrationService;
            _userService = userService;
            _ccService = ccService;
        }

        public async Task<IActionResult> OnGet()
        {
            var competitionCategories = await _ccService.GetAll();
            ViewData["CategoryId"] = new SelectList(competitionCategories, "CategoryId", "CategoryName");
            var user = await _userService.GetAllAsync();
            ViewData["JuryId"] = new SelectList(user, "UserId", "Email");
            var regis = await _registrationService.GetAllAsync();
            ViewData["RegistrationId"] = new SelectList(regis, "RegistrationId", "RegistrationId");
            return Page();
        }

        [BindProperty]
        public PointOnProgressing PointOnProgressing { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _pointOnprocessingService.Create(PointOnProgressing);

            return RedirectToPage("./Index");
        }
    }
}
