using System.Net;

public class Quiz
{
    // Name of the quiz
    private string _quizName;
    // List of questions in the quiz
    private List<Question> _questions = new();
    // Total pts in quiz
    private int _totalPoints;
    // Total pts earned
    private float _pointsEarned;
    // Tells us if teacher has given feedback
    private bool _recievedFeedback = false;
    // Tells us if the quiz has been taken
    private bool _complete;
    // The teacher's feedback
    Feedback _feedback = new Feedback("No feedback yet.");

    public Quiz(string quizName, List<Question> questions)
    {
        _quizName = quizName;
        _questions = questions;
    }

    // Takes the quiz
    public void TakeQuiz()
    {
        Console.Clear();
        // First writes the name of the quiz
        Console.WriteLine($"{_quizName}\n");
        foreach (Question question in _questions)
        {
            // Displays each question in the quiz as question format
            question.DisplayQuestionQuiz();
            // Checks what kind of question it is and displays prompts accordingly
            if (question is SelectAll selectAllQuestion)
            {
                Console.WriteLine("Enter answer as letters separated by a comma and a space (, ): ");
                string response = Console.ReadLine().ToLower();
                selectAllQuestion.SetStudentAnswer(response);
                selectAllQuestion.CalculatePointsEarned();
            }
            else if (question is MultipleChoice multipleChoiceQuestion)
            {
                Console.WriteLine("Enter answer as a letter: ");
                string response = Console.ReadLine().ToLower();
                multipleChoiceQuestion.SetStudentAnswer(response);
                multipleChoiceQuestion.CalculatePointsEarned();
            }
            else if (question is FreeResponse freeResponseQuestion)
            {
                Console.WriteLine("Enter answer as free response: \n");
                string response = Console.ReadLine();
                freeResponseQuestion.SetStudentAnswer(response);
                freeResponseQuestion.CalculatePointsEarned();
            }
            Console.Clear();

        }
        _complete = true;
        this.CalculatePointsEarned();
        this.CalculatePointValue();
        float score = this.CalculateScore() * 100;
        Console.WriteLine($"Your score is {score}%");

        int pendingGrading = this.GetPendingGrading();
        Console.WriteLine($"{pendingGrading} questions pending grading.\n");

        Console.WriteLine("Press enter to return.");
        Console.ReadLine();
    }
    // Calculates pt value of the quiz
    public void CalculatePointValue()
    {
        int ptsSoFar = 0;
        foreach (Question question in _questions)
        {
            int pts = question.GetPointValue();
            ptsSoFar += pts;
        }
        _totalPoints = ptsSoFar;
    }
    // Calculates points earned on the quiz
    public void CalculatePointsEarned()
    {
       float ptsSoFar = 0;
        foreach (Question question in _questions)
        {
            float pts = question.GetPointsEarned();
            ptsSoFar += pts;
        }
        _pointsEarned = ptsSoFar; 
    }
    // Gets their total score
    public float CalculateScore()
    {
        return _pointsEarned / _totalPoints;
    }

    public void ReviewQuiz()
    {
        Console.Clear();
        // First writes the name of the quiz
        Console.WriteLine($"{_quizName}\n");
        foreach (Question question in _questions)
        {
            // Displays each question in the quiz as question format
            question.DisplayQuestionResults();
        }
        float score = this.CalculateScore() * 100;
        Console.WriteLine($"Score: {score}%");
        int pendingGrading = this.GetPendingGrading();
        Console.WriteLine($"{pendingGrading} questions pending grading.");
        if (this.HasFeedback())
        {
            _feedback.ShowFeedback();
        }
        else 
        {
            Console.WriteLine("No feedback yet.");
        }
    }
    // Calculates the number of questions on the quiz that need to be graded
    public int GetPendingGrading()
    {
        int pendingGrading = 0;
        foreach (Question question in _questions)
        {
            if (!question.IsGraded())
            {
                pendingGrading++;
            }
        }
        return pendingGrading;
    }
    // Returns all the questions
    public List<Question> GetQuestions()
    {
        return _questions;
    }
    // Has feedback
    public bool HasFeedback()
    {
        return _recievedFeedback;
    }
    // Sets the feedback
    public void SetFeedback(string feedback)
    {
        _feedback.SetTextContent(feedback);
        _recievedFeedback = true;
    }

    public string GetQuizName()
    {
        return _quizName;
    }

    public bool IsComplete()
    {
        return _complete;
    }

    public float GetPointsEarned()
    {
        return _pointsEarned;
    }

    public float GetAllPoints()
    {
        return _totalPoints;
    }
}