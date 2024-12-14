namespace DelegateClass;

public class MessageHandler
{

    public delegate void MessageDelegate(string message);

    public static void ShowMessage(string message)
    {
        Console.WriteLine($"Message: {message}");
    }

    public static void ShowUpperMessage(string message)
    {
        Console.WriteLine($"Uppercase Message: {message.ToUpper()}");
    }

    public static void ShowLowerMessage(string message)
    {
        Console.WriteLine($"Lowercase Message: {message.ToLower()}");
    }
}
