public class InputProcessor
{
    public OperationOptions ProcessInput()
    {
        Console.Write("Allow negative numbers? (y/n): ");
        bool allowNegativeValues = Console.ReadLine()?.Trim().ToLower() == "y";

        Console.Write("Custom delimiter (default \\n): ");
        string? delimeterInput = Console.ReadLine()?.Trim();
        string? customDelimiter = string.IsNullOrWhiteSpace(delimeterInput) ? null : delimeterInput;

        Console.Write("Maximum number (default 1000): ");
        string? maxAllowedInput = Console.ReadLine()?.Trim();
        int? maxAllowedValue = string.IsNullOrEmpty(maxAllowedInput) || !int.TryParse(maxAllowedInput, out var value) ? (int?)null : value;

        return new OperationOptions(allowNegativeValues, maxAllowedValue, customDelimiter);
    }

    public string GetOperationType()
    {
        Console.WriteLine("Select Operation: ");
        Console.WriteLine("a) Add \t s) Subtract \t m) Multiply \t d) Divide");
        return Console.ReadLine()?.Trim().ToLower() ?? "add";
    }

    public string GetInput()
    {
        Console.WriteLine("Please input your numbers: ");
        return Console.ReadLine() ?? string.Empty;
    }
}
