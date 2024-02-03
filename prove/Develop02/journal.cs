using System.ComponentModel.DataAnnotations;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

public class Journal
{
    public static string _startUp = "1. Write \n2. Display \n3. Load \n4. Save \n5. Quit";
    public static string _options = "\nWhat do you want to do?";
    public static string randomPrompt;

    public static void Display()
    {
        Console.Write($"\n{_startUp}\n{_options} ");
    }


    public static List<string> _promptslist = new List<string> 
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?", 
            "How did I see the hand of the Lord in my life today?", 
            "What was the strongest emotion I felt today?", 
            "If I had one thing I could do over today, what would it be?"
        };

    public static List<string> _motivationlist = new List<string> 
        {
            "Keep up the good work!",
            "You're doing great!",
            "Keep going!",
            "Keep trying to write each day!",
            "Remember, even just few lines each day is a good thing!"
        };

    public static void GiveMotivation()
    {
        int l = _motivationlist.Count;
        Random r = new Random();
        int num = r.Next(l);
        var randomPrompt = _motivationlist[num];

        Console.WriteLine($"\n{randomPrompt}");
    }

    public static void ShowPrompts()
    {
        int l = _promptslist.Count;
        Random r = new Random();
        int num = r.Next(l);
        var randomPrompt = _promptslist[num];

        Console.WriteLine($"\n{randomPrompt}");
    }

}