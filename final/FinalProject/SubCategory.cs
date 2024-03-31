using System.Globalization;

public class SubCategory : Category
{
    private bool _focus;
    private bool _theBest = false;
    public SubCategory(string name, string assignedButton, int timesDone, bool theBest, bool focus) : base(name, assignedButton, timesDone)
    {
        _focus = focus;
        _theBest = theBest;
    }

    public bool GetTheBest()
    {
        return _theBest;
    } 
    public bool GetFocus()
    {
        return _focus;
    }

    public string PutTogetherForList()
    {
        string addName = GetName();
        string addAssignedButton = GetAssignedButton();
        int addTimesDone = GetTimesDone();
        string stringTimesDone = addTimesDone.ToString();
        bool addTheBest = GetTheBest();
        bool addFocus = GetFocus();

        return $"{addName},{addAssignedButton},{stringTimesDone},{addTheBest},{addFocus}/";
    }


    // public string GetSubDictionaryFormat()
    // {
        
    // }
    
}