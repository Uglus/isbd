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

namespace Windows.Views
{
    /// <summary>
    /// Interaction logic for Settngs_User.xaml
    /// </summary>
    public partial class Settngs_User : Window
    {
        public User UserSet { get; set; }

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

        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            //string style = comboThemeChange.SelectedItem as string;
            //// определяем путь к файлу ресурсов
            //var uri = new Uri(style + ".xaml", UriKind.Relative);
            //// загружаем словарь ресурсов
            //ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            //// очищаем коллекцию ресурсов приложения
            //Application.Current.Resources.Clear();
            //// добавляем загруженный словарь ресурсов
            //Application.Current.Resources.MergedDictionaries.Add(resourceDict);

            string yellow_path = @"pack://application:,,,/Yellow.xaml";
            string darkblue_path = @"pack://application:,,,/DarkBlue.xaml";
            if (radioThemeChange.IsChecked == true)
            {
                this.Resources = new ResourceDictionary() { Source = new Uri(yellow_path) };
            }
            else
            {
                this.Resources = new ResourceDictionary() { Source = new Uri(darkblue_path) };
            }
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

        }
    }
}
