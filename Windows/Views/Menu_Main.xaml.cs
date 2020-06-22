using MaterialDesignThemes.Wpf;
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
using Windows.ViewModels;

using ClassLibrary;

namespace Windows.Views
{
    /// <summary>
    /// Interaction logic for Menu_Main.xaml
    /// </summary>
    public partial class Menu_Main : Window
    {
        public User userLogin { get; set; } = new User();

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

        public Menu_Main(User user)
        {
            InitializeComponent();

            userLogin = user;
            LoadData(userLogin);

            var menuRegister_Quizz = new List<SubItem>();
            menuRegister_Quizz.Add(new SubItem("Create session", new UserControlCreateSesson(user)));
            menuRegister_Quizz.Add(new SubItem("Create new quizz", new UserControlProviders(user)));
            menuRegister_Quizz.Add(new SubItem("Join session", new UserControlJoinSesson()));

            var item_quizz = new ItemMenu("Quizezz", menuRegister_Quizz, PackIconKind.Abc);

            var menuRegister_Friends = new List<SubItem>();
            menuRegister_Quizz.Add(new SubItem("My friends"));

            //var item_Profile = new ItemMenu("Profile", new UserControlSettngsUser(), PackIconKind.User);

            StackMenu.Children.Add(new UserControlMenuItem(item_quizz, this));
            
        }

        public void LoadData(User user)
        {
            labelNick.Content = user.Login;
        }
        
        internal void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);

            if(screen != null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void PanelProfile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //UserControlSettngsUser user_settings = new UserControlSettngsUser();
                //user_settings.ShowDialog();
                Settngs_User settngs_User = new Settngs_User(userLogin);
                settngs_User.Owner = this;
                //this.Hide();
                settngs_User.ShowDialog();
            }
        }

        private void BtnFormClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }  
    }
}
