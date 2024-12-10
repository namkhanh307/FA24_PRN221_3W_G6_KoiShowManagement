using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiShowManagement.Repositories.Models;
using KoiShowManagement.Services;
using Microsoft.AspNetCore.Authorization;

namespace FA24_PRN221_3W_G6_KoiShowManagement.Pages.FinalResultsPage
{
    public class IndexModel : PageModel
    {
        private readonly FinalResultService _service;
        private readonly int _pageSize = 5; // Số item trên mỗi trang

        public IndexModel(FinalResultService service)
        {
            _service = service;
        }

        public PaginatedList<FinalResult> FinalResult { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchName { get; set; }

        [BindProperty(SupportsGet = true)]
        public double? SearchScore { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? SearchRank { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? CurrentPage { get; set; } = 1;

        public async Task OnGetAsync()
        {
            var query = await _service.GetAllWithDetails();

            // Áp dụng các điều kiện tìm kiếm
            if (!string.IsNullOrEmpty(SearchName))
            {
                query = query.Where(x => x.ResultName.Contains(SearchName, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (SearchScore.HasValue)
            {
                query = query.Where(x => x.TotalScore == SearchScore).ToList();
            }

            if (SearchRank.HasValue)
            {
                query = query.Where(x => x.Rank == SearchRank).ToList();
            }

            // Phân trang
            int pageSize = _pageSize;
            FinalResult = PaginatedList<FinalResult>.Create(
                query.AsQueryable(),
                CurrentPage ?? 1,
                pageSize
            );
        }
    }
}
