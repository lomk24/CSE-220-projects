using System;
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

// Create a student object
Student student = new Student("John Doe", 20, 3.7);

// Serialize the student object to a JSON string
string jsonString = JsonSerializer.Serialize(student);
Console.WriteLine("Serialized Student JSON: " + jsonString);

// Write the JSON string to a file
File.WriteAllText("student.json", jsonString);

Console.WriteLine("Student object serialized to student.json");

// Read the JSON string from the file
string jsonFromFile = File.ReadAllText("student.json");

// Deserialize the JSON string to a Student object
Student deserializedStudent = JsonSerializer.Deserialize<Student>(jsonFromFile);
Console.WriteLine($"Deserialized Student: {deserializedStudent}");

Console.ReadLine();