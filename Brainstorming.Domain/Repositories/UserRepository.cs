using Brainstorming.Domain.EF;
using Brainstorming.Domain.Entities;
using Brainstorming.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brainstorming.Domain.Repositories
{
    class UserRepository : IUserRepository
    {
        private readonly UserContext _dbContext;

        public UserRepository(UserContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteUser(int userId)
        {
            var user = _dbContext.Products.Find(userId);
            _dbContext.Products.Remove(user);
            Save();
        }

        public IEnumerable<User> GetUser()
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public void InsertUser(User user)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
