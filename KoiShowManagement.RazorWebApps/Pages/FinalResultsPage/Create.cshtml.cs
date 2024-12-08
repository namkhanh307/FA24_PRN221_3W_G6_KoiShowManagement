using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiShowManagement.Repositories.Models;
using Microsoft.AspNetCore.Authorization;

namespace FA24_PRN221_3W_G6_KoiShowManagement.Pages.FinalResultsPage
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly KoiShowManagement.Repositories.Models.FA24_PRN221_3W_G6_KoiShowManagementContext _context;

        public CreateModel(KoiShowManagement.Repositories.Models.FA24_PRN221_3W_G6_KoiShowManagementContext context)
        {
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

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.FinalResults.Add(FinalResult);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
