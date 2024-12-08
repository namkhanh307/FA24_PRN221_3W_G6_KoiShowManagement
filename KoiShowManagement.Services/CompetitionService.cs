using KoiShowManagement.Repositories.Models;
using KoiShowManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiShowManagement.Services
{
    public class CompetitionService
    {
        private CompetitionRepository _competitionRepository;
        public CompetitionService()
        {
            _competitionRepository = new CompetitionRepository();
        }
        public async Task<List<Competition>> GetAllAsync()
        {
            return await _competitionRepository.GetAllAsync();
        }
        public async Task<int> Create(Competition competition)
        {
            return await _competitionRepository.CreateAsync(competition);
        }

        //public async Task<Competition> GetById(string id)
        //{
        //    return await repositories.GetByIdAsync(id);
        //}

        public async Task<Competition> GetById(int id)
        {
            return await _competitionRepository.GetByIdAsync(id);
        }

        public async Task<int> Update(Competition competition)
        {
            return await _competitionRepository.UpdateAsync(competition);
        }

        public async Task<bool> Delete(Competition competition)
        {
            return await _competitionRepository.RemoveAsync(competition);
        }
    }
}
