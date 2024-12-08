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
    }
}
