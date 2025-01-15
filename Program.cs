class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter numbers (use a custom single-character delimiter if starting with '//', e.g., //#\\n1#2):");
        string input = Console.ReadLine() ?? string.Empty;

        try
        {
            int result = Calculator.CalculateSum(input);
            Console.WriteLine($"Result: {result}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
