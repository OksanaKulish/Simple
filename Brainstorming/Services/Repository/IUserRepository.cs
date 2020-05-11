using Brainstorming.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brainstorming.Services.Repository
{
    interface IUserRepository
    {
        IEnumerable<User> GetProducts();
        User GetProductById(int userId);
        void InsertProduct(User user);
        void DeleteProduct(int userId);
        void UpdateProduct(User user);
        void Save();
    }
}
