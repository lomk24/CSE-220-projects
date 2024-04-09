using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, welcome to the Performance Tracker!\n"); 

        bool done = false;
        CreateNew newGame = new CreateNew();
        while(done == false)
        {   
            // Console.Clear();
            Console.WriteLine("What would you like to do?\n");
            Console.WriteLine("1. Create New Tracker");
            Console.WriteLine("2. Load Tracker");
            Console.WriteLine("3. Edit Tracker");
            Console.WriteLine("4. Play Tracker");
            Console.WriteLine("5. Quite\n");

            string choice = Console.ReadLine();
            bool choiceDone = false;

            switch(choice)
            {
                case "1":
                Console.Clear();

                while(choiceDone == false)
                {
                    bool subCategoryDone = false;
                    Console.Write("Name of New Category: ");
                    string newName = Console.ReadLine();

                    Console.Write("Would you like to add a subcategory? (y/n): ");
                    string addingSubcategories = Console.ReadLine();

                    switch(addingSubcategories)
                    {
                        case "y":
                            while(subCategoryDone == false)
                            {
                                bool theFocus = false;
                                Console.Write("\n> Name of New SubCategory: ");
                                string newSubCategoryName = Console.ReadLine();
                                Console.Write("> Assign Button to SubCategory: ");
                                string subAssingedButton = Console.ReadLine();
                                Console.Write("Is this subcategory the focus of this category? (y/n): ");
                                string decidingTheFocus = Console.ReadLine();

                                if(decidingTheFocus == "y")
                                {
                                    theFocus = true;
                                }
                                else if(decidingTheFocus == "n")
                                {
                                    theFocus = false;
                                }

                                SubCategory withSubCategory = new SubCategory(newSubCategoryName, subAssingedButton, 0, false, theFocus);
                                string listVersion = withSubCategory.PutTogetherForList();
                                newGame.AddToSubList(listVersion);

                                Console.Write("Would you like to add another Sub-Category? (y/n): ");      
                                string moreSubCategories = Console.ReadLine();

                                if(moreSubCategories == "y")
                                {
                                    subCategoryDone = false;
                                }
                                else if(moreSubCategories == "n")
                                {
                                    string wholeThing = newGame.AddListContentsTogether();
                                    newGame.AddToDictioanry(newName, wholeThing);
                                    newGame.ClearList();
                                    subCategoryDone = true;
                                }
                            } 

                            Console.WriteLine("Do you want to make another Category? (y/n): ");
                            string createMore = Console.ReadLine();

                            if(createMore == "y")
                            {
                                choiceDone = false;
                            }

                            else if(createMore == "n")
                            {

                                choiceDone = true;
                            }

                            // Add exception catcher
                        
                        break;

                        case "n":
                            Console.Write("Assigned button: ");
                            string assignedButtonNoSub = Console.ReadLine();
                            Category noSubCategory = new Category(newName, assignedButtonNoSub, 0);
                            string name = noSubCategory.GetName();
                            string numberAndButton = noSubCategory.GetDictionaryFormat();
                            newGame.AddToDictioanry($"~{name}", $"{numberAndButton}");

                            Console.WriteLine("Do you want to make another Category? (y/n): ");
                            string createMore2 = Console.ReadLine();

                            if(createMore2 == "y")
                                {
                                    choiceDone = false;
                                }

                            else if(createMore2 == "n")
                            {
                                choiceDone = true;
                            }           
                        break;
                    }
                }
                Dictionary<string,string> GetDictionary = newGame.GetMyDictionary();
                
                Console.Clear();
                Console.WriteLine("Save Options");
                Console.WriteLine("    1. Create new file");
                Console.WriteLine("    2. Save to existing file");
                Console.Write("\nHow would you like to save the Game?: ");
                string saveOption = Console.ReadLine();

                Console.Write("What is the Name of the File?: ");
                string theFileName = Console.ReadLine();

                LoadAndSave saveGame = new LoadAndSave(theFileName);
                switch(saveOption)
                {
                    case "1":
                        saveGame.CreateNewFile(GetDictionary);
                    break;

                    case "2":
                        saveGame.SaveFile(GetDictionary);
                    break;

                    // Throw in exception catcher
                }

                break;
    
                case "2":
                Console.Clear();
                Console.Write("What file do you want to load?: ");
                string loadFileName = Console.ReadLine();
                LoadAndSave load = new LoadAndSave(loadFileName);
                load.LoadGame(newGame);
                // newGame.DisplayDictionary();
                break;

                case "3":
                    Edit edit = new Edit();
                    
                    edit.Editer(newGame);

                    Dictionary<string,string> GetDictionary2 = newGame.GetMyDictionary();

                    Console.Clear();
                    Console.WriteLine("Save Options");
                    Console.WriteLine("    1. Create new file");
                    Console.WriteLine("    2. Save to existing file");
                    Console.Write("\nHow would you like to save the Game?: ");
                    string saveOption2 = Console.ReadLine();

                    Console.Write("What is the Name of the File?: ");
                    string theFileName2 = Console.ReadLine();

                    LoadAndSave saveGame2 = new LoadAndSave(theFileName2);
                    switch(saveOption2)
                    {
                        case "1":
                            saveGame2.CreateNewFile(GetDictionary2);
                        break;

                        case "2":
                            saveGame2.SaveFile(GetDictionary2);
                        break;
                    }

                    break;

                case "4":
                Console.Clear();
                Play letsPlayAGame = new Play();
                letsPlayAGame.ResetGame();
                letsPlayAGame.StartGame(newGame);
                break;

                case "5":
                done = true;
                break;

            }
        }
    }
}
