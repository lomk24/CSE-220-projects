using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Transactions;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int termanate = 1;
        Console.WriteLine("Enter numbers to be put in a list, enter 0 when you wish to finish");
        while (termanate != 0)
            {
                Console.Write("Enter number: ");
                string user_response = Console.ReadLine();
                termanate = int.Parse(user_response);

                if (termanate != 0)
                {
                    numbers.Add(termanate);
                }
            }
        int sum = 0;
        int max = 0;

        foreach (int num in numbers)
        {
            sum += num;
            if (num > max)
            {
                max = num;
            }
        }
        float average = ((float)sum) / numbers.Count;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The max is: {max}");


    }
}