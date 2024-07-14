public class FreeResponse : Question
{
    // The free response answer the student gave
    private string _studentAnswer;
    // Tells us if they answered correctly
    private bool _answeredCorrectly;

    public FreeResponse(string question, int points) : base(question, points){}

    // Returns student's answer to the free response question
    public string GetResponse()
    {
        return _studentAnswer;
    }
    // Checks how many points the teacher gave the student and determines if they answered correctly accordingly
    public override void CheckAnswer()
    {
        if (_pointsEarned != _points)
        {
            _answeredCorrectly = true;
        }
        else
        {
            _answeredCorrectly = false;
        }
    }
    // Method wherein the teacher grades the quiz
    public override void CalculatePointsEarned()
    {
        _pointsEarned = 0;
        _graded = false;
    }
    // Where teacher grades the question
    public void GradeResponse()
    {
        Console.WriteLine("Student response: \n");
        Console.WriteLine(_studentAnswer);
        Console.WriteLine($"\nPoints earned (out of {_points}): ");
        _pointsEarned = float.Parse(Console.ReadLine());
    }
    // Displays the question in quiz format
    public override void DisplayQuestionQuiz()
    {
        Console.WriteLine(_question);
        Console.WriteLine("\n");
    }
    // Displays question in result format
    public override void DisplayQuestionResults()
    {
        Console.WriteLine(_question);
        Console.WriteLine("\n");
        Console.WriteLine($"\"{_studentAnswer}\"");
        if (_graded)
        {
            Console.WriteLine($"{_pointsEarned}/{_points}\n");
        }
        else
        {
            Console.WriteLine("Needs grading.\n");
        }
    }
    // Sets the student's answer
    public override void SetStudentAnswer(string studentAnswer)
    {
        _studentAnswer = studentAnswer;
    }

    public void SetPtsEarned(int pts)
    {
        _pointsEarned = pts;
        _graded = true;
    }
}