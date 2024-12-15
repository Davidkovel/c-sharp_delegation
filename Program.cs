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
Message: Hello, World!
Uppercase Message: HELLO, WORLD!
Lowercase Message: hello, world!
All methods executed successfully.
Program execution completed.

C:\Users\David\source\repos\ConsoleApp1\ConsoleApp1\bin\Debug\net8.0\ConsoleApp1.exe (process 4816) exited with code 0 (0x0).
Press any key to close this window . . .

 
*/