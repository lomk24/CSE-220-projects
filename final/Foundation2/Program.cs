using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, int> exercises = new Dictionary<string, int>
    {
        { "Push Ups", 0 },
        // Add more exercises if needed
    };

    static void Main(string[] args)
    {
        Console.WriteLine("Press 'd' to increment Push Ups count.");

        while (true)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.D)
                {
                    IncrementExerciseCount("Push Ups");
                }
            }
        }
    }

    static void IncrementExerciseCount(string exerciseName)
    {
        exercises[exerciseName]++;
        Console.Clear();
        PrintExercises();
    }

    static void PrintExercises()
    {
        foreach (var exercise in exercises)
        {
            Console.WriteLine($"{exercise.Key}: {new string('-', 10)} {exercise.Value}");
        }
    }
}
