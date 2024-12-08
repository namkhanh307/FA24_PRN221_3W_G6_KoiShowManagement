using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiShowManagement.Repositories.Models;
using KoiShowManagement.Services;

namespace KoiShowManagement.RazorWebApp.Pages.CompetitionPage
{
    public class CreateModel : PageModel
    {
        public readonly CompetitionService _competitionService;
        public readonly CompetitionTypeService _competitionTypeService;
        public CreateModel(CompetitionService competitionService, CompetitionTypeService competitionTypeService)
        {
            _competitionService = competitionService;
            _competitionTypeService = competitionTypeService;
        }
        public async Task<IActionResult> OnGet()
        {
            var selectList = await _competitionTypeService.GetAllAsync();
            ViewData["CompetitionTypeId"] = new SelectList(selectList, "CompetitionTypeId", "CompetitionTypeName");
            return Page();
        }

        [BindProperty]
        public  Competition Competition { get; set; } = default;
            
        // For more information, see https://aka.ms/RazorPagesCRUD.
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.Competitions.Add(Competition);
        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("./Index");
        //}
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                await _competitionService.Create(Competition);
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
                return Page();
            }

        }
    }
}
