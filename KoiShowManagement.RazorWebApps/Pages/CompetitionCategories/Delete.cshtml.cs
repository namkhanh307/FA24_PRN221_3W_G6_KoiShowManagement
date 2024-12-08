using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiShowManagement.Repositories.Models;
using KoiShowManagement.Services;

namespace KoiShowManagement.RazorWepApp.Pages.CompetitionCategories
{
    public class DeleteModel : PageModel
    {
        private readonly CompetitionCategoryService _competitionCategoryService;

        public DeleteModel(CompetitionCategoryService competitionCategoryService)
        {
            _competitionCategoryService = competitionCategoryService;
        }

        [BindProperty]
      public CompetitionCategory CompetitionCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competitioncategory = await _competitionCategoryService.GetById(id) ;

            if (competitioncategory == null)
            {
                return NotFound();
            }
            else 
            {
                CompetitionCategory = competitioncategory;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var competitioncategory = await _competitionCategoryService.GetById(id);

            if (competitioncategory != null)
            {
                CompetitionCategory = competitioncategory;
                
               await _competitionCategoryService.Delete(CompetitionCategory);
            }

            return RedirectToPage("./Index");
        }
    }
}
