using KoiShowManagement.Repositories.Models;
using KoiShowManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiShowManagement.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }
        public async Task<User?> Login(string username, string password) 
        {
            return await _userRepository.Login(username, password);
        }
    }
}
