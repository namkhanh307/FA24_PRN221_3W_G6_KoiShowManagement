using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiShowManagement.Repositories.Models;
using KoiShowManagement.Services;

namespace KoiShowManagement.RazorWebApps.Pages.RegistrationPages
{
    public class CreateModel : PageModel
    {
        private readonly RegistrationService _registrationService;
        private readonly UserService _userService;
        private readonly CompetitionService _competitionService;
        private readonly AnimalService _animalService;

        public CreateModel(RegistrationService registrationService, UserService userService, CompetitionService competitionService, AnimalService animalService)
        {
            _registrationService = registrationService;
            _userService = userService;
            _competitionService = competitionService;
            _animalService = animalService;
        }

        public async Task<IActionResult> OnGet()
        {
        ViewData["AnimalId"] = new SelectList(await _animalService.GetAllAsync(), "AnimalId", "AnimalName");
        ViewData["CompetitionId"] = new SelectList(await _competitionService.GetAllAsync(), "CompetitionId", "CompetitionName");
        ViewData["UserId"] = new SelectList(await _userService.GetAllAsync(), "UserId", "Username");
            return Page();
        }

        [BindProperty]
        public Registration Registration { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await PopulateData();
                return Page();
            }
            int count = _registrationService.CheckDuplicateRegistration(Registration.CompetitionId, Registration.UserId, Registration.AnimalId);
            if (count > 0)
            {
                ViewData["Error"] = "This koi of user has been registered!";
                await PopulateData();
                return Page();
            }
            await _registrationService.CreateAsync(Registration);
            return RedirectToPage("./Index");
        }
        private async Task PopulateData()
        {
            ViewData["AnimalId"] = new SelectList(await _animalService.GetAllAsync(), "AnimalId", "AnimalName");
            ViewData["CompetitionId"] = new SelectList(await _competitionService.GetAllAsync(), "CompetitionId", "CompetitionName");
            ViewData["UserId"] = new SelectList(await _userService.GetAllAsync(), "UserId", "Username");
        }
    }
}
