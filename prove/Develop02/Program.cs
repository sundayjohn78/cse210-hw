using System;

class Program
{
    static void Main(string[] args)
    {
        int userInput = -1;
        Journal journal = new Journal();

        while (userInput != 5)
        {
            DateTime theCurrentTime = DateTime.Now;
            string dateText = theCurrentTime.ToShortDateString();
            PromptGenerator aPromptGenerator = new PromptGenerator();
            string promptText = aPromptGenerator.GetRandomPrompt();

            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write\n2. Display\n3. Load\n4. Save\n5. Quit");
            Console.Write("What would you like to do? ");
            userInput = int.Parse(Console.ReadLine());

            if (userInput == 1)
            {
                Console.WriteLine($"{promptText}");
                Console.Write("");
                string entryText = Console.ReadLine();
                Entry anEntry = new Entry(dateText, promptText, entryText);
                journal.AddEntry(anEntry);
            }
            else if (userInput == 2)
            {
                journal.DisplayAll();
            }
            else if (userInput == 3)
            {
                Console.Write("Enter a filename to load the journal: ");
                string loadFilename = Console.ReadLine();
                journal.LoadFromFile(loadFilename);
                Console.WriteLine("Journal loaded successfully.\n");
            }
            else if (userInput == 4)
            {
                Console.Write("Enter a filename to save the journal: ");
                string saveFilename = Console.ReadLine();
                journal.SaveToFile(saveFilename);
                Console.WriteLine("Journal saved successfully.\n");
            }
        }
    }
}
