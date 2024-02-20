using System;

class Program
{
    static void Main(string[] args)
    {
        // Create activity objects
        var activities = new Activity[]
        {
            new Running(DateTime.Parse("2024-02-20"), 30, 3.0),
            new StationaryBicycle(DateTime.Parse("2024-02-20"), 45, 15.0),
            new Swimming(DateTime.Parse("2024-02-20"), 60, 20)
        };

        // Display summaries
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
