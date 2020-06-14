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
using Microsoft.Win32;
using System.IO;


namespace Windows.Views
{
    /// <summary>
    /// Interaction logic for Settngs_User.xaml
    /// </summary>
    public partial class Settngs_User : Window
    {
        public User UserSet { get; set; }
        BitmapImage image = new BitmapImage();

        SolidColorBrush Off = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        SolidColorBrush On = new SolidColorBrush(Color.FromRgb(240, 222, 45));

        public Settngs_User(User user)
        {
            InitializeComponent();
            UserSet = user;
            UserNameTextBox.Text = user.Login;
            boxNameUser.Text = user.Name;
            boEmailUser.Text = user.Email;

        }

        public Settngs_User()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void btnChangePass_Click(object sender, RoutedEventArgs e)
        {
            NewPassword newPassword = new NewPassword(UserSet);
            newPassword.Owner = this;
            this.Hide();
            newPassword.ShowDialog();
        }

        private void btnChangeLanguage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMusic_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnToggle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            

        }

        private void list_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }

        private void btnSettingsSave_Click(object sender, RoutedEventArgs e)
        {
            DbCommands cmd = new DbCommands();
            UserSet.Login = UserNameTextBox.Text;
            UserSet.Name = boxNameUser.Text;
            UserSet.Email = boEmailUser.Text;
            UserSet.FuncName = "UserEdit";
            cmd.SendUser(UserSet);
            MessageBox.Show("Зміни збережені!");
            this.Hide();
        }

        private void ImgUserImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Image files (*.JPG, *.PNG,)|*.jpg;*.png;";
            if (opf.ShowDialog() == true)
            {
                imgUserImage.Source = new BitmapImage(new Uri(opf.FileName));
                image = new BitmapImage(new Uri(opf.FileName));
            }
        }
    }
}
