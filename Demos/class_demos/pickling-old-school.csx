/**
 * C# program to demonstrate the old school (original) way to perform serialization
 * and deserialization of an object to binary data. In this example, we save the
 * object to a file and then read it back from the file. We could save the binary
 * data to a database or send it over the network.
 *
 * THIS IS A DEPRECATED WAY TO PERFORM SERIALIZATION IN C#. USE THE JSON SERIALIZATION. 
 */
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
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

class Program
{
    static void Main(string[] args)
    {
        // Create a student object
        Student student = new Student("John Doe", 20, 3.7);

        // Serialize the student object to a binary file
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream("student.dat", FileMode.Create))
        {
            formatter.Serialize(stream, student);
        }

        Console.WriteLine("Student object serialized to student.dat");

        // Deserialize the student object from the binary file
        using (FileStream stream = new FileStream("student.dat", FileMode.Open))
        {
            Student deserializedStudent = (Student)formatter.Deserialize(stream);
            Console.WriteLine($"Deserialized Student: {deserializedStudent}");
        }

        Console.ReadLine();
    }
}