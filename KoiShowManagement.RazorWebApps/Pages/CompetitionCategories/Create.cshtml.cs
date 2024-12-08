using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiShowManagement.Repositories.Models;
using KoiShowManagement.Services;

namespace KoiShowManagement.RazorWepApp.Pages.CompetitionCategories
{
    public class CreateModel : PageModel
    {
      /*  private readonly KoiShowManagement.Repositories.Models.FA24_SE1702_PRN221_G6_KoiShowManagementContext _context;*/
        private readonly CompetitionCategoryService _competitionCategoryService;
        private readonly CompetitionService _competitionService;
        private readonly AnimalVarietyService _varietyService;
        public CreateModel(CompetitionCategoryService competitionCategoryService, 
            CompetitionService competitionService, AnimalVarietyService animalVarietyService)
        {
            _competitionCategoryService = competitionCategoryService;
            _competitionService = competitionService;
            _varietyService = animalVarietyService;
        }

        public async Task<IActionResult> OnGet()
        {
            var selectListItems = await _competitionService.GetAllAsync();
            var animalVarietyListItems = await _varietyService.GetAll();
            ViewData["CompetitionId"] = new SelectList(selectListItems, "CompetitionId", "CompetitionName");
            ViewData["VarietyId"] = new SelectList(animalVarietyListItems, "VarietyId", "VarietyName");
            return Page();
        }

        [BindProperty]
        public CompetitionCategory CompetitionCategory { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            await _competitionCategoryService.Create(CompetitionCategory);

            return RedirectToPage("./Index");
        }
    }
}
