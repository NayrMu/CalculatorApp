using System;
using System.Linq;
using System.Windows.Controls;

public class ButtonClass
{
	string[] ops = {"+", "-",  "*", "÷", "^"};
	public void doSomething(string buttonText, TextBlock outputLocation)
	{
        if (ops.Contains(buttonText))
        {
            if (SharedData.outputText.Length < 16)
            {
                if (SharedData.startNewEx == false || Array.IndexOf(ops, buttonText) > -1) //starting new expression or t
                {
                    SharedData.outputText += buttonText;
                    SharedData.startNewEx = false;
                }
                else
                {
                    SharedData.outputText = buttonText;
                    SharedData.startNewEx = false;
                }
                outputLocation.Text = SharedData.outputText;
            }
        }
        else if (SharedData.outputText.Length < 17)
        {
            if (SharedData.startNewEx == false || Array.IndexOf(ops, buttonText) > -1) //starting new expression or t
            {
                SharedData.outputText += buttonText;
                SharedData.startNewEx = false;
            }
            else
            {
                SharedData.outputText = buttonText;
                SharedData.startNewEx = false;
            }
            outputLocation.Text = SharedData.outputText;
        }
    }
}
