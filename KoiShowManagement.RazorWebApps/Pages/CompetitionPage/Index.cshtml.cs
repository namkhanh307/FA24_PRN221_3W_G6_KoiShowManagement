using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiShowManagement.Repositories.Models;
using KoiShowManagement.Services;

namespace KoiShowManagement.RazorWebApp.Pages.CompetitionPage
{
    public class IndexModel : PageModel
    {
        private readonly CompetitionService _competitionService;
        public IndexModel(CompetitionService competitionService)
        {
            _competitionService = competitionService;
        }    

        public IList<Competition> Competition { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Competition = await _competitionService.GetAllAsync();
        }
    }
}
