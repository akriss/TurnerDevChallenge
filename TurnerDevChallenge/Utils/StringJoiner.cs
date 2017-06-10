using System;

namespace TurnerDevChallenge.Utils
{
    public class StringJoiner
    {
        private string Delimiter { get; set; }

        public string JoinedString { get; set; }

        public StringJoiner(string delimiter)
        {
            Delimiter = delimiter;
            JoinedString = "";
        }

        public void Join(string addedString)
        {
            if (JoinedString.Length == 0)
            {
                JoinedString = addedString;
            }
            else
            {
                JoinedString += Delimiter + addedString;
            }
        }
    }
}
