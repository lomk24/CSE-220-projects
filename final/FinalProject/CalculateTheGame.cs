using System.Diagnostics.Contracts;
using System.IO.Compression;
using System.Net;
using System.Runtime.CompilerServices;

public class CalculateTheGame
{
    List<Tuple<string, TimeSpan>> saveTime = new List<Tuple<string, TimeSpan>>();
    List<string> saveResults = new List<string>();
    List<string> averageTimeList = new List<string>();
    public void Calculations(List<Tuple<string, TimeSpan>> time, List<string> finalResults)
    {
        saveTime = time;
        saveResults = finalResults;

        Dictionary<string, (TimeSpan totalTime, int count)> categoryStats = new Dictionary<string, (TimeSpan, int)>();

        foreach (var (category, duration) in time)
        {
            if (!categoryStats.ContainsKey(category))
            {
                categoryStats[category] = (TimeSpan.Zero, 0);
            }

            var (totalTime, count) = categoryStats[category];
            categoryStats[category] = (totalTime + duration, count + 1);
        }

        Dictionary<string, TimeSpan> averageTimes = new Dictionary<string, TimeSpan>();

        foreach (var (category, (totalTime, count)) in categoryStats)
        {
            averageTimes[category] = TimeSpan.FromSeconds(totalTime.TotalSeconds / count);
        }

        foreach (var (category, averageTime) in averageTimes)
        {
            Console.WriteLine($"Category: {category}, Average Time Between: {averageTime}");
            averageTimeList.Add($"Category: {category}, Average Time Between: {averageTime}");
        }
            foreach (var (eventName, eventTime) in saveTime)
    
        if (eventName == "End")
        {
            Console.WriteLine($"\nTotal Time: {eventTime}");
            string endTime = eventTime.ToString();
            averageTimeList.Add(endTime);
            break; 
        }
        
        SaveCalulations();
    }
    public void SaveCalulations()
    {
        Console.WriteLine("Save Options");
        Console.WriteLine("    1. Create new file");
        Console.WriteLine("    2. Save to existing file");
        Console.WriteLine("    3. Don't save");
        Console.Write("\nHow would you like to save the game results?: ");
        
        string savingOption = Console.ReadLine();

        switch(savingOption)
        {
            case "1":

            Console.Write("What is the Name of the New File?: ");
            string newFileName = Console.ReadLine();
            newFileName += ".txt";

            using(StreamWriter outPutFile = new StreamWriter(newFileName))
            {
                foreach(string results in saveResults)
                {
                    outPutFile.WriteLine(results);
                }
                foreach(string average in averageTimeList)
                {
                    outPutFile.WriteLine(average);
                }
            }

            break;

            case "2":
            
            Console.Write("What is the name of the file?: ");
            string existingFileName = Console.ReadLine();
            using(StreamWriter outPutFile = new StreamWriter(existingFileName, true))
            {
                foreach(string results in saveResults)
                {
                    outPutFile.WriteLine(results);
                }

                foreach(string average in averageTimeList)
                {
                    outPutFile.WriteLine(average);
                }
            }

            break;

            case "3":

            break;
        }
        saveTime.Clear();
        saveResults.Clear();
        averageTimeList.Clear();
    }
}
