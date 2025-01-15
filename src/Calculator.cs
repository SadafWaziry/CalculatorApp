using System.Text.RegularExpressions;

public class Calculator : ICalculator
{
    public int PerformOperation(string input, string operationType, OperationOptions? options = null)
    {
        if (string.IsNullOrEmpty(input)) return 0;
        
        var parsedNumbers = ParseNumbersFromInput(input);

        var negatives = parsedNumbers.Where(n => n < 0).ToList();

        if (negatives.Count > 0 && !(options?.AllowNegativeValues ?? false))
            throw new ArgumentException($"Negative numbers not allowed: {string.Join(", ", negatives)}");

        string formula = string.Empty;
        int result = 0;

        switch (operationType.ToLower())
        {
            case "a":
                formula = string.Join(" + ", parsedNumbers);
                result = parsedNumbers.Sum();
                break;

            case "s":
                formula = string.Join(" - ", parsedNumbers);
                result = parsedNumbers.Aggregate((x, y) => x - y);
                break;

            case "m":
                formula = string.Join(" * ", parsedNumbers);
                result = parsedNumbers.Aggregate((x, y) => x * y);
                break;

            case "d":
                formula = string.Join(" / ", parsedNumbers);
                result = parsedNumbers.Aggregate((x, y) => y == 0 ? throw new DivideByZeroException() : x / y);
                break;

            default:
                throw new ArgumentException("Invalid operation specified.");
        }

        Console.WriteLine($"{formula} = {result}");
        return result;
    }

    private static IEnumerable<int> ParseNumbersFromInput(string input, OperationOptions? options = null) 
    {
        input = input.Replace(@"\n", Environment.NewLine);

        List<string> delimiters = [",", options?.CustomDelimiter ?? "\n"];

        var regex = new Regex(@"^//(\[.*\]|\S)\n(.*)$");

        Match match = regex.Match(input);
        if (match.Success)
        {
            string delimiterPart = match.Groups[1].Value;
            string numbersPart = match.Groups[2].Value;

            if (delimiterPart.StartsWith('[') && delimiterPart.EndsWith(']'))
            {
                var customDelimiters = delimiterPart.Trim('[', ']').Split("][", StringSplitOptions.RemoveEmptyEntries);
                delimiters.AddRange(customDelimiters);
            }
            else
            {
                delimiters.Add(delimiterPart);
                numbersPart = input[(match.Groups[1].Length + 3)..]; 
            }

            input = numbersPart;
        }

        var splitNumbers = input.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

        int maximumValue = options?.MaxAllowedValue ?? 1000;

        var parsedNumbers = splitNumbers
                            .Select(num => int.TryParse(num, out int parsedNumber) ? parsedNumber : 0)
                            .Where(num => num <=  maximumValue);

        return parsedNumbers;
    }
}
