public class BreathingActivity : Activity
{
    public BreathingActivity(string directions, int lengthofTime) : base(directions, lengthofTime)
    {
        
    }
    public override void Play()
    {
        Console.Clear();
        LoadingAnimation();
    }
    private void LoadingAnimation()
    {
        int timeElapsed = GetTimer();
        int countUp = 1;
        while (timeElapsed > 0)
        {
            Console.Clear();
            Console.Write("Breath in...");
            Console.WriteLine($"...{countUp}");                 
            timeElapsed -= 1;
            countUp += 1;
            Thread.Sleep(1000);
            Console.WriteLine($"...{countUp}");
            timeElapsed -= 1;
            countUp += 1;
            Thread.Sleep(1000);
            Console.WriteLine($"...{countUp}");
            timeElapsed -= 1;
            countUp += 1;
            
            Console.Write("Breath out...");
            Console.WriteLine($"...{countUp}");                 
            timeElapsed -= 1;
            countUp += 1;
            Thread.Sleep(1000);
            Console.WriteLine($"...{countUp}");
            timeElapsed -= 1;
            countUp += 1;
            Thread.Sleep(1000);
            Console.WriteLine($"...{countUp}");
            timeElapsed -= 1;
            countUp += 1;
            Thread.Sleep(1000);
            Console.WriteLine($"...{countUp}");
            timeElapsed -= 1;
            countUp += 1;
            Thread.Sleep(1000);
            Console.WriteLine($"...{countUp}");
            timeElapsed -= 1;
            countUp += 1;
            Thread.Sleep(1000);
        }
    }
}