public class OperationOptions
{
    public bool AllowNegativeValues { get; set; }
    public int MaxAllowedValue { get; set; }
    public string? CustomDelimiter { get; set; }

    public OperationOptions(bool allowNegativeValues = false, int? maxAllowedValue = null, string? customDelimiter = null)
    {
        AllowNegativeValues = allowNegativeValues;
        MaxAllowedValue = maxAllowedValue ?? 1000;
        CustomDelimiter = customDelimiter;
    }
}
