using System;
using System.CodeDom;
using System.Linq;
using System.Printing;
using System.Text.RegularExpressions;
using System.Windows.Documents;

public class Evaluate
{
	//Goes through the text and evlautates it

	string[] parsableText;
	string[] ConvertExpression(string output)
	{
		//System.Diagnostics.Debug.WriteLine(SharedData.outputText);
		string operators = @"([+/*/\/^/√/-]|ln)";
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
			for (int i = 0; i < exLen; i++)
			{
				if (PEMDAS(expression[i], opType, expression) || opType == "")
				{
                    Negative(expression[i], i, ref expression);
                    opType = expression[i];
					operatorIndex = i;
					foreach (string j in expression)
					{
						System.Diagnostics.Debug.WriteLine(j);
						//System.Diagnostics.Debug.WriteLine("");

                    }
					System.Diagnostics.Debug.WriteLine("here " + opType + " " + operatorIndex);
                }
			}
			System.Diagnostics.Debug.WriteLine(opType + "huh" +  operatorIndex);
			double prevNum = 0;
			if (operatorIndex > 0 && (double.TryParse(expression[operatorIndex - 1], out prevNum)));
			double nextNum = Convert.ToDouble(expression[operatorIndex + 1]);
			result = Convert.ToString(performOperation(prevNum, opType, nextNum));

			if (operatorIndex > 0) expression[operatorIndex-1] = "";
			expression[operatorIndex] = result;
			expression[operatorIndex + 1] = "";

			expression = expression.Where(n => n != "").ToArray();
			//System.Diagnostics.Debug.WriteLine(expression.Length);
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
			case "√":

                System.Diagnostics.Debug.WriteLine("here"+Math.Pow(b, 0.5));
                return Math.Pow(b, 0.5);
				break;
			case "ln":
				return Math.Log(b);
				break;
		}
		return 0;
    }
	bool PEMDAS(string op1, string op2, string[] arr)
	{
		// true if op1 has higher priority
		string[] opTypes1 = { "^", "√", "ln" };
		string[] opTypes2 = { "/", "*" };
		string[] opTypes3 = { "-", "+" };
		int op1OGIndex = Array.IndexOf(arr, op1);
		int op2OGIndex = Array.IndexOf(arr, op2);
		if (opTypes1.Contains(op1) || opTypes2.Contains(op1) || opTypes3.Contains(op1))
		{
			if (!opTypes1.Contains(op2) && !opTypes2.Contains(op2) && !opTypes3.Contains(op2))
			{
				return true;
			}
			if (opTypes1.Contains(op1))
			{
				if (opTypes1.Contains(op2))
				{
					if (op1OGIndex < op2OGIndex)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					return true;
				}
			}
			else if (opTypes2.Contains(op1))
			{
				if (opTypes2.Contains(op2) || !opTypes1.Contains(op2))
				{
					if (op1OGIndex < op2OGIndex)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					return false;
				}
			}
			else if (opTypes3.Contains(op1))
			{
				if ((opTypes3.Contains(op2) || !opTypes1.Contains(op2)) || !opTypes2.Contains(op2))
				{
					if (op1OGIndex < op2OGIndex)
					{
						return true;
					}
				}
				else
				{
					return false;
				}
			}
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
