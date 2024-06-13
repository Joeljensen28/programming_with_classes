public class Activity
{
    // Duration of the activity
    protected int _duration;
    // List of prompts for both reflecting and listing activites
    protected List<string> _prompts;
    // Title of the activity
    protected string _title;
    // Description of the activity
    protected string _description;

    // Constructor for duration. Note there is no parameter for _prompts as the breathing exercise won't have a list
    public Activity(string title, string description)
    {
        _title = title;
        _description = description;
    }

    // Functions as the outro for each activity
    public void Congradulate()
    {
        Console.WriteLine("Well done!");
        Animation(5);
        Console.WriteLine("");
        Console.WriteLine($"You have completed {_duration} seconds of the {_title} Activity.");
        Animation(5);
    }

    // Functions as the intro to the activity and also stores the duration
    public void Description()
    {
        Console.WriteLine($"Welcome to the {_title} Activity!");
        Console.WriteLine("");
        Console.WriteLine(_description);
        Console.WriteLine("");
        Console.WriteLine("How long in seconds would you like to do this activity? ");
        _duration = int.Parse(Console.ReadLine());
        Console.Clear();
    }

    // Tells them to get ready
    public void GetReady()
    {
        Console.WriteLine("Get ready...");
        Animation(5);
    }

    // Counts down from 3 so they can prepare for the activity
    public static void CountDown()
    {
            Console.Write("You may begin in: 5\b");
            Thread.Sleep(1000);
            Console.Write("4\b");
            Thread.Sleep(1000);
            Console.Write("3\b");
            Thread.Sleep(1000);
            Console.Write("2\b");
            Thread.Sleep(1000);
            Console.Write("1\b");
            Thread.Sleep(1000);
            Console.Write("\b\n");
    }

    // Shows the prompt, takes the _prompts attribute as parameter
    public static void ShowPrompt(List<string> prompts)
    {
        Random random = new Random();
        int randomIndex = random.Next(prompts.Count);
        string randomPrompt = prompts[randomIndex];
        Console.WriteLine(randomPrompt);
    }

    // Loops the animation for x number of seconds
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