public interface ICalculator
{
    int PerformOperation(string input, string operationType, OperationOptions? options = null);
}
