public class Goal
{
    protected string name;
    protected string description;
    protected int points;
    protected bool completed;

    public int Points { get { return points; } }
    public string Name { get { return name; } }
    public string Description { get { return description; } }


    public Goal(string name, string description, int points, bool completed = false)
    {
        this.name = name;
        this.description = description;
        this.points = points;
        this.completed = completed;
    }

    public virtual void RecordEvent()
    {
        completed = true;
    }

    public virtual bool IsComplete()
    {
        return completed;
    }

    public virtual string GetDetailsString()
    {
        return $"{name}: {description} [{points} points]";
    }

    public virtual string GetStringRepresentation()
    {
        return $"{name},{description},{points},{completed}";
    }
}
