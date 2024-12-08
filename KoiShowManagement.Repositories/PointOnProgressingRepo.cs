using KoiShowManagement.Repositories;
using KoiShowManagement.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class PointOnProgressingRepo  : GenericRepository<PointOnProgressing>
    {
        public PointOnProgressingRepo() { }
        public async Task<IEnumerable<PointOnProgressing>> GetAllWithRelatedDataAsync()
        {
            return await _context.Set<PointOnProgressing>()
                .Include(p => p.Category)
                .Include(p => p.Jury)
                .Include(p => p.Registration)
                .ToListAsync();
        }
        public async Task<PointOnProgressing> GetByIdAsyncInclude(int? id)
        {
            if (id == null) return null;

            return await _context.Set<PointOnProgressing>()
                .Include(p => p.Category)
                .Include(p => p.Jury)
                .Include(p => p.Registration)
                .FirstOrDefaultAsync(p => p.PointId == id);
        }
        public class PointRespone
        {
            public List<PointOnProgressing> PointOnProgressings { get; set; }
            public int TotalPages { get; set; }
            public int PageIndex { get; set; }
        }
        public async Task<PointRespone> GetListAs(string searchTerm1, string searchTerm2, string searchTerm3, int pageIndex, int pageSize)
        {
            var query = _context.PointOnProgressings.Include(p => p.Category)
                .Include(p => p.Jury)
                .Include(p => p.Registration).AsQueryable();

            int? shapePoint = string.IsNullOrEmpty(searchTerm1) ? (int?)null : int.TryParse(searchTerm1, out int sp) ? sp : (int?)null;
            int? colorPoint = string.IsNullOrEmpty(searchTerm2) ? (int?)null : int.TryParse(searchTerm2, out int cp) ? cp : (int?)null;
            int? patternPoint = string.IsNullOrEmpty(searchTerm3) ? (int?)null : int.TryParse(searchTerm3, out int pp) ? pp : (int?)null;

            // Apply search filters if any search terms are provided
            if (shapePoint.HasValue || colorPoint.HasValue || patternPoint.HasValue)
            {
                query = query.Where(p =>
                    // Check ShapePoint
                    (!shapePoint.HasValue || p.ShapePoint == shapePoint) &&

                    // Check ColorPoint
                    (!colorPoint.HasValue || p.ColorPoint == colorPoint) &&

                    // Check PatternPoint
                    (!patternPoint.HasValue || p.PatternPoint == patternPoint)
                );
            }


            int count = await query.CountAsync(); 
            int totalPages = (int)Math.Ceiling(count / (double)pageSize); 

            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return new PointRespone
            {
                PointOnProgressings = await query.ToListAsync(),
                TotalPages = totalPages,
                PageIndex = pageIndex
            };
        }
    }
}
