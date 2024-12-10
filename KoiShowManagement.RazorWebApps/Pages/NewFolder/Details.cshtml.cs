using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiShowManagement.Repositories.Models;

namespace KoiShowManagement.RazorWebApps.Pages.NewFolder
{
    public class DetailsModel : PageModel
    {
        private readonly KoiShowManagement.Repositories.Models.FA24_PRN221_3W_G6_KoiShowManagementContext _context;

        public DetailsModel(KoiShowManagement.Repositories.Models.FA24_PRN221_3W_G6_KoiShowManagementContext context)
        {
            _context = context;
        }

        public Animal Animal { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animals.FirstOrDefaultAsync(m => m.AnimalId == id);
            if (animal == null)
            {
                return NotFound();
            }
            else
            {
                Animal = animal;
            }
            return Page();
        }
    }
}
