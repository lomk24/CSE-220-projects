using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

class Program
{
    static void Main(string[] args)
    {
        bool done = false;
        string fileName = "";
        SaveLoadAndList simpleAdd = new SaveLoadAndList(fileName);
        int currentPoints = 0;

        while(done == false)
        {
            Console.WriteLine($"You have {currentPoints} points.\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Update Goals");
            Console.WriteLine("  6. Quit");

            Console.Write("\nSelect a choice from the menu: ");
            string choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                    Console.WriteLine("The types of Goals are:\n1. Simple Goal \n2. Eternal Goals \n3. Checklist Goals");
                    string choice2 = Console.ReadLine();

                    switch(choice2)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("Simple Goal\n");
                            Console.Write("What is the name of your goal?: ");
                            string simpleName = Console.ReadLine();
                            Console.Write("Give a short description of your goal: ");
                            string simpleDescription = Console.ReadLine();
                            Console.Write("Assign points: ");
                            string stringPoints = Console.ReadLine();
                            int simplePoints = int.Parse(stringPoints);

                            SimpleGoal simple = new SimpleGoal(simpleName, simpleDescription, simplePoints, false);
    
                            string simpleStoreFormate = simple.StoreFormat();
                            simpleAdd.AddToList(simpleStoreFormate);
                            Console.Clear();

                            Console.WriteLine("\nSimple Goal created.");
                            Console.Clear();
                            break;

                        case "2":
                            Console.Clear();
                            Console.WriteLine("Eternal Goal\n");
                            Console.Write("What is the name of your goal?: ");
                            string eternalName = Console.ReadLine();
                            Console.Write("Give a short description of your goal: ");
                            string eternalDescription = Console.ReadLine();
                            Console.Write("Assign points: ");
                            string stringPoints2 = Console.ReadLine();
                            int eternalPoints = int.Parse(stringPoints2);

                            EternalGoal eternal = new EternalGoal(eternalName, eternalDescription, eternalPoints);

                            string eternalStoreFormate = eternal.StoreFormat();
                            simpleAdd.AddToList(eternalStoreFormate);

                            // Add wayu to put goal into list or dicitonary

                            Console.WriteLine("Eternal Goal created.");
                            break;

                        case "3":
                            int howManyCompleted = 0;
                            Console.Clear();
                            SaveLoadAndList checklistAdd = new SaveLoadAndList(fileName);
                            Console.WriteLine("Checklist Goal\n");
                            Console.Write("What is the name of your goal?: ");
                            string checklistName = Console.ReadLine();
                            Console.Write("Give a short description of your goal: ");
                            string checklistDescription = Console.ReadLine();
                            Console.Write("How many times do you want to do this goal?: ");
                            string assignedTimes = Console.ReadLine();
                            int checklistAssignedTimes = int.Parse(assignedTimes);
                            Console.Write("Assign points:");
                            string stringPoints3 = Console.ReadLine();
                            int checklistPoints = int.Parse(stringPoints3);
                            Console.Write("Assign bonus points for completion: ");
                            string bonus = Console.ReadLine();
                            int checkListBonus = int.Parse(bonus);

                            CheckListGoal checklist = new CheckListGoal(checklistName, checklistDescription, checklistPoints, checklistAssignedTimes, howManyCompleted, checkListBonus);

                            string checklistStore = checklist.StoreFormat();
                            simpleAdd.AddToList(checklistStore);

                            Console.WriteLine("Checklist Goal created.");
                            break;
                    }
                    break;

                case "2":
                    Console.Clear();
                    simpleAdd.FormatAndPrintGoals();
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("Save File:\n");
                    Console.WriteLine("1: Save to existing file \n2. Create new file");
                    string existingOrNew = Console.ReadLine();

                    switch(existingOrNew)
                    {
                        case "1":
                            Console.Clear();
                            Console.Write("File name: ");
                            string filerName = Console.ReadLine();
                            simpleAdd.UpdateFileName(filerName);
                            simpleAdd.SaveFile(currentPoints);
                            simpleAdd.FileSavedNotification();
                            break;
                        case "2":
                            Console.Clear();
                            Console.Write("Name new file: ");
                            string filerName2 = Console.ReadLine();
                            simpleAdd.UpdateFileName(filerName2);
                            simpleAdd.CreateFile();
                            simpleAdd.SaveFile(currentPoints);
                            simpleAdd.FileSavedNotification();
                            break;
                    }
                        
                break;

                case "4":
                    Console.Clear();
                    Console.Write("Input file: ");
                    string theFilesName = Console.ReadLine();
                    simpleAdd.UpdateFileName(theFilesName);
                    simpleAdd.LoadFile(ref currentPoints);
                    simpleAdd.FileLoadedNotification();

                break;

                case "5":
                    Console.Clear();
                    Console.WriteLine("What goal do you want to edit?");
                    simpleAdd.FormatAndPrintGoalsAgain();
                    string choose = Console.ReadLine();
                    int chooseNumber = int.Parse(choose);
                    simpleAdd.EditTheThing(simpleAdd.goalsList, chooseNumber, ref currentPoints);
                break;

                case "6":
                    done = true;
                break;
            }
        }

    }
}