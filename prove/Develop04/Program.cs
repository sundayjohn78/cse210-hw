class Program
{
    static void Main(string[] args)
    {
        int userInput = 0;
        Activity activity = null;

        Console.WriteLine("Enter the number of the activity you would like to choose to start the activity:\n1.Breathing Activity \n2.Reflection Activity \n3.Listing Activity");
        Console.Write("");
        userInput = int.Parse(Console.ReadLine());

        if (userInput == 1)
        {
            activity = new BreathingActivity();
        }
        else if (userInput == 2)
        {
            activity = new ReflectingActivity();
        }
        else if (userInput == 3)
        {
            activity = new ListingActivity();
        }
        else
        {
            Console.WriteLine("Invalid Input Restart the program");
            return;
        }

        // Now you have the correct activity type and can call its methods
        activity.DisplayStartingMessage();

        // Use 'as' to cast the activity to the specific type
        (activity as BreathingActivity)?.Run();
        (activity as ReflectingActivity)?.Run();
        (activity as ListingActivity)?.Run();

        activity.DisplayEndingMessage();
    }
}
