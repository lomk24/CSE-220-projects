using System;
using System.IO;
using System.IO.Enumeration;

class Program
{
    static void Main(string[] args)
    {
        int num;
        string write = "";
        JournalEntry journalEntry = new JournalEntry();
        
        do
        {
            Journal.Display();
            string choice = Console.ReadLine();
            num = int.Parse(choice);
        
            if (num == 1)
            {
                Journal.ShowPrompts();
                write = Console.ReadLine();

                journalEntry.AddEntry(write);
                
            }
            else if (num == 2)
            {
                journalEntry.Display();
            }
            else if (num == 3)
            {
                string filename = "actualJournal.txt";
                LoadAndDisplayEntriesFromFile(filename);
            }

            else if (num == 4)
            {
                SaveEntriesToFile(journalEntry);
            }
        }
        while (num != 5);
    }

    static void LoadAndDisplayEntriesFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            List<string> lines = new List<string>(File.ReadAllLines(filename));
            int count = 0;
            Console.WriteLine("Entries loaded from the file:");
            foreach (string line in lines)
            {
                Console.WriteLine($"\n{line}");
                count++;
            }
            Console.WriteLine($"\nThere are {count} entries.");
            Journal.GiveMotivation();
        }
        else
        {
            Console.WriteLine("File not found. No entries loaded.");
        }
    }

    static void SaveEntriesToFile(JournalEntry journalEntry)
    {
        Console.WriteLine("Enter the file name to save your journal:");
        string file = Console.ReadLine();

        File.AppendAllLines(file, journalEntry._theEntry);

        Console.WriteLine($"Journal saved to: {file}");
    }
}