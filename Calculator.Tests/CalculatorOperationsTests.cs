namespace Calculator.Tests;

public class CalculatorOperationsTests
{
    [Fact]
    public void Add_TwoNumbers_ReturnsCorrectSum()
    {
        // Arrange
        int a = 10;
        int b = 5;

        // Act
        int result = CalculatorOperations.Add(a, b);

        // Assert
        Assert.Equal(15, result);
    }

    [Fact]
    public void Subtract_TwoNumbers_ReturnsCorrectDifference()
    {
        // Arrange
        int a = 10;
        int b = 5;

        // Act
        int result = CalculatorOperations.Subtract(a, b);

        // Assert
        Assert.Equal(5, result);
    }

    [Fact]
    public void Multiply_TwoNumbers_ReturnsCorrectProduct()
    {
        // Arrange
        int a = 10;
        int b = 5;

        // Act
        int result = CalculatorOperations.Multiply(a, b);

        // Assert
        Assert.Equal(50, result);
    }

    [Fact]
    public void Divide_TwoNumbers_ReturnsCorrectQuotient()
    {
        // Arrange
        int a = 10;
        int b = 5;

        // Act
        double result = CalculatorOperations.Divide(a, b);

        // Assert
        Assert.Equal(2.0, result);
    }

    [Fact]
    public void Divide_ByZero_ThrowsDivideByZeroException()
    {
        // Arrange
        int a = 10;
        int b = 0;

        // Act & Assert
        Assert.Throws<DivideByZeroException>(() => CalculatorOperations.Divide(a, b));
    }

    [Fact]
    public void CalculateCircleArea_PositiveRadius_ReturnsCorrectArea()
    {
        // Arrange
        double radius = 5.0;
        double expectedArea = Math.PI * 25;

        // Act
        double result = CalculatorOperations.CalculateCircleArea(radius);

        // Assert
        Assert.Equal(expectedArea, result, 5); // 5 decimal places precision
    }

    [Fact]
    public void CalculateCircleArea_NegativeRadius_ThrowsArgumentException()
    {
        // Arrange
        double radius = -5.0;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => CalculatorOperations.CalculateCircleArea(radius));
    }

    [Fact]
    public void SquareRoot_PositiveNumber_ReturnsCorrectRoot()
    {
        // Arrange
        double number = 16;

        // Act
        double result = CalculatorOperations.SquareRoot(number);

        // Assert
        Assert.Equal(4.0, result);
    }

    [Fact]
    public void SquareRoot_NegativeNumber_ThrowsArgumentException()
    {
        // Arrange
        double number = -16;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => CalculatorOperations.SquareRoot(number));
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 1, 2)]
    [InlineData(-5, 5, 0)]
    [InlineData(-10, -5, -15)]
    public void Add_VariousInputs_ReturnsCorrectSum(int a, int b, int expected)
    {
        // Act
        int result = CalculatorOperations.Add(a, b);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(10, 2, 5.0)]
    [InlineData(20, 4, 5.0)]
    [InlineData(-10, 2, -5.0)]
    public void Divide_VariousInputs_ReturnsCorrectQuotient(int a, int b, double expected)
    {
        // Act
        double result = CalculatorOperations.Divide(a, b);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Power_PositiveExponent_ReturnsCorrectResult()
    {
        // Arrange
        double baseNumber = 2;
        double exponent = 3;

        // Act
        double result = CalculatorOperations.Power(baseNumber, exponent);

        // Assert
        Assert.Equal(8.0, result);
    }

    [Fact]
    public void Power_ZeroExponent_ReturnsOne()
    {
        // Arrange
        double baseNumber = 5;
        double exponent = 0;

        // Act
        double result = CalculatorOperations.Power(baseNumber, exponent);

        // Assert
        Assert.Equal(1.0, result);
    }

    [Theory]
    [InlineData(2, 3, 8.0)]
    [InlineData(5, 2, 25.0)]
    [InlineData(10, 0, 1.0)]
    [InlineData(3, -1, 0.333333)]
    public void Power_VariousInputs_ReturnsCorrectResult(double baseNumber, double exponent, double expected)
    {
        // Act
        double result = CalculatorOperations.Power(baseNumber, exponent);

        // Assert
        Assert.Equal(expected, result, 5); // 5 decimal places precision
    }
}
