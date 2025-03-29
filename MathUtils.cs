using System;

namespace BlackScholesCalculator;

public static class MathUtils {
    private static double Erf(double x) {
        // Define constants 
        const double a1 = 0.254829592;
        const double a2 = -0.284496736;
        const double a3 = 1.421413741;
        const double a4 = -1.453152027;
        const double a5 = 1.061405429;
        const double p = 0.3275911;
        
        int sign = x < 0 ? -1 : 1;  // Get the sign of x
        x = Math.Abs(x);
        
        double t = 1.0 / (1.0 + p * x);
        double y = 1 - ((((a5 * t + a4) * t + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);

        return sign * y;
    }
    
    public static double StandardNormalCDF(double x) {
        return 0.5 * (1 + Erf(x / Math.Sqrt(2)));
    }
}