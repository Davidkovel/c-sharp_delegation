namespace DelegateClass;

public class MathHandler
{

    public delegate void MathDelegate(double a, double b);

    private MathDelegate? MakeAction { get; set; }

    public MathHandler(params char[] operations)
    {
        MakeAction = null;
        foreach (char c in operations)
        {
            switch (c)
            {
                case '+':
                    if (MakeAction == null)
                    {
                        MakeAction = Add;
                    }
                    else
                    {
                        MakeAction += Add;
                    }
                    break;
                case '-':
                    if (MakeAction == null)
                    {
                        MakeAction = Subtract;
                    }
                    else
                    {
                        MakeAction += Subtract;
                    }
                    break;
                case '*':
                    if (MakeAction == null)
                    {
                        MakeAction = Multiply;
                    }
                    else
                    {
                        MakeAction += Multiply;
                    }
                    break;
                default:
                    throw new ArgumentException($"Unsupported operation: {c}");
            }
        }
    }

    public static void Add(double a, double b) => Console.WriteLine($"Addition: {a} + {b} = {a + b}");
    public static void Subtract(double a, double b) => Console.WriteLine($"Subtract: {a} - {b} = {a - b}");
    public static void Multiply(double a, double b) => Console.WriteLine($"Multiply: {a} * {b} = {a * b}");

    public void Execute(double a, double b)
    {
        MakeAction.Invoke(a, b); // -- same syntax MakeAction(a, b);

    }
}




public class NumberHandler
{
    public Predicate<int> CheckEven = IsEven;
    public Predicate<int> CheckOdd = IsOdd;
    public Predicate<int> CheckPrime = IsPrime;
    public Predicate<int> CheckFibonacci = IsFibonacci;

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

    public void ExecuteAllChecks(int number)
    {
        bool isEven = CheckEven(number);
        bool isOdd = CheckOdd(number);
        bool isPrime = CheckPrime(number);
        bool isFibonacci = CheckFibonacci(number);

        Console.WriteLine($"Result of checks for {number}:");
        Console.WriteLine($"  1. Even: {isEven}");
        Console.WriteLine($"  2. Odd: {isOdd}");
        Console.WriteLine($"  3. Prime: {isPrime}");
        Console.WriteLine($"  4. Fibonacci: {isFibonacci}");
    }
}