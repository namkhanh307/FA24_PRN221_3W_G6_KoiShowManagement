using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiShowManagement.Repositories.Models;
using KoiShowManagement.Service;

namespace KoiShowManagement.RazorWebApp.Pages.CompetitionPage
{
    public class CreateModel : PageModel
    {
        public  CompetitionService _competitionService;

        public CreateModel(CompetitionService competitionService)
        {
            _competitionService = competitionService;
        }
        public IActionResult OnGet()
        {
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
