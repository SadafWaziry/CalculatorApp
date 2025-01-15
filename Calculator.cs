public class Calculator
{
    public static int CalculateSum(string inputString)
    {
        if (string.IsNullOrEmpty(inputString)) 
            return 0;

        // Split the input string into an array of numbers based on the comma delimiter
        var splitNumbers = inputString.Split(',');

        // Convert the string array to integers and sum them up
        return splitNumbers
            .Select(num => int.TryParse(num, out int parsedNumber) ? parsedNumber : 0)
            .Sum();
    }
}
