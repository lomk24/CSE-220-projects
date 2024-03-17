using System.Runtime.CompilerServices;

public class CheckListGoal : Goal
{
    private int _howManyTimes;
    private int _howManyCompleted;
    private int _bonus;
    
    public CheckListGoal(string name, string description, int points, int howManyTimes, int HowManyCompleted, int bonus) : base (name, description, points)
    {
        _howManyTimes = howManyTimes;
        _howManyCompleted = HowManyCompleted;
        _bonus = bonus;
    }

    public int GetHowManyTimes()
    {
        return _howManyTimes;
    }
    public int GetHowManyCompleted()
    {
        return _howManyCompleted;
    }
    public int GetBonus()
    {
        return _bonus;
    }

    public override string ListDisplayFormat()
    {
        string name = GetName();
        string description = GetDescription();
        int howManyTimes = GetHowManyTimes();
        int howManyCompleted = GetHowManyCompleted();
        
        return $"[ ] {name} ({description}) --- Currently completed: {howManyCompleted}/{howManyTimes}";
    }
    public override string StoreFormat()
    {
        string name = GetName();
        string description = GetDescription();
        int points = GetPoints();
        int bonus = GetBonus();
        int howManyTimes = GetHowManyTimes();
        int howManyCompleted = GetHowManyCompleted();
        return $"ChecklistGoal: {name},{description},{points},{bonus},{howManyTimes},{howManyCompleted}";
    }
    public override string Update()
    {
        throw new NotImplementedException();
    }
}