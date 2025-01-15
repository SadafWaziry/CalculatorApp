using Microsoft.Extensions.DependencyInjection;

// Set up DI container
var serviceProvider = new ServiceCollection()
    .AddSingleton<ICalculator, Calculator>()
    .AddSingleton<InputProcessor>()
    .BuildServiceProvider();

var calculationService = serviceProvider.GetService<ICalculator>();
var inputProcessor = serviceProvider.GetService<InputProcessor>();

// Initialize operation options
var operationOptions = inputProcessor!.ProcessInput();

Console.CancelKeyPress += (sender, eventArgs) =>
{
    Console.WriteLine("\nCtrl+C detected. Exiting...");
    Environment.Exit(0);
};

while (true)
{
    string input = inputProcessor.GetInput();
    string operationType = inputProcessor.GetOperationType();

    try
    {
        calculationService!.PerformOperation(input, operationType, operationOptions);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

