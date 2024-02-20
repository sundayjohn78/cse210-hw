using System;

public class Activity
{
    protected DateTime Date { get; set; }
    protected int DurationMinutes { get; set; }

    public Activity(DateTime date, int durationMinutes)
    {
        Date = date;
        DurationMinutes = durationMinutes;
    }

    public virtual double GetDistance()
    {
        // Base class implementation (no specific distance calculation)
        return 0;
    }

    public virtual double GetSpeed()
    {
        // Base class implementation (no specific speed calculation)
        return 0;
    }

    public virtual double GetPace()
    {
        // Base class implementation (no specific pace calculation)
        return 0;
    }

    public virtual string GetSummary()
    {
        return $"{Date.ToShortDateString()} - Duration: {DurationMinutes} min";
    }
}
