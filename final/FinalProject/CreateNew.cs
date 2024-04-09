using System.ComponentModel;
using System.Data;
using System.IO.Compression;
using System.Security.AccessControl;

public class CreateNew
{
    public List<string> multipleSubCategoryHolder = new List<string>();
    private Dictionary<string, string> categoriesDictionary = new Dictionary<string, string>();
    
    public void AddToDictioanry(string key, string value)
    {
        categoriesDictionary.Add(key, value);
    }

    public Dictionary<string,string> GetMyDictionary()
    {
        return categoriesDictionary;
    }
    public void AddToSubList(string subCategory)
    {
        multipleSubCategoryHolder.Add(subCategory);
    }

    public string AddListContentsTogether()
    {
        return string.Join("", multipleSubCategoryHolder);
    }

    public void ClearList()
    {
        multipleSubCategoryHolder.Clear();
    }

    public void DeleteDictionary()
    {
        categoriesDictionary.Clear();
    }
    public void DisplayDictionary()
    {
        foreach(KeyValuePair<string, string> i in categoriesDictionary)
        Console.WriteLine(i);
    }
    
    
}