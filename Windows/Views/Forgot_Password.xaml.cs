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
    /// Interaction logic for Restore_Password.xaml
    /// </summary>
    public partial class Restore_Password : Window
    {
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
            Login_Page lg = new Login_Page();
            lg.Owner = this;
            this.Hide();
            lg.ShowDialog();
        }

        private void BtnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
