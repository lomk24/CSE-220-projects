using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What was your grade? ");
        string grade = Console.ReadLine();
        int percent = int.Parse(grade);

        string letter = "";

        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80 )
        {
            letter = "B";
        }
        else if (percent >= 70 )
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is: {letter}");

        if (percent >= 70)
        {
            Console.WriteLine("Congratulations, you've passed the class!");
        }
        else
        {
            Console.WriteLine("Don't worry, you'll get it next time.");
        }

    }   

}