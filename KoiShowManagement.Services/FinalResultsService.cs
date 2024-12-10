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
    public class FinalResultService 
    {
        private FinalResultsRepository _repository;
        public FinalResultService()
        {
            _repository = new FinalResultsRepository();
        }

        public async Task<List<FinalResult>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<int> Create(FinalResult categoryBankAccount)
        {
            return await _repository.CreateAsync(categoryBankAccount);
        }

        public async Task<FinalResult> GetById(string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<int> Update(FinalResult categoryBankAccount)
        {
            return await _repository.UpdateAsync(categoryBankAccount);
        }

        public async Task<bool> Delete(FinalResult categoryBankAccount)
        {
            return await _repository.RemoveAsync(categoryBankAccount);
        }
        public async Task<List<FinalResult>> GetAllWithDetails()
        { return await _repository.GetAllWithDetails(); }
            //public List<CategoryBankAccount> Search(string bankNo, string holderName, string holderTaxCode)
            //{
            //    return _repository.Search(bankNo, holderName, holderTaxCode);
            //}
        }
}
