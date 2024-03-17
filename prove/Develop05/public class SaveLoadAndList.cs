using System.IO.Enumeration;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Xml.Schema;
using Microsoft.VisualBasic;

public class SaveLoadAndList
{
    private string _fileName;
    private string theFile;
    private StreamReader read;
    private string line;
    public List<string> goalsList = new List<string>();
    private string path = @"C:\Users\lkrog\OneDrive\Documents\CSE 250\CSE-220-projects\prove\Develop05";
    public SaveLoadAndList(string fileName)
    {
        this._fileName = fileName;
    }
    public void UpdateFileName(string newFileName)
    {
        _fileName = newFileName;
    }
    public string GetFileName()
    {
        return _fileName;
    }
    public void CreateFile()
    {   
        theFile = GetFileName();
        using (StreamWriter theFile = File.CreateText(path)) {}
    }

    public void SaveFile(int currentPoints)
    {
        theFile = GetFileName();
        using (StreamWriter outPutFile = new StreamWriter($"{theFile}"))

        {
            outPutFile.WriteLine(currentPoints);
            foreach (string line in goalsList)
            {
                outPutFile.WriteLine(line);
            }
        }
    }
    public void LoadFile(ref int currentPoints)
    {
        theFile = GetFileName();
        using (StreamReader read = new StreamReader(theFile))
        {
            string firstLine = read.ReadLine();
            if(int.TryParse(firstLine, out int loadedPoints))
            {
                currentPoints = loadedPoints;
            }
            string line;
        
            while((line = read.ReadLine()) != null)
            {
                AddToList(line);
            }
        }

    }
    public void AddToList(string added)
    {
        goalsList.Add(added);
    }

    public void FileSavedNotification()
    {
        Console.WriteLine("File Saved");
    }

    public void FileLoadedNotification()
    {
        Console.WriteLine("File Loaded");
    }

    public void FormatAndPrintGoals()
    {
        GoalFormatter formatter = new GoalFormatter();
        List<string> formattedGoals = formatter.FormatGoals(goalsList);

        foreach(string goal in formattedGoals)
        {
            Console.WriteLine(goal);
        }
    }
    public void FormatAndPrintGoalsAgain()
    {
        Editor edit = new Editor();
        List<string> formattedGoals = edit.GoalsFormat(goalsList);

        foreach(string goal in formattedGoals)
        {
            Console.WriteLine(goal);
        }
    }
    public void EditTheThing(List<string> goalsList, int chosenNumber, ref int currentPoints)
    {
        if(chosenNumber >= 0 && chosenNumber <= goalsList.Count)
        {
            string chosenGoal = goalsList[chosenNumber - 1];
            string[] parts = chosenGoal.Split(":");
            string type = parts [0];
            string[] data = parts[1].Split(",");
        
        switch(type)
        {
            case "SimpleGoal":
                if(data[3] == "False")
                {
                    data[3] = "true";
                    currentPoints += int.Parse(data[2]);
                }
            break;

            case "EternalGoal":
                currentPoints += int.Parse(data[2]);
            break;

            case "ChecklistGoal":
                int currentProgress = int.Parse(data[5]);
                int targetProgress = int.Parse(data[4]);

                if (currentProgress == targetProgress)
                {
                    currentPoints += int.Parse(data[2]);
                    currentPoints += int.Parse(data[3]);
                }
                else
                {
                    currentProgress += 1;
                    data[5] = currentProgress.ToString();
                    currentPoints += int.Parse(data[2]);
                }
            break;
        }
        string editedGoal = $"{type}:{string.Join(",", data)}";
        goalsList[chosenNumber - 1] = editedGoal;

        }
    }
}




