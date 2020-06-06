using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassLibrary;
using System.Data.SqlClient;
using Dapper;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace Server
{
    public class DataManager : DbProvider
    {
        //User
        public void UserSignUp(User user)
        {
            connection.Open();
            var sqlQuery = "INSERT INTO Users (Name, Login, Email, Password, RegistrationDate, RoleId, StatusId) " +
                                "VALUES (@Name, @Login, @Email, @Password, @RegistrationDate, @RoleId, 2) ";
            connection.Execute(sqlQuery, user);
            connection.Close();
        }

        public void UserEdit(User user)
        {
            connection.Open();
            var sqlQuery = "UPDATE Users " +
                           "SET Name = @Name, Login = @Login, Email = @Email, Password = @Password, RoleId = @RoleId, ActivateLink = @ActivateLink " +
                           "WHERE Id = @Id";   
            connection.Execute(sqlQuery, user);
            connection.Close();
        }

        public User UserSignIn(User user)
        {
            connection.Open();
            var sqlQuery = "SELECT * " +
                           "FROM Users " +
                           "WHERE Login = @Login and Password = @Password";
            user = connection.QueryFirstOrDefault<User>(sqlQuery, user);
            connection.Close();
            return user;

        }

        public User UserFind(User user)
        {
            connection.Open();
            string sqlQuery = "";
            if (user.Email != "")
            {
                 sqlQuery = "SELECT * " +
                            "FROM Users " +
                            "WHERE Email = @Email";
            }
            else if(user.Login != "")
            {
                sqlQuery = "SELECT * " +
                            "FROM Users " +
                            "WHERE Login = @Login";
            }
            user = connection.QueryFirstOrDefault<User>(sqlQuery, user);
            connection.Close();
            return user;
        }

        public User SendActivateLink(User user)
        {
            try
            {
                //Знаходимо юзера по мейлу
                user = UserFind(user);

                //Приписуємо цьому юзеру лінк
                Random r = new Random();
                int activateLink = r.Next(1000, 10000);
                user.ActivateLink = activateLink;

               // UserEdit(user);

                MailAddress from =
                    new MailAddress("ashotiuksus@gmail.com");
                MailAddress to =
                    new MailAddress(user.Email);
                MailMessage message =
                    new MailMessage(from, to);

                message.Subject = "Зкидання паролю в BrainDuels";
                message.Body = $" {user.Login}, код активації для зкидання паролю: {user.ActivateLink}";

                int port = 587;
                string server = "smtp.gmail.com";
                string login = "ashotiuksus@gmail.com";
                string password = GetPassword();

                SmtpClient client = new SmtpClient(server, port);
                client.Credentials = new NetworkCredential(login, password);
                client.EnableSsl = true;
                client.Send(message);

                Console.WriteLine($"\n> Повідомлення для зкидання паролю відправлено користувачу {user.Email} ");
            }
            catch (Exception err) { Console.WriteLine(err.Message); }

            return user;
        }

        static string GetPassword()
        {
            string path = @"..\..\Access\pass.txt";
            string passw = "";
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    passw = sr.ReadLine();
                }
            }
            return passw;
        }

        //Task



    }
}
