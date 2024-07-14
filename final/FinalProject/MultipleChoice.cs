using System.Formats.Asn1;

public class MultipleChoice : Question // Can be used as multiple choice or select all that apply
{
    // The correct answer. Stores as a list so when SelectAll inherits it can have multiple answers. Will only have 1 item for 
    // this class. Stored as a string, i.e. "A", "B", "C", or "D"
    protected List<string> _answers;
    // The student's answer. Similar to above, stored as a list of strings for inheritance.
    protected List<string> _studentAnswers = new List<string>();
    // Tells us if the student answered the question correctly
    protected bool _answeredCorrectly;
    // List of potential answers
    protected string[] _choices;
    // Array of letters to loop through when displaying the question
    protected string[] _letters = ["A", "B", "C", "D"];

    // Constructor for when object is created
    public MultipleChoice(string question, int points, List<string> answers, string[] choices) : base(question, points)
    {
        _answers = answers;
        _choices = choices;
    }

    // Sets _studentAnswer to what they gave
    public void AnswerQuestion(string studentAnswers)
    {
        _studentAnswers.Add(studentAnswers);
    }
    // Checks if student answered correctly and sets attribute accordingly
    public override void CheckAnswer()
    {
        if (_studentAnswers == _answers)
        {
            _answeredCorrectly = true;
        }
        else
        {
            _answeredCorrectly = false;
        }
    }
    // Calculates their points earned based on how many of the correct options they chose
    public override void CalculatePointsEarned()
    {
        // Calculate how many points each answer is by dividing the point value of the question by the number of correct 
        // answers
        float answerValue = _points / _answers.Count;
        foreach (string answer in _studentAnswers)
        {
            // Check if it is a correct answer
            if (_answers.Contains(answer))
            {
                // If so, give them points for choosing the right one
                _pointsEarned += answerValue;
            }
        }
        // Find the absolute difference between how many answers they chose and how many answers there were
        int difference = Math.Abs(_answers.Count - _studentAnswers.Count);
        // Remove points for any missing or extraneous answers
        _pointsEarned -= difference * answerValue;
        // Check that _pointsEarned is not less than 0
        if (_pointsEarned < 0)
        {
            // If it is, set it back to 0 so the student doesn't lose more points than the question is worth
            _pointsEarned = 0;
        }
        // Marks the question as graded
        _graded = true;
    }
    // Displays the question in quiz format
    public override void DisplayQuestionQuiz()
    {
        Console.WriteLine(_question);
        Console.WriteLine("\n");

        for (int i = 0; i < _choices.Length; i++)
        {
            string letter = _letters[i];
            string choice = _choices[i];
            Console.WriteLine($"{letter}. {choice}");
        }
    }
    // Displays the question in result format
    public override void DisplayQuestionResults()
    {
        Console.WriteLine(_question);
        Console.WriteLine("\n");

        for (int i = 0; i < _choices.Length; i++)
        {
            string letter = _letters[i];
            letter = letter.ToLower();
            string choice = _choices[i];
            if (_studentAnswers.Contains(letter) && !_answers.Contains(letter))
            {
                Console.WriteLine($"{letter}. {choice} X");
            }
            else if (_studentAnswers.Contains(letter) && _answers.Contains(letter))
            {
                Console.WriteLine($"{letter}. {choice} ✓");
            }
            else
            {
                Console.WriteLine($"{letter}. {choice}");
            }
        }

        Console.WriteLine($"{_pointsEarned}/{_points}\n");
    }
    // Sets the student's answer
    public override void SetStudentAnswer(string studentAnswers)
    {
        string[] parsed = studentAnswers.Split(", ");
        foreach (string answer in parsed)
        {
            _studentAnswers.Add(answer);
        }
    }
}