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
using Windows.Commands;
using System.IO;

namespace Windows.Views
{
    /// <summary>
    /// Interaction logic for Login_Page.xaml
    /// </summary>
    public partial class Login_Page : Window
    {
       // public User user { get; set; }
        const string filePathUser = @"../../Data/User.bin";

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

        public Login_Page()
        {
            InitializeComponent();
            AutoLogin();// Зчитування логіну і пароля з файлу
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
            try
            {
                DbCommands commands = new DbCommands();
                User user = new User();
                user.Login = UserNameTextBox.Text;
                user.Password = UserPasswordTextBlock.Password;
                user.FuncName = "UserSignIn";
                user = commands.SendAndReceiveUser(user);

                if (rememberUserRadioBtn.IsChecked == true)
                {
                    SaveUser(user); //Збереження юзера в файл
                }

                if (user.Id != 0)
                {
                    GoToMainWindow(user);
                }
            }
           catch (Exception err) { MessageBox.Show(err.Message); } 
        }

        private void Window_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private async void SaveUser(User user)
        {
            await Task.Run(() => {
                Stream SaveFileStream = File.Create(filePathUser);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(SaveFileStream,user);
                SaveFileStream.Close();
            });
        }

        private void AutoLogin()
        {
            if (File.Exists(filePathUser))
            {
                Stream openFS = File.OpenRead(filePathUser);
                BinaryFormatter bf = new BinaryFormatter();
                User user = new User();
                user = (User)bf.Deserialize(openFS);
                openFS.Close();

                UserNameTextBox.Text = user.Login;
                UserPasswordTextBlock.Password = user.Password;
                //GoToMainWindow(user);

            }
        }

        private void GoToMainWindow(User userLogin)
        {
            Menu_Main menu_Main = new Menu_Main(userLogin);
            menu_Main.Owner = this;

            this.Hide();
            menu_Main.ShowDialog();
        }

    }
}
