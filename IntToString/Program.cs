using System;
using System.Collections.Generic;
using System.Globalization;

namespace IntToString
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                decimal inputAmount;
                CultureInfo culture = (CultureInfo)CultureInfo.GetCultureInfo("EN-us").Clone();
                bool isConversionSuccessful;
                do
                {
                    Console.WriteLine("Please enter the number: ");
                    string numberTemp = Console.ReadLine();
                    if (!(isConversionSuccessful = decimal.TryParse(numberTemp, NumberStyles.Currency, culture, out inputAmount)))
                    {
                        Console.WriteLine($"{numberTemp} is not of a proper float value");
                        continue;
                    }
                    if (inputAmount > (ulong)RankStrings.billion)
                    {
                        Console.WriteLine($"Max Value is {(ulong)RankStrings.billion}");
                        isConversionSuccessful = false;
                    }
                }
                while (!isConversionSuccessful);
                Console.WriteLine(NumberBuilder.BuildNumber(inputAmount));
            }
        }


    }
}
