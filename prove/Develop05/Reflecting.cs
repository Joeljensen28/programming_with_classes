public class Reflecting : Activity
{
    // List of follow up questions for the user to ponder on
    private List<string> _followUps = new List<string> {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
        };

    public Reflecting() : base("Reflecting", "This activity will help empower you by inviting you to think of things you have done and how they made you feel.")
    {
        _prompts = new List<string> {
        "----Think of a time when you did something really difficult.----",
        "----Think of a time when you stood up for someone else.----",
        "----Think of a time when you helped someone in need.----",
        "----Think of a time when you did something truly selfless.----"
        };
    }
    
    // The actual activity of reflecting
    public void PerformReflecting()
    {
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine("\n");
        ShowPrompt(_prompts);
        Console.WriteLine("\n");

        Console.Write("When you have something in mind, press enter to continue.");
        string proceed = Console.ReadLine();
        if (string.IsNullOrEmpty(proceed))
        {
            Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
            CountDown();
            // Starts a timer
            Timer newTimer = new Timer(_duration);
            newTimer.StartTimer();

            while (newTimer.TimerActive())
            {
                // This if statement is used due to the functionality of ShowFollowUp which removes a prompt from the list once it has been used. If the user chooses an activity duration that is longer than the list of prompts can accomodate, the loop will terminate once all the prompts have been used.
                if (_followUps.Count == 0)
                {
                    break;
                }
                else
                {
                    ShowFollowUp(_followUps);
                    Animation(15);
                }
            }
        }
    }

    // Satic function that will choose a random follow up. Parameter is intended for the _followUps list
    public static void ShowFollowUp(List<string> followUps)
    {
        Random random = new Random();
        int randomIndex = random.Next(followUps.Count);
        // Get a random follow up, write it
        string randFollowUp = followUps[randomIndex];
        Console.WriteLine(randFollowUp);
        // Remove the follow up to avoid repitition
        followUps.Remove(randFollowUp);
    }
}