using System;

class Program
{
    static void Main(string[] args)
    {
        string breathingInstructions = "This activity will help you relax by walking your through breathing in and out slowly. Breath in and out when prompted";
        string reflectionInstructions = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        string listingInstructions = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        
        bool terminate = false;
        while(! terminate)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness program! \nPlease select an activity (select 4 to quit):");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Writing Activity");
            Console.WriteLine("4. Quit\n");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("How long would you like to do this activity");
                    string time = Console.ReadLine();
                    int  clock = int.Parse(time);
                    BreathingActivity breath = new BreathingActivity(breathingInstructions, clock);
                    breath.Play();
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    Console.Clear();
                    break;

                
            }
        }
    }
}