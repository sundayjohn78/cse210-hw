using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int userInput = -1;
        while (userInput != 5)
        {
            

            DateTime theCurrentTime = DateTime.Now;
            string dateText = theCurrentTime.ToShortDateString();
            PromptGenerator aPrompt = new PromptGenerator();
            string promptText = aPrompt.GetRandomPrompt();
            Console.WriteLine("Please select one of the following choices:\n1.Write\n2.Display\n3.Load\n4.Save\n5.Quit");
            Console.Write("What would you like to do? ");
            userInput = int.Parse(Console.ReadLine());
 

            Entry anEntry = new Entry();
            if (userInput == 1)
            {
                Console.WriteLine($"{promptText}");
                Console.Write("");
                string entryText = Console.ReadLine();
                anEntry.__entryText = $"{entryText}";
                anEntry.__dateText = $"{dateText}";
                anEntry.__promptText = $"{promptText}";
                anEntry.Display();
            }
            else if (userInput == 2)
            {

                Entry aDisplayEntry = new Entry();
                aDisplayEntry.Display();  
            }
        }

        
    }
}