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
