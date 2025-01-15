class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter numbers (use custom delimiters of any length if starting with //[delimiter]\\n, e.g., //[***]\\n1***2):");
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
