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
        public Quiz QuizSet { get; set; }

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
            QuizSet = q;
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
            int point = 0;
            point = Convert.ToInt32(boxScore.Text);
            //Створення питання
            Question question = new Question()
            {
                QuizId = QuizSet.Id,
                TypeId = comboOfTypeQuestion.SelectedIndex + 1,
                Text = boxTrueFalse.Text,
                Points = point,
                Image = ""
            };

            //Дивлячись, який обрано тип питання - вичисляємо відповідь
            if(panelSequence.Visibility == Visibility.Visible)
            {
                SequenceTrue sequence = new SequenceTrue {
                    Answer1 = boxSequence1.Text,
                    Answer2 = boxSequence2.Text,
                    Answer3 = boxSequence3.Text,
                    Answer4 = boxSequence4.Text,
                };
                question.SequenceTrue.Add(sequence);
                MessageBox.Show("SequenceTrue added");
            }
            if (panelBool.Visibility == Visibility.Visible)
            {
                bool answer = true;
                if (radioTrue.IsChecked == true)
                { answer = true; } else { answer = false; }
                
                BoolTrue boolTrue = new BoolTrue {
                    Answer = answer
                };
                question.BoolTrue.Add(boolTrue);
                MessageBox.Show("BoolTrue added");
            }
            if (panelVariant.Visibility == Visibility.Visible)
            {
                string answer = "";
                if (radioVar1.IsChecked == true) { answer = boxVariant1.Text; }
                else if (radioVar2.IsChecked == true) { answer = boxVariant2.Text; }
                else if (radioVar3.IsChecked == true) { answer = boxVariant3.Text; }
                else if (radioVar4.IsChecked == true) { answer = boxVariant4.Text; }

                DefaultTrue defaultTrue = new DefaultTrue {
                    Variant1 = boxVariant1.Text,
                    Variant2 = boxVariant2.Text,
                    Variant3 = boxVariant3.Text,
                    Variant4 = boxVariant4.Text,
                    Answer = answer
                };

                question.DefaultTrue.Add(defaultTrue);
                MessageBox.Show("DefaultTrue added");
            }
            QuizSet.Question.Add(question);
            this.Hide();
        }

        private void ComboOfTypeQuestion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboOfTypeQuestion.SelectedIndex == 0)
            {
                panelSequence.Visibility = Visibility.Visible;
                panelBool.Visibility = Visibility.Collapsed;
                panelVariant.Visibility = Visibility.Collapsed;

            }
            if (comboOfTypeQuestion.SelectedIndex == 1)
            {
                panelSequence.Visibility = Visibility.Collapsed;
                panelBool.Visibility = Visibility.Visible;
                panelVariant.Visibility = Visibility.Collapsed;
            }

            if (comboOfTypeQuestion.SelectedIndex == 2)
            {
                panelSequence.Visibility = Visibility.Collapsed;
                panelBool.Visibility = Visibility.Collapsed;
                panelVariant.Visibility = Visibility.Visible;
            }

            btnCreateQuestion.Visibility = Visibility.Visible;
            boxTrueFalse.Visibility = Visibility.Visible;
        }
    }
}
