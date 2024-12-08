using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiShowManagement.Repositories.Models;
using KoiShowManagement.Services;
using Microsoft.AspNetCore.Authorization;

namespace FA24_PRN221_3W_G6_KoiShowManagement.Pages.FinalResultsPage
{
    public class IndexModel : PageModel
    {
        private readonly FinalResultService _service;

        public IndexModel(FinalResultService service)
        {
            _service = service;
        }

        public IList<FinalResult> FinalResult { get;set; } = default!;

        public async Task OnGetAsync()
        {
            FinalResult = await _service.GetAll();
        }
    }
}
