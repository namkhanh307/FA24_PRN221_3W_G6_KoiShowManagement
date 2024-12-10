using KoiShowManagement.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiShowManagement.Repositories
{
    public class RegistrationRepository : GenericRepository<Registration>
    {
        public RegistrationRepository()
        {
            
        }

        public async Task<List<Registration>> GetAllAsync()
        {
            return await _context.Registrations.Include(r => r.User).Include(r => r.Animal).Include(r => r.Competition).ToListAsync();
        }
        public async Task<Registration> GetByIdAsync(int? id)
        {
            var entity = await _context.Registrations.Include(r => r.User).Include(r => r.Animal).Include(r => r.Competition).FirstOrDefaultAsync(r => r.RegistrationId == id);
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }

            return entity;
		}
		public async Task<List<Registration>> Search(string competitionName, string userName, string animalName)
		{
			return await _context.Registrations.Where(r => (r.Competition.CompetitionName.Contains(competitionName) || string.IsNullOrWhiteSpace(competitionName)) && (r.User.Username.Contains(userName) || string.IsNullOrWhiteSpace(userName)) && (r.Animal.AnimalName.Contains(animalName) || string.IsNullOrWhiteSpace(animalName))).Include(r => r.User).Include(r => r.Animal).Include(r => r.Competition).ToListAsync();
		}

        public int CheckDuplicateRegistration(int? competitionId, int? userId, int? animalId)
        {
            return _context.Registrations.Where(r => r.CompetitionId == competitionId && r.UserId == userId && r.AnimalId == animalId).Count();
        }
        public async Task<IList<Registration>> SearchNew(string SelectedCompetitionName, bool CheckInStatus, string AnimalName)
        {
            return await _context.Registrations.Where(r => (r.Competition.CompetitionName.Contains(SelectedCompetitionName) || string.IsNullOrWhiteSpace(SelectedCompetitionName)) && r.CheckInStatus == CheckInStatus && (r.Animal.AnimalName.Contains(AnimalName) || string.IsNullOrWhiteSpace(AnimalName))).Include(r => r.User).Include(r => r.Animal).Include(r => r.Competition).ToListAsync();
        }
    }
}
