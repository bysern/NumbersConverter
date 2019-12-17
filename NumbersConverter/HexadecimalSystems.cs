using System;
using System.Linq;

namespace NumbersConverter
{
    class HexadecimalSystems : INumberSystem
    {
        public string userInput { get; set; }

        public HexadecimalSystems(string newUserInput)
        {
            this.userInput = newUserInput;
        }

        public double HexToDec()
        {
            double result = 0;
            string FractionalPart = string.Empty;
            string IntegralPart;

            if (userInput.Contains(','))
            {
                string[] SplittedNumber = userInput.Split(',');

                IntegralPart = SplittedNumber[0];
                FractionalPart = SplittedNumber[1];
            }
            else IntegralPart = userInput;

            int count = IntegralPart.Length - 1;
            for (int i = 0; i < IntegralPart.Length; i++)
            {
                int temp = 0;
                switch (IntegralPart[i])
                {
                    case 'x': break;
                    case 'A': temp = 10; break;
                    case 'B': temp = 11; break;
                    case 'C': temp = 12; break;
                    case 'D': temp = 13; break;
                    case 'E': temp = 14; break;
                    case 'F': temp = 15; break;
                    default: temp = -48 + (int)IntegralPart[i]; break; // -48 because of ASCII
                }

                result += temp * (int)(Math.Pow(16, count));
                count--;
            }

            if (FractionalPart != string.Empty)
            {
                string tempResult = result.ToString();
                tempResult += '.';
                for (int i = 0; i < 16; ++i)
                {
                    double FractionalValue = result - Math.Truncate(result);
                    FractionalValue = FractionalValue * 16;
                    int digit = (int)FractionalValue;

                    tempResult += digit.ToString("X");

                    FractionalValue = FractionalValue - digit;

                    if (FractionalValue == 0)
                    {
                        break;
                    }

                    tempResult = result.ToString();
                }
            }

            return result;
        }

        public void ShowResults()
        {
            Console.WriteLine("In hexadecimal: " + userInput);
            Console.WriteLine("In decimal: " + HexToDec());
            double result = HexToDec();
            DecimalSystems decimalSystems = new DecimalSystems(result.ToString());
            Console.WriteLine(decimalSystems.DecimalToBinary());
            Console.WriteLine(decimalSystems.DecimalToOctal());
        }
    }
}
