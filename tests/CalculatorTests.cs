namespace CalculatorTests;

public class CalculatorTests
{
    private readonly Calculator _calculator = new Calculator(); // Create instance directly
    // For addition the opreation type is a
    private readonly string operationType = "a";

    [Fact]
    public void Test_EmptyInput_ReturnsZero()
    {
        // Arrange
        string input = string.Empty;
        // Act
        int result = _calculator.PerformOperation(input, operationType);
        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Test_SingleNumber_ReturnsSameNumber()
    {
        // Arrange
        string input = "20";
        // Act
        int result = _calculator.PerformOperation(input, operationType);
        // Assert
        Assert.Equal(20, result);
    }

    [Fact]
    public void Test_TwoNumbers_ReturnsSum()
    {
        // Arrange
        string input = "1,5000";
        // Act
        int result = _calculator.PerformOperation(input, operationType);
        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Test_MissingNumbers_ReturnsZero()
    {
        // Arrange
        string input = ",";
        // Act
        int result = _calculator.PerformOperation(input, operationType);
        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Test_InvalidNumbers_ReturnsSumIgnoringInvalidNumbers()
    {
        // Arrange
        string input = "5,tytyt";
        // Act
        int result = _calculator.PerformOperation(input, operationType);
        // Assert
        Assert.Equal(5, result);
    }

    [Fact]
    public void Test_RemoveMaximumConstraint_ReturnsSumOfAllNumbers()
    {
        // Arrange
        string input = "1,2,3,4,5,6,7,8,9,10,11,12";
        // Act
        int result = _calculator.PerformOperation(input, operationType);
        // Assert
        Assert.Equal(78, result);
    }

    [Fact]
    public void Test_NewlineDelimiter_ReturnsSum()
    {
        // Arrange
        string input = "1\n2,3";
        // Act
        int result = _calculator.PerformOperation(input, operationType);
        // Assert
        Assert.Equal(6, result);
    }

    [Fact]
    public void Test_SingleNegativeNumber_ThrowsException()
    {
        // Arrange
        string input = "4,-3";
        // Act
        var exception = Assert.Throws<ArgumentException>(() => _calculator.PerformOperation(input, operationType));
        // Assert
        Assert.Equal("Negative numbers not allowed: -3", exception.Message);
    }

    [Fact]
    public void Test_MultipleNegativeNumbers_ThrowsException()
    {
        // Arrange
        string input = "4,-3,-7";
        // Act
        var exception = Assert.Throws<ArgumentException>(() => _calculator.PerformOperation(input, operationType));
        // Assert
        Assert.Equal("Negative numbers not allowed: -3, -7", exception.Message);
    }

    [Fact]
    public void Test_ValuesGreaterThan1000_AreIgnored()
    {
        // Arrange
        string input = "2,1001,6";
        // Act
        int result = _calculator.PerformOperation(input, operationType);
        // Assert
        Assert.Equal(8, result);
    }

    [Fact]
    public void Test_SingleCharacterCustomDelimiter_ReturnsSum()
    {
        // Arrange
        string input = "//#\n2#5";
        // Act
        int result = _calculator.PerformOperation(input, operationType);
        // Assert
        Assert.Equal(7, result);
    }

    [Fact]
    public void Test_InvalidNumbersWithSingleCustomDelimiter_ReturnsSumIgnoringInvalidNumbers()
    {
        // Arrange
        string input = "//,\n2,ff,100";
        // Act
        int result = _calculator.PerformOperation(input, operationType);
        // Assert
        Assert.Equal(102, result);
    }

    [Fact]
    public void Test_MultiCharacterCustomDelimiter_ReturnsSum()
    {
        // Arrange
        string input = "//[***]\n11***22***33";
        // Act
        int result = _calculator.PerformOperation(input, operationType);
        // Assert
        Assert.Equal(66, result);
    }

    [Fact]
    public void Test_MultipleCustomDelimiters_ReturnsSum()
    {
        // Arrange
        string input = "//[*][!!][r9r]\n11r9r22*hh*33!!44";
        // Act
        int result = _calculator.PerformOperation(input, operationType);
        // Assert
        Assert.Equal(110, result);
    }

    [Fact]
    public void Test_SingleCustomDelimiterWithSpecialCharacter()
    {
        // Arrange
        string input = "//$\n4$5";
        // Act
        int result = _calculator.PerformOperation(input, operationType);
        // Assert
        Assert.Equal(9, result);
    }

    [Fact]
    public void Test_MultipleCustomDelimitersWithNoNumbers()
    {
        // Arrange
        string input = "//[*][!!]\n";
        // Act
        int result = _calculator.PerformOperation(input, operationType);
        // Assert
        Assert.Equal(0, result);
    }
    
}