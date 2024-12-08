using KoiShowManagement.Repositories;
using KoiShowManagement.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiShowManagement.Services
{
    public class CompetitionCategoryService
    {
        private CompetitionCategoryRepository _repository;
        public CompetitionCategoryService()
        {
            _repository = new CompetitionCategoryRepository();
        }

        public async Task<List<CompetitionCategory>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<int> Create(CompetitionCategory CompetitionCategory)
        {
            return await _repository.CreateAsync(CompetitionCategory);
        }

        public async Task<CompetitionCategory> GetById(string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<CompetitionCategory> GetById(int? id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<int> Update(CompetitionCategory CompetitionCategory)
        {
            return await _repository.UpdateAsync(CompetitionCategory);
        }

        public async Task<bool> Delete(CompetitionCategory CompetitionCategory)
        {
            return await _repository.RemoveAsync(CompetitionCategory);
        }

        //public List<CompetitionCategory> Search(string bankNo, string holderName, string holderTaxCode)
        //{
        //    return _repository.Search(bankNo, holderName, holderTaxCode);
        //}

        public async Task<List<CompetitionCategory>> Search(string minSize, string judgingCriteria, string documents)
        {
            return await _repository.Search(minSize, judgingCriteria, documents);
        }
    }
}
