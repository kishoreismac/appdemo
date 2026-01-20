// Simple Calculator Program
Console.WriteLine("=== Simple Calculator ===\n");

int num1 = 10;
int num2 = 5;
Console.WriteLine($"Addition: {num1} + {num2} = {CalculatorOperations.Add(num1, num2)}");
Console.WriteLine($"Subtraction: {num1} - {num2} = {CalculatorOperations.Subtract(num1, num2)}");
Console.WriteLine($"Multiplication: {num1} * {num2} = {CalculatorOperations.Multiply(num1, num2)}");
Console.WriteLine($"Division: {num1} / {num2} = {CalculatorOperations.Divide(num1, num2)}");

double radius = 5.0;
Console.WriteLine($"\nArea of circle with radius {radius}: {CalculatorOperations.CalculateCircleArea(radius):F2}");

double number = 16;
Console.WriteLine($"Square root of {number}: {CalculatorOperations.SquareRoot(number)}");

double baseNum = 2;
double exp = 3;
Console.WriteLine($"\nPower (Demo Feature): {baseNum}^{exp} = {CalculatorOperations.Power(baseNum, exp)}");


public static class CalculatorOperations
{
    public static int Add(int a, int b) => a + b;
    
    public static int Subtract(int a, int b) => a - b;
    
    public static int Multiply(int a, int b) => a * b;
    
    public static double Divide(int a, int b)
    {
        if (b == 0)
            throw new DivideByZeroException("Cannot divide by zero");
        return (double)a / b;
    }
    
    public static double CalculateCircleArea(double radius)
    {
        if (radius < 0)
            throw new ArgumentException("Radius cannot be negative", nameof(radius));
        return Math.PI * Math.Pow(radius, 2);
    }
    
    public static double SquareRoot(double number)
    {
        if (number < 0)
            throw new ArgumentException("Cannot calculate square root of negative number", nameof(number));
        return Math.Sqrt(number);
    }
    
    public static double Power(double baseNumber, double exponent)
    {
        return Math.Pow(baseNumber, exponent);
    }
}
