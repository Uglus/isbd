using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    [Serializable]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int RoleId { get; set; }
        public int StatusId { get; set; } = 2;
        public int ActivateLink { get; set; }

        public string FuncName { get; set; } = "";//Для визначення сервером, яку функцію юзати

        public User()
        {
            Id = 0;
            Name = "";
            Login = "";
            Email = "";
            Password = "";
            RegistrationDate = DateTime.MinValue;
            RoleId = 1;
            StatusId = 2;
            ActivateLink = 0;
            FuncName = "";
        }

        public User(int id, string name, string login,string email,string passw,DateTime regDate, int roleId, int statusId = 2, string funcName = "")
        {
            Id = id;
            Name = name;
            Login = login;
            Email = email;
            Password = passw;
            RegistrationDate = regDate;
            RoleId = roleId;
            FuncName = funcName;
            StatusId = statusId;
        }
    }
}
