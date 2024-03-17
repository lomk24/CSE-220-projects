using System.IO;

string filePath = "large-file.txt";
int numLines = 1000000; // 100 million lines

using (StreamWriter writer = new StreamWriter(filePath, false))
{
    for (int i = 0; i < numLines; i++)
    {
        writer.WriteLine($"Line {i + 1}");
    }
}

Console.WriteLine("File created successfully.");