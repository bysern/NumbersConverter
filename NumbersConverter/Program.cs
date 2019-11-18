using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type a number");
            string Input = Console.ReadLine();
            double Parsed = 0;
            try
            {
                Parsed = Convert.ToDouble(Input);
            }
            catch (Exception e) { Console.WriteLine("Wrong input \n" + e.Message); }


            Console.WriteLine("In Decimal: " + decimalToBinary(Parsed, 10));
            Console.WriteLine("In Binary: " + decimalToBinary(Parsed, 2));
            Console.WriteLine("In Octal: " + decimalToBinary(Parsed, 8));
            Console.WriteLine("In Hexadecimal: " + decimalToHexa(Parsed));
        }


        static string decimalToBinary(double num, int Base)
        {
            string binary = string.Empty;

            // Integral part of decimal number 
            int Integral = (int)num;

            // Fractional part of decimal number 
            double fractional = num - Integral;

            //decimal to binary before point conversio
            while (Integral > 0)
            {
                int rem = Integral % Base;

                //if (rem == 11) rem = 'B';
                // Append 0 in binary 
                binary += (char)(rem + '0');
                //binary = rem.ToString() + binary;

                Integral /= Base;
            }

            // Reverse string to get correct binary result
            binary = Reverse(binary);

            // Point before fractional 
            binary += ('.');

            // Conversion of fractional part to binary
            int Limit = 7;       //limit of digits after point
            while (true && Limit > 0)
            {
                Limit--;
                // Find next bit in fraction 
                fractional *= Base;
                int fract_bit = (int)fractional;
                if (fractional == 0) break;
                else
                {
                    binary += fract_bit;
                    fractional -= fract_bit;
                }
            }
            return binary;
        }


        static string decimalToHexa(double num)
        {
            string binary = string.Empty;

            // Integral part of decimal number 
            int Integral = (int)num;

            // Fractional part of decimal number 
            double fractional = num - Integral;

            binary += string.Format("{0:x}", Integral); //decimal to hex convertion integral part

            // Point before fractional 
            binary += ('.');

            // Conversion of fractional part to hex
            int Limit = 7;       //limit of digits after point
            while (true && Limit > 0)
            {
                Limit--;
                fractional *= 16;
                int fract_bit = (int)fractional;
                if (fractional == 0) break;
                else
                {
                    binary += string.Format("{0:x}", fract_bit);
                    fractional -= fract_bit;
                }
            }
            return binary;
        }
        
                                 
        static string Reverse(string input)
        {
            char[] temparray = input.ToCharArray();
            int left, right = 0;
            right = temparray.Length - 1;

            for (left = 0; left < right; left++, right--)
            {
                // Swap values of left and right  
                char temp = temparray[left];
                temparray[left] = temparray[right];
                temparray[right] = temp;
            }
            return string.Join("", temparray);
        }
                                            


        //DecimalResult = Convert.ToString(Convert.ToInt32(NumberInput, 10), 10);
        //Console.WriteLine("In decimal: " + DecimalResult);

        //string BinaryResult = Convert.ToString(Convert.ToInt64(NumberInput, 10), 2);
        //Console.WriteLine("In binary: " + BinaryResult);

        //string octal = Convert.ToString(Convert.ToInt32(NumberInput, 10), 8);
        //Console.WriteLine("In Octal: " + octal);

        //string hexadecimal = Convert.ToString(Convert.ToInt32(NumberInput, 10), 16);
        //Console.WriteLine("In Hexadecimal: " + hexadecimal);
    }

}
