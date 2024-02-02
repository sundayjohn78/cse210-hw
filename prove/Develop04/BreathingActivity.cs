using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public new void DisplayEndingMessage()
    {
        base.DisplayEndingMessage();
        Console.WriteLine("Breathe in....");
        ShowCountDown(_duration);
    }

    public void Run()
    {
        Console.WriteLine("Breathe in....");
        ShowCountDown(_duration);
        Console.WriteLine("Breathe out....");
        ShowCountDown(_duration);
    }
}
