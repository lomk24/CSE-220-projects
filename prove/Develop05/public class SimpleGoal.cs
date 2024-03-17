using System.Reflection;

public class SimpleGoal : Goal
{
    private bool _completed = false;
    public SimpleGoal(string name, string description, int points, bool completed) : base(name, description, points)
    {
        _completed = completed;
    }
    public bool GetCompletion()
    {
        return _completed;
    }
    public override string ListDisplayFormat()
    {
        string name = GetName();
        string description = GetDescription();
        
        return $"[ ] {name} ({description})";
    }
    public override string StoreFormat()
    {
        string name = GetName();
        string description = GetDescription();
        int points = GetPoints();
        bool completed = GetCompletion();
        return $"SimpleGoal: {name},{description},{points},{completed}";
    }
    public override string Update()
    {
        throw new NotImplementedException();
    }

}