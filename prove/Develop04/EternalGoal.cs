public class EternalGoal : Goal
{
    // No new attributes to initialize

    public EternalGoal(string goalTitle, string description, int pointsValue) : base(goalTitle, description, pointsValue){}

    public override void RecordEvent()
    {
        _isComplete = false;
    }
}