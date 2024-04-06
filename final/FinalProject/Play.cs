using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.SymbolStore;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

public class Play
{
    static bool gameOver = false;

    static Dictionary<string,string> game = new Dictionary<string, string>();
    public void StartGame(CreateNew startGame)
    {
        Dictionary<string,string> gameDictionary = startGame.GetMyDictionary();
        game = startGame.GetMyDictionary();
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        Update();

        // Add way to pause the game
    }

    static void Update()
    {
        DictionaryDisplayFormat();
        Console.WriteLine("Press assigned button");
        while(gameOver == false)
        {
            if(Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).KeyChar;
                foreach(KeyValuePair<string,string> gamePairs in game)
                {
                    char checkForSign = '~';
                    bool containsSign = gamePairs.Key.Contains(checkForSign);

                    string[] valueSplitter = gamePairs.Value.Split(",");

                    if(gamePairs.Key.Contains('~'))
                    {
                        char assignedButton = valueSplitter[0][0]; // Secon [0] reaches into ["d"] and pulls out "d"
                        int count = int.Parse(valueSplitter[1]);
                        if(assignedButton == key)
                        {
                            IncrementCount(gamePairs.Key);
                            break;
                        }  
                    }
                    else
                    {
                        string[] subCategories = gamePairs.Value.Split("/");
                        foreach(string subCategory in subCategories)
                        {
                            string[] subCategoryData = subCategory.Split(',');

                            char assignedButton = subCategoryData[1][0];
                            int count = int.Parse(subCategoryData[2]);

                            if(assignedButton == key)
                            {
                                IncrementCountSubCategory(gamePairs.Key, subCategory);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }


    private static void IncrementCount(string taskName)
    {
        string[] valueSplitter = game[taskName].Split(",");
        int count = int.Parse(valueSplitter[1]);
        count++;
        game[taskName] = $"{valueSplitter[0]},{count}";
        Console.Clear();
        DictionaryDisplayFormat();
    }

    private static void IncrementCountSubCategory(string taskName, string subCategory)
    {
        string[] subCategoryData = subCategory.Split(",");
        int count = int.Parse(subCategoryData[2]) + 1;
        
        string updatedSubCategory = $"{subCategoryData[0]},{subCategoryData[1]},{count}";
        string newValue = game[taskName].Replace(subCategory, updatedSubCategory);
        game[taskName] = newValue;

        Console.Clear();
        DictionaryDisplayFormat();
    }

    // private static void IncrementCountSubCategory(string taskName)
    // {
    //     string[] valueSplitter = 
    // }

    private static void DictionaryDisplayFormat()
    {
        foreach(KeyValuePair<string,string> gamePairs in game)
        {
            char checkForSign = '~';
            bool containsSign = gamePairs.Key.Contains(checkForSign);

            string[] valueSplitter = gamePairs.Value.Split(",");
            string asctricRemover = gamePairs.Key.Replace("~", "");
            if(containsSign)
            {
                Console.WriteLine($"{asctricRemover}:{valueSplitter[0]} - {valueSplitter[1]}");
            }
            else
            {
                Console.WriteLine(gamePairs.Key);
                string[] subCategorySplitter = gamePairs.Value.Split("/");
                int max = subCategorySplitter.Count();

                for(int maxSubCat = 0; maxSubCat < max - 1; maxSubCat++)
                {
                    string subCategory = subCategorySplitter[maxSubCat];
                    string[] valueSplitt = subCategory.Split(",");
                    string name = valueSplitt[0];
                    string button = valueSplitt[1];
                    int timesDone = int.Parse(valueSplitt[2]);
                    bool theBest = bool.Parse(valueSplitt[3]);
                    bool focus = bool.Parse(valueSplitt[4]);
                    
                    if(focus == true)
                    {
                        Console.WriteLine($"> {name}:{button} - {timesDone}*");
                    }
                    else
                    {
                        Console.WriteLine($"> {name}: {button} - {timesDone}");
                    }
                }
            }
        }
    }
}
    // static int GetMaxFirstPartLength(List<string[]> items)
    // {
    //     int maxLength = 0;
    //     foreach(string[] item in items)
    //     {
    //         int length = item[0].Length;
    //         if(length > maxLength)
    //         {
    //             maxLength = length;
    //         }
    //     }
    //     return maxLength;
    // }