using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int RoleId { get; set; }

        public User(int id, string name, string login,string email,string passw,DateTime regDate, int roleId)
        {
            Id = id;
            Name = name;
            Login = login;
            Email = email;
            Password = passw;
            RegistrationDate = regDate;
            RoleId = roleId;
        }
    }
}
