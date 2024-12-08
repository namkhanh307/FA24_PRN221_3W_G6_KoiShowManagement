using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Models;
using KoiShowManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Service;

namespace Page.Pages.PointOnProgressings
{
    public class DetailsModel : PageModel
    {
        private readonly PointOnProgressingService _pointOnprocessingService;
        public DetailsModel(PointOnProgressingService pointOnProgressingService)
        {
            _pointOnprocessingService = pointOnProgressingService;
        }

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
            else
            {
                PointOnProgressing = pointonprogressing;
            }
            return Page();
        }
    }
}
