using System;

public class StationaryBicycle : Activity
{
    private double Speed { get; set; }

    public StationaryBicycle(DateTime date, int durationMinutes, double speed) : base(date, durationMinutes)
    {
        Speed = speed;
    }

    public override double GetSpeed()
    {
        return Speed;
    }

    public override double GetPace()
    {
        return 60 / Speed; // Pace in minutes per mile
    }

    public override string GetSummary()
    {
        return base.GetSummary() + $" - Stationary Bicycle: Speed {Speed:F2} mph, Pace: {GetPace():F2} min/mile";
    }
}
