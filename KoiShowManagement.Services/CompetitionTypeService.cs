using KoiShowManagement.Repositories.Models;
using KoiShowManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiShowManagement.Services
{
    public class CompetitionTypeService
    {
        private CompetitionTypeRepositories _competitionTypeRepository;
        public CompetitionTypeService()
        {
            _competitionTypeRepository = new CompetitionTypeRepositories();
        }
        public async Task<List<CompetitionType>> GetAllAsync()
        {
            return await _competitionTypeRepository.GetAllAsync();
        }

    }
}
