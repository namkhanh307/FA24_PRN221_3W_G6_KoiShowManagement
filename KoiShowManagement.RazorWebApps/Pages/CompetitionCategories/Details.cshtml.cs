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
    public class DetailsModel : PageModel
    {

        private readonly CompetitionCategoryService _competitionCategoryService;
  
        public DetailsModel(CompetitionCategoryService competitionCategoryService)
        {
            _competitionCategoryService = competitionCategoryService;
         
        }

        public CompetitionCategory CompetitionCategory { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competitioncategory = await _competitionCategoryService.GetById(id);
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
    }
}
