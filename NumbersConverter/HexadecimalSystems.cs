using System;
using System.Linq;

namespace NumbersConverter
{
    class HexadecimalSystems
    {
        public string userInput { get; set; }

        public HexadecimalSystems(string newUserInput)
        {
            this.userInput = newUserInput;
        }

        public int HexToDec()
        {
            char sep = ',';
            int result = 0;

            int count = userInput.Length - 1;
            for (int i = 0; i < userInput.Length; i++)
            {
                int temp = 0;
                switch (userInput[i])
                {
                    case 'x': break;
                    case 'A': temp = 10; break;
                    case 'B': temp = 11; break;
                    case 'C': temp = 12; break;
                    case 'D': temp = 13; break;
                    case 'E': temp = 14; break;
                    case 'F': temp = 15; break;
                    default: temp = -48 + (int)userInput[i]; break; // -48 because of ASCII
                }

                result += temp * (int)(Math.Pow(16, count));
                count--;
            }

            if (userInput.Contains(sep))
            {
                Console.WriteLine("separator");
                char[] separators = { ',' };
                string secondword = userInput.Split(separators, 2)[1];

                result.ToString();
                result += '.';
                result += Convert.ToInt32(secondword, 16);
            }
            return result;
        }

        //char[] separators = { ',' };
        //string fractionalPart = myString.Split(separators, 2)[1];

        public void ShowingHexadecimalResults()
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
