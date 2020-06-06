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

namespace Windows.Views
{
    /// <summary>
    /// Interaction logic for UserControlPlayQuizezz.xaml
    /// </summary>
    public partial class UserControlPlayQuizezz : UserControl
    {
        public UserControlPlayQuizezz()
        {
            InitializeComponent();
        }

        private void btnJoinToSession_Click(object sender, RoutedEventArgs e)
        {
            Lobby lobby = new Lobby();
            lobby.ShowDialog();
        }
    }
}
