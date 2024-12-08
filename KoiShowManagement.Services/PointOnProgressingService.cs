using KoiShowManagement.Repositories.Models;
using Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PointOnProgressingService
    {
        private PointOnProgressingRepo _repository;

        public PointOnProgressingService()
        {
            _repository = new PointOnProgressingRepo();
        }
        public Task<PointOnProgressingRepo.PointRespone> GetList(string searchTerm1, string searchTerm2, string searchTerm3, int pageIndex, int pageSize)
        {

            return _repository.GetListAs(searchTerm1, searchTerm2, searchTerm3, pageIndex, pageSize);
        }
        public async Task<bool> CheckExist(int id)
        {
            return await _repository.ExistsByIdAsync(id);
        }
        public async Task<IEnumerable<PointOnProgressing>> GetAllWith()
        {
            return await _repository.GetAllWithRelatedDataAsync(); 
        }
        public async Task<List<PointOnProgressing>> GetAll()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<int> Create(PointOnProgressing pointOnProgressing)
        {
            return await _repository.CreateAsync(pointOnProgressing);
        }
        public async Task<PointOnProgressing> GetByIdAsyncInclude(int? id)
        {
            return await _repository.GetByIdAsyncInclude(id);
        }
        public async Task<PointOnProgressing> GetByIdAsync(int? id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<int> Update(PointOnProgressing pointOnProgressing)
        {
            return await _repository.UpdateAsync(pointOnProgressing);
        }

        public async Task<bool> Delete(PointOnProgressing pointOnProgressing)
        {
            return await _repository.RemoveAsync(pointOnProgressing);
        }

        //public List<CategoryBankAccount> Search(string bankNo, string holderName, string holderTaxCode)
        //{
        //    return _repository.Search(bankNo, holderName, holderTaxCode);
        //}
    }
}
