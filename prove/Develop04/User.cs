using System.Runtime.CompilerServices;

public class User
{
    // List of the user's current goals.
    private List<Goal> _currentGoals = new();
    // Total accrued points so far
    private int _points = 0;

    // Empty constructor by default
    public User(){}
    // Constructor contains _points so the program can initialize the user object based on points they've accrued from previous sessions
    public User(int points)
    {
        _points = points;
    }

    // Adds a goal to the list of goals
    public void AddGoal(Goal goal)
    {
        _currentGoals.Add(goal);
    }
    // Shows the list of goals
    public void ShowGoals()
    {
        int i = 0;
        foreach (Goal goal in _currentGoals)
        {
            i++;
            Console.Write($"{i}. ");
            goal.ShowGoal();
        }
    }
    // Retreives user's current points
    public int GetPts()
    {
        return _points;
    }
    // Adds the points to the user's total
    public void SetPts(int points)
    {
        _points += points;
    }
    // Gets the users current level with a simple square root function based on the user's current points. Rounds down to the nearest int.
    public int GetLevel()
    {
        int level = (int)(Math.Sqrt(_points) / 10);
        return level;
    }
    // Converts object to string format for writing
    public static string ConvertGoalToString(Goal goal)
    {
        if (goal is ChecklistGoal checklistGoal)
        {
            // Turns a checklist goal object into a string with the following format:
            // GoalType,goalTitle,goalDesc,goalPts,goalCompletionStatus,goalBonusPts,goalTimesDone,goalCompletionTimes
            // Example may look like:
            // "ChecklistGoal,Read a book,Read a book for 5 mins,20,false,50,2,3"
            string goalString = $"{checklistGoal},{checklistGoal.GetTitle()},{checklistGoal.GetDesc()},{checklistGoal.GetPts()},{checklistGoal.IsComplete()},{checklistGoal.GetBonusPoints()},{checklistGoal.GetTimesDone()},{checklistGoal.GetCompletionTimes()}";
            return goalString;
        }
        else
        {
            // Turns any other goal object into a string with the following format:
            // GoalType,goalTitle,goalDesc,goalPts,goalCompletionStatus
            // Example may look like:
            // "EternalGoal,Read a book,Read a book for 5 mins,20,false"
            string goalString = $"{goal},{goal.GetTitle()},{goal.GetDesc()},{goal.GetPts()},{goal.IsComplete()}";
            return goalString;
        }
    }
    // Takes a string and converts it to a goal object
    public static Goal ConvertStringToGoal(string goalString)
    {
        // Splits the line into an array of strings
        string[] goalData = goalString.Split(',');
        // Grab the first item in the array which will be the type of object it will convert to
        string goalType = goalData[0];
        // Uses goalType for conditional checks
        if (goalType == "EternalGoal")
        {
            // Grabs the rest of the data from the array and makes a new object
            string goalTitle = goalData[1];
            string goalDesc = goalData[2];
            int goalPoints = int.Parse(goalData[3]);
            EternalGoal newEternalGoal = new EternalGoal(goalTitle, goalDesc, goalPoints);
            return newEternalGoal;
        }
        else if (goalType == "ChecklistGoal")
        {
            // Grabs the rest of the data from the array and makes a new object
            string goalTitle = goalData[1];
            string goalDesc = goalData[2];
            int goalPoints = int.Parse(goalData[3]);
            bool goalCompletionStatus = bool.Parse(goalData[4]);
            int goalBonusPoints = int.Parse(goalData[5]);
            int goalTimesDone = int.Parse(goalData[6]);
            int goalCompletionTimes = int.Parse(goalData[7]);
            ChecklistGoal newChecklistGoal = new ChecklistGoal(goalTitle, goalDesc, goalPoints, goalCompletionStatus, goalBonusPoints, goalTimesDone, goalCompletionTimes);
            return newChecklistGoal;
        }
        // If the goalType is a simple goal
        else
        {
            // Grabs the rest of the data from the array and makes a new object
            string goalTitle = goalData[1];
            string goalDesc = goalData[2];
            int goalPoints = int.Parse(goalData[3]);
            bool goalCompletionStatus = bool.Parse(goalData[4]);
            Goal newSimpleGoal = new Goal(goalTitle, goalDesc, goalPoints, goalCompletionStatus);
            return newSimpleGoal;
        }
    }
    // Saves the accrued points and current list of goals to a .txt file. Program.cs will ask user for a file name which will then be passed into the parameters
    public void SaveState(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            // First thing on the .txt file will be the points accrued
            outputFile.WriteLine(_points);
            // Followed by each goal in their current list
            foreach (Goal goal in _currentGoals)
            {
                // Converts and writes each goal in string format as specified in ConvertGoalToString
                outputFile.WriteLine(ConvertGoalToString(goal));
            }
        }
    }
    // Loads total accrued points and previous list of goals from a .txt file.
    public void LoadState(string fileName)
    {
        // Read all the lines into an array of strings
        string[] lines = System.IO.File.ReadAllLines(fileName);
        // Take the first line and set it to the _points value
        _points = int.Parse(lines[0]);

        // Loop through the rest of the lines, converting each one to a new goal object and adding it to _currentGoals
        for (int i = 1; i < lines.Length; i++)
        {
            string goal = lines[i];
            Goal newGoal = ConvertStringToGoal(goal);
            _currentGoals.Add(newGoal);
        }
    }

    public List<Goal> GetGoals()
    {
        return _currentGoals;
    }
}