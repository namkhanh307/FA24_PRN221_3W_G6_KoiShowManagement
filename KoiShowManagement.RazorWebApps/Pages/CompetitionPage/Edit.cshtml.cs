using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiShowManagement.Repositories.Models;
using KoiShowManagement.Service;

namespace KoiShowManagement.RazorWebApp.Pages.CompetitionPage
{
    public class EditModel : PageModel
    {
        private readonly CompetitionService _competitionService;
        public EditModel(CompetitionService competitionService)
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

        //    var competition =  await _context.Competitions.FirstOrDefaultAsync(m => m.CompetitionId == id);
        //    if (competition == null)
        //    {
        //        return NotFound();
        //    }
        //    Competition = competition;
        //    return Page();
        //}

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if(id == null)
            {
                return NotFound();  
            }
            var mainTbale = await _competitionService.GetById(id);
            if (mainTbale == null)
            {
                return NotFound();
            }

            Competition = mainTbale;
            return Page();
        }
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.Attach(Competition).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CompetitionExists(Competition.CompetitionId))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

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
                var results = await _competitionService.Update(Competition);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return RedirectToPage("./Index");

        }
    }
}
