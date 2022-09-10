using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;



public class CLR_func
{
    public static string LetterUP(string str)
    {
        TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
        return ti.ToTitleCase(str);
    }

    public static bool Check_phone(string str)
    {
        string pattern = @"^\d{11}$";
        return Regex.IsMatch(str, pattern);
    }
}



