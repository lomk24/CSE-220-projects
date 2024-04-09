using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;
using System.Security.Cryptography;

public class Edit
{
    public void Editer(CreateNew editor)
    {
        bool done = false;
        bool choiceDone = false;
        Dictionary<string,string> dictionaryEditor = editor.GetMyDictionary();


        while(done != true)
        {
            Console.WriteLine("What do you want to edit");
            Console.WriteLine(" 1. Remove categories");
            Console.WriteLine(" 2. Add categories");
            Console.WriteLine(" 3. Edit current Category");
            Console.WriteLine(" 4. Done");

            string edit = Console.ReadLine();

            switch(edit)
            {
                case "1":
                    int listingNumber = 1;
                    Console.WriteLine("Which Category do you want to remove?");
                    foreach(KeyValuePair<string,string> i in dictionaryEditor)
                    {
                        Console.WriteLine($"    {listingNumber}. {i.Key}");
                        listingNumber += 1;
                    }
                    Console.Write("Enter the number of the category you want to remove: ");
                    string deletingInput = Console.ReadLine();

                    if(int.TryParse(deletingInput, out int selection) && selection >= 1 && selection <= dictionaryEditor.Count)
                    {
                        string keyToRemove = dictionaryEditor.Keys.ElementAt(selection - 1);
                        dictionaryEditor.Remove(keyToRemove);
                        Console.WriteLine($"Category '{keyToRemove}' deleted");
                    } 
                    else
                    {
                        Console.WriteLine("Invalid selection. Please enter a valid number.");
                    }


                break;

                case "2":
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
                                editor.AddToSubList(listVersion);

                                Console.Write("Would you like to add another Sub-Category? (y/n): ");      
                                string moreSubCategories = Console.ReadLine();

                                if(moreSubCategories == "y")
                                {
                                    subCategoryDone = false;
                                }
                                else if(moreSubCategories == "n")
                                {
                                    string wholeThing = editor.AddListContentsTogether();
                                    editor.AddToDictioanry(newName, wholeThing);
                                    editor.ClearList();
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
                        
                        break;

                        case "n":
                            Console.Write("Assigned button: ");
                            string assignedButtonNoSub = Console.ReadLine();
                            Category noSubCategory = new Category(newName, assignedButtonNoSub, 0);
                            string name = noSubCategory.GetName();
                            string numberAndButton = noSubCategory.GetDictionaryFormat();
                            editor.AddToDictioanry($"~{name}", $"{numberAndButton}");

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
                break;

                case "3":
                    bool subCategoryDone2 = false;
                    int listingNumber2 = 1;
                    Console.WriteLine("Which Category do you want to remove?");
                    foreach(KeyValuePair<string,string> i in dictionaryEditor)
                    {
                        Console.WriteLine($"    {listingNumber2}. {i.Key}");
                        listingNumber2 += 1;
                    }
                    Console.Write("Enter the number of the category you want to remove: ");
                    string changingInput = Console.ReadLine();

                    if(int.TryParse(changingInput, out int selection2) && selection2 >= 1 && selection2 <= dictionaryEditor.Count)
                    {
                        string valueToEdit = dictionaryEditor.Values.ElementAt(selection2 - 1);
                        string keyToEdit = null;
                        foreach (var key in dictionaryEditor)
                        {
                            if (key.Value == valueToEdit)
                            {
                                keyToEdit = key.Key;
                                break;
                            }
                        }

                        Console.Write("Name of New Category: ");
                        string newName = Console.ReadLine();

                        dictionaryEditor.Remove(keyToEdit);

                        Console.Write("Would you like to add a subcategory? (y/n): ");
                        string addingSubcategories = Console.ReadLine();

                        switch(addingSubcategories)
                        {
                            case "y":
                                while(subCategoryDone2 == false)
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
                                    editor.AddToSubList(listVersion);

                                    Console.Write("Would you like to add another Sub-Category? (y/n): ");      
                                    string moreSubCategories = Console.ReadLine();

                                    if(moreSubCategories == "y")
                                    {
                                        subCategoryDone2 = false;
                                    }
                                    else if(moreSubCategories == "n")
                                    {
                                        string wholeThing = editor.AddListContentsTogether();
                                        dictionaryEditor.Add(newName, wholeThing);
                                        editor.ClearList();
                                        subCategoryDone2 = true;
                                    }
                                }    
                            break;

                            case "n":
                                Console.Write("Assigned button: ");
                                string assignedButtonNoSub = Console.ReadLine();
                                Category noSubCategory = new Category(newName, assignedButtonNoSub, 0);
                                string name = noSubCategory.GetName();
                                string numberAndButton = noSubCategory.GetDictionaryFormat();
                                dictionaryEditor.Add($"~{name}", numberAndButton);
                                
                            break;
                        }
                    }
                        
                    else
                    {
                        Console.WriteLine("Invalid selection. Please enter a valid number.");
                    }
                break;

                case "4":
                done = true;
                break;
            }
        }
        
    }
    
}