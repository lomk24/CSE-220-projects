using System;
using System.ComponentModel;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string UserName = PromptUserName();
        int UserNumber = PromptUserNumber();

        int SquaredNumber = SquareNumber(UserNumber);

        DisplayResult(UserName, SquaredNumber);
    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program");
    }

    static string PromptUserName()
    {
        Console.WriteLine("Please enter your name: ");
        string name = Console.ReadLine();

        return name;
    }
    static int PromptUserNumber()
    {
        Console.WriteLine("Please enter your favorite number: ");
        string number = Console.ReadLine();
        int num = int.Parse(number);

        return num;
    }
    static int SquareNumber(int num)
    {
        int square = num * num;
        return square;
    }
    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
    
}