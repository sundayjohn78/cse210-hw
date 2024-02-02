using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _items;

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        _items = new List<string>();
    }

    public new void DisplayEndingMessage()
    {
        base.DisplayEndingMessage();
        Console.WriteLine("Listing your items...");
        Run();
        Console.WriteLine($"Number of items listed: {_items.Count}");
    }

    public void Run()
    {
        foreach (var prompt in _prompts)
        {
            Console.WriteLine(prompt);
            Console.WriteLine($"Think about this for {_duration} seconds...");
            ShowSpinner(_duration);
            Console.Write("Enter item: ");
            var item = Console.ReadLine();
            _items.Add(item);
        }
    }
}
