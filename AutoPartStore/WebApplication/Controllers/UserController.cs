using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Repositories;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public UserController()
        {
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserModel>> GetAllUsers()
        {
            string connectionString = @"Server=DESKTOP-TCVVLRS\SQLEXPRESS;Database=AutoPartStore;Trusted_Connection=True";
            //string connectionString = @"Server=DESKTOP-4NO7DTE\SQLEXPRESS;Database=AutoPartStore;Trusted_Connection=True;";

            using var dbContext = new AutoPartsContext(connectionString);
            dbContext.Database.EnsureCreated();

            IUserRepository userRepository = new UserRepository(dbContext);

            IEnumerable<UserModel> userList = userRepository.GetAllUsers();

            return userList.ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<UserModel> GetUser(int id)
        {
            string connectionString = @"Server=DESKTOP-TCVVLRS\SQLEXPRESS;Database=AutoPartStore;Trusted_Connection=True";
            //string connectionString = @"Server=DESKTOP-4NO7DTE\SQLEXPRESS;Database=AutoPartStore;Trusted_Connection=True";

            using var dbContext = new AutoPartsContext(connectionString);
            dbContext.Database.EnsureCreated();

            IUserRepository userRepository = new UserRepository(dbContext);

            var user = userRepository.GetUser(id);

            return user;
        }

        [HttpPost]
        public IActionResult CreateUser(string email, string password, string firstName, string lastName, int personalIdNo)
        {
            string connectionString = @"Server=DESKTOP-TCVVLRS\SQLEXPRESS;Database=AutoPartStore;Trusted_Connection=True";
            //string connectionString = @"Server=DESKTOP-4NO7DTE\SQLEXPRESS;Database=AutoPartStore;Trusted_Connection=True";

            using var dbContext = new AutoPartsContext(connectionString);
            dbContext.Database.EnsureCreated();

            IUserRepository userRepository = new UserRepository(dbContext);

            var userModel = new UserModel(email, password, firstName, lastName, personalIdNo)
            {
                Email = email,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                PersonalIdNo = personalIdNo
            };

            userRepository.CreateUser(userModel);

            return CreatedAtAction(nameof(CreateUser), new { id = userModel.UserModelId }, userModel);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string connectionString = @"Server=DESKTOP-TCVVLRS\SQLEXPRESS;Database=AutoPartStore;Trusted_Connection=True";
            //string connectionString = @"Server=DESKTOP-4NO7DTE\SQLEXPRESS;Database=AutoPartStore;Trusted_Connection=True";

            using var dbContext = new AutoPartsContext(connectionString);
            dbContext.Database.EnsureCreated();

            IUserRepository userRepository = new UserRepository(dbContext);

            var existingUser = userRepository.GetUser(id);

            if (existingUser is null)
                return NotFound();

            userRepository.DeleteUser(id);

            return NoContent();
        }
    }
}
