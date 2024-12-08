using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Models;
using KoiShowManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Service;

namespace Page.Pages.PointOnProgressings
{
    public class EditModel : PageModel
    {
        private readonly PointOnProgressingService _pointOnprocessingService;
        private readonly RegistrationService _registrationService;
        private readonly CompetitionService _competitionService;
        private readonly UserService _userService;
        public EditModel(PointOnProgressingService pointOnProgressingService, CompetitionService competitionCategory, RegistrationService registrationService, UserService userService)
        {
            _pointOnprocessingService = pointOnProgressingService;
            _registrationService = registrationService;
            _competitionService = competitionCategory;
            _userService = userService;
        }

        [BindProperty]
        public PointOnProgressing PointOnProgressing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointonprogressing = await _pointOnprocessingService.GetByIdAsyncInclude(id);
            if (pointonprogressing == null)
            {
                return NotFound();
            }
            PointOnProgressing = pointonprogressing;
            var cate = await _competitionService.GetAllAsync();
            ViewData["CategoryId"] = new SelectList(cate, "CategoryId", "CategoryName");
            var user = await _userService.GetAllAsync();
            ViewData["JuryId"] = new SelectList(user, "UserId", "Email");
            var regis = await _registrationService.GetAllAsync();
            ViewData["RegistrationId"] = new SelectList(regis, "RegistrationId", "RegistrationId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _pointOnprocessingService.Update(PointOnProgressing);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PointOnProgressingExists(PointOnProgressing.PointId).Result)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private Task<bool> PointOnProgressingExists(int id)
        {
            return _pointOnprocessingService.CheckExist(id);
        }
    }
}
