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

namespace Windows.Views
{
    /// <summary>
    /// Interaction logic for Settngs_User.xaml
    /// </summary>
    public partial class Settngs_User : Window
    {
        SolidColorBrush Off = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        SolidColorBrush On = new SolidColorBrush(Color.FromRgb(240, 222, 45));

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
            NewPassword newPassword = new NewPassword();
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
    }
}
