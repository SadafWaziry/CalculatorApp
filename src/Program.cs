class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter numbers (use multiple custom delimiters if starting with //[del1][del2]\\n, e.g., //[***][%%]\\n1***2%%3):");
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
