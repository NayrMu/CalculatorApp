using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Controls;
public class SharedData
{
    //holds shared variables
    public static string outputText = "0";
    public static string historyText;
    public static bool startNewEx;
    public static string varA;
    public static string varB;
    public static string varX;
    public static string varY;
    public static Dictionary<string, string> varMap = new Dictionary<string, string>();
    public static bool setMode = false;
    public string shellColor;
    public string buttonColor;
    public string buttonPressedColor;
    public string screenColor;
    public string screenTextColor;
    public string specialButtonColor;
    public string specialButtonPressedColor;
    public string varButtonColor;
    public string varButtonPressedColor;
    public string buttonTextColor;
    public string otherButtonTextColor;
    public string plateColor;
    public string plateBorderColor;
    public string buttonSelectColor;
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
        varMap.Add("e", "2.718282");
        varMap.Add("pi", "3.1415927");
    }
	public void OldSchoolLook()
	{
        shellColor = "#294542";
        buttonColor = "#404040";
        buttonPressedColor = "#141414";
        screenColor = "#2c704d";
        screenTextColor = "#10b05d";
        specialButtonColor = "#ba564e";
        specialButtonPressedColor = "#803630";
        varButtonColor = "#bfb25e";
        varButtonPressedColor = "#918837";
        buttonTextColor = "White";
        otherButtonTextColor = "White";
        plateColor = "#a6a59f";
        plateBorderColor = "Black";
        buttonSelectColor = "White";
    }
    public void ClassicLook()
    {
        shellColor = "White";
        buttonColor = "LightGray";
        buttonPressedColor = "Gray";
        screenColor = "PowderBlue";
        screenTextColor = "Black";
        specialButtonColor = "PowderBlue";
        specialButtonPressedColor = "#8ab0b5";
        varButtonColor = "PowderBlue";
        varButtonPressedColor = "#8ab0b5";
        buttonTextColor = "Black";
        otherButtonTextColor = "Black";
        plateColor = "White";
        plateBorderColor = "White";
        buttonSelectColor = "Blue";
    }
    public void DarkLook()
    {
        shellColor = "#424242";
        buttonColor = "#0f0f0f";
        buttonPressedColor = "#0a0a0a";
        screenColor = "#0f0f0f";
        screenTextColor = "White";
        specialButtonColor = "#424242";
        specialButtonPressedColor = "#2b2b2b";
        varButtonColor = "#424242";
        varButtonPressedColor = "#2b2b2b";
        buttonTextColor = "White";
        otherButtonTextColor = "Black";
        plateColor = "#292929";
        plateBorderColor = "Black";
        buttonSelectColor = "White";
    }
}
