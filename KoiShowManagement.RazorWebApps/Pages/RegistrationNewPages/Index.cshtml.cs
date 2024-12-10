using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiShowManagement.Repositories.Models;
using KoiShowManagement.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KoiShowManagement.RazorWebApps.Pages.RegistrationNewPages
{
    public class IndexModel : PageModel
    {
        private readonly RegistrationService _registrationService;

        public IndexModel(RegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        public IList<Registration> Registration { get;set; } = default!;
        public List<SelectListItem> CompetitionNames { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SelectedCompetitionName { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool CheckInStatus { get; set; }

        [BindProperty(SupportsGet = true)]
        public string AnimalName { get; set; }

        public async Task OnGet()
        {
            // Populate CompetitionNames dropdown
            CompetitionNames = new List<SelectListItem>
            {
                new SelectListItem { Value = "Summer Splash", Text = "Summer Splash" },
                new SelectListItem { Value = "Spring Koi Show", Text = "Spring Koi Show" },
                new SelectListItem { Value = "Winter Championship", Text = "Winter Championship" }
            };
            Registration = await _registrationService.SearchNew(SelectedCompetitionName, CheckInStatus, AnimalName);

        }
    }
}
