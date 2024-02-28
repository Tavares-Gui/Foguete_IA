namespace AIContinuous.Nuenv;

public static class Integrate
{
    public static double Romberg(double[]x, double[] y)
    {
        var size = x.Length - 1;
        double sum = 0.0;

        if (x.Length != y.Length)
            throw new ArgumentException("X and Y must have the same lenght");
        
        for (int i = 0; i < size; i++)
            sum += 0.5 * (x[i + 1] - x[i]) * (y[i + 1] - y[i]);

        return sum;
    }
}
