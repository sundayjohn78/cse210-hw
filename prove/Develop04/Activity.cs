using System;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity()
    {
        // Default constructor
    }

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"{_name}: {_description}");
        Console.Write("Enter Duration (in seconds): ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine($"Prepare to begin... ({_duration} seconds pause)");
        ShowCountDown(_duration);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Good job!");
        Console.WriteLine($"Activity: {_name}, Duration: {_duration} seconds");
        Console.WriteLine($"{_duration} seconds pause before finishing...");
        ShowCountDown(_duration);
    }

    public void ShowCountDown(int seconds)
    {
        Console.Write("Counting down: ");
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public void ShowSpinner(int seconds)
    {
        Console.Write("Spinning: ");
        List<string> animationStrings = new List<string> { "^", ">", "~", "<" };

        for (int i = 0; i < seconds; i++)
        {
            foreach (var symbol in animationStrings)
            {
                Console.Write(symbol + " ");
                Thread.Sleep(250); // Adjust the delay as needed
                Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
            }
        }

        Console.WriteLine();
    }
}
