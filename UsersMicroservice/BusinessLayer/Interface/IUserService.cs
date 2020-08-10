using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersMicroservice.Entities;

namespace UsersMicroservice.BusinessLayer.Interface
{
   public interface IUserService
    {
        Task<IEnumerable<Users>> GetAllUserName();
        Task<IEnumerable<Users>> UserReadAsync();
        Task<Users> UserCreateAsync(Users user);
        Task<Users> UserUpdateAsync(Users user);
        Task<bool> UserDeleteAsync(string email);
    }
}
