class Program
{
    static void Main(string[] args)
    {
        Console.Write("Allow negative numbers? (y/n): ");
        bool allowNegativeValues = Console.ReadLine()?.Trim().ToLower() == "y";

        Console.Write("Custom delimiter (default \\n): ");
        string? delimeterInput = Console.ReadLine()?.Trim();
        string? customDelimiter = string.IsNullOrWhiteSpace(delimeterInput) ? null : delimeterInput;

        Console.Write("Maximum number (default 1000): ");
        string? maxAllowedInput = Console.ReadLine()?.Trim();
        int? maxAllowedValue = string.IsNullOrEmpty(maxAllowedInput) || !int.TryParse(maxAllowedInput, out var value) ? (int?)null : value;

        try
        {
            var operationOptions = new OperationOptions(
                allowNegativeValues,
                maxAllowedValue,
                customDelimiter
            );

            Console.CancelKeyPress += (sender, eventArgs) =>
            {
                Console.WriteLine("\nCtrl+C detected. Exiting...");
                Environment.Exit(0); // Exit the application immediately
            };

            Console.WriteLine("Please input your numbers: ");
                
            while (true)
            {
                string input = Console.ReadLine() ?? string.Empty;

                try
                {
                    Calculator.CalculateSum(input, operationOptions);
                 }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
