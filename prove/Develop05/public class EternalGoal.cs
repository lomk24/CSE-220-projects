using System.Diagnostics.Contracts;
using System.Runtime;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
        
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
        int pointers = GetPoints();
        string points = pointers.ToString();
        return $"EternalGoal: {name},{description},{points}";
    }
    public override string Update()
    {
        throw new NotImplementedException();
    }
}