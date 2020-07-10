using System;

namespace IntToString
{
    public static class NumberBuilder
    {
        public static string BuildNumber(decimal input)
        {
            string output = GetByRank((ulong)input, RankStrings.billion);

            if (output != "") output += $" dollar{((ulong)input != 1 ? "s" : "")}";
            
            if (input % 1 != 0)
            {
                if (output != "")
                    output += " ";
                output += GetDozens((ulong)Math.Round(input % 1 * (ulong)RankStrings.hundred)) + $" cent{((ulong)Math.Round(input % 1 * (ulong)RankStrings.hundred) != 1 ? "s" : "")}";
            }
            return output.Trim();
        }
        private static string GetDozens(ulong number)
        {
            if (Enum.IsDefined(typeof(Numbers), number))
                return ((Numbers)number).ToString();
            string output = ((DozenPart)(number / 10)).ToString() + "ty";
            if (number % 10 != 0)
                output += "-" + ((Numbers)(number % 10)).ToString();
            return output;
        }
        private static string GetHundred(ulong number)
        {
            string output = "";
            if (number / 100 != 0)
            {
                if (Enum.IsDefined(typeof(Numbers), number / 100))
                    output += $" {((Numbers)(number / 100)).ToString()} hundred";
            }
            if (number % 100 != 0)
            {
                output += $" {GetDozens(number % 100)}";
            }
            return output;
        }
       
        private static string GetByRank(ulong number, RankStrings rank)
        {
            string output = "";
            if (number / (ulong)rank != 0)
                output += $"{GetHundred(number / (ulong)rank)} {rank.ToString()}";


            if (rank != RankStrings.thousand)
                output += GetByRank(number % (ulong)rank, (RankStrings)((ulong)rank / 1000));
            else output += GetHundred(number % 1000);
            return output;
        }
    }
}
