public class ReflectionActivity : Activity
{
    private List<string> _questionPrompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need",
        "Think of a time when you did something truly selfless",
        "Think of one thing that you would like to improve about yourself.",
        "If you could change one thing about today, what would it be?",
        "If you could be anywhere in the world right now, where would it be? Why? Imagine yourself in this place"
    };
    private List<string> _reflectionPrompts = new List<string>
    {
        "Why was this experience meaningful to you?",
        "have you ever done anything like this before",
        "How did you get started",
        "What made this time diffferent than other times when you were not as succesful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };
    private List<int> _chosenQuestions = new List<int>();
    private List<int> _chosenReflection = new List<int>(); 
    private Random _random = new Random();
    int number;
    public ReflectionActivity(string directions, int lengthofTime) : base(directions, lengthofTime)
    {
        
    }

    private bool _notIn1 = true;
    private bool _notIn2 = true;
    public override void Play()
    {
        Console.Clear();
        LoadingAnimation();
    }

    private string GetRandomQuestion()
    {
        while(_notIn1 == true)
        {
            number = _random.Next(_questionPrompts.Count());
            if(_chosenQuestions.Contains(number))
            {
                number = _random.Next(_questionPrompts.Count());             
            }
            else if(_chosenQuestions.Count() == _questionPrompts.Count())
            {
                string prompt = ("That is all the questions");
                return prompt;
            }
            else
            {
               _notIn1 = false; 
            }
        }
        _chosenQuestions.Add(number);
        string prompt1 = _questionPrompts[number];

        return prompt1;
    }

    private string GetRandomReflection()
        {
        while(_notIn2 == true)
        {
            number = _random.Next(_reflectionPrompts.Count);
            if(_chosenReflection.Contains(number))
            {
                number = _random.Next(_reflectionPrompts.Count);             
            }
            else if(_chosenReflection.Count() == _reflectionPrompts.Count())
            {
                string prompt = ("That is all the reflections");
                return prompt;
            }
            else
            {
               _notIn2 = false; 
            }
        }
        _chosenReflection.Add(number);
        string prompt1 = _reflectionPrompts[number];

        return prompt1;
    }

    private void LoadingAnimation()
    {
        Console.Clear();
        int timeElapsed = GetTimer();
        int questionTime = 0;
        int reflectionTime = 0;
        while (timeElapsed < 0)
        {
            string questioner = GetRandomQuestion();
            string reflect = GetRandomReflection();
            
            while (questionTime < 5000)
            {
                Console.WriteLine($"{questioner}...\\");
                Thread.Sleep(625);
                questionTime += 625;
                Console.Clear();
                Console.WriteLine($"{questioner}...|");
                Thread.Sleep(625);
                questionTime += 625;
                Console.Clear();
                Console.WriteLine($"{questioner}.../");
                Thread.Sleep(625);
                questionTime += 625;
                Console.Clear();
                Console.WriteLine($"{questioner}...-");
                Thread.Sleep(625);
                questionTime += 625;
                Console.Clear();
            }
            timeElapsed -= 5;

            while(reflectionTime < 15000)
            {
                Console.WriteLine($"{reflect}...\\");
                Thread.Sleep(625);
                questionTime += 625;
                Console.Clear();
                Console.WriteLine($"{reflect}...|");
                Thread.Sleep(625);
                questionTime += 625;
                Console.Clear();
                Console.WriteLine($"{reflect}.../");
                Thread.Sleep(625);
                questionTime += 625;
                Console.Clear();
                Console.WriteLine($"{reflect}...-");
                Thread.Sleep(625);
                questionTime += 625;
                Console.Clear();
                
            }
            timeElapsed -= 15;
        }
        GetFeedback();
    }

}