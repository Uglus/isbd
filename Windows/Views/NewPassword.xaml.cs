using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

using ClassLibrary;
using Windows.Commands;
using System.IO;

namespace Windows.Views
{
    /// <summary>
    /// Interaction logic for NewPassword.xaml
    /// </summary>
    public partial class NewPassword : Window
    {
        public User UserSet { get; set; }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

        public NewPassword(User user)
        {
            InitializeComponent();
            UserSet = user;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void letsGoBtn_Click(object sender, RoutedEventArgs e)
        {
            if(boxOldPass.Password == UserSet.Password)
            {
                if(NewPasswordTexBox.Password == ConfirmPasswordTextBox.Password)
                {
                    UserSet.Password = NewPasswordTexBox.Password;
                    DbCommands cmd = new DbCommands();
                    UserSet.FuncName = "UserEdit";
                    cmd.SendUser(UserSet);

                    const string filePathUser = @"../../Data/User.bin";
                    if (File.Exists(filePathUser)) //Якщо юзер користувався функцією автологіна
                    {
                        File.Delete(filePathUser);
                    }

                    MessageBox.Show("Пароль змінено!");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Нові паролі не співпадають");
                }
            }
            else
            {
                MessageBox.Show("Неправильний старий пароль");
            }
            

            
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
