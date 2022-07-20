using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Repositories
{
    public interface IUserRepository
    {
        void CreateUser(UserModel user);
        void DeleteUser(int userId);
        UserModel GetUser(int userId);
        IEnumerable<UserModel> GetAllUsers();
    }
}