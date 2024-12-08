using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiShowManagement.Repositories.Models;
using KoiShowManagement.Services;

namespace KoiShowManagement.RazorWepApp.Pages.CompetitionCategories
{
    public class EditModel : PageModel
    {
        private readonly CompetitionCategoryService _competitionCategoryService;
        private readonly CompetitionService _competitionService;
        private readonly AnimalVarietyService _varietyService;

        public EditModel(CompetitionCategoryService competitionCategoryService,
           CompetitionService competitionService, AnimalVarietyService animalVarietyService)
        {
            _competitionCategoryService = competitionCategoryService;
            _competitionService = competitionService;
            _varietyService = animalVarietyService;
        }

        [BindProperty]
        public CompetitionCategory CompetitionCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
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
           
            var selectListItems = await _competitionService.GetAllAsync();
            var animalVarietyListItems = await _varietyService.GetAll();
            ViewData["CompetitionId"] = new SelectList(selectListItems, "CompetitionId", "CompetitionName");
            ViewData["VarietyId"] = new SelectList(animalVarietyListItems, "VarietyId", "VarietyName");
            CompetitionCategory = competitioncategory;
            return Page();
            
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

          

            try
            {
                await _competitionCategoryService.Update(CompetitionCategory);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return RedirectToPage("./Index");
        }

   /*     private bool CompetitionCategoryExists(int id)
        {
          return (_context.CompetitionCategories?.Any(e => e.CategoryId == id)).GetValueOrDefault();
        }*/
    }
}
