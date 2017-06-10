using System;
using System.Globalization;

namespace TurnerDevChallenge.Utils
{
    public static class TitleCaseWriter
    {
        public static string ToTitleCase(string stringIn)
        {
            if(String.IsNullOrWhiteSpace(stringIn))
            {
                return stringIn;
            }

            var splitString = stringIn.Split(' ');

            var joiner = new StringJoiner(" ");
            foreach (var substring in splitString)
            {
                joiner.Join(TitleCaseSubstring(substring));
            }

            return joiner.JoinedString;
        }

        private static string TitleCaseSubstring(string stringIn)
        {
            if(String.IsNullOrEmpty(stringIn))
            {
                return "";
            }

            string firstChar = stringIn[0] + "";
            string trailingString = stringIn.Substring(1, stringIn.Length-1);

            TextInfo textInfo = new CultureInfo("en-US").TextInfo;

            return textInfo.ToUpper(firstChar) + textInfo.ToLower(trailingString);
        }
    }
}
