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
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;

using ClassLibrary;
using Windows.Commands;

namespace Windows.Views
{
    /// <summary>
    /// Interaction logic for Lobby.xaml
    /// </summary>
    public partial class Lobby : Window
    {
        public User UserSet { get; set; }
        public Quiz QuizSet { get; set; }


        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

        public Lobby()
        {
            InitializeComponent();
        }

        public Lobby(User user,Quiz quiz)
        {
            InitializeComponent();
            UserSet = user;
            QuizSet = quiz;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void BtnStartGame_Click(object sender, RoutedEventArgs e)
        {
            UserToSession userSession = new UserToSession();
            Session session = new Session();
            userSession.Session = session;
            userSession.User = UserSet;
            userSession.Session.Quiz = QuizSet;
            int cnt = QuizSet.Question.Count;
            for(int i=0; i < cnt;i++)
            {
                Play_Quiz play = new Play_Quiz(userSession,i);
                if(play.ShowDialog() == true)
                {
                    userSession = play.UserSessionSet;
                }
            }

            DbCommands cmd = new DbCommands();
            cmd.SendUserSession(userSession);

            Quiz_Final final = new Quiz_Final();
            final.ShowDialog();

        }
    }
}
