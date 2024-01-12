using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep2 World!");
        Console.Write("What is your percentage score? (0-100)")
        userInput = int.Parse(Console.ReadLine());
        if (userInput >= 90)
        {
            Console.WriteLine("Grade A")
            Console.WriteLine("Excellent Score!!!!")
        }
        else if (userInput >= 80)
        {
            Console.WriteLine("Grade B")
            Console.WriteLine("Excellent Score!!!!")
        }
        else if (userInput >= 70)
        {
            Console.WriteLine("Grade C")
            Console.WriteLine("Excellent Score!!!!")
        }
        else if (userInput >= 60)
        {
            Console.WriteLine("Grade D")
            Console.WriteLine("You can try better, anticipate for 70% score")
        }
        else (userInput < 60)
        {
            Console.WriteLine("Grade F")
            Console.WriteLine("Very low score, you can try better, anticipate for 70% score")
        }
        
    }
}