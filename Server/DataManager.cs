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
                user.ActivateLink = activateLink.ToString();

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

        //Quiz
        public void QuizQuestionsAdd(Quiz quiz)
        {
            connection.Open();
            string sqlQuery = "";
            ICollection<Question> questions = quiz.Question;

            foreach(Question qest in questions)
            {
                sqlQuery = "INSERT INTO Questions (Text, Points, Image, TypeId, QuizId) " +
                    "VALUES (@Text, @Points, @Image, @TypeId, @QuizId)";
                connection.Execute(sqlQuery, qest);

                sqlQuery = "SELECT * " +
                           "FROM Questions " +
                           "WHERE Text = @Text and QuizId = @QuizId and TypeId = @TypeId";
                Question question = new Question(); 
                question = connection.QueryFirstOrDefault<Question>(sqlQuery, qest);

                if(question.SequenceTrue.Count != 0)
                {
                    sqlQuery = "INSERT INTO SequencesTrue (Answer1,Answer2,Answer3,Answer4,QuestionId) " +
                        "VALUES (@Answer1,@Answer2,@Answer3,@Answer4,@QuestionId)";
                    connection.Execute(sqlQuery, question.SequenceTrue.First());
                }
                else if (question.BoolTrue.Count != 0)
                {
                    sqlQuery = "INSERT INTO BoolsTrue (Answer, QuestionId) " +
                        "VALUES (@Answer, @QuestionId)";
                    connection.Execute(sqlQuery, question.BoolTrue.First());
                }
                else if (question.DefaultTrue.Count != 0)
                {
                    sqlQuery = "INSERT INTO DefaultsTrue (Answer, Variant1, Variant2, Variant3, Variant4, QuestionId) " +
                        "VALUES (@Answer, @Variant1, @Variant2, @Variant3, @Variant4, @QuestionId)";
                    connection.Execute(sqlQuery, question.DefaultTrue.First());
                }
            }
            connection.Close();
        }

        public Quiz QuizInit(Quiz quiz)
        {
            //додаємо новий квіз і повертаємо обєкт з готовим айдішніком
            connection.Open();
            string sqlQuery = "INSERT INTO Quizes(Title, Description, Image, Date, StatusId, UserId) " +
                              "VALUES (@Title, @Description, @Image, @Date, @StatusId, @UserId)";
            connection.Execute(sqlQuery,quiz);
            sqlQuery = "SELECT * " +
                       "FROM Quizes " +
                       "WHERE Title = @Title and Date = @Date";
            quiz = connection.QueryFirstOrDefault<Quiz>(sqlQuery, quiz);
            connection.Close();
            return quiz;
        }

        public List<Quiz> QuizGetAll()
        {
            connection.Open();
            List<Quiz> quizes = new List<Quiz>();
            string sqlQuery = "SELECT * " +
                              "FROM Quizes";
            quizes.AddRange(connection.Query<Quiz>(sqlQuery));

            foreach(Quiz quiz in quizes)
            {
                sqlQuery = "SELECT * " +
                           "FROM Questions " +
                           "WHERE QuizId = @Id";
                List<Question> questions = new List<Question>();
                questions.AddRange(connection.Query<Question>(sqlQuery, quiz));
                foreach(Question question in questions)
                {
                    if(question.TypeId == 1)
                    {
                        sqlQuery = "SELECT * " +
                                   "FROM SequencesTrue " +
                                   "WHERE QuestionId = @Id";
                        question.SequenceTrue.Add(connection.QueryFirstOrDefault<SequenceTrue>(sqlQuery, question));
                    }
                    else if (question.TypeId == 2)
                    {
                        sqlQuery = "SELECT * " +
                                   "FROM BoolsTrue " + 
                                   "WHERE QuestionId = @Id";
                        question.BoolTrue.Add(connection.QueryFirstOrDefault<BoolTrue>(sqlQuery,question));
                    }
                    else if(question.TypeId == 3)
                    {
                        sqlQuery = "SELECT * " +
                                   "FROM DefaultsTrue " +
                                   "WHERE QuestionId = @Id";
                        question.DefaultTrue.Add(connection.QueryFirstOrDefault<DefaultTrue>(sqlQuery, question));
                    }
                }
                quiz.Question = questions;
            }
            connection.Close();
            return quizes;
        }

        //Question



    }
}
