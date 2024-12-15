using System;
using DelegateClass;

namespace Delegate
{
    public class ArrayHandler
    {
        public delegate bool NumberPredicate(int number);

        public static int[] GetNumbers(int[] array, NumberPredicate predicate)
        {
            List<int> result = new List<int>();

            foreach (var number in array)
            {
                if (predicate(number))
                {
                    result.Add(number);
                }
            }

            return result.ToArray();
        }

        public static bool IsEven(int number) => number % 2 == 0;

        public static bool IsOdd(int number) => number % 2 != 0;

        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
        public static bool IsFibonacci(int number)
        {
            int a = 0;
            int b = 1;
            while (a < number)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a == number;
        }
    }
 

    internal class Program
    {
        static void Main()
        {
            try
            {
                int[] array = { 1, 7, 9, 3, 9, 8, 22, 18, 32, 52 };

                int[] evenNumbers = ArrayHandler.GetNumbers(array, ArrayHandler.IsEven); 
                int[] oddNumbers = ArrayHandler.GetNumbers(array, ArrayHandler.IsOdd); 
                int[] primeNumbers = ArrayHandler.GetNumbers(array, ArrayHandler.IsPrime); 
                int[] fibonacciNumbers = ArrayHandler.GetNumbers(array, ArrayHandler.IsFibonacci);

                Console.WriteLine("Even Numbers: " + string.Join(", ", evenNumbers));
                Console.WriteLine("Odd Numbers: " + string.Join(", ", oddNumbers));
                Console.WriteLine("Prime Numbers: " + string.Join(", ", primeNumbers));
                Console.WriteLine("Fibonacci Numbers: " + string.Join(", ", fibonacciNumbers));
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
Even Numbers: 8, 22, 18, 32, 52
Odd Numbers: 1, 7, 9, 3, 9
Prime Numbers: 7, 3
Fibonacci Numbers: 1, 3, 8
Program execution completed.

C:\Users\David\source\repos\ConsoleApp1\ConsoleApp1\bin\Debug\net8.0\ConsoleApp1.exe (process 18340) exited with code 0 (0x0).
Press any key to close this window . . .

*/