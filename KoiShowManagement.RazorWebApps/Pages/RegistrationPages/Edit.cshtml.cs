using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiShowManagement.Repositories.Models;
using KoiShowManagement.Services;

namespace KoiShowManagement.RazorWebApps.Pages.RegistrationPages
{
    public class EditModel : PageModel
    {
        private readonly RegistrationService _registrationService;
        private readonly UserService _userService;
        private readonly CompetitionService _competitionService;
        private readonly AnimalService _animalService;

        public EditModel(RegistrationService registrationService, UserService userService, CompetitionService competitionService, AnimalService animalService)
        {
            _registrationService = registrationService;
            _userService = userService;
            _competitionService = competitionService;
            _animalService = animalService;
        }


        [BindProperty]
        public Registration Registration { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration =  await _registrationService.GetByIdAsync(id);
            if (registration == null)
            {
                return NotFound();
            }
            Registration = registration;
                ViewData["AnimalId"] = new SelectList(await _animalService.GetAllAsync(), "AnimalId", "AnimalName");
                ViewData["CompetitionId"] = new SelectList(await _competitionService.GetAllAsync(), "CompetitionId", "CompetitionName");
                ViewData["UserId"] = new SelectList(await _userService.GetAllAsync(), "UserId", "Username");
                return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            try
            {
                await _registrationService.UpdateAsync(Registration);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await RegistrationExists(Registration.RegistrationId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private async Task<bool> RegistrationExists(int id)
        {
            return await _registrationService.GetByIdAsync(id) != null;
        }
    }
}
