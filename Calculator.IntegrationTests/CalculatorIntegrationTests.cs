namespace Calculator.IntegrationTests;

/// <summary>
/// Integration tests for Calculator operations
/// These tests validate end-to-end behavior and cross-operation scenarios
/// </summary>
public class CalculatorIntegrationTests
{
    [Fact]
    public void ComplexCalculation_MultipleOperations_ReturnsCorrectResult()
    {
        // Arrange: Simulate (10 + 5) * 2 / 3
        int a = 10, b = 5, c = 2, d = 3;

        // Act: Chain multiple operations
        int sum = CalculatorOperations.Add(a, b);        // 15
        int product = CalculatorOperations.Multiply(sum, c);  // 30
        double result = CalculatorOperations.Divide(product, d);  // 10

        // Assert
        Assert.Equal(10.0, result);
    }

    [Fact]
    public void CircleAreaAndSquareRoot_Integration_ReturnsExpectedValues()
    {
        // Arrange
        double radius = 4.0;

        // Act: Calculate area and then square root of area
        double area = CalculatorOperations.CalculateCircleArea(radius);
        double sqrtOfArea = CalculatorOperations.SquareRoot(area);

        // Assert
        Assert.InRange(area, 50.0, 51.0); // Pi * 16 ≈ 50.26
        Assert.InRange(sqrtOfArea, 7.0, 7.1); // sqrt(50.26) ≈ 7.09
    }

    [Fact]
    public void PowerAndSquareRoot_InverseOperations_ReturnsOriginalValue()
    {
        // Arrange
        double baseNumber = 5.0;
        double exponent = 2.0;

        // Act: Power then square root (inverse operations)
        double powered = CalculatorOperations.Power(baseNumber, exponent);
        double result = CalculatorOperations.SquareRoot(powered);

        // Assert: Should return original value
        Assert.Equal(baseNumber, result, precision: 10);
    }

    [Theory]
    [InlineData(100, 20, 5)]
    [InlineData(50, 10, 5)]
    [InlineData(1000, 100, 10)]
    public void SubtractAndDivide_MultipleScenarios_ReturnsCorrectResults(int num1, int num2, int expected)
    {
        // Act: Subtract then divide
        int difference = CalculatorOperations.Subtract(num1, num2);
        double result = CalculatorOperations.Divide(difference, num2);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void NestedCalculations_WithCircleArea_HandlesComplexScenario()
    {
        // Arrange: Calculate area of circle, then use it in other operations
        double radius = 3.0;

        // Act
        double area = CalculatorOperations.CalculateCircleArea(radius);
        int roundedArea = (int)Math.Round(area);
        int result = CalculatorOperations.Add(roundedArea, 10);

        // Assert
        // Area ≈ 28.27, rounded = 28, + 10 = 38
        Assert.InRange(result, 37, 39);
    }

    [Fact]
    public void ErrorHandling_DivideByZero_ThrowsException()
    {
        // Arrange
        int numerator = 10;
        int divisor = 0;

        // Act & Assert
        Assert.Throws<DivideByZeroException>(() =>
            CalculatorOperations.Divide(numerator, divisor));
    }

    [Fact]
    public void ErrorHandling_NegativeRadius_ThrowsArgumentException()
    {
        // Arrange
        double negativeRadius = -5.0;

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() =>
            CalculatorOperations.CalculateCircleArea(negativeRadius));
        
        Assert.Contains("Radius cannot be negative", exception.Message);
    }

    [Fact]
    public void ErrorHandling_NegativeSquareRoot_ThrowsArgumentException()
    {
        // Arrange
        double negativeNumber = -16.0;

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() =>
            CalculatorOperations.SquareRoot(negativeNumber));
        
        Assert.Contains("Cannot calculate square root of negative number", exception.Message);
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 1, 2)]
    [InlineData(-5, 5, 0)]
    [InlineData(-10, -5, -15)]
    public void EdgeCases_Addition_HandlesVariousInputs(int a, int b, int expected)
    {
        // Act
        int result = CalculatorOperations.Add(a, b);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void LargeNumbers_Operations_HandlesCorrectly()
    {
        // Arrange
        int largeNum1 = int.MaxValue - 1000;
        int largeNum2 = 500;

        // Act
        int difference = CalculatorOperations.Subtract(largeNum1, largeNum2);
        
        // Assert
        Assert.Equal(largeNum1 - largeNum2, difference);
    }

    [Fact]
    public void Multiply_ZeroScenarios_ReturnsZero()
    {
        // Arrange & Act
        int result1 = CalculatorOperations.Multiply(0, 100);
        int result2 = CalculatorOperations.Multiply(100, 0);
        int result3 = CalculatorOperations.Multiply(0, 0);

        // Assert
        Assert.Equal(0, result1);
        Assert.Equal(0, result2);
        Assert.Equal(0, result3);
    }

    [Fact]
    public void SquareRoot_PerfectSquares_ReturnsExactValues()
    {
        // Arrange & Act
        double sqrt4 = CalculatorOperations.SquareRoot(4);
        double sqrt9 = CalculatorOperations.SquareRoot(9);
        double sqrt16 = CalculatorOperations.SquareRoot(16);
        double sqrt25 = CalculatorOperations.SquareRoot(25);

        // Assert
        Assert.Equal(2.0, sqrt4);
        Assert.Equal(3.0, sqrt9);
        Assert.Equal(4.0, sqrt16);
        Assert.Equal(5.0, sqrt25);
    }

    [Fact]
    public void CircleArea_SmallAndLargeRadius_CalculatesCorrectly()
    {
        // Arrange
        double smallRadius = 0.5;
        double largeRadius = 100.0;

        // Act
        double smallArea = CalculatorOperations.CalculateCircleArea(smallRadius);
        double largeArea = CalculatorOperations.CalculateCircleArea(largeRadius);

        // Assert
        Assert.InRange(smallArea, 0.78, 0.79); // Pi * 0.25 ≈ 0.785
        Assert.InRange(largeArea, 31415, 31416); // Pi * 10000 ≈ 31415.93
    }

    [Theory]
    [InlineData(2, 0, 1)]
    [InlineData(2, 1, 2)]
    [InlineData(2, 8, 256)]
    [InlineData(5, 3, 125)]
    [InlineData(10, 2, 100)]
    public void Power_VariousExponents_ReturnsCorrectValues(double baseNum, double exp, double expected)
    {
        // Act
        double result = CalculatorOperations.Power(baseNum, exp);

        // Assert
        Assert.Equal(expected, result);
    }
}
