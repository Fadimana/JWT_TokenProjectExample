using DataAccess.Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Layer.Interface
{
    public interface IUserRepository
    {
        Task<User1> CreateUser(User1 user);
        Task<User1>GetUser1(string email);
    }
}
