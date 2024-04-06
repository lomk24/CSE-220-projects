using System.Linq.Expressions;
using System.Net.Mail;
using System.Text.Json.Serialization;
using Microsoft.Win32.SafeHandles;

public class LoadAndSave
{
    private string _fileName;
    public LoadAndSave(string fileName)
    {
        this._fileName = fileName;
    }

    public string GetFileName()
    {
        return _fileName;
    }
    
    public void CreateNewFile(Dictionary<string,string> dictionary)
    {
        string newFileName = GetFileName();

        newFileName += ".txt";
        string directoryPath = Environment.CurrentDirectory;
        string filePath = Path.Combine(directoryPath, newFileName);

        // Add code to see if the program already exists (if file.Exists)

        using(StreamWriter writer = File.CreateText(filePath));

        using(StreamWriter outPutFile = new StreamWriter(newFileName))
        
        foreach(var diction in dictionary)
        {
            outPutFile.WriteLine($"{diction.Key}:{diction.Value}");
        }
    }

    public void SaveFile(Dictionary<string,string> dictionary)
    {
        string theFile = GetFileName();
        using(StreamWriter outPutFile = new StreamWriter(theFile))
        
        foreach(var diction in dictionary)
        {
            outPutFile.WriteLine($"{diction.Key}:{diction.Value}");
        }
        
    }
    public void LoadGame(CreateNew loader)
    {
        string theFile = GetFileName();
        using(StreamReader read = new StreamReader(theFile))
        {
            string line;
            while((line = read.ReadLine()) != null)
            {
                string[] parts = line.Split(":");
                if(parts.Length == 2)
                {
                    string key = parts[0];
                    string value = parts[1];

                    loader.AddToDictioanry(key, value);
                }  
            }
        }
    }

}