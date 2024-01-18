using System;

class Program
{
    static void Main(string[] args)
    {
        string to_continue = "yes";
        while (to_continue == "yes")
        {
            Console.Write("Pick a positive integer ");
            string num = Console.ReadLine();
            int max = int.Parse(num);

            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1,max);

            int response = 0;

            Console.Write($"Guess a number between 1 and {max} ");

            while (response != number)
            {
                string word_guess = Console.ReadLine();
                int guess = int.Parse(word_guess);

                if (guess > number)
                {
                    Console.WriteLine("Too High");
                }
                else if (guess < number)
                {
                    Console.WriteLine("Too Low");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    response = number;
                }
            }
            
            Console.WriteLine("Do you wish to continue? Write yes or no ");
            string play_again = Console.ReadLine();
                if (play_again == "yes")
            {
                to_continue = "yes";
            }
            else
            {
                to_continue = "no";
            } 
        }
    }
}
// Error happening, adding this to see if help with git hub