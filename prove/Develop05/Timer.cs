public class Timer
{
    // Duration of the timer in seconds
    private int _duration;
    // Used in StarTimer() to track when the timer started and how much has elapsed
    private DateTime _startTime;

    public Timer(int duration)
    {
        _duration = duration;
    }

    // Starts the timer, marking when the timer started
    public void StartTimer()
    {
        _startTime = DateTime.Now;
    }

    // Checks the difference between now and the time the timer was initiated
    public bool TimerActive()
    {
        if (DateTime.Now - _startTime < TimeSpan.FromSeconds(_duration))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void Animation(int seconds)
    {
        Timer animationTimer = new Timer(seconds);
        animationTimer.StartTimer();
        while (animationTimer.TimerActive())
        {
            Console.Write("_\b");
            Thread.Sleep(100);
            Console.Write("*\b");
            Thread.Sleep(100);
            Console.Write("°\b");
            Thread.Sleep(100);
            Console.Write("*\b");
            Thread.Sleep(100);
        }
    }
}