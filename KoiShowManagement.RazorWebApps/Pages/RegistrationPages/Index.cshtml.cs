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
    public class IndexModel : PageModel
    {
        private readonly RegistrationService _registrationService;

        public IndexModel(RegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        public IList<Registration> Registration { get;set; } = default!;

        //public async Task OnGetAsync()
        //{
        //    Registration = await _registrationService.GetAllAsync();
        //}
        [BindProperty(SupportsGet = true)]
        public string UserName { get; set; }
        [BindProperty(SupportsGet = true)]
        public string CompetitionName { get; set; }  
        [BindProperty(SupportsGet = true)]
        public string AnimalName { get; set; }
        public async Task OnGetAsync()
            {
            var registrations = await _registrationService.Search(CompetitionName, UserName, AnimalName);                         
            Registration = registrations;
        }
    }
}
