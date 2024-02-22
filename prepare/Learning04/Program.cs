using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Win32.SafeHandles;

class Program
{
    static void Main(string[] args)
    {
        Assignment assign = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(assign.GetSummary());

        MathAssignment math = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(math.GetSummary());
        Console.WriteLine(math.GetHomeworkList());

        WritingAssignment writer = new WritingAssignment("Marry Waters", "European History", "The Causes of War");
        Console.WriteLine(writer.GetSummary());
        Console.WriteLine(writer.GetWritingInformation());

    }
}
