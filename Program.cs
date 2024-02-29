using AIContinuous;
using AIContinuous.Nuenv;
using AIContinuous.Rocket;

int numberOfPoints = 11;
var timeData = Space.Geometric(1.0, 501.0, numberOfPoints).Select(x => x - 1.0).ToArray();

double Simulate(double[] massFlowData)
{
    var rocket = new Rocket(
        750.0,
        Math.PI * Math.Pow(0.6, 2) / 4.0,
        1916.0,
        0.8,
        timeData,
        massFlowData
    );

    return rocket.LaunchUntilMax();
}

double Restriction(double[] x)
    => Integrate.Romberg(timeData, x) - 3500.0;

double FitnessDiffEvol(double[] x)
    => -Simulate(x);

double FitnessGD(double[] x)
{
    var minimize = -Simulate(x);
    var combTotal = Integrate.Romberg(timeData, x);
    double penalty = combTotal - 3500.0;

    return minimize + penalty;
}

var bounds = new List<double[]>(numberOfPoints);

for (int i = 0; i < numberOfPoints; i++)
    bounds.Add(new double[] { 0.0, 10 });

var diffEvol = new DiffEvolution(FitnessDiffEvol, bounds, 15 * numberOfPoints, Restriction);

var sol = diffEvol.Optimize(1000);

foreach (var s in sol)
    Console.WriteLine(s);

Console.WriteLine($"Altitude maxima: {Simulate(sol)}");
