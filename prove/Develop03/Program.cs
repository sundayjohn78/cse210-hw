using System;

class Program
{
    static void Main()
    {
        // Create a sample scripture
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        Scripture scripture = new Scripture(reference, "Trust in the LORD with all thine heart; and lean not unto thine own understanding. \nIn all thy ways acknowledge him and he shall direct thy paths.");

        // Main program loop
        do
        {
            // Clear console
            Console.Clear();

            // Display scripture
            Console.WriteLine(scripture.GetDisplayText());

            // Prompt user
            Console.WriteLine("Press Enter to hide more words, type 'quit' to end.");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
            {
                // Exit the loop if the user types 'quit'
                break;
            }
            else
            {
                // Hide random words
                int numberOfWordsToHide = 1;
                scripture.HideRandomWords(numberOfWordsToHide);
            }

        } while (!scripture.IsCompletelyHidden());

        // Display a message when all words are hidden
        Console.WriteLine("All words are hidden. Program ended.");
    }
}
