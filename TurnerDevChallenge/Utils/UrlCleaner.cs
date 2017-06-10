using System;

namespace TurnerDevChallenge.Utils
{
    public static class UrlCleaner
    {
        public static string CleanUrl(string uriIn)
        {
            if (String.IsNullOrWhiteSpace(uriIn))
            {
                return uriIn;
            }

            var splitString = uriIn.Split('/');

            var joiner = new StringJoiner("/");
            foreach (var substring in splitString)
            {
                if (substring != "api")
                {
                    joiner.Join(substring);
                }
            }

            return joiner.JoinedString;
        }
    }
}