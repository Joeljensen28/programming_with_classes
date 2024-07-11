public abstract class Question
{
    // The question/prompt that must be answered
    protected string _question;
    // How many points the question is worth
    protected int _points;
    // How many points the student earned
    protected float _pointsEarned;

    // Constructor for multiple choice (default)
    public Question(string question, int points)
    {
        _question = question;
        _points = points;
    }

    // Checks if they answered the question correct
    public abstract void CheckAnswer();
}