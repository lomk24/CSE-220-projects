using System.Linq.Expressions;

public class LoadAndSave
{
    private string _fileName;
    private string theFile;
    public LoadAndSave(string fileName)
    {
        this._fileName = fileName;
    }

    public string GetFileName()
    {
        return _fileName;
    }
    
    public void CreateNewFile()
    {
        string newFileName = GetFileName();

        newFileName += ".txt";
        string directoryPath = Environment.CurrentDirectory;
        string filePath = Path.Combine(directoryPath, newFileName);

        // Add code to see if the program already exists (if file.Exists)

        using(StreamWriter writer = File.CreateText(filePath));
    }

    public void SaveFile(Dictionary<string,string> dictionary)
    {
        theFile = GetFileName();
        using(StreamWriter outPutFile = new StreamWriter($"{theFile}"));

        foreach(var diction in dictionary)
        {
            Console.WriteLine($"{diction.Key}: {diction.Value}")
        }
    }
}