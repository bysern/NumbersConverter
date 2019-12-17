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
                    INumberSystem numberSystem;
                    if (input[0] == '0' && input[1] != 'x' && input[1] != 'X' && input[1] != ',')   //if number is octal
                    {
                        numberSystem = new OctalSystems(input);
                    }
                    else if (input[1] == 'x' || input[1] == 'X')  // if number is hexadecimal
                    {
                        numberSystem = new HexadecimalSystems(input);
                    }
                    else // if number is decimal
                    {
                        numberSystem = new DecimalSystems(input);
                    }
                    numberSystem.ShowResults();
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