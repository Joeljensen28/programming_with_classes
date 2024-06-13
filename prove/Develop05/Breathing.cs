public class Breathing : Activity
{
    public Breathing() : base("Breathing", "This activity will help you relax by controlling your breathing and meditating.")
    {
        // No new attributes
    }

    public void PerformBreathing()
    {
        Timer activityTimer = new Timer(_duration);
        activityTimer.StartTimer();

        while (activityTimer.TimerActive())
        {
            Console.Write($"Breathe in..4\b");
            Thread.Sleep(1000);
            Console.Write($"3\b");
            Thread.Sleep(1000);
            Console.Write($"2\b");
            Thread.Sleep(1000);
            Console.Write($"1\b");
            Thread.Sleep(1000);
            Console.Write($"0\b");
            Thread.Sleep(1000);
            Console.WriteLine("\n");
            Console.Write($"Breathe out..6\b");
            Thread.Sleep(1000);
            Console.Write($"5\b");
            Thread.Sleep(1000);
            Console.Write($"4\b");
            Thread.Sleep(1000);
            Console.Write($"3\b");
            Thread.Sleep(1000);
            Console.Write($"2\b");
            Thread.Sleep(1000);
            Console.Write($"1\b");
            Thread.Sleep(1000);
            Console.Write($"0\b");
            Thread.Sleep(1000);
            Console.WriteLine("\n");
        }
    }
}