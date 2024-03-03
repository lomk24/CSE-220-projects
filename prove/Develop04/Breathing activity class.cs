public class BreathingActivity : Activity
{
    public BreathingActivity(string directions, int lengthofTime, string name) : base(directions, lengthofTime, name)
    {
        
    }
    public override void Play()
    {
        Thread.Sleep(5000);
        LoadingAnimation();
    }
    private void LoadingAnimation()
    {
        int timeElapsed = GetTimer();
        int countUp = 1;
        while (timeElapsed > 0)
        {
            Console.Clear();
            Console.WriteLine("Breath in");
            Thread.Sleep(1000);
            Console.WriteLine($"> {countUp}");                 
            timeElapsed -= 1;
            countUp += 1;
            Thread.Sleep(1000);
            Console.WriteLine($"> {countUp}");
            timeElapsed -= 1;
            countUp += 1;
            Thread.Sleep(1000);
            Console.WriteLine($"> {countUp}");
            timeElapsed -= 1;
            countUp += 1;
            Thread.Sleep(1000);
            
            Console.WriteLine("\nBreath out");
            Thread.Sleep(1000);
            Console.WriteLine($"> {countUp}");                 
            timeElapsed -= 1;
            countUp += 1;
            Thread.Sleep(1000);
            Console.WriteLine($"> {countUp}");
            timeElapsed -= 1;
            countUp += 1;
            Thread.Sleep(1000);
            Console.WriteLine($"> {countUp}");
            timeElapsed -= 1;
            countUp += 1;
            Thread.Sleep(1000);
            Console.WriteLine($"> {countUp}");
            timeElapsed -= 1;
            countUp += 1;
            Thread.Sleep(1000);
            Console.WriteLine($"> {countUp}");
            timeElapsed -= 1;
            countUp += 1;
            Thread.Sleep(1000);
        }
    }
}