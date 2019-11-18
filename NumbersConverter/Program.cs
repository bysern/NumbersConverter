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
            double Parsed = Convert.ToDouble(Input);

            Console.WriteLine("In Decimal: " + decimalToBinary(Parsed, 10));
            Console.WriteLine("In Binary: " + decimalToBinary(Parsed, 2));
            Console.WriteLine("In Octal: " + decimalToBinary(Parsed, 8));
            Console.WriteLine("In Hexadecimal: " + decimalToBinary(Parsed, 16));
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
            while (true && Limit > 0 )
            {
                Limit--;
                // Find next bit in fraction 
                fractional *= Base;
                int fract_bit = (int)fractional;

                if (fractional == 0) break;
                else
                {
                    binary += fract_bit;
                    fractional -= fract_bit; }
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
















        //static string decimaltobinary(double n, int k_prec) //note this uint
        //{
        //    if (n == 0) //special case
        //        return "0";

        //    string binary = string.empty;
        //    int integral = (int)n; // to get number before .
        //    double fractional = n - integral;
        //    while (integral > 0)
        //    {
        //        // get the lsb
        //        int remainder = integral % 2;


        //        //binary = binary + remainder; 

        //        integral /= 2;
        //        binary = remainder.tostring() + binary;
        //    }

        //    binary += ('.');

        //    while (k_prec-- > 0)
        //    {
        //        fractional *= 2;
        //        int fract_bit = (int)fractional;

        //        if (fract_bit == 1)
        //        {
        //            fractional -= fract_bit;
        //            binary = remainder.tostring() + binary;
        //        }
        //        else binary = remainder.tostring() + binary;
        //    }

        //    console.writeline("binary: " + binary);
        //    return binary;
        //}


        //other try
        //const int asciidiff = 48;
        //double num1 = 0, num2 = 0, result = 0;
        //double fact = 1;
        //int[] ihexanumeric = new int[] { 10, 11, 12, 13, 14, 15 };
        //char[] chexa = new char[] { 'a', 'b', 'c', 'd', 'e', 'f' };
        //string a = "";
        //char op;
        //bool b = false;
        //const int base10 = 10;

        //static string decimaltobase(int idec, int numbase)
        //{
        //    char[] chexa = new char[] { 'a', 'b', 'c', 'd', 'e', 'f' };
        //    string strbin = "";
        //    int[] result = new int[32];
        //    int maxbit = 32;
        //    for (; idec > 0; idec /= numbase)
        //    {
        //        int rem = idec % numbase;
        //        result[--maxbit] = rem;
        //    }
        //    for (int i = 0; i < result.length; i++)
        //        if ((int)result.getvalue(i) >= base10)
        //            strbin += chexa[(int)result.getvalue(i) % base10];
        //        else
        //            strbin += result.getvalue(i);
        //    strbin = strbin.trimstart(new char[] { '0' });
        //    console.writeline("in case 1: " + strbin);
        //    return strbin;
        //}

        //int basetodecimal(string sbase, int numbase)
        //{

        //    int dec = 0;
        //    int b;
        //    int iproduct = 1;
        //    string shexa = "";
        //    if (numbase > base10)
        //        for (int i = 0; i < chexa.length; i++)
        //            shexa += chexa.getvalue(i).tostring();
        //    for (int i = sbase.length - 1; i >= 0; i--, iproduct *= numbase)
        //    {
        //        string svalue = sbase[i].tostring();
        //        if (svalue.indexofany(chexa) >= 0)
        //            b = ihexanumeric[shexa.indexof(sbase[i])];
        //        else
        //            b = (int)sbase[i] - asciidiff;
        //        dec += (b * iproduct);
        //    }
        //    console.writeline("in case 1: " + dec);
        //    return dec;
        //}
        //string DecimalResult;


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
