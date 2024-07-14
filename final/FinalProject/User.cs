public class User
{
    // Tells us if user is a student or a teacher
    private string _userType;
    // List of quizzes they have created/can take, interacted with differently depending on `_userType`
    private List<Quiz> _quizzes = new();
    // Student's current grade in the class
    Grade _grade = new Grade();

    public User(string userType)
    {
        _userType = userType;
    }

    // Adds a quiz to the list of quizzes
    public void MakeQuiz(Quiz quiz)
    {
        _quizzes.Add(quiz);
    }
    // Set user type
    public void SetUserType(string userType)
    {
        _userType = userType;
    }
    public List<Quiz> GetQuizzes()
    {
        return _quizzes;
    }

    public List<Quiz> GetCompleteQuizzes()
    {
        List<Quiz> complete = new();
        foreach (Quiz quiz in _quizzes)
        {
            if (quiz.IsComplete())
            {
                complete.Add(quiz);
            }
        }
        return complete;
    }

    public float GetGradePercent()
    {
        float pointsEarned = 0;
        float pointsTotal = 0;
        foreach (Quiz quiz in _quizzes)
        {
            // Ensure scores are up to date
            quiz.CalculatePointsEarned();
            quiz.CalculatePointValue();
            float earned = quiz.GetPointsEarned();
            float total = quiz.GetAllPoints();
            pointsEarned += earned;
            pointsTotal += total;
        }

        return (pointsEarned / pointsTotal) * 100;
    }

    public void SetLetterGrade()
    {
        float pct = this.GetGradePercent();
        _grade.SetLetterGrade(pct);
    }

    public string GetLetterGrade()
    {
        return _grade.GetLetterGrade();
    }

    public List<Quiz> GetQuizzesNeedFeedback()
    {
        List<Quiz> complete = this.GetCompleteQuizzes();

        List<Quiz> needsFeedback = new();
        foreach (Quiz completeQuiz in complete)
        {
            if (!completeQuiz.HasFeedback())
            {
                needsFeedback.Add(completeQuiz);
            }
        }
        return needsFeedback;
    }
}