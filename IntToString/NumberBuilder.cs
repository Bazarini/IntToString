using System;

namespace IntToString
{
    public static class NumberBuilder
    {
        public static string BuildNumber(string input)
        {
            string output = GetByRank((uint)float.Parse(input), RankStrings.billion);
            if (output != "") output += " dollar";
            if (float.Parse(input) % 1 != 0)
            {
                if (output != "")
                    output += " ";
                output += GetDozens( (uint)Math.Round(float.Parse(input) % 1 * (uint)RankStrings.hundred)) + " cents";
            }
            return output;
        }
        private static string GetDozens(uint number)
        {
            if (Enum.IsDefined(typeof(Numbers), number))
                return ((Numbers)number).ToString();
            string output = ((DozenPart)(number / 10)).ToString() + "ty";
            if (number % 10 != 0)
                output += "-" + ((Numbers)(number % 10)).ToString();
            return output;
        }
        private static string GetHundred(uint number)
        {
            string output = "";
            if (number / 100 != 0)
            {
                if (Enum.IsDefined(typeof(Numbers), number / 100))
                    output += ((Numbers)(number / 100)).ToString() + " hundred ";
            }
            if (number % 100 != 0)
                output += GetDozens(number % 100);
            return output;
        }
       
        private static string GetByRank(uint number, RankStrings rank)
        {
            string output = "";
            if (number / (uint)rank != 0)
                output += GetHundred(number / (uint)rank) + $" {rank.ToString()} ";


            if (rank != RankStrings.thousand)
                output += GetByRank(number % (uint)rank, (RankStrings)((uint)rank / 1000));
            else output += GetHundred(number % 1000);
            return output;
        }
    }
}
