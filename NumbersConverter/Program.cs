using System;

namespace NumbersConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            MainProgram();

            void MainProgram()
            {
                input = ReadNumber.AskUser();
                try
                {
                    if (input[0] == '0' && input[1] != 'x' && input[1] != 'X' && input[1] != ',')   //if number is octal
                    {
                        OctalSystems octal = new OctalSystems(input);
                        octal.ShowingOctalResults();

                    }
                    else if (input[1] == 'x' || input[1] == 'X')  // if number is hexadecimal
                    {
                        HexadecimalSystems hexadecimal = new HexadecimalSystems(input);
                        hexadecimal.ShowingHexadecimalResults();
                    }
                    else                      // if number is decimal
                    {
                        DecimalSystems dec = new DecimalSystems(input);
                        Console.WriteLine("In decimal: " + input + "\n" + dec.DecimalToBinary() + "\n" + dec.DecimalToHexa() + "\n" + dec.DecimalToOctal());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + " Error try again");
                }
                LoopOfMainProgram();
            }

            void LoopOfMainProgram()
            {
                while (true)
                {
                    Console.WriteLine("Do you want to try another number? \n Type 'yes' or 'exit'");
                    string answer = Console.ReadLine();
                    if (answer == "exit") { Environment.Exit(0); break; }
                    else if (answer == "yes") { Console.Clear(); MainProgram(); break; }
                    else Console.WriteLine("Wrong answer");
                }

            }
        }
    }
}