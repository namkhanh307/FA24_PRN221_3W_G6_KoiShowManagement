﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly CompetitionService _competitionService;
        public  DetailsModel(CompetitionService competitionService)
        {
            _competitionService = competitionService;
        }

        public Competition Competition { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competition = await _competitionService.GetById(id);
            if (competition == null)
            {
                return NotFound();
            }
            else
            {
                Competition = competition;
            }
            return Page();
        }
    }
}
