using System.ComponentModel;
using System.Linq.Expressions;

public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;
    private string _congrates;
    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }
    public string GetName() { return _name; }
    public string GetDescription() { return _description; }
    public int GetPoints() { return _points; }

    public abstract string StoreFormat();
    public abstract string ListDisplayFormat();
    public abstract string Update();

    // public bool Update()
    // {
        
    // }
}