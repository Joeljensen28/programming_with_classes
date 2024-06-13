public class Listing : Activity
{
    private int _lenResponses;

    public Listing() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area")
    {
        _prompts = new List<string> {
            "----Who are people that you appreciate?----",
            "----What are personal strengths of yours?----",
            "----Who are people that you have helped this week?----",
            "----When have you felt the Holy Ghost this month?----",
            "----Who are some of your personal heroes?----"
        };
    }

    public void PerformListing()
    {
        Console.WriteLine("List as many responses as you can to the following prompt:\n");
        ShowPrompt(_prompts);
        Console.Write("\n");
        CountDown();
        Console.Write("\n");

        _lenResponses = 0;

        Timer newTimer = new Timer(_duration);
        newTimer.StartTimer();

        while (newTimer.TimerActive())
        {
            Console.Write("> ");
            Console.ReadLine();
            _lenResponses++;
        }

        Console.WriteLine($"You listed {_lenResponses} items!");
    }
}