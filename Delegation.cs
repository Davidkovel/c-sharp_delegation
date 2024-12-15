namespace DelegateClass;

public class MathHandler
{

    public delegate void MathDelegate(double a, double b);

    private MathDelegate _operations;

    public MathHandler(params char[] args)
    {
        foreach (char c in args)
        {
            switch (c)
            {
                case '+':
                    _operations += (a, b) => Console.WriteLine($"Add: {a} + {b} = {a + b}");
                    break;
                case '-':
                    _operations += (a, b) => Console.WriteLine($"Subtract: {a} - {b} = {a - b}");
                    break;
                case '*':
                    _operations += (a, b) => Console.WriteLine($"Multiply: {a} * {b} = {a * b}");
                    break;
                default:
                    throw new ArgumentException($"Unsupported operation: {c}");
            }
        }
    }

    public static double Add(double a, double b) => a + b;
    public static double Subtract(double a, double b) => a - b;
    public static double Multiply(double a, double b) => a * b;

    public void Execute(double a, double b)
    {
        _operations.Invoke(a, b);
    }
}
