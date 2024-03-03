using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public  class ListiningActivity : Activity
{
    private bool _notChosen = true;
    private Random _rand = new Random();
    private List<int> _usedPrompts = new List<int>();
    private List<string> _wordList = new List<string>();
    string prompt;

    int number;
    public ListiningActivity(string directions, int lengthofTime, string feedback) : base(directions, lengthofTime, feedback)
    {
    }

    List <string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private string GetRandomPrompt()
    {
        while(_notChosen == true);
        {
            number = _rand.Next(_prompts.Count);
            if(_usedPrompts.Contains(number))
            {
                number = _rand.Next(_prompts.Count());
            }
            else if(_prompts.Count() == _usedPrompts.Count())
            {
                Console.WriteLine("That is all the questions");
            }
            else
            {
                _notChosen = false;
            }
            _usedPrompts.Add(number);
            prompt = _prompts[number];

            return prompt;

        }
    }

    private void LoadingAnimation()
    {
        int timeElapsed = GetTimer();
        int countDown1 = 5;

        Console.Clear();
        Console.WriteLine("Ready?");
        Thread.Sleep(1000);
        timeElapsed -= 1;

        var stopwatch = new Stopwatch();
        stopwatch.Start();

        string prompter = GetRandomPrompt();
        while(countDown1 > 0)
        {
            Console.WriteLine($"{prompt}");
            Console.WriteLine($"{countDown1}");
            Thread.Sleep(1000);
            countDown1--;
            Console.WriteLine($"{countDown1}");
            countDown1--;
            Thread.Sleep(1000);
            Console.WriteLine($"{countDown1}");
            countDown1--;
            Thread.Sleep(1000);
            Console.WriteLine($"{countDown1}");
            countDown1--;
            Thread.Sleep(1000);
            Console.WriteLine($"{countDown1}");
            countDown1--;
        }
    
        while(stopwatch.Elapsed.TotalSeconds < timeElapsed)
        {

            var listers = Console.ReadLine();
            _wordList.Add(listers);

        }
        stopwatch.Stop();
            
    }
    public void Display()
    {
        int counted = _wordList.Count();
        Console.WriteLine($"Congragulations, you wrote {counted} items!");
    }
    public override void Play()
    {
        Console.Clear();
        LoadingAnimation();
        Display();
    }
}