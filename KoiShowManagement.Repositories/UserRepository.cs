using KoiShowManagement.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiShowManagement.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public async Task<User?> Login(string username, string password)
        {
            return await _context.Users.Include(u => u.Role).SingleOrDefaultAsync(u => u.Username.Equals(username) && u.Password.Equals(password));   
        }

    }
}
