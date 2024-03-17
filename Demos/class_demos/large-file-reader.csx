using System.IO;
using System.Diagnostics;

string filePath = "large-file.txt";
Stopwatch stopwatch = new Stopwatch();

if (File.Exists(filePath))
{
    stopwatch.Start();

    using (StreamReader reader = new StreamReader(filePath)) //Using is C# equivilant of pythons "with"
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {   
            /**
             * Uncomment the following line to see the lines being read.
             * THIS WILL DRASTICALLY SLOW DOWN THE PROGRAM!
             */
            Console.WriteLine(line);
        }
    }

    Console.WriteLine("File reading completed.");
    Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds / 1000} seconds");
}
else
{
    Console.WriteLine($"File '{filePath}' does not exist.");
}