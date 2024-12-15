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

                Console.WriteLine("Math Operations:");
                var handler = new MathHandler('+', '-', '*');
                handler.Execute(num1, num2);

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
Add: 10 + 5 = 15
Subtract: 10 - 5 = 5
Multiply: 10 * 5 = 50

All methods executed successfully.
Program execution completed.

C:\Users\David\source\repos\ConsoleApp1\ConsoleApp1\bin\Debug\net8.0\ConsoleApp1.exe (process 10208) exited with code 0 (0x0).
Press any key to close this window . . .

 
*/
