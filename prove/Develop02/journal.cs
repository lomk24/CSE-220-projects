using System.ComponentModel.DataAnnotations;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

public class Journal
{
    public string _startUp = "1. Write \n2. Display \n3. Load \n4. Save \n5. Quit";
    public string _options = "\nWhat do you want to do?";
    public string randomPrompt;

    public void Display()
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

    public static void ShowPrompts()
    {
        int l = _promptslist.Count;
        Random r = new Random();
        int num = r.Next(l);
        var randomPrompt = _promptslist[num];

        Console.WriteLine($"\n{randomPrompt}");
    }

}