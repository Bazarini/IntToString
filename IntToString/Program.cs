using System;
using System.Collections.Generic;

namespace IntToString
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please enter the number: ");
                Console.WriteLine(NumberBuilder.BuildNumber(Console.ReadLine().Replace(" ", "").Replace('.', ',')));
            }
        }


    }
}
