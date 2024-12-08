using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiShowManagement.Repositories.Models;

namespace FA24_PRN221_3W_G6_KoiShowManagement.Pages.FinalResultsPage
{
    public class DetailsModel : PageModel
    {
        private readonly KoiShowManagement.Repositories.Models.FA24_PRN221_3W_G6_KoiShowManagementContext _context;

        public DetailsModel(KoiShowManagement.Repositories.Models.FA24_PRN221_3W_G6_KoiShowManagementContext context)
        {
            _context = context;
        }

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
    }
}
