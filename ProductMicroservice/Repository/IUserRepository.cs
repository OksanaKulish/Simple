using ProductMicroservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        Task<User> GetUserByIdAsync(Guid userId);
        Task InsertUserAsync(User user);
        Task DeleteUserAsync(Guid userId);
        Task UpdateUserAsync(User user);
        void Save();
    }
}
