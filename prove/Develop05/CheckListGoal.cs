public class ChecklistGoal : Goal
{
    private int target;
    private int currentProgress;
    private int bonus;

    public int Target { get { return target; } }
    public int CurrentProgress { get { return currentProgress; } }
    public int Bonus { get { return bonus; } }

    public ChecklistGoal(string name, string description, int points, int target, int bonus, bool completed = false) 
        : base(name, description, points, completed)
    {
        this.target = target;
        this.bonus = bonus;
        this.currentProgress = 0;
    }

    public override void RecordEvent()
    {
        if (!completed)
        {
            currentProgress++;
            if (currentProgress == target)
            {
                completed = true;
                points += bonus;
            }
        }
    }

    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} [Progress: {currentProgress}/{target}]";
    }

    public override string GetStringRepresentation()
    {
        return $"{base.GetStringRepresentation()},{target},{currentProgress},{bonus}";
    }
}
