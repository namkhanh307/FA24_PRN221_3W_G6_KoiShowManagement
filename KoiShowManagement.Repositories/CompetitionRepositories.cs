using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiShowManagement.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace KoiShowManagement.Repositories
{
    public class CompetitionRepositories : GenericRepository<Competition>
    {
        public CompetitionRepositories() { }
        //public async Task<List<Competition>> Search(string id, string name, string title)
        //{
        //    var item = await _context.Competitions.Include(b => b.CompetitionCategories)
        //        .Where(ba => ba.CompetitionCategories.Contains());
        //    return item;
        //}
        public async Task<List<Competition>> GetAll()
        {
            var referenceKey = await _context.Competitions.Include
                (m => m.CompetitionType).ToListAsync();
            return referenceKey;
        }
    }
}
