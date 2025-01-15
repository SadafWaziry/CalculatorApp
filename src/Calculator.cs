using System.Text.RegularExpressions;

public class Calculator
{
    public static int CalculateSum(string inputString, OperationOptions? options = null)
    {
        if (string.IsNullOrEmpty(inputString)) 
            return 0;
        
        // Replace any escaped "\n" sequence with actual newlines to handle user input
        inputString = inputString.Replace(@"\n", Environment.NewLine);

        List<string> delimiters = [",", options?.CustomDelimiter ?? "\n"];

        // Regular expression to match:
        // 1. //{delimiter}\n{numbers} (single character delimiter)
        // 2. //[{delimiter}]\n{numbers} (multi-character delimiter)
        // 3. //[{delimiter1}][{delimiter2}]...\n{numbers} (multiple delimiters)
        var regex = new Regex(@"^//(\[.*\]|\S)\n(.*)$");

        Match match = regex.Match(inputString);
        if (match.Success)
        {
            // Extract the custom delimiters
            string delimiterPart = match.Groups[1].Value;
            string numbersPart = match.Groups[2].Value;

            // Handle multiple delimiters
            if (delimiterPart.StartsWith('[') && delimiterPart.EndsWith(']'))
            {
                var customDelimiters = delimiterPart.Trim('[', ']').Split("][", StringSplitOptions.RemoveEmptyEntries);
                delimiters.AddRange(customDelimiters);
            }
            else
            {
                // Single delimiter case
                delimiters.Add(delimiterPart);
                numbersPart = inputString[(match.Groups[1].Length + 3)..]; // Skip the `//{delimiter}\n` part
            }

            inputString = numbersPart; // Extract the numbers part
        }

        // Split the input string based on both commas and newlines
        var splitNumbers = inputString.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

        // Convert the string array to integers
        int maximumValue = options?.MaxAllowedValue ?? 1000;

        var parsedNumbers = splitNumbers
                            .Select(num => int.TryParse(num, out int parsedNumber) ? parsedNumber : 0)
                            .Where(num => num <=  maximumValue);
        
        var negatives = parsedNumbers.Where(n => n < 0).ToList();

        if (negatives.Count > 0 && !(options?.AllowNegativeValues ?? false))
            throw new ArgumentException($"Negative numbers not allowed: {string.Join(", ", negatives)}");

        var formula = string.Join(" + ", parsedNumbers);
        int result = parsedNumbers.Sum();

        Console.WriteLine($"{formula} = {result}");

        return result; 
    }
}
