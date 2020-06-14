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
using Windows.Views;

using ClassLibrary;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Windows.Commands;

namespace Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DbCommands commands = new DbCommands();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = UserNameTextBox.Text;
            string name = FirsNameTextBox.Text;
            string email = EmailTexBox.Text;
            string passw = PasswordTexBox.Password;
            DateTime regDate = DateTime.Now;

            User userSignUp = new User()
            {
                Name = name, Login = login,
                Email = email, Password = passw,
                RegistrationDate = regDate,RoleId = 1,
                StatusId = 2, FuncName = "UserSignUp"
            };

            commands.SendUser(userSignUp);
            //User userSignUp = new User(0, name, login, email, passw, regDate, 1, 2, "UserSignUp");
            /*
            string ipConnect = "127.0.0.1";
            int port = 1488;
            IPAddress ip = IPAddress.Parse(ipConnect);
            TcpClient client = new TcpClient();
            client.Connect(ip, port);

            NetworkStream ns = client.GetStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ns, userSignUp);

            ns.Close();
            client.Close();
            */

            Login_Page lg = new Login_Page();
            lg.Owner = this;
            this.Hide();
            lg.ShowDialog();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
