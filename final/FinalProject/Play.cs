using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.SymbolStore;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text.Json.Serialization;
using System.Timers;

public class Play
{
    static bool gameOver = false;

    static Dictionary<string,string> game = new Dictionary<string, string>();
    static List<Tuple<string, TimeSpan>> buttonPressTimes = new List<Tuple<string, TimeSpan>>();
    static List<string> finalResults = new List<string>();
    static Stopwatch stopwatch = new Stopwatch();
    public void StartGame(CreateNew startGame)
    {
        Dictionary<string,string> gameDictionary = startGame.GetMyDictionary();
        game = startGame.GetMyDictionary();
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
                TimeSpan pressTime = stopwatch.Elapsed;
                foreach(KeyValuePair<string,string> gamePairs in game)
                {
                    string[] valueSplitter = gamePairs.Value.Split(",");

                    if(gamePairs.Key.Contains('~'))
                    {
                        char assignedButton = valueSplitter[0][0]; // Secon [0] reaches into ["d"] and pulls out "d"
                        int count = int.Parse(valueSplitter[1]);
                        if(assignedButton == key)
                        {
                            IncrementCount(gamePairs.Key);
                            RecordButtonPress(gamePairs.Key, pressTime);
                            break;
                        }  
                    }
                    else
                    {

                        string[] subCategories = gamePairs.Value.Split("/");
                        int max = subCategories.Count();

                        for(int maxSubCat = 0; maxSubCat < max - 1; maxSubCat++)
                        {
                            string subCategoryData = subCategories[maxSubCat];
                            string[] subCategorySplit = subCategoryData.Split(",");
                            char assignedButton = subCategorySplit[1][0];
                            int count = int.Parse(subCategorySplit[2]);

                            if(assignedButton != key)
                            {
                                continue;
                            }
                            else
                            {
                                IncrementCountSubCategory(gamePairs.Key, subCategoryData);
                                RecordButtonPress(subCategorySplit[0], pressTime);
                                break;
                            }
                        }
                    }

                    if(key == '\r')
                    {
                        stopwatch.Stop();
                        gameOver = true;
                        buttonPressTimes.Add(new Tuple<string, TimeSpan>("End", pressTime));
                        if(gamePairs.Key.Contains('~'))
                        {
                            continue;
                        }

                        else
                        {
                            int bestMax = 0;
                            int timesDone;
                            string[] subCategorySplit;
                            string subCategoryData;
                            string[] subCategories = gamePairs.Value.Split("/");
                            int max = subCategories.Count();

                            int counter = 0;

                            for(int maxSubCat = 0; maxSubCat < max - 1; maxSubCat++)
                            {
                                subCategoryData = subCategories[maxSubCat];
                                subCategorySplit = subCategoryData.Split(",");
                                timesDone = int.Parse(subCategorySplit[2]);

                                if(timesDone > bestMax)
                                {
                                    bestMax = timesDone;
                                }
                                counter += 1;
                            }
                            
                            for(int maxSubCat = 0; maxSubCat < max - 1; maxSubCat++)
                            {
                                subCategoryData = subCategories[maxSubCat];
                                subCategorySplit = subCategoryData.Split(",");
                                timesDone = int.Parse(subCategorySplit[2]);

                            {
                                
                                if(bestMax == timesDone)
                                {
                                    string changeBoolean = "True";
                                    string upDateBoolean = $"{subCategorySplit[0]},{subCategorySplit[1]},{subCategorySplit[2]},{changeBoolean},{subCategorySplit[4]}";
                                    string newValue = game[gamePairs.Key].Replace(subCategoryData, upDateBoolean);
                                    game[gamePairs.Key] = newValue;
                                }
                            
                                else{continue;}
                            }
                            
                     
                            }

                        //     CalculateTheGame calculate = new CalculateTheGame();
                        //     calculate.Calculations(game, buttonPressTimes);

                        }
                    }
                }
            }
        }
        PrintFinal();
        CalculateTheGame calculate = new CalculateTheGame();
        calculate.Calculations(buttonPressTimes, finalResults);
        game.Clear();
        buttonPressTimes.Clear();
        finalResults.Clear();
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
    private static void RecordButtonPress(string buttonName, TimeSpan pressTime)
    {
        buttonPressTimes.Add(new Tuple<string, TimeSpan>(buttonName, pressTime));
    }
    private static void IncrementCountSubCategory(string taskName, string subCategory)
    {
        string[] subCategoryData = subCategory.Split(",");
        int count = int.Parse(subCategoryData[2]) + 1;
        
        string updatedSubCategory = $"{subCategoryData[0]},{subCategoryData[1]},{count},{subCategoryData[3]},{subCategoryData[4]}";
        string newValue = game[taskName].Replace(subCategory, updatedSubCategory);
        game[taskName] = newValue;

        Console.Clear();
        DictionaryDisplayFormat();
    }

    private static void PrintFinal()
    {
        Console.Clear();
        foreach(KeyValuePair<string,string> gamePairs in game)
        {
            char checkForSign = '~';
            bool containsSign = gamePairs.Key.Contains(checkForSign);

            string[] valueSplitter = gamePairs.Value.Split(",");
            string asctricRemover = gamePairs.Key.Replace("~", "");

            if(containsSign)
            {
                finalResults.Add($"{asctricRemover} - Total: {valueSplitter[1]}");
            }
            else
            {
                string subCategory;
                string[] valueSplitt;
                string name;
                string button;
                int timesDone;
                bool theBest;
                bool focus;
                int total = 0;
                string[] subCategorySplitter = gamePairs.Value.Split("/");
                int max = subCategorySplitter.Count();

                for(int maxSubCat = 0; maxSubCat < max - 1; maxSubCat++)
                {
                    subCategory = subCategorySplitter[maxSubCat];
                    valueSplitt = subCategory.Split(",");
                    name = valueSplitt[0];
                    button = valueSplitt[1];
                    timesDone = int.Parse(valueSplitt[2]);
                    theBest = bool.Parse(valueSplitt[3]);
                    focus = bool.Parse(valueSplitt[4]);

                    total += timesDone;
                }
                finalResults.Add($"{gamePairs.Key}: {total}");
                for(int maxSubCat = 0; maxSubCat < max - 1; maxSubCat++)
                {
                    subCategory = subCategorySplitter[maxSubCat];
                    valueSplitt = subCategory.Split(",");
                    name = valueSplitt[0];
                    button = valueSplitt[1];
                    timesDone = int.Parse(valueSplitt[2]);
                    theBest = bool.Parse(valueSplitt[3]);
                    focus = bool.Parse(valueSplitt[4]);

                    if(focus == true)
                    {
                        if(theBest == true)
                        {
                            finalResults.Add($"> {name} - Total: {timesDone}* ----- The Best");
                        }
                        else
                        {
                            finalResults.Add($"> {name} - Total: {timesDone}*");
                        }
                    }
                    else
                    {
                        if(theBest == true)
                        {
                            finalResults.Add($"> {name} - Total: {timesDone} ----- The Best");
                        }
                        else
                        {
                            finalResults.Add($"> {name} - Total: {timesDone}");
                        }
                    }
                }
            }
        }

        foreach(var i in finalResults)
        {
            Console.WriteLine($"{i}");
        }
    }


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