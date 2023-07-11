using System;
using System.Linq;
using System.Windows.Controls;

public class TestClass
{
	string[] ops = {"+", "-",  "*", "/", "^"};
	public void doSomething(string buttonText, TextBlock outputLocation)
	{
		if (SharedData.startNewEx == false || Array.IndexOf(ops, buttonText) > -1)
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
