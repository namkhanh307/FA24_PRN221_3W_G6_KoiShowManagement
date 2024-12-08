using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Models;
using KoiShowManagement.Service;
using KoiShowManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Service;

namespace Page.Pages.PointOnProgressings
{
    public class IndexModel : PageModel
    {
        private readonly PointOnProgressingService _pointOnprocessingService;
        private readonly IScoreService _scoreService;
        [BindProperty(SupportsGet = true)]
        public string searchTerm1 { get; set; }
        [BindProperty(SupportsGet = true)]
        public string searchTerm2 { get; set; }
        [BindProperty(SupportsGet = true)]
        public string searchTerm3 { get; set; }


        //paging
        public int PageIndex { get; set; } = 1;

        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 2;
        public IndexModel(PointOnProgressingService pointOnProgressingService,IScoreService scoreService)
        {
            _pointOnprocessingService = pointOnProgressingService;
            _scoreService = scoreService;
        }

        public IList<PointOnProgressing> PointOnProgressing { get;set; } = default!;

        
        public async Task OnGetAsync(int pageIndex = 1)
        { 
            var result = await _pointOnprocessingService.GetList(searchTerm1, searchTerm2, searchTerm3, pageIndex,3);

            PointOnProgressing = result.PointOnProgressings;
            PageIndex = result.PageIndex;
            TotalPages = result.TotalPages;
        }
        public async Task<IActionResult> OnPostStartCalculationAsync()
        {
            await _scoreService.StartCalculatingScoresAsync();
            return RedirectToPage(); // Redirect back to the index page
        }

        public IActionResult OnPostStopCalculation()
        {
            _scoreService.StopCalculatingScores();
            return RedirectToPage(); // Redirect back to the index page
        }
    }
}
