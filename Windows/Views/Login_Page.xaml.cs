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
using System.Windows.Shapes;

using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using ClassLibrary;

namespace Windows.Views
{
    /// <summary>
    /// Interaction logic for Login_Page.xaml
    /// </summary>
    public partial class Login_Page : Window
    {
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
        public Login_Page()
        {
            InitializeComponent();
        }

        private void ForgotPasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            Restore_Password rest_pass = new Restore_Password();
            rest_pass.Owner = this;
            this.Hide();
            rest_pass.ShowDialog();
        }

        private void BtnSignUp_Click(object sender, RoutedEventArgs e)
        {

            MainWindow mainWindow = new MainWindow();
            mainWindow.Owner = this;
            this.Hide();
            mainWindow.ShowDialog();
        }

        private void loginUserBtn_Click(object sender, RoutedEventArgs e)
        {
           // try
           // {
                string ipConnect = "127.0.0.1";
                int port = 1488;
                IPAddress ip = IPAddress.Parse(ipConnect);
                TcpClient client = new TcpClient();
                client.Connect(ip, port);

                
                NetworkStream ns = client.GetStream();
                BinaryFormatter bf = new BinaryFormatter();
                
                User user = new User();
                user.Login = UserNameTextBox.Text;
                user.Password = UserPasswordTextBlock.Password;
                user.FuncName = "UserSignIn";
                bf.Serialize(ns, user);

                bool result = (bool)bf.Deserialize(ns);
                ns.Close();
                client.Close();

                if (result == true)
                {

                    Menu_Main menu_Main = new Menu_Main();
                    menu_Main.Owner = this;
                    this.Hide();
                    menu_Main.ShowDialog();

                }
          // }
          // catch (Exception err) { }

            
        }
    }
}
