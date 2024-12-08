using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiShowManagement.Repositories.Models;
using KoiShowManagement.Services;

namespace KoiShowManagement.RazorWebApps.Pages.RegistrationPages
{
    public class DetailsModel : PageModel
    {
        private readonly RegistrationService _registrationService;
        private readonly UserService _userService;
        private readonly CompetitionService _competitionService;
        private readonly AnimalService _animalService;

        public DetailsModel(RegistrationService registrationService, UserService userService, CompetitionService competitionService, AnimalService animalService)
        {
            _registrationService = registrationService;
            _userService = userService;
            _competitionService = competitionService;
            _animalService = animalService;
        }

        public Registration Registration { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _registrationService.GetByIdAsync(id);
            if (registration == null)
            {
                return NotFound();
            }
            else
            {
                Registration = registration;
            }
            return Page();
        }
    }
}
