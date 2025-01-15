using System.Text.RegularExpressions;

public class Calculator
{
    public static int CalculateSum(string inputString)
    {
        if (string.IsNullOrEmpty(inputString)) 
            return 0;
        
        // Replace any escaped "\n" sequence with actual newlines to handle user input
        inputString = inputString.Replace(@"\n", Environment.NewLine);

        string[] delimiters = [",", "\n"];

        // Regular expression to match both formats:
        // 1. //{delimiter}\n{numbers} (single character delimiter)
        // 2. //[{delimiter}]\n{numbers} (multi-character delimiter)
        var regex = new Regex(@"^//(\[.*\]|\S)\n(.*)$");

        Match match = regex.Match(inputString);
        if (match.Success)
        {
            // Extract the custom delimiter
            string customDelimiter = match.Groups[1].Value.Trim('[', ']');
            delimiters = [customDelimiter];
            inputString = match.Groups[2].Value; // Extract the numbers part
        }

        // Split the input string based on both commas and newlines
        var splitNumbers = inputString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

        // Convert the string array to integers
        var parsedNumbers = splitNumbers
                            .Select(num => int.TryParse(num, out int parsedNumber) ? parsedNumber : 0)
                            .Where(num => num <= 1000);
        
        var negatives = parsedNumbers.Where(n => n < 0).ToList();
        if (negatives.Count > 0)
            throw new ArgumentException($"Negative numbers not allowed: {string.Join(", ", negatives)}");

        return parsedNumbers.Sum(); 
    }
}
