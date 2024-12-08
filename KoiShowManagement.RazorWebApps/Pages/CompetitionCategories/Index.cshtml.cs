using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiShowManagement.Repositories.Models;
using KoiShowManagement.Services;

namespace KoiShowManagement.RazorWepApp.Pages.CompetitionCategories
{
    public class IndexModel : PageModel
    {
/*        private readonly KoiShowManagement.Repositories.Models.FA24_SE1702_PRN221_G6_KoiShowManagementContext _context;
*/        private readonly CompetitionCategoryService _competitionCategoryService;

       /* public IndexModel(KoiShowManagement.Repositories.Models.FA24_SE1702_PRN221_G6_KoiShowManagementContext context)
        {
            _context = context;
        }*/

        public IndexModel(CompetitionCategoryService competitionCategoryService)
        {
            _competitionCategoryService = competitionCategoryService;
        }

        public IList<CompetitionCategory> CompetitionCategory { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string MinSize { get; set; }

        [BindProperty(SupportsGet = true)]
        public string JudgingCriteria { get; set; }

        [BindProperty(SupportsGet = true)]
        public string RequiredDocuments { get; set; }

   

        /* public async Task OnGetAsync()
         {
             if (_context.CompetitionCategories != null)
             {
                 CompetitionCategory = await _context.CompetitionCategories
                 .Include(c => c.Competition)
                 .Include(c => c.Variety).ToListAsync();
             }
         }*/


        public async Task OnGetAsync()
        {
            var categories = await _competitionCategoryService.Search(this.MinSize
                , this.JudgingCriteria, this.RequiredDocuments);
        
            
            CompetitionCategory = categories;
        }
    }
}
