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
        public void UserSignUp(User user)
        {
            connection.Open();
            var sqlQuery = "INSERT INTO Users (Name, Login, Email, Password, RegistrationDate, RoleId) " +
                                 "VALUES (@Name, @Login, @Email, @Password, @RegistrationDate, @RoleId)";
            connection.Execute(sqlQuery, user);
            connection.Close();
        }

        public void UserEdit(User user)
        {
            connection.Open();
            var sqlQuery = "UPDATE Users " +
                           "SET Name = @Name, Login = @Login, Email = @Email, Password = @Password, RegistrationDate = @RegistrationDate, RoleId = @RoleId " +
                           "WHERE Id = @Id";
            connection.Execute(sqlQuery, user);
            connection.Close();
        }

        public bool UserSignIn(User user)
        {
            connection.Open();
            var sqlQuery = "SELECT * " +
                           "FROM Users " +
                           "WHERE Login = @Login and Password = @Password";
            User u = new User();
            u = connection.QueryFirstOrDefault<User>(sqlQuery, user);
            connection.Close();
            if (u.Id != 0)
                return true;
            else
                return false;
        }

        //Task



    }
}
