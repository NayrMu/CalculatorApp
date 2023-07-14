using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Controls;
public class SharedData
{
    //holds shared variables
    public static string outputText;
    public static string historyText;
    public static bool startNewEx;
    public static string varA;
    public static string varB;
    public static string varX;
    public static string varY;
    public static Dictionary<string, string> varMap = new Dictionary<string, string>();
    public static bool setMode = false;
    string shellColor;
    string buttonColor;
    string buttonHoverColor;
    string screenColor;
    static SharedData()
	{
        outputText = "";
        historyText = "";
        startNewEx = true;
        varA = "0";
        varB = "0";
        varX = "0";
        varY = "0";

        varMap.Add("var a", varA);
        varMap.Add("var b", varB);
        varMap.Add("var x", varX);
        varMap.Add("var y", varY);
        varMap.Add("e", "2.718281828459");
        varMap.Add("pi", "3.1415926535897932");
    }
	public void ClassicLook()
	{

	}
}
