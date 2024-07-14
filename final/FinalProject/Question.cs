public abstract class Question
{
    // The question/prompt that must be answered
    protected string _question;
    // How many points the question is worth
    protected int _points;
    // How many points the student earned
    protected float _pointsEarned;
    // Tells us if the question is graded
    protected bool _graded;

    // Constructor for multiple choice (default)
    public Question(string question, int points)
    {
        _question = question;
        _points = points;
    }

    public abstract void CheckAnswer();
    public abstract void CalculatePointsEarned();
    public abstract void DisplayQuestionQuiz();
    public abstract void DisplayQuestionResults();
    public abstract void SetStudentAnswer(string studentAnswers);
    public int GetPointValue()
    {
        return _points;
    }
    public float GetPointsEarned()
    {
        return _pointsEarned;
    }
    public bool IsGraded()
    {
        return _graded;
    }
}