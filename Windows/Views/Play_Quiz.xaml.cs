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
    /// Interaction logic for Play_Quiz.xaml
    /// </summary>
    public partial class Play_Quiz : Window
    {
        public UserToSession UserSessionSet { get; set; }
        public int NumberOfQuestion { get; set; }

        public Play_Quiz()
        {
            InitializeComponent();
        }

        public Play_Quiz(UserToSession uts, int num)
        {
            InitializeComponent();
            UserSessionSet = uts;
            NumberOfQuestion = num;
            InitQuestion();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void InitQuestion()
        {
            Question question = UserSessionSet.Session.Quiz.Question.ElementAt(NumberOfQuestion);
            boxQuestionText.Text = question.Text;
            lblNum.Content = NumberOfQuestion.ToString();
            if (question.BoolTrue.Count != 0)
            {
                panelBool.Visibility = Visibility.Visible;
            }
            else if(question.DefaultTrue.Count != 0)
            {
                panelDefault.Visibility = Visibility.Visible;
                boxVariant1.Text = question.DefaultTrue.First().Variant1;
                boxVariant2.Text = question.DefaultTrue.First().Variant2;
                boxVariant3.Text = question.DefaultTrue.First().Variant3;
                boxVariant4.Text = question.DefaultTrue.First().Variant4;
            }
            else if(question.SequenceTrue.Count != 0)
            {
                panelSequence.Visibility = Visibility.Visible;

                comboOfSeq1.Items.Add(question.SequenceTrue.First().Answer1);
                comboOfSeq1.Items.Add(question.SequenceTrue.First().Answer2);
                comboOfSeq1.Items.Add(question.SequenceTrue.First().Answer3);
                comboOfSeq1.Items.Add(question.SequenceTrue.First().Answer4);

                comboOfSeq2.Items.Add(question.SequenceTrue.First().Answer1);
                comboOfSeq2.Items.Add(question.SequenceTrue.First().Answer2);
                comboOfSeq2.Items.Add(question.SequenceTrue.First().Answer3);
                comboOfSeq2.Items.Add(question.SequenceTrue.First().Answer4);

                comboOfSeq3.Items.Add(question.SequenceTrue.First().Answer1);
                comboOfSeq3.Items.Add(question.SequenceTrue.First().Answer2);
                comboOfSeq3.Items.Add(question.SequenceTrue.First().Answer3);
                comboOfSeq3.Items.Add(question.SequenceTrue.First().Answer4);

                comboOfSeq4.Items.Add(question.SequenceTrue.First().Answer1);
                comboOfSeq4.Items.Add(question.SequenceTrue.First().Answer2);
                comboOfSeq4.Items.Add(question.SequenceTrue.First().Answer3);
                comboOfSeq4.Items.Add(question.SequenceTrue.First().Answer4);
            }
        }

        private void BtnAnswerSend_Click(object sender, RoutedEventArgs e)
        {
            if(panelBool.Visibility == Visibility.Visible)
            {
                UserAnswerBool answ = new UserAnswerBool();
                
                if(radioTrue.IsChecked == true)
                    answ.Answer = true;
                else
                    answ.Answer = false;
                UserSessionSet.UserAnswerBool.Add(answ);

            }
            else if (panelDefault.Visibility == Visibility.Visible)
            {
                UserAnswerDefault answ = new UserAnswerDefault();
                if(radioVar1.IsChecked==true)
                {
                    answ.Answer = boxVariant1.Text;
                }
                else if (radioVar2.IsChecked == true)
                {
                    answ.Answer = boxVariant2.Text;
                }
                else if (radioVar3.IsChecked == true)
                {
                    answ.Answer = boxVariant3.Text;
                }
                else if (radioVar4.IsChecked == true)
                {
                    answ.Answer = boxVariant4.Text;
                }
                UserSessionSet.UserAnswerDefault.Add(answ);
            }
            else if (panelSequence.Visibility == Visibility.Visible)
            {
                UserAnswerSequence answ = new UserAnswerSequence();
                answ.Answer1 = comboOfSeq1.Text;
                answ.Answer2 = comboOfSeq2.Text;
                answ.Answer3 = comboOfSeq3.Text;
                answ.Answer4 = comboOfSeq4.Text;
                UserSessionSet.UserAnswerSequence.Add(answ);
            }
            ////////////
            this.Hide();
        }
    }
}
