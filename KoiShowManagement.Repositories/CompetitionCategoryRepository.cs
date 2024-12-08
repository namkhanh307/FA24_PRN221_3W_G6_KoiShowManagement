using KoiShowManagement.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiShowManagement.Repositories
{
    public class CompetitionCategoryRepository : GenericRepository<CompetitionCategory>
    {
        
        public CompetitionCategoryRepository() {
        }

        
        public async Task<List<CompetitionCategory>> GetAllAsync()
        {
            var competitionsCategory = await _context.CompetitionCategories
                            .Include(c =>c.Competition)
                            .Include(x => x.Variety)                      
                            .ToListAsync();
            return competitionsCategory;
        }

        public async Task<CompetitionCategory> GetByIdAsync(int? id)
        {
            var competitionCategory = await _context.CompetitionCategories
                                .Include(c =>c.Competition)
                                .Include(x => x.Variety)
                                .FirstOrDefaultAsync(y=> y.CategoryId == id);

            return competitionCategory ?? new CompetitionCategory();

        }

        public async Task<List<CompetitionCategory>> Search(string minSize, string judgingCriteria, string documents)
        {
          
            var competitionCategory = await _context.CompetitionCategories
                                .Include(c => c.Competition)
                                .Include(x => x.Variety)
                                .Where(ca =>
                                    (ca.MinSize.ToString().Equals(minSize) || string.IsNullOrEmpty(minSize))
                                    && (ca.JudgingCriteria.Contains(judgingCriteria) || string.IsNullOrEmpty(judgingCriteria))
                                    && (ca.RequiredDocuments.Contains(documents) || string.IsNullOrEmpty(documents))
                                ).ToListAsync();

            return competitionCategory;
        }
    }
}
