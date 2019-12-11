using System;

namespace NumbersConverter
{
    public class ReadNumber
    {
        public static string AskUser()
        {
            Console.WriteLine("Input Number");
            string input = Console.ReadLine();

            return input;
        }
    }
}
