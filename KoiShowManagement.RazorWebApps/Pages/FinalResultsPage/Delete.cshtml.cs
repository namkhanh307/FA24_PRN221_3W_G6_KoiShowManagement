using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiShowManagement.Repositories.Models;
using Microsoft.AspNetCore.Authorization;

namespace FA24_PRN221_3W_G6_KoiShowManagement.Pages.FinalResultsPage
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly KoiShowManagement.Repositories.Models.FA24_PRN221_3W_G6_KoiShowManagementContext _context;

        public DeleteModel(KoiShowManagement.Repositories.Models.FA24_PRN221_3W_G6_KoiShowManagementContext context)
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

            var finalresult = await _context.FinalResults.FirstOrDefaultAsync(m => m.CompetitionResultId == id);

            if (finalresult == null)
            {
                return NotFound();
            }
            else
            {
                FinalResult = finalresult;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finalresult = await _context.FinalResults.FindAsync(id);
            if (finalresult != null)
            {
                FinalResult = finalresult;
                _context.FinalResults.Remove(FinalResult);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
