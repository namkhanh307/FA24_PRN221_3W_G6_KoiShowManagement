using KoiShowManagement.Repositories;
using KoiShowManagement.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiShowManagement.Services
{
    public class RegistrationService
    {
        private RegistrationRepository _registrationRepository;
        public RegistrationService()
        {
            _registrationRepository = new RegistrationRepository();
        }
        public async Task<List<Registration>> GetAllAsync()
        {
            return await _registrationRepository.GetAllAsync();
        }
        public async Task<Registration> GetByIdAsync(int? id)
        {
            return await _registrationRepository.GetByIdAsync(id);
        }
        public async Task<int> CreateAsync(Registration entity)
        {
            return await _registrationRepository.CreateAsync(entity);
        }
        public async Task<int> UpdateAsync(Registration entity)
        {
            return await _registrationRepository.UpdateAsync(entity);
        }
        public async Task<bool> RemoveAsync(Registration entity)
        {
            return await _registrationRepository.RemoveAsync(entity);
        }
		public async Task<List<Registration>> Search(string competitionName, string userName, string animalName)
		{
			return await _registrationRepository.Search(competitionName, userName, animalName);
		}
        public int CheckDuplicateRegistration(int? competitionId, int? userId, int? animalId)
        {
            return _registrationRepository.CheckDuplicateRegistration(competitionId, userId, animalId);
        }
        public async Task<IList<Registration>> SearchNew(string SelectedCompetitionName, bool CheckInStatus, string AnimalName)
        {
            return await _registrationRepository.SearchNew(SelectedCompetitionName, CheckInStatus, AnimalName);
        }

    }
}
