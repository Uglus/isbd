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

using ClassLibrary;
using Windows.Commands;

namespace Windows.Views
{
    /// <summary>
    /// Interaction logic for Restore_Password.xaml
    /// </summary>
    public partial class Restore_Password : Window
    {
        public User user = new User();
        DbCommands commands = new DbCommands();

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
        public Restore_Password()
        {
            InitializeComponent();
        }

        private void btnChangePass_Click(object sender, RoutedEventArgs e)
        {
            if (boxCodeEntry.Text == user.ActivateLink.ToString())
            {
                if (boxNewPassEntry.Password == boxConfirmPass.Password)
                {
                    string passw = boxNewPassEntry.Password;
                    user.Password = passw;
                    user.FuncName = "UserEdit";
                    commands.SendUser(user);

                    Login_Page lg = new Login_Page();
                    lg.Owner = this;
                    this.Hide();
                    lg.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Паролі не сходяться");
                }
            }
            else
            {
                
                MessageBox.Show($"Код активації не вірний {boxCodeEntry.Text} - {user.ActivateLink.ToString()}");
            }

            
        }

        private void BtnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            //Відправляємо мило і яким методом працювати сереверу
            string email = BoxEmail.Text;
            string method = "SendActivateLink";
            user.Email = email;
            user.FuncName = method;
            user = commands.SendAndReceiveUser(user);

            MessageBox.Show(user.ActivateLink.ToString());
        }

        private void SendToServer(User user)
        {

        }

    }
}
