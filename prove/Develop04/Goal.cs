using System.Diagnostics.Contracts;

public class Goal // NOTE: THIS IS THE SIMPLE GOAL CLASS
{
    // What the user names the goal as
    protected string _goalTitle;
    // How the user describes the goal
    protected string _description;
    // Point value ascribed by the user
    protected int _pointsValue;
    // Potentially will be used to record events (when going through the list of goals when the user wants to record an event)
    protected int _goalIndex;
    // Tells us if the goal has already been completed, false until triggered by RecordEvent()
    protected bool _isComplete;

    // Constructor sets complete status to false by default
    public Goal(string goalTitle, string description, int pointsValue)
    {
        _goalTitle = goalTitle;
        _description = description;
        _pointsValue = pointsValue;
        _isComplete = false;
    }
    // Second constructor allows user to specify status of goal completion (specifically for loading goals)
    public Goal(string goalTitle, string description, int pointsValue, bool IsComplete)
    {
        _goalTitle = goalTitle;
        _description = description;
        _pointsValue = pointsValue;
        _isComplete = IsComplete;
    }

    // Tells us if the event is completed or not
    public virtual bool IsComplete()
    {
        return _isComplete;
    }
    // Sets the title of the goal
    public void SetTitle(string goalTitle)
    {
        _goalTitle = goalTitle;
    }
    // Sets the description of the goal
    public void SetDescription(string goalDesc)
    {
        _description = goalDesc;
    }
    // Sets the point value of the goal
    public virtual void SetPtValue(int ptValue)
    {
        _pointsValue = ptValue;
    }
    // Used in the show goals menu to show if the goal is complete or not
    public void ShowCompleteStatus()
    {
        if (_isComplete)
        {
            Console.Write("[X]");
        }
        else
        {
            Console.Write("[ ]");
        }
    }
    // Displays the name of the goal and the description
    public virtual void ShowGoal()
    {
        this.ShowCompleteStatus();
        Console.WriteLine($" {_goalTitle} ({_description})");
    }
    // Gets the pts and marks the goal as done
    public virtual int GetPts()
    {
        return _pointsValue;
    }

    public virtual void RecordEvent()
    {
        _isComplete = true;
    }

    public string GetTitle()
    {
        return _goalTitle;
    }

    public string GetDesc()
    {
        return _description;
    }
}