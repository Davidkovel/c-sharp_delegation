using System;
using DelegateClass;

namespace Delegate
{

    public static class DisplayMethods
    {
        public static void ShowCurrentTime() => Console.WriteLine($"Current Time: {DateTime.Now.ToLongTimeString()}");

        public static void ShowCurrentDate() => Console.WriteLine($"Current Date: {DateTime.Now.ToShortDateString()}");

        public static void ShowCurrentDayOfWeek() => Console.WriteLine($"Current Day of the Week: {DateTime.Now.DayOfWeek}");

        public static double CalculateTriangleArea(double baseLength, double height) => 0.5 * baseLength * height;

        public static double CalculateRectangleArea(double length, double width) => length * width;
    }

    internal class Program
    {
        static void Main()
        {
            try
            {
                Action showTime = DisplayMethods.ShowCurrentTime;
                Action showDate = DisplayMethods.ShowCurrentDate;
                Action showDayOfWeek = DisplayMethods.ShowCurrentDayOfWeek;

                InvokeAction(showTime);
                InvokeAction(showDate);
                InvokeAction(showDayOfWeek);

                Func<double, double, double> calculateTriangleArea = DisplayMethods.CalculateTriangleArea;
                Func<double, double, double> calculateRectangleArea = DisplayMethods.CalculateRectangleArea;

                double triangleBase = 10, triangleHeight = 5;
                double rectangleLength = 8, rectangleWidth = 4;

                double triangleArea = InvokeFunc(calculateTriangleArea, triangleBase, triangleHeight);
                double rectangleArea = InvokeFunc(calculateRectangleArea, rectangleLength, rectangleWidth);

                Console.WriteLine($"Triangle Area: {triangleArea}");
                Console.WriteLine($"Rectangle Area: {rectangleArea}");

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

        private static void InvokeAction(Action action) 
        { 
            action.Invoke(); 
        }
        private static TResult InvokeFunc<T1, T2, TResult>(Func<T1, T2, TResult> func, T1 arg1, T2 arg2) 
        { 
            return func.Invoke(arg1, arg2); 
        }
    }
}

/*
Current Time: 15:11:31
Current Date: 15.12.2024
Current Day of the Week: Sunday
Triangle Area: 25
Rectangle Area: 32
Program execution completed.

C:\Users\David\source\repos\ConsoleApp1\ConsoleApp1\bin\Debug\net8.0\ConsoleApp1.exe (process 15576) exited with code 0 (0x0).
Press any key to close this window . . .


*/