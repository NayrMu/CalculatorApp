using System;
using System.Collections.Generic;
using System.Data;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    /* Started 06/10/2023
     * Calculator App
     * a basic calculator with some basic ui
     * a learning project
     * 
     * last touched 07/10/2023 - was going to add buttons for other operators
     */
    public partial class MainWindow : Window
    {

        public TestClass test;
        public Evaluate eval;
        string[] ops = {"+", "-", "*", "/", "^"};
        public MainWindow()
        {
            InitializeComponent();
            test = new TestClass();
            eval = new Evaluate();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            Button buttonClicked = (Button)sender;
            string buttonText = buttonClicked.Content.ToString();

            if (Array.IndexOf(ops, buttonText) > -1 && Convert.ToString(SharedData.outputText[SharedData.outputText.Length - 1]) == buttonText) //check if same operator button clicked twice
            {
                buttonClicked.Background = Brushes.Red;
                System.Threading.Thread.Sleep(500);
                buttonClicked.Background = Brushes.LightGray;
            }
            else
            {
                test.doSomething(buttonText, OutputWindow);
            }
        }

        private void EqualClick(object sender, RoutedEventArgs e)
        {
            Button buttonEqual = (Button)sender;
            eval.Eval();
            OutputWindow.Text = SharedData.outputText;
        }
        private void ClearClick(object sender, RoutedEventArgs e)
        {
            SharedData.outputText = "0";
            OutputWindow.Text = SharedData.outputText;
            SharedData.startNewEx = true;
        }
    }
}
