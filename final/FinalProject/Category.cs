using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

public class Category
{
    private string _name;
    private string _assignedButton;
    private int _timesDone;
    
    public Category(string name, string assignedButton, int timesDone)
    {
        _name = name;
        _assignedButton = assignedButton;
        _timesDone = timesDone;
    }

    public Category(string name)
    {
        _name = name;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetAssignedButton()
    {
        return _assignedButton;
    }
    
    public int GetTimesDone()
    {
        return _timesDone;
    }
    
    public string GetDictionaryFormat()
    {
        int number = GetTimesDone();
        string stringNumber = number.ToString();
        string button = GetAssignedButton();
        return $"{button}, {stringNumber}";
    }
}