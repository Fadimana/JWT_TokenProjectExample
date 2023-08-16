using DataAccess.Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.Interface
{
    public interface IUserBusiness
    {
        Task<User1> CreateUser(User1 user);
        Task<User1> GetUser1(string email);
    }
}
