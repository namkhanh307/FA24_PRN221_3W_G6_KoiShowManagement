using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiShowManagement.Repositories.Models;
using Microsoft.AspNetCore.Authorization;

namespace FA24_PRN221_3W_G6_KoiShowManagement.Pages.FinalResultsPage
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly KoiShowManagement.Repositories.Models.FA24_PRN221_3W_G6_KoiShowManagementContext _context;

        public EditModel(KoiShowManagement.Repositories.Models.FA24_PRN221_3W_G6_KoiShowManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FinalResult FinalResult { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finalresult =  await _context.FinalResults.FirstOrDefaultAsync(m => m.CompetitionResultId == id);
            if (finalresult == null)
            {
                return NotFound();
            }
            FinalResult = finalresult;
           ViewData["CategoryId"] = new SelectList(_context.CompetitionCategories, "CategoryId", "CategoryName");
           ViewData["CompetitionId"] = new SelectList(_context.Competitions, "CompetitionId", "CompetitionId");
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

            _context.Attach(FinalResult).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinalResultExists(FinalResult.CompetitionResultId))
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

        private bool FinalResultExists(int id)
        {
            return _context.FinalResults.Any(e => e.CompetitionResultId == id);
        }
    }
}
