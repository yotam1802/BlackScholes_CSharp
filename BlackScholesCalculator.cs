using BlackScholesCalculator;

namespace BlackScholesCalculator;

public class BlackScholesCalculator {
    public static double CalculateCallPrice(double S, double K, double T, double r, double sigma) {
        double d1 = (Math.Log(S/K) + (r + Math.Pow(sigma, 2) / 2) * T) / (sigma * Math.Sqrt(T));
        double d2 = d1 - (sigma * Math.Sqrt(T));
        return S * MathUtils.StandardNormalCDF(d1) - K * Math.Exp(-r * T) * MathUtils.StandardNormalCDF(d2);
    }
    
    public static double CalculatePutPrice(double S, double K, double T, double r, double sigma) {
        double d1 = (Math.Log(S/K) + (r + Math.Pow(sigma, 2) / 2) * T) / (sigma * Math.Sqrt(T));
        double d2 = d1 - (sigma * Math.Sqrt(T));
        return K * Math.Exp(-r * T) * MathUtils.StandardNormalCDF(-d2) - S * MathUtils.StandardNormalCDF(-d1);
    }
}