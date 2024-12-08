using KoiShowManagement.Repositories.Models;
using KoiShowManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiShowManagement.Services
{
    public class AnimalService
    {
        private AnimalRepository _animalRepository;
        public AnimalService()
        {
            _animalRepository = new AnimalRepository();
        }
        public async Task<List<Animal>> GetAllAsync()
        {
            return await _animalRepository.GetAllAsync();
        }
    }
}
