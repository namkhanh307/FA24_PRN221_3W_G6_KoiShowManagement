using KoiShowManagement.Repositories;
using KoiShowManagement.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiShowManagement.Services
{
    public class AnimalVarietyService
    {
        private AnimalVarietyRepository _repository;

        public AnimalVarietyService()
        {
            _repository = new AnimalVarietyRepository();
        }



        public async Task<List<AnimalVariety>> GetAll()
        {
            return await _repository.GetAllAsync();
        }
    }
}
