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
        public ButtonClass button;
        public Evaluate eval;
        string ops = @"\+\-\*\/^";
        public SharedData sData;
        public MainWindow()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
            button = new ButtonClass();
            eval = new Evaluate();
            sData = new SharedData();
        }

        private async void ButtonClick(object sender, RoutedEventArgs e)
        {
            string output = SharedData.outputText;
            Button buttonClicked = (Button)sender;
            string buttonText = buttonClicked.Content.ToString();
            if (!(ops.Contains(buttonText) && ops.Contains(output[output.Length - 1]))) //check if same operator button clicked twice
            {
                button.doSomething(buttonText, OutputWindow);
            }
        }

        private void EqualClick(object sender, RoutedEventArgs e)
        {
            Button buttonEqual = (Button)sender;
            eval.Eval();
            OutputWindow.Text = SharedData.outputText;
            History.Text = SharedData.historyText;
        }
        private void ClearClick(object sender, RoutedEventArgs e)
        {
            SharedData.outputText = "0";
            OutputWindow.Text = SharedData.outputText;
            SharedData.startNewEx = true;
        }
        private void HistClick(object sender, RoutedEventArgs e)
        {
            if (ops.Contains(SharedData.outputText[SharedData.outputText.Length - 1]))
            {
                SharedData.outputText += SharedData.historyText;
                OutputWindow.Text = SharedData.outputText;
            }
            else
            {
                SharedData.outputText = SharedData.historyText;
                OutputWindow.Text = SharedData.outputText;
            }
        }

        private void SqrtClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Content.ToString();
            if (SharedData.startNewEx == true || !(ops.Contains(SharedData.outputText[SharedData.outputText.Length - 1])))
            {
                SharedData.outputText = buttonText;
                OutputWindow.Text = SharedData.outputText;
                SharedData.startNewEx = false;
            }
            else
            {
                SharedData.outputText += buttonText;
                OutputWindow.Text = SharedData.outputText;
            }
        }
        private void LogClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Content.ToString();
            if (SharedData.startNewEx == true || !(ops.Contains(SharedData.outputText[SharedData.outputText.Length - 1])))
            {
                SharedData.outputText = buttonText;
                OutputWindow.Text = SharedData.outputText;
                SharedData.startNewEx = false;
            }
            else
            {
                SharedData.outputText += buttonText;
                OutputWindow.Text = SharedData.outputText;
            }
        }
        private void VarClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Content.ToString();
            if (SharedData.setMode == false)
            {
                if (SharedData.startNewEx == true || !(ops.Contains(SharedData.outputText[SharedData.outputText.Length - 1])))
                {
                    SharedData.outputText = SharedData.varMap[buttonText].ToString();
                    OutputWindow.Text = SharedData.outputText;
                }
                else
                {
                    SharedData.outputText += SharedData.varMap[buttonText].ToString();
                    OutputWindow.Text = SharedData.outputText;
                }
            }
            else
            {
                SharedData.varMap[buttonText] = SharedData.historyText;
                SharedData.setMode = false;
            }
        }
        private void SetClick(object sender, RoutedEventArgs e)
        {
            SharedData.setMode = true;
        }
    }
}
