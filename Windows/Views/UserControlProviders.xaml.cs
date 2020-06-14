using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using ClassLibrary;
using Windows.Commands;
using Microsoft.Win32;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Windows.Views
{
    /// <summary>
    /// Interaction logic for UserControlProviders.xaml
    /// </summary>
    public partial class UserControlProviders : UserControl
    {
        public User UserSet { get; set; }
        BitmapImage imageQuiz = new BitmapImage();
        public UserControlProviders(User user)
        {
            InitializeComponent();
            UserSet = user;
        }

        private  void btnUserConStart_Click(object sender, RoutedEventArgs e)
        {
            int item = comboQuestionsCount.SelectedIndex;

            int count = 2;
            if (item == 0)
            {
                count = 6;
            }
            if (item == 1)
            {
                count = 10;
            }
            if (item == 2)
            {
                count = 20;
            }
 
            Quiz quiz = new Quiz
            {
                Title = boxQuizTitle.Text,
                Description = boxQuizDescription.Text,
                Image = "../Images/user_logo.png",
                Date = DateTime.Now,
                FuncName = "QuizInit",
                StatusId = 1,
                UserId = UserSet.Id
            };

            DbCommands cmd = new DbCommands();
            quiz = cmd.SendAndReceiveQuiz(quiz);

            for (int i = 0; i < count; i++)
            {
                Create_Quiz create_quiz = new Create_Quiz(quiz);
                if (create_quiz.ShowDialog() == true)
                {
                    quiz = create_quiz.QuizSet;
                }
            }

            quiz.FuncName = "QuizQuestionsAdd";
            quiz = cmd.SendQuiz(quiz);
        }

        /*
        private string ImageSerialization(BitmapImage image)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            bf.Serialize(stream, image);
            stream = Encoding.ASCII.GetBytes(stream);

        }
        */

        private void ImgQuizImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Image files (*.JPG, *.PNG,)|*.jpg;*.png;";
            if (opf.ShowDialog() == true)
            {
                imgQuizImage.Source = new BitmapImage(new Uri(opf.FileName));
                imageQuiz = new BitmapImage(new Uri(opf.FileName));
            }

        }
    }
}
