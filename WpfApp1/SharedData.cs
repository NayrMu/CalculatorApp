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
    public static double varA;
    public static double varB;
    public static double varX;
    public static double varY;
    public static Dictionary<string, double> varMap = new Dictionary<string, double>();

    string shellColor;
    string buttonColor;
    string buttonHoverColor;
    string screenColor;
    public SharedData()
	{
        outputText = "";
        historyText = "";
        startNewEx = false;
        varA = 0;
        varB = 0;
        varX = 0;
        varY = 0;

        varMap.Add("var a", varA);
        varMap.Add("var b", varB);
        varMap.Add("var x", varX);
        varMap.Add("var y", varY);
    }
	public void ClassicLook()
	{

	}
}
