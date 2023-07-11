using System;
using System.CodeDom;
using System.Linq;
using System.Text.RegularExpressions;
public class Evaluate
{
	//Goes through the text and evlautates it

	string[] parsableText;
	string[] ConvertExpression()
	{
		string operators = @"([+/*/\/^/-])";
		string[] parsableText = Regex.Split(SharedData.outputText, operators);
		foreach (string s in parsableText)
		{
			System.Diagnostics.Debug.WriteLine(s);
		}
        return parsableText;
	}

	public void Eval()
	{
		SharedData.outputText = EvaluateExpression(ConvertExpression());
		SharedData.startNewEx = true;
	}
	string EvaluateExpression(string[] expression)
	{
		string result;
		int exLen = expression.Length;
		if (exLen == 1)
		{
			result = expression[0];
			System.Diagnostics.Debug.WriteLine(result);
		}
		else
		{
			string opType = null;
			int operatorIndex = -1;
			for (int i = 1; i < exLen - 1; i+=2)
			{
				if (PEMDAS(expression[i], opType) || opType == null)
				{
					opType = expression[i];
					operatorIndex = i;
				}
			}

			double prevNum = Convert.ToDouble(expression[operatorIndex - 1]);
			double nextNum = Convert.ToDouble(expression[operatorIndex + 1]);
			result = Convert.ToString(performOperation(prevNum, opType, nextNum));

			expression[operatorIndex-1] = result;
			expression[operatorIndex] = "";
			expression[operatorIndex + 1] = "";

			expression = expression.Where(n => n != "").ToArray();

			EvaluateExpression(expression);
		}
		return result;
	}
	double performOperation(double a, string op, double b)
    {
		switch(op)
		{
			case "+":
				return a + b;
				break;
			case "-":
				return a - b;
				break;
			case "*":
				return a * b;
				break;
			case "/":
				return a / b;
				break;
			case "^":
				return Math.Pow(a, b);
				break;
		}
		return 0;
    }
    bool PEMDAS(string op1, string op2)
    {
		string[] opTypes = { "^", "*", "/", "+", "-" };
		if (Array.IndexOf(opTypes, op1) < Array.IndexOf(opTypes, op2))
		{
			return true;
		}
		else
		{
			return false;
		}

        return false;
    }

}
