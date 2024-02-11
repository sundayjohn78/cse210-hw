using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> goals;
    private int totalScore;

    public GoalManager()
    {
        goals = new List<Goal>();
        totalScore = 0;
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine($"Total Points Earned: {totalScore}");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Save goals");
            Console.WriteLine("4. Load goals");
            Console.WriteLine("5. Record event");
            Console.WriteLine("6. Quit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoalMenu();
                    break;
                case "2":
                    if (goals.Count == 0)
                    {
                        Console.WriteLine("You have not created any goals yet.");
                    }
                    else
                    {
                        ListGoals();
                    }
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    private void CreateGoalMenu()
    {
        Console.WriteLine("1. Simple goal");
        Console.WriteLine("2. Eternal goal");
        Console.WriteLine("3. Checklist goal");
        Console.Write("Enter goal type: ");
        string goalType = Console.ReadLine();

        Console.Write("Enter name of the goal: ");
        string name = Console.ReadLine();
        Console.Write("Enter description of the goal: ");
        string description = Console.ReadLine();
        Console.Write("Enter points for the goal: ");
        int points = int.Parse(Console.ReadLine());

        switch (goalType)
        {
            case "1":
                goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("Enter target count: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type");
                break;
        }
    }

    private void ListGoals()
    {
        for (int i = 0; i < goals.Count; i++)
        {
            string status = goals[i].IsComplete() ? "[x]" : "[ ]";
            Console.WriteLine($"{status} {goals[i].GetDetailsString()}");
        }
    }

    private void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            foreach (Goal goal in goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
            writer.WriteLine(totalScore);
        }
    }

    private void LoadGoals()
    {
        goals.Clear();
        using (StreamReader reader = new StreamReader("goals.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 4)
                {
                    goals.Add(new SimpleGoal(parts[0], parts[1], int.Parse(parts[2]), bool.Parse(parts[3])));
                }
                else if (parts.Length == 6)
                {
                    goals.Add(new ChecklistGoal(parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]), bool.Parse(parts[5])));
                }
                else if (parts.Length == 3)
                {
                    goals.Add(new EternalGoal(parts[0], parts[1], int.Parse(parts[2])));
                }
            }
            totalScore = int.Parse(reader.ReadLine());
        }
    }

    private void RecordEvent()
    {
        ListGoals();
        Console.Write("Enter the number of the goal you completed: ");
        int choice = int.Parse(Console.ReadLine());
        if (choice >= 1 && choice <= goals.Count)
        {
            Goal goal = goals[choice - 1];
            goal.RecordEvent();
            totalScore += goal.Points;
            Console.WriteLine($"Congratulations! You earned {goal.Points} points.");

            // Check if it's a checklist goal and update progress
            if (goal is ChecklistGoal checklistGoal)
            {
                if (checklistGoal.IsComplete())
                {
                    Console.WriteLine($"Goal '{checklistGoal.Name}' completed! Bonus points earned: {checklistGoal.Bonus}");
                    totalScore += checklistGoal.Bonus;
                }
                else
                {
                    Console.WriteLine($"Progress: {checklistGoal.CurrentProgress}/{checklistGoal.Target}");
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid choice");
        }
    }
}
