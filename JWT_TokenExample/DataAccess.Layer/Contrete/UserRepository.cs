using DataAccess.Layer.Entity;
using DataAccess.Layer.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Layer.Contrete
{
    public class UserRepository : IUserRepository
    {
        private readonly User1DbContext _context;

        public UserRepository(User1DbContext context)
        {
            _context = context;
        }

        public async Task<User1> CreateUser(User1 user)
        {
            await _context.Users1.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User1> GetUser1(string email)
        {
            return await _context.Users1.FirstOrDefaultAsync(x => x.E_Mail == email);

        }
       
                
    }
}
