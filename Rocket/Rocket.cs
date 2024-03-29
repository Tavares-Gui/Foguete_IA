using AIContinuous.Nuenv;

namespace AIContinuous.Rocket;

public class Rocket
{
    public double Ve { get; set; }
    public double Cd0 { get; set; }
    public double Mass { get; set; }
    public double Time { get; set; }
    public double Height { get; set; }
    public double DryMass { get; set; }
    public double Velocity { get; set; }
    public double[] TimeData { get; set; }
    public double[] MassFlowData { get; set; }
    public double CrossSectionArea { get; set; }

    public Rocket(
        double dryMass, double crossSectionArea, 
        double ve, double cd0, 
        double[] timeData , double[] massFlowData
    )
    {
        Ve = ve;
        Cd0 = cd0;
        DryMass = dryMass;
        CrossSectionArea = crossSectionArea;
        TimeData = (double[])timeData.Clone();
        MassFlowData = (double[])massFlowData.Clone();

        Time = 0.0;
        Height = 0.0;
        Velocity = 0.0;
        Mass = DryMass + Integrate.Romberg(TimeData, MassFlowData);
    }

    public double CalculateMassFlow(double t)
        => t > TimeData[^1] ? 0.0 : Interp1D.Linear(TimeData, MassFlowData, t);

    public static double CalculateWeight(double h, double m)
        => Gravity.GetGravity(h) * (-m);

    public double CalculateDrag(double v, double h)
    {
        var rho = Atmosphere.Density(h); 
        var temperature = Atmosphere.Temperature(h);
        var cd = Drag.Coefficient(v, temperature, Cd0);

        return -0.5 * cd * rho * CrossSectionArea * Math.Pow(v, 2) * Math.Sign(v);
    }

    public double CalculateThrust(double t)
        => t > TimeData[^1] ? 0.0 : CalculateMassFlow(t) * Ve;

    public double MomentumEq(double t)
    {
        var thrust = CalculateThrust(t);
        var drag = CalculateDrag(Velocity, Height);
        var weight = CalculateWeight(Height, Mass);

        return (thrust + drag + weight) / Mass;
    }

    public void UpdateVelocity(double t, double dt)  
        => Velocity += MomentumEq(t) * dt;

    public void UpdateHeight(double dt)
        => Height += Velocity * dt;

    public void UpdateMass(double t, double dt)
        => Mass -= dt * (CalculateMassFlow(t) + CalculateMassFlow(t + dt)) * 0.5;

    public void FlyALittleBit(double dt)
    {
        UpdateVelocity(Time, dt);
        UpdateHeight(dt);
        UpdateMass(Time, dt);

        Time += dt;
    }

    public double Launch(double time, double dt = 1e-1)
    {
        for (double t = 0.0; t < time; t += dt)
            FlyALittleBit(dt);
    
        return Height;
    }

    public double LaunchUntilMax(double dt = 1e-1)
    {
        do FlyALittleBit(dt);
        while (Velocity > 0.0);

        return Height;
    }

    public double LaunchUntilGround(double dt = 1e-1)
    {
        do {Console.WriteLine("."); FlyALittleBit(dt); }
        while (Height > 0.0);

        return Height;
    }
}