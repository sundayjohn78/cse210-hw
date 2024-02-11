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
        Console.WriteLine("List of Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            string status = goals[i].IsComplete() ? "[x]" : "[ ]";
            Console.WriteLine($"{i + 1}. {status} {goals[i].GetDetailsString()}");
        }
    }

    private void SaveGoals()
    {
        Console.Write("Enter the filename to save the goals (e.g., name.txt): ");
        string filename = Console.ReadLine();
        
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Goal goal in goals)
            {
                writer.WriteLine($"{goal.GetType().Name},{goal.Name},{goal.Description},{goal.Points},{goal.IsComplete()}");
                }
                writer.WriteLine(totalScore);
        }
        Console.WriteLine("Goals saved successfully.");
    }


    private void LoadGoals()
    {
        Console.Write("Enter the filename to load the goals from: ");
        string filename = Console.ReadLine();

        goals.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts.Length >= 5)
                {
                    string goalType = parts[0];
                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);
                    bool isComplete = bool.Parse(parts[4]);

                    Goal goal = null;
                    switch (goalType)
                    {
                        case nameof(SimpleGoal):
                            goal = new SimpleGoal(name, description, points, isComplete);
                            break;
                        case nameof(ChecklistGoal):
                            if (parts.Length >= 7)
                            {
                                int target = int.Parse(parts[5]);
                                int bonus = int.Parse(parts[6]);
                                goal = new ChecklistGoal(name, description, points, target, bonus, isComplete);
                            }
                            break;
                        case nameof(EternalGoal):
                            goal = new EternalGoal(name, description, points);
                            break;
                    }
                    if (goal != null)
                    {
                        goals.Add(goal);
                    }
                }
            }
            string totalScoreLine = reader.ReadLine();
            if (totalScoreLine != null)
            {
                totalScore = int.Parse(totalScoreLine);   
            }
        }

        Console.WriteLine("Goals loaded successfully.");
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
