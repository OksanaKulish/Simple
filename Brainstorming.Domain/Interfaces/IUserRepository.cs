using Brainstorming.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brainstorming.Domain.Interfaces
{
    interface IUserRepository
    {
        IEnumerable<User> GetUser();
        User GetUserById(int userId);
        void InsertUser(User user);
        void DeleteUser(int userId);
        void UpdateUser(User user);
        void Save();
    }
}
