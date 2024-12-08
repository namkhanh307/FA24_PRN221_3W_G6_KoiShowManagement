using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiShowManagement.Repositories.Models;
using KoiShowManagement.Service;

namespace KoiShowManagement.RazorWebApp.Pages.CompetitionPage
{
    public class DeleteModel : PageModel
    {
        private CompetitionService _competitionService;

        public DeleteModel(CompetitionService competitionService)
        {
            _competitionService = competitionService;
        }

        [BindProperty]
        public Competition Competition { get; set; } = default!;

        //public async Task<IActionResult> OnGetAsync(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var competition = await _context.Competitions.FirstOrDefaultAsync(m => m.CompetitionId == id);

        //    if (competition == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        Competition = competition;
        //    }
        //    return Page();
        //}
        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var competition = await _competitionService.GetById(id);

            if (competition == null)
            {
                return NotFound();
            }
            Competition = competition;
            return Page();
        }
        //public async Task<IActionResult> OnPostAsync(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var competition = await _context.Competitions.FindAsync(id);
        //    if (competition != null)
        //    {
        //        Competition = competition;
        //        _context.Competitions.Remove(Competition);
        //        await _context.SaveChangesAsync();
        //    }

        //    return RedirectToPage("./Index");
        //}
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var competition = await _competitionService.GetById(id);
            if (competition != null)
            {
                Competition = competition;
                await _competitionService.Delete(competition);

            }
            return RedirectToPage("./Index");

        }
    }
}
