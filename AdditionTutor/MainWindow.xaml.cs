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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Collections;


namespace AdditionTutor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
         

        AdditionTutor_Validate AdditionTutor = new AdditionTutor_Validate();

        public MainWindow()
        {
            InitializeComponent();
            DisplayProblem();
                        
        }

        public async void Check_Click(object sender, RoutedEventArgs e)
        {
            int yourSum = 0, mySum = AdditionTutor.myNums[2];
            bool bCorrect = false;

            if (int.TryParse(your_sum.Text, out yourSum))
            {
                if (yourSum == AdditionTutor.myNums[2])
                {
                    lbl_Result.Content = "Correct! Great job";
                    bCorrect = true;
                   
                }

                else
                {
                    lbl_Result.Content = "Oops! The correct answer is " + mySum;
                    bCorrect = false;


                }

                SaveResultsToFile(bCorrect); // Save Math question , UserAnser, Correct Answer to file

                 // want a delay without blocking the current thread
                await Task.Delay(1500);

                DisplayProblem();  // Display Math Question using two Random numbers
               

            }
            else
            {
                lbl_Result.Content = "Please enter an integer value";
                your_sum.Background = Brushes.Red;
                your_sum.Foreground = Brushes.Black;
                your_sum.Focus();
            }

      
           
        }

        public void SaveResultsToFile(bool bCorrect)
        {
            // Save the results to file
            const string DIRNAME = "Addition Tutor";
            


            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string fullpath = System.IO.Path.Combine(path, DIRNAME);
            Directory.CreateDirectory(fullpath);

            string filepath = System.IO.Path.Combine(fullpath, "addtutor.txt");
            File.AppendAllText(filepath, AdditionTutor.myNums[0].ToString() + " + " + AdditionTutor.myNums[1].ToString() + " = "  + AdditionTutor.myNums[2].ToString() +
              ( bCorrect ? " Correct" : " Incorrect")  +  " Your Answer was " + your_sum.Text.ToString() + Environment.NewLine);


        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Close();
            
        }

        public void DisplayProblem()
        {
             

            int[] myNums = new int[3];

            myNums = AdditionTutor.Rands_and_mySum();

            lbl_num1.Content = myNums[0];
            lbl_num2.Content = myNums[1];
            your_sum.Background = Brushes.Transparent;
            your_sum.Foreground = Brushes.Black;

            your_sum.Text = "";
            lbl_Result.Content = "";

            your_sum.Focus();
 
        }

    
    }
}
