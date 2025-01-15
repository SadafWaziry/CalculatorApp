# Calculator App with Tests

This project contains a simple calculator application that supports multiple operations, custom delimiters, and additional features. It also includes unit tests to verify the application's functionality. The project uses Dependency Injection (DI) for flexibility, and you can easily extend the calculator to add more operations.

## Prerequisites

Before running the application and tests, make sure you have the following installed:

- [.NET SDK 6.0 or later](https://dotnet.microsoft.com/download)
- A code editor like [Visual Studio](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/).
- [xUnit](https://xunit.net/) (for testing) if using xUnit. Other testing frameworks like MSTest can be used too.

## Setting Up the Calculator App

### Clone the Repository

    git clone https://github.com/sadafwaziry/CalculatorApp.git
    cd CalculatorApp/src

### Restore Dependencies
Ensure you have the required dependencies by running:

    dotnet restore

### Build the Project
Build the CalculatorApp project:

    dotnet build

This will compile the CalculatorApp project and make it ready to run.

### Running the Calculator App
To run the application, simply use:

    dotnet run

This will start the console application and prompt you to enter numbers and choose various options (e.g., allow negative numbers, specify custom delimiters, etc.). The app performs calculations based on your inputs.

Example interaction:

    Allow negative numbers? (y/n): n
    Custom delimiter (default \n): ?
    Maximum number (default 1000): 5000
    Please input your numbers: 
    1,2,5
    Select Operation: 
    a) Add   s) Subtract     m) Multiply     d) Divide
    a
    1 + 2 + 5 = 8
    Please input your numbers: 
    1?6,-2
    Select Operation: 
    a) Add   s) Subtract     m) Multiply     d) Divide
    a
    Error: Negative numbers not allowed: -2

### Setting Up the Test Project
    cd CalculatorApp/tests
    dotnet test

## License

This project is licensed under the MIT License.

Developed By Sadaf Waziry




