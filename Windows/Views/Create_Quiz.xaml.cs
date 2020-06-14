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
    /// Interaction logic for Create_Quiz.xaml
    /// </summary>
    public partial class Create_Quiz : Window
    {
        public Quiz quiz { get; set; }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

        public Create_Quiz()
        {
            InitializeComponent();
        }

        public Create_Quiz(Quiz q)
        {
            quiz = q;
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void btnFormCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCreateQuestion_Click(object sender, RoutedEventArgs e)
        {
            Question question = new Question()
            {
                QuizId = quiz.Id,
                TypeId = comboOfTypeQuestion.SelectedIndex,
                Text = boxTrueFalse.Text,
                Points = boxScore.Text,

            };

            quiz.Question.Add(question);
        }
    }
}
