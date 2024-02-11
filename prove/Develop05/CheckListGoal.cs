public class ChecklistGoal : Goal
{
    private int target;
    private int bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus, bool completed = false) 
        : base(name, description, points, completed)
    {
        this.target = target;
        this.bonus = bonus;
    }

    public override void RecordEvent()
    {
        if (!completed)
        {
            completed = true;
            points += bonus;
        }
    }

    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} [Completed {target}/{target} times]";
    }

    public override string GetStringRepresentation()
    {
        return $"{name},{description},{points},{target},{bonus},{completed}";
    }
}
