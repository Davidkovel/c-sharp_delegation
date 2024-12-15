using System;
using DelegateClass;

namespace Delegate
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                double num1 = 10;
                double num2 = 5;
                const int number = 10;

                Console.WriteLine("Math Operations:");
                var handler = new MathHandler('+', '-', '*');
                handler.Execute(num1, num2);

                Console.WriteLine("\nCheck numbers");
                NumberHandler numberHandler = new NumberHandler();

                numberHandler.ExecuteAllChecks(number);

                Console.WriteLine("\nAll methods executed successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
            finally
            {

                Console.WriteLine("Program execution completed.");
            }
        }
    }
}


/*
Math Operations:
Addition: 10 + 5 = 15
Subtract: 10 - 5 = 5
Multiply: 10 * 5 = 50

Check numbers
Result of checks for 10:
  1. Even: True
  2. Odd: False
  3. Prime: False
  4. Fibonacci: False

All methods executed successfully.
Program execution completed.

C:\Users\David\source\repos\ConsoleApp1\ConsoleApp1\bin\Debug\net8.0\ConsoleApp1.exe (process 15316) exited with code 0 (0x0).
Press any key to close this window . . .

*/