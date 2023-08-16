using Business.Layer.Interface;
using DataAccess.Layer.Entity;
using DataAccess.Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.Contrete
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository _userRepository;

        public UserBusiness(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User1> CreateUser(User1 user)
        {
         return await _userRepository.CreateUser(user);
        }

        public async Task<User1> GetUser1(string email)
        {
            return await _userRepository.GetUser1(email);
        }
    }
}
