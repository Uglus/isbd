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

namespace Windows.Views
{
    /// <summary>
    /// Interaction logic for UserControlCreateSesson.xaml
    /// </summary>
    public partial class UserControlCreateSesson : UserControl
    {
        public User UserSet { get; set; }

        public UserControlCreateSesson(User user)
        {
            InitializeComponent();
            UserSet = user;
            LoadData();
        }

        private void LoadData()
        {
            DbCommands cmd = new DbCommands();
            Quiz quiz = new Quiz();
            quiz.FuncName = "QuizGetAll";
            List<Quiz> quizes = cmd.SendAndReceiveQuizList(quiz);
            foreach (Quiz q in quizes.ToList())
            {
                viewPlayQuizezz.Items.Add(q); 
            }
        }

        private void ViewPlayQuizezz_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Quiz quiz = (Quiz)viewPlayQuizezz.SelectedItem;
            Lobby lobby = new Lobby(UserSet,quiz);
            lobby.ShowDialog();

        }
    }
}
