using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class UserModel
    {
        public int UserModelId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PersonalIdNo { get; set; }

        public UserModel()
        {

        }
        public UserModel(string email, string password, string firstName, string lastName, int personalIdNo)
        {
            this.Email = email;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PersonalIdNo = personalIdNo;
        }
    }
}
