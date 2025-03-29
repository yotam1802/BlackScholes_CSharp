using BlackScholesCalculator;
using System.Diagnostics;

namespace BlackScholesCalculator;

public class Program {
    public static void Main(string[] args) {
        // RunTests(); 

        Console.WriteLine("Enter current stock price (S):");
        double S = double.Parse(Console.ReadLine());
        
        Console.WriteLine("Enter strike price (K):");
        double K = double.Parse(Console.ReadLine());
        
        Console.WriteLine("Enter time to maturity in years (T):");
        double T = double.Parse(Console.ReadLine());
        
        Console.WriteLine("Enter risk-free interest rate (r):");
        double r = double.Parse(Console.ReadLine());
        
        Console.WriteLine("Enter volatility (sigma):");
        double sigma = double.Parse(Console.ReadLine());
        
        double callPrice = BlackScholesCalculator.CalculateCallPrice(S, K, T, r, sigma);
        double putPrice = BlackScholesCalculator.CalculatePutPrice(S, K, T, r, sigma);
        
        Console.WriteLine($"Call Price: {callPrice:F4}");
        Console.WriteLine($"Put Price:  {putPrice:F4}");
    }

    private static void AssertApproximatelyEqual(double actual, double expected) {
        Debug.Assert(Math.Abs(expected - actual) <= 1e-4, $"Expected {expected} but was {actual}");
    }
    
    private static void RunTests() {
        AssertApproximatelyEqual(MathUtils.StandardNormalCDF(-3.0), 0.0013);
        AssertApproximatelyEqual(MathUtils.StandardNormalCDF(-2.0), 0.0228);
        AssertApproximatelyEqual(MathUtils.StandardNormalCDF(-1.0), 0.1587);
        AssertApproximatelyEqual(MathUtils.StandardNormalCDF(0.0), 0.5000);
        AssertApproximatelyEqual(MathUtils.StandardNormalCDF(1.0), 0.8413);
        AssertApproximatelyEqual(MathUtils.StandardNormalCDF(2.0), 0.9772);
        AssertApproximatelyEqual(MathUtils.StandardNormalCDF(3.0), 0.9987);
    }
    
}