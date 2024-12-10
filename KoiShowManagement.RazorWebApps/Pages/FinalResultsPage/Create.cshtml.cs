using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiShowManagement.Repositories.Models;
using Microsoft.AspNetCore.Authorization;
using KoiShowManagement.Services;

namespace FA24_PRN221_3W_G6_KoiShowManagement.Pages.FinalResultsPage
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly FinalResultService _finalResultService;
        private readonly FA24_PRN221_3W_G6_KoiShowManagementContext _context;

        public CreateModel(FinalResultService finalResultService,
            FA24_PRN221_3W_G6_KoiShowManagementContext context)
        {
            _finalResultService = finalResultService;
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CategoryId"] = new SelectList(_context.CompetitionCategories, "CategoryId", "CategoryName");
            ViewData["CompetitionId"] = new SelectList(_context.Competitions, "CompetitionId", "CompetitionId");
            return Page();
        }

        [BindProperty]
        public FinalResult FinalResult { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewData["CategoryId"] = new SelectList(_context.CompetitionCategories, "CategoryId", "CategoryName");
                    ViewData["CompetitionId"] = new SelectList(_context.Competitions, "CompetitionId", "CompetitionId");
                    return Page();
                }

                // Bỏ phần generate ID vì sẽ dùng auto-increment
                await _finalResultService.Create(FinalResult);
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Có lỗi xảy ra: {ex.Message}");
                ViewData["CategoryId"] = new SelectList(_context.CompetitionCategories, "CategoryId", "CategoryName");
                ViewData["CompetitionId"] = new SelectList(_context.Competitions, "CompetitionId", "CompetitionId");
                return Page();
            }
        }
    }
}
