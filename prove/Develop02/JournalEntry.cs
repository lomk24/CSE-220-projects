
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Dataflow;
using System.Xml.Schema;

public class JournalEntry
{
    public List<string> _theEntry = new List<string>();

    public void AddEntry(string entry)
    {
        _theEntry.Add($"{dateTime()}: {entry}");
    }


    public void Display()
    {
        foreach (string entry in _theEntry)
        {
            Console.WriteLine($"\n{entry}");
        }
    }
    public static string dateTime()
    {
        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();

        return dateText;
    }

}