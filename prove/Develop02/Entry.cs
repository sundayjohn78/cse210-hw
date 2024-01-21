using System;

public class Entry
{
    public string __dateText;
    public string __promptText;
    public string __entryText;

    public Entry(string dateText, string promptText, string entryText)
    {
        __dateText = dateText;
        __promptText = promptText;
        __entryText = entryText;
    }

    public void Display()
    {
        Console.WriteLine($"{__dateText}");
        Console.WriteLine($"{__promptText}");
        Console.WriteLine($"{__entryText}");
    }
}
