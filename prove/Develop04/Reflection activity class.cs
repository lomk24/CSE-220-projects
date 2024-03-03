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
    public ReflectionActivity(string directions, int lengthofTime, string name) : base(directions, lengthofTime, name)
    {
        
    }

    private bool _notIn1 = true;
    private bool _notIn2 = true;
    public override void Play()
    {
        Thread.Sleep(5000);
        LoadingAnimation();
    }

    private string GetRandomQuestion()
    {
        if(_chosenQuestions.Count() == _questionPrompts.Count())
        {
            return "That is all the questions";
        }

        do
        {
            number = _random.Next(_questionPrompts.Count());
        }
        while(_chosenQuestions.Contains(number));

        _chosenQuestions.Add(number);
        return _questionPrompts[number];

    }


    private string GetRandomReflection()
    {
                if(_chosenReflection.Count() == _reflectionPrompts.Count())
        {
            return "That is all the questions";
        }
        do
        {
            number = _random.Next(_reflectionPrompts.Count());
        }
        while(_chosenReflection.Contains(number));

        _chosenReflection.Add(number);
        return _reflectionPrompts[number];

    }

    private void LoadingAnimation()
    {
        Console.Clear();
        int timeElapsed = GetTimer();

        while (timeElapsed > 0)
        {
            int questionTime = 0;
            int reflectionTime = 0;
            string questioner = GetRandomQuestion();
            string reflect = GetRandomReflection();
            
            while (questionTime < 10000)
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

            timeElapsed -= 10;

            while(reflectionTime < 10000)
            {
                Console.WriteLine($"{reflect}...\\");
                Thread.Sleep(625);
                reflectionTime+= 625;
                Console.Clear();
                Console.WriteLine($"{reflect}...|");
                Thread.Sleep(625);
                reflectionTime += 625;
                Console.Clear();
                Console.WriteLine($"{reflect}.../");
                Thread.Sleep(625);
                reflectionTime += 625;
                Console.Clear();
                Console.WriteLine($"{reflect}...-");
                Thread.Sleep(625);
                reflectionTime += 625;
                Console.Clear();            
            }
            timeElapsed -= 20;
        }
    }

}