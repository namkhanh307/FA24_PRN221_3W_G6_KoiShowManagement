using KoiShowManagement.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiShowManagement.Repositories
{
    public class FinalResultsRepository : GenericRepository<FinalResult>
    {
        public FinalResultsRepository() { }
        public async Task<List<FinalResult>> GetAllWithDetails()
        {
            return await _context.FinalResults
                .Include(f => f.CategoryNavigation)
                .Include(f => f.Competition)
                .ToListAsync();
        }
    }
}
