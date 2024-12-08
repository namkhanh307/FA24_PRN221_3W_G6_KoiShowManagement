using KoiShowManagement.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiShowManagement.Repositories
{
    public class CompetitionRepository : GenericRepository<Competition>
    {
        public async Task<List<Competition>> GetAllAsync()
        {
            var referenceKey = await _context.Competitions.Include
                (m => m.CompetitionType).ToListAsync();
            return referenceKey;
        }
    }
}
