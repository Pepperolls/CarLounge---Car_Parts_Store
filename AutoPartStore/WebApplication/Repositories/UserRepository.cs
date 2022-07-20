using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AutoPartsContext _dbContext;

        public UserRepository(AutoPartsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateUser(UserModel user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            _dbContext.Users.Remove(GetUser(userId));
            _dbContext.SaveChanges();
        }

        public UserModel GetUser(int userId)
        {
            return _dbContext.Users.Find(userId);
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            return _dbContext.Users;
        }

    }
}
