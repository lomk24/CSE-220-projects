using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double GPA { get; set; }

    public Student(string name, int age, double gpa)
    {
        Name = name;
        Age = age;
        GPA = gpa;
    }

    public override string ToString()
    {
        return $"Name={Name}, Age={Age}, GPA={GPA}";
    }
}

public class ClassRoster
{
    public List<Student> Students { get; set; }

    public ClassRoster()
    {
        Students = new List<Student>();
    }

    public void PrintRoster()
    {
        foreach (Student student in Students)
        {
            Console.WriteLine($"{student.Name} present!");
        }
    }
}

const string fileName = "classroster.json";
ClassRoster roster;

if (File.Exists(fileName))
{
    // Read the JSON string from the file
    string jsonFromFile = File.ReadAllText(fileName);

    // Deserialize the JSON string to a ClassRoster object
    roster = JsonSerializer.Deserialize<ClassRoster>(jsonFromFile);
    Console.WriteLine("Deserialized Class Roster:");
}
else
{
    // Create a class roster with three students
    roster = new ClassRoster();
    roster.Students.Add(new Student("John Doe", 20, 3.7));
    roster.Students.Add(new Student("Jane Smith", 21, 3.9));
    roster.Students.Add(new Student("Bob Johnson", 19, 3.5));

    // Serialize the class roster to a JSON string
    string jsonString = JsonSerializer.Serialize(roster);
    Console.WriteLine("Serialized Class Roster JSON: " + jsonString);

    // Write the JSON string to a file
    File.WriteAllText(fileName, jsonString);

    Console.WriteLine("Class roster serialized to " + fileName);
    Console.WriteLine("Deserialized Class Roster:");
}

// Print the deserialized class roster
foreach (Student student in roster.Students)
{
    Console.WriteLine(student);
}

// Do roll call.
Console.WriteLine("Do roll call:");
roster.PrintRoster();

Console.ReadLine();