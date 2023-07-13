using System;
using System.CodeDom;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Documents;

public class Evaluate
{
	//Goes through the text and evlautates it

	string[] parsableText;
	string[] ConvertExpression(string output)
	{
		//System.Diagnostics.Debug.WriteLine(SharedData.outputText);
		string operators = @"([+/*/\/^/-])";
        string[] oldParsableText = Regex.Split(output, operators);
        if (oldParsableText[0] == "")
		{
			parsableText = new string[oldParsableText.Length - 1];
            Array.Copy(oldParsableText, 1, parsableText, 0, oldParsableText.Length - 1);
        }
		else
		{
			parsableText = oldParsableText;
		}
        return parsableText;
	}

	public void Eval()
	{
		SharedData.outputText = SharedData.historyText = EvaluateExpression(ConvertExpression(SharedData.outputText));
		SharedData.startNewEx = true;
	}
	string EvaluateExpression(string[] expression)
	{
		string result;
		int exLen = expression.Length;
		if (exLen == 1)
		{
			result = expression[0];
			return result;
		}
		else
		{
			string opType = "";
			int operatorIndex = -1;
			for (int i = 0; i < exLen - 1; i+=1)
			{
				if (PEMDAS(expression[i], opType) || opType == "")
				{
                    Negative(expression[i], i, ref expression);
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

            return EvaluateExpression(expression);
		}
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
		string[] opTypes = { "-", "+", "/", "*", "^" };
		if (Array.IndexOf(opTypes, op1) > Array.IndexOf(opTypes, op2))
		{
			return true;
		}
		else
		{
			return false;
		}

        return false;
		
    }
	void Negative(string opType, int opIndex, ref string[] arr)
	{
		if (opType == "-" && opIndex == 0)
		{
			string[] newArr = new string[arr.Length + 1];
			Array.Copy(arr, 0, newArr, 1, arr.Length);
			newArr[0] = "0";
            Array.Clear(arr);
			Array.Resize(ref arr, newArr.Length);
            arr = newArr;
        }
    }
	void trialNegative(string opType, int opIndex, ref string[] arr)
	{
		if (opType == "-")
		{
			double num = Convert.ToDouble(arr[opIndex + 1]);
			arr[opIndex + 1] = (num * -1).ToString();
			arr[opIndex] = "";
		}
	}

}
