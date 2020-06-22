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
            Console.WriteLine($"Server: QuizQuestionsAdd - QuizId:{quiz.Id}");
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
                Console.WriteLine($">>>Question Added. Id:{question.Id}");
                if (qest.SequenceTrue.Count > 0)
                {
                    question.SequenceTrue = qest.SequenceTrue;
                    question.SequenceTrue.First().QuestionId = question.Id;
                    sqlQuery = "INSERT INTO SequencesTrue (Answer1,Answer2,Answer3,Answer4,QuestionId) " +
                        "VALUES (@Answer1,@Answer2,@Answer3,@Answer4,@QuestionId)";
                    connection.Execute(sqlQuery, question.SequenceTrue.First());
                    Console.WriteLine($">>>>>>Added SequenceTrue. Answers:{question.SequenceTrue.First().Answer1}{question.SequenceTrue.First().Answer2}{question.SequenceTrue.First().Answer3}{question.SequenceTrue.First().Answer4}");
                }
                else if (qest.BoolTrue.Count > 0)
                {
                    question.BoolTrue = qest.BoolTrue;
                    question.BoolTrue.First().QuestionId = question.Id;
                    sqlQuery = "INSERT INTO BoolsTrue (Answer, QuestionId) " +
                        "VALUES (@Answer, @QuestionId)";
                    connection.Execute(sqlQuery, question.BoolTrue.First());
                    Console.WriteLine($">>>>>>Added BoolTrue. Answer{question.BoolTrue.First().Answer}");
                }
                else if (qest.DefaultTrue.Count > 0)
                {
                    question.DefaultTrue = qest.DefaultTrue;
                    question.DefaultTrue.First().QuestionId = question.Id;
                    sqlQuery = "INSERT INTO DefaultsTrue (Answer, Variant1, Variant2, Variant3, Variant4, QuestionId) " +
                        "VALUES (@Answer, @Variant1, @Variant2, @Variant3, @Variant4, @QuestionId)";
                    connection.Execute(sqlQuery, question.DefaultTrue.First());
                    Console.WriteLine($">>>>>>Added DefaultTrue. Answer-{question.DefaultTrue.First().Answer} Var1{question.DefaultTrue.First().Variant1} Var2{question.DefaultTrue.First().Variant2} Var3{question.DefaultTrue.First().Variant3} Var4{question.DefaultTrue.First().Variant4}");
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

        //Session
        public void UserSessionAdd(UserToSession uts)
        {
            connection.Open();
          //  UserToSession userSession = uts;
            Session session = uts.Session;
            User user = uts.User;
            Quiz quiz = uts.Session.Quiz;
            session.Date = DateTime.Now;
            session.QuizId = quiz.Id;
            session.AccessCode = "asdad";

            string sqlQuery = "INSERT INTO Sessions(AccessCode, Date, StatusId, QuizId) " +
                              "VALUES (@AccessCode, @Date, 1, @QuizId)";
            connection.Execute(sqlQuery, session);
            Console.WriteLine(">>>Inserted in Sessions");

            sqlQuery = "SELECT * FROM Sessions WHERE QuizId = @QuizId and Date = @Date";
            session = connection.QueryFirst<Session>(sqlQuery, session);
            Console.WriteLine(">>>Selected from Sessions");

            sqlQuery = "INSERT INTO UsersToSessions(SessionId,UserId) " +
                      $"VALUES (@Id, {user.Id})";
            connection.Execute(sqlQuery,session);
            Console.WriteLine(">>>Inserted in UsersToSessions");
            
            //?
            sqlQuery = "SELECT Id FROM UsersToSessions " +
                       $"WHERE SessionId = @Id and UserId = {user.Id}";
            uts.Id = connection.QueryFirst<int>(sqlQuery, session);
            Console.WriteLine(">>>Selected ID from UsersToSessions");

            foreach(Question question in uts.Session.Quiz.Question)
            {
                if (question.BoolTrue.Count != 0)
                {
                    sqlQuery = "INSERT INTO UserAnswersBool(Answer, BoolId, UserSessionId) " +
                              $"VALUES (@Answer, {question.BoolTrue.First().Id},{uts.Id})";
                    connection.Execute(sqlQuery,uts.UserAnswerBool);
                    Console.WriteLine(">>>>>>Inserted in UserAnswersBool");
                }
                if (question.DefaultTrue.Count != 0)
                {
                    sqlQuery = "INSERT INTO UserAnswersDefault(Answer, DefaultId, UserSessionId) " +
                               $"VALUES (@Answer, {question.DefaultTrue.First().Id},{uts.Id})";
                    connection.Execute(sqlQuery, uts.UserAnswerDefault);
                    Console.WriteLine(">>>>>>Inserted in UserAnswersDefault");
                }
                if (question.SequenceTrue.Count != 0)
                {
                    sqlQuery = "INSERT INTO UsersAnswersSequence(Answer1,Answer2,Answer3,Answer4,SequenceId,UserSessionId) " +
                               $"VALUES (@Answer1,@Answer2,@Answer3,@Answer4,{question.SequenceTrue.First().Id},{uts.Id})";
                    connection.Execute(sqlQuery, uts.UserAnswerSequence);
                    Console.WriteLine(">>>>>>Inserted in UsersAnswersSequence");
                }
            }

            connection.Close();
        }


        //Забив
        public Quiz GetLeaders(Quiz quiz)
        {
            connection.Open();
            string sqlQuery = "SELECT * FROM Sessions WHERE QuizId = @QuizId ";

            List<Session> sessionsList = new List<Session>();
            sessionsList.AddRange(connection.Query<Session>(sqlQuery, quiz));

            sqlQuery = "SELECT * FROM UsersToSessions WHERE SessionId = @SessionId";
            List<UserToSession> usersSessionsList = new List<UserToSession>();
            foreach (Session session in sessionsList)
            {
                usersSessionsList.AddRange(connection.Query<UserToSession>(sqlQuery, session));
            }


            sqlQuery = "SELECT * FROM Questions WHERE QuizId = @QuizId ";
            List<Question> questions = new List<Question>();
            questions.AddRange(connection.Query<Question>(sqlQuery,quiz));
            int pointsSum = 0;
            foreach(Question question in questions)
            {
                /*SELECT *  FROM table1 t1
                 * RIGHT JOIN table2 t2
                    WHERE
                    t1.c1 = t2.c6 AND
                    t1.c2 = t2.c7*/
                if (question.TypeId == 1)
                {
                    sqlQuery = "SELECT SUM(Points) " +
                               "FROM Questions quest " +
                               "RIGHT JOIN SequencesTrue sTrue " +
                               "RIGTH JOIN UsersAnswersSequence sUser " +
                               "WHERE quest.TypeId = 1 " +
                               "and sTrue.Answer1 = sUser.Answer1 " +
                               "and sTrue.Answer2 = sUser.Answer2 " +
                               "and sTrue.Answer3 = sUser.Answer3 " +
                               "and sTrue.Answer4 = sUser.Answer4 " +
                               "and sUser.SequenceId = sTrue.Id";
                    pointsSum += connection.QueryFirst<int>(sqlQuery);
                }
                if (question.TypeId == 2)
                {
                    sqlQuery = "SELECT SUM(Points) " +
                               "FROM Questions quest " +
                               "RIGHT JOIN BoolsTrue bTrue " +
                               "RIGTH JOIN UserAnswersBool bUser " +
                               "WHERE quest.TypeId = 2 " +
                               "and bTrue.Answer = bUser.Answer " +
                               "and bUser.BoolId = bTrue.Id";
                    pointsSum += connection.QueryFirst<int>(sqlQuery);
                }
                if (question.TypeId == 3)
                {
                    sqlQuery = "SELECT SUM(Points) " +
                                "FROM Questions quest " +
                                "RIGHT JOIN DefaultsTrue dTrue " +
                                "RIGTH JOIN UserAnswersDefault dUser " +
                                "WHERE quest.TypeId = 3 " +
                                "and dTrue.Answer = dUser.Answer " +
                                "and dUser.DefaultId = dTrue.Id";
                    pointsSum += connection.QueryFirst<int>(sqlQuery);
                }
            }

            List<Leader> leaders = new List<Leader>();

           // ICollection<Session> sessionsAllColl = connection.Query<Session>(sqlQuery, quiz); ;
          //  ICollection<UserToSession> usersSessionsAllColl;

            connection.Close();
            return quiz;
        }


    }
}
