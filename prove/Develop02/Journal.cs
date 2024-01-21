using System;
using System.Collections.Generic;

public class Journal
{
    public List<Entry> __entries;

    public Journal()
    {
        __entries = new List<Entry>();
    }

    public void AddEntry(Entry newEntry)
    {
        __entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in __entries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }

    public void SaveToFile(string file)
    {
        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(file))
        {
            foreach (Entry entry in __entries)
            {
                sw.WriteLine($"{entry.__dateText}|{entry.__promptText}|{entry.__entryText}");
            }
        }
    }

    public void LoadFromFile(string file)
    {
        __entries.Clear();
        try
        {
            using (System.IO.StreamReader sr = new System.IO.StreamReader(file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        __entries.Add(new Entry(parts[0], parts[1], parts[2]));
                    }
                }
            }
        }
        catch (System.IO.FileNotFoundException)
        {
            Console.WriteLine("File not found. Creating a new journal.");
        }
    }
}
