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

namespace Windows.Views
{
    /// <summary>
    /// Interaction logic for Menu_Main.xaml
    /// </summary>
    public partial class Menu_Main : Window
    {
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
        public Menu_Main()
        {
            InitializeComponent();

            var menuRegister_Quizz = new List<SubItem>();
            //menuRegister_Quizz.Add(new SubItem("Play quizz", new UserControlPlayQuizezz()));
            menuRegister_Quizz.Add(new SubItem("Create session", new UserControlCreateSesson()));
            menuRegister_Quizz.Add(new SubItem("Create new quizz", new UserControlProviders()));
            menuRegister_Quizz.Add(new SubItem("Join session", new UserControlJoinSesson()));

            var item_quizz = new ItemMenu("Quizezz", menuRegister_Quizz, PackIconKind.Abc);

            //!!!!!!!!!!!!
            var menuRegister_Chats = new List<SubItem>();
            menuRegister_Chats.Add(new SubItem("My chats", new UserControlChats1()));

            var item_Chats = new ItemMenu("Chats", new UserControlChats1(), PackIconKind.Chat);

            var menuRegister_Friends = new List<SubItem>();
            menuRegister_Quizz.Add(new SubItem("My friends"));

            var item_Friends = new ItemMenu("Friends", new UserControl(), PackIconKind.UsersGroup);

            var menuRegister_News = new List<SubItem>();
            menuRegister_Quizz.Add(new SubItem("My news"));

            var item_News = new ItemMenu("News", new UserControl(), PackIconKind.Newspaper);

            StackMenu.Children.Add(new UserControlMenuItem(item_quizz, this));
            StackMenu.Children.Add(new UserControlMenuItem(item_Chats, this));
            StackMenu.Children.Add(new UserControlMenuItem(item_Friends, this));
            StackMenu.Children.Add(new UserControlMenuItem(item_News, this));
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
    }
}
