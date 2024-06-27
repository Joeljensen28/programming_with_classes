public class ChecklistGoal : Goal
{
    // How many times the activity has been done (to count toward completion)
    private int _timesDone = 0;
    // How many times the user has to do the activity to mark the goal complete
    private int _completionTimes;
    // Bonus pts awarded when _timesDone == _completionTimes
    private int _bonusPts;

    public ChecklistGoal(string goalTitle, string description, int pointsValue, int bonusPts, int completionTimes) : base(goalTitle, description, pointsValue)
    {
        _bonusPts = bonusPts;
        _timesDone = 0;
        _completionTimes = completionTimes;
    }

    public ChecklistGoal(string goalTitle, string description, int pointsValue, bool isComplete, int bonusPts, int timesDone, int completionTimes) : base(goalTitle, description, pointsValue, isComplete)
    {
        _bonusPts = bonusPts;
        _timesDone = timesDone;
        _completionTimes = completionTimes;
    }

    // Sets the number of times the goal must be completed
    public void SetCompleteTime()
    {
        Console.WriteLine("How many times do you have to do this goal to mark it complete?");
        _completionTimes = int.Parse(Console.ReadLine());
    }
    // Sets the value of the total completion points
    public override void SetPtValue(int ptValue)
    {
        _pointsValue = ptValue;
    }
    // Sets bonus pts value
    public void SetBonusPts(int bonusPts)
    {
        _bonusPts = bonusPts;
    }
    // Tracks completion status of the goal and gets points accordingly
    public override void RecordEvent()
    {
        // This method is intended to be called when they record an event, so very first thing it adds 1 to _timesDone
        _timesDone++;
        // Then it checks if they've done the goal however many times they specified
        if (_timesDone == _completionTimes)
        {
            // If so, then the goal is marked complete and they get the points
            _isComplete = true;
        }
    }

    public override int GetPts()
    {
        if (_isComplete)
        {
            return _pointsValue + _bonusPts;
        }
        else
        {
            return _pointsValue;
        }
    }

    public int GetTimesDone()
    {
        return _timesDone;
    }

    public int GetCompletionTimes()
    {
        return _completionTimes;
    }

    public override void ShowGoal()
    {
        this.ShowCompleteStatus();
        Console.WriteLine($" {_goalTitle} ({_description}) -- Completed: {_timesDone}/{_completionTimes}");
    }

    public int GetBonusPoints()
    {
        return _bonusPts;
    }
}