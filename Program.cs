using AIContinuous.Nuenv;
using AIContinuous.Rocket;

var timeData = Space.Linear(0.0, 100.0, 11);
var massFlowData = Space.Uniform(35.0, 11);

var rocket = new Rocket(
    750.0,
    Math.PI * Math.Pow(0.6, 2) / 4.0,
    1916.0,
    0.8,
    timeData,
    massFlowData
);

Console.WriteLine(rocket.LaunchUntilMax());
