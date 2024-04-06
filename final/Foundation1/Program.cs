using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string[]> items = new List<string[]>
        {
            new string[] { "change", "blue" },
            new string[] { "and", "orange" },
            new string[] { "apple", "green" }
            // Add more items as needed
        };

        PrintItems(items);
    }

    static void PrintItems(List<string[]> items)
    {
        int maxFirstPartLength = GetMaxFirstPartLength(items);

        foreach (string[] item in items)
        {
            string firstPart = item[0];
            string secondPart = item[1];
            int spacesToAdd = maxFirstPartLength - firstPart.Length;

            Console.WriteLine($"{firstPart}{new string(' ', spacesToAdd)} - {secondPart}");
        }
    }

    static int GetMaxFirstPartLength(List<string[]> items)
    {
        int maxLength = 0;
        foreach (string[] item in items)
        {
            int length = item[0].Length;
            if (length > maxLength)
            {
                maxLength = length;
            }
        }
        return maxLength;
    }
}

    }
}