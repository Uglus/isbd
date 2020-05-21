using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassLibrary;
using System.Data.SqlClient;
using Dapper;

namespace Server
{
    public class DataManager : DbProvider
    {
        //User
        public void AddUser(User user)
        {
            connection.Open();
            var sqlQuery = "INSERT INTO Users (Name, Login, Email, Password, RegistrationDate, RoleId) " +
                                      "VALUES (@Name, @Login, @Email, @Password, @RegistrationDate, @RoleId)";
            connection.Execute(sqlQuery, user);
            connection.Close();
        }
        public void EditUser(User user)
        {
            connection.Open();
            var sqlQuery = "UPDATE Users " +
                           "SET Name = @Name, Login = @Login, Email = @Email, Password = @Password, RegistrationDate = @RegistrationDate, RoleId = @RoleId " +
                           "WHERE Id = @Id";
            connection.Execute(sqlQuery, user);
            connection.Close(); 
        }


        //Task



    }
}
