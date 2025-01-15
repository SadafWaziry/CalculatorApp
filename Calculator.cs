public class Calculator
{
    public static int CalculateSum(string inputString)
    {
        if (string.IsNullOrWhiteSpace(inputString)) 
            return 0;

        // Split the input string into an array of numbers based on the comma delimiter
        var splitNumbers = inputString.Split(',');

        // Ensure only two numbers are provided; throw an exception otherwise
        if (splitNumbers.Length > 2)
            throw new ArgumentException("Input must contain at most two numbers.");

        // Convert the string array to integers and sum them up
        return splitNumbers
            .Select(num => int.TryParse(num, out int parsedNumber) ? parsedNumber : 0)
            .Sum();
    }
}
