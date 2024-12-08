using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Models;
using KoiShowManagement.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Service;

namespace Page.Pages.PointOnProgressings
{
    public class DeleteModel : PageModel
    {
        private readonly PointOnProgressingService _pointOnprocessingService;
        private readonly IHubContext<NotificationHub> _hubContext;
        public DeleteModel(PointOnProgressingService pointOnProgressingService, IHubContext<NotificationHub> hubContext)
        {
            _pointOnprocessingService = pointOnProgressingService;
            _hubContext = hubContext;
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
            else
            {
                PointOnProgressing = pointonprogressing;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointonprogressing = await _pointOnprocessingService.GetByIdAsync(id);
            if (pointonprogressing != null)
            {
                PointOnProgressing = pointonprogressing;
                await _pointOnprocessingService.Delete(PointOnProgressing);
            }
            try
            {
                await _hubContext.Clients.All.SendAsync("ReceiveDeleteNotification", id.Value);
                Console.WriteLine($"Notification sent for deletion of point ID: {id.Value}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending notification: {ex.Message}");
            }
            return RedirectToPage("./Index");
        }
    }
}
