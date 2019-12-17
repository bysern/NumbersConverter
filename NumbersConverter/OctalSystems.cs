using System;
using System.Collections.Generic;

namespace NumbersConverter
{
    class OctalSystems : INumberSystem
    {
        public double number { get; private set; }

        public OctalSystems(string userInput)
        {
            number = double.Parse(userInput);
        }

        public string octalToDecimal()
        {
            int num = (int)number;
            double decValue = 0;

            int baseToPowerNum = 1;     // initalising i.e 8^1 

            int temp = num;
            while (temp > 0)
            {
                int lastDigit = temp % 10;
                if (lastDigit > 8) throw new IndexOutOfRangeException();
                temp /= 10;

                // Multiplying last digit with base and saving it
                decValue += lastDigit * baseToPowerNum;

                baseToPowerNum *= 8;
            }
            string result = decValue.ToString();


            //double fractional = number - (double)num;
            double fractional = number - Math.Truncate(number);
            //double fractional = number % 1;

            if (fractional != 0) result += (',');

            // Conversion of fractional part
            int Limit = 5;       //limit of digits after point
            while (true && Limit > 0)
            {
                Limit--;
                fractional *= 8;
                int fractionalBit = (int)fractional;
                if (fractional == 0) break;
                else
                {
                    result += fractionalBit;
                    fractional -= fractionalBit;
                }
            }
            return result;

        }
        public void ShowResults()
        {
            Console.WriteLine("In octal: " + number);
            Console.WriteLine("In decimal: " + octalToDecimal());
            string Result = octalToDecimal();
            DecimalSystems dec = new DecimalSystems(Result);
            Console.WriteLine(dec.DecimalToBinary());
            Console.WriteLine(dec.DecimalToHexa());
        }
    }
}
