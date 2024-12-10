using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiShowManagement.Repositories.Models;

namespace KoiShowManagement.RazorWebApps.Pages.NewFolder
{
    public class IndexModel : PageModel
    {
        private readonly KoiShowManagement.Repositories.Models.FA24_PRN221_3W_G6_KoiShowManagementContext _context;

        public IndexModel(KoiShowManagement.Repositories.Models.FA24_PRN221_3W_G6_KoiShowManagementContext context)
        {
            _context = context;
        }

        public IList<Animal> Animal { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Animal = await _context.Animals
                .Include(a => a.Variety).ToListAsync();
        }
    }
}
