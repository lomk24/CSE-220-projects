using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, welcome to the Performance Tracker!\n"); 
        Console.WriteLine("Would you like an explanation of how to run this Program? (y/n)");
        string tutorial = Console.ReadLine();
        
        
        switch(tutorial)
        {
            case "y":
            break;

            case "n":
            break;
        }
        
        bool done = false;

        while(done == false)
        {   
            // Console.Clear();
            Console.WriteLine("What would you like to do?\n");
            Console.WriteLine("1. Create New Tracker");
            Console.WriteLine("2. Load Tracker");
            Console.WriteLine("3. Save Tracker");
            Console.WriteLine("4. Edit Tracker");
            Console.WriteLine("5. Play Tracker");
            Console.WriteLine("6. Quite");

            string choice = Console.ReadLine();
            bool choiceDone = false;
            bool subCategoryDone = false;

            switch(choice)
            {
                case "1":
                CreateNew newGame = new CreateNew();

                while(choiceDone == false)
                {
                    Console.Write("Name of New Category: ");
                    string newName = Console.ReadLine();

                    Console.Write("\nWould you like to add a subcategory? (y/n): ");
                    string addingSubcategories = Console.ReadLine();

                    switch(addingSubcategories)
                    {
                        case "y":
                            while(subCategoryDone == false)
                            {
                                bool theFocus = false;
                                Console.Write("Name of New SubCategory: ");
                                string newSubCategoryName = Console.ReadLine();
                                Console.Write("Assign Button to SubCategory: ");
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

                                // AddSaveFunction

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
                            newGame.AddToDictioanry(name, numberAndButton);

                            Console.WriteLine("Do you want to make another Category? (y/n): ");
                            string createMore2 = Console.ReadLine();

                            if(createMore2 == "y")
                                {
                                    choiceDone = false;
                                }

                            else if(createMore2 == "n")
                            {

                                // AddSaveFunction

                                choiceDone = true;
                                
                            }           
                        break;
                    }
                }
                newGame.DisplayDictionary();
                break;
    
                case "2":
                break;

                case "3":
                break;

                case "4":
                break;

                case "5":
                break;

                case "6":
                break;

            }
        }
    }
}