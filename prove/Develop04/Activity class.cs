using System.Runtime.InteropServices.Marshalling;

public abstract class Activity
{
    private string _directions;
    private int _lengthofTime;
    private string _positiveFeedback;
    private string _activity;
    private string basicStart = "Welcome!";
    private List<string> _feedback = new List<string>
    {
        "Good Job!",
        "Well Done!",
        "Just a little everyday helps!",
        "Keep it up!"
    };
    private Random _random = new Random();
    public abstract void Play();

    public Activity(string instructions, int lengthofTime)
    { 
        _directions = instructions;
        _lengthofTime = lengthofTime;
    }

    
    public string GetInstrucions()
    {
        return _directions;
    }
    public int GetTimer()
    {
        return _lengthofTime;
    }
    public string GetFeedback()
    {
        return _positiveFeedback;
    }
    
    private string GetRandom()
    {
        int number = _random.Next(_feedback.Count);
        return _feedback[number];

    }

    public void DisplayFeedback()
    {
        string positiveFeedback = GetRandom();
        Console.WriteLine($"You did {_activity} for {_lengthofTime}");
        Console.WriteLine($"{positiveFeedback}");
    }
}