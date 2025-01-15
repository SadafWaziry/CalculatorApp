class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter numbers (separated by commas or newlines; Negative numbers are not allowed):");
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
