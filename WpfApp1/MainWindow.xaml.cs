using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.InteropServices;
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
     * last touched 07/16/2023 was working on style changes, am going to try different "pages" each their their own style settings
     */
    public partial class MainWindow : Window
    {
        public ButtonClass button;
        public Evaluate eval;
        string ops = @"\+\-\*\÷^";
        public SharedData sData;
        public MainWindow()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
            button = new ButtonClass();
            eval = new Evaluate();
            sData = new SharedData();
            SharedData.outputText = "0";
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
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
            if (SharedData.outputText.Length + SharedData.historyText.Length < 17)
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
        }

        private void SqrtClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Content.ToString();
            if (SharedData.outputText.Length < 16)
            {
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
        }
        private void LogClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Content.ToString();
            if (SharedData.outputText.Length < 15)
            {
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
        }
        private void VarClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Content.ToString();
            if (SharedData.outputText.Length + SharedData.historyText.Length < 17)
            {
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
        }
        private void SetClick(object sender, RoutedEventArgs e)
        {
            SharedData.setMode = true;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var currentSelection = comboBox.SelectedIndex;
            System.Diagnostics.Debug.WriteLine("Made it and the current selection is written as " + currentSelection);
            if (currentSelection == 0)
            {
                sData.ClassicLook();
            }
            else if (currentSelection == 1)
            {
                sData.DarkLook();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Made it and the current selection is written as " + currentSelection);
                sData.OldSchoolLook();
            }

            this.Resources["ButtonColor"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(sData.buttonColor));
            this.Resources["ButtonPressedColor"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(sData.buttonPressedColor));
            this.Resources["SpecialButtonColor"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(sData.specialButtonColor));
            this.Resources["SpecialButtonPressedColor"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(sData.specialButtonPressedColor));
            this.Resources["VarButtonColor"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(sData.varButtonColor));
            this.Resources["VarButtonPressedColor"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(sData.varButtonPressedColor));
            this.Resources["ButtonTextColor"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(sData.buttonTextColor));
            this.Resources["OtherButtonColor"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(sData.otherButtonTextColor));
            this.Resources["PlateColor"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(sData.plateColor));
            this.Resources["ShellColor"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(sData.shellColor));
            this.Resources["ButtonSelectColor"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(sData.buttonSelectColor));
            this.Resources["PlateBorderColor"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(sData.plateBorderColor));
            this.Resources["ScreenColor"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(sData.screenColor));
            this.Resources["ScreenTextColor"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(sData.screenTextColor));
        }
        private void BackSpaceClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(SharedData.outputText);
            if (SharedData.outputText != "0")
            {
                System.Diagnostics.Debug.WriteLine(SharedData.outputText);
                SharedData.outputText = SharedData.outputText.Remove((SharedData.outputText.Length)-1);
                System.Diagnostics.Debug.WriteLine(SharedData.outputText);
                OutputWindow.Text = SharedData.outputText;
            }
            if (SharedData.outputText == "")
            {
                SharedData.outputText = "0";
                OutputWindow.Text = SharedData.outputText;
                SharedData.startNewEx = true;
            }
        }
    }
}
