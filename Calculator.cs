public class Calculator
{
    public static int CalculateSum(string inputString)
    {
        if (string.IsNullOrEmpty(inputString)) 
            return 0;
        
        // Replace any escaped "\n" sequence with actual newlines to handle user input
        inputString = inputString.Replace(@"\n", Environment.NewLine);

        var delimiters = new[] { ',', '\n' };

        // Split the input string based on both commas and newlines
        var splitNumbers = inputString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

        // Convert the string array to integers
        var parsedNumbers = splitNumbers.Select(num => int.TryParse(num, out int parsedNumber) ? parsedNumber : 0);
        
        var negatives = parsedNumbers.Where(n => n < 0).ToList();
        if (negatives.Count > 0)
            throw new ArgumentException($"Negative numbers not allowed: {string.Join(", ", negatives)}");

        return parsedNumbers.Sum(); 
    }
}
