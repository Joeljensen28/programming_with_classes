public class MultipleChoice : Question // Can be used as multiple choice or select all that apply
{
    // The correct answer. Stores as a list so when SelectAll inherits it can have multiple answers. Will only have 1 item for 
    // this class. Stored as a string, i.e. "A", "B", "C", or "D"
    private List<string> _answers;
    // The student's answer. Similar to above, stored as a list of strings for inheritance.
    private List<string> _studentAnswers;
    // Tells us if the student answered the question correctly
    private bool _answeredCorrectly;
    // List of potential answers
    private List<string> _choices;

    // Constructor for when object is created
    public MultipleChoice(string question, int points, List<string> answers, List<string> choices) : base(question, points)
    {
        _answers = answers;
        _choices = choices;
    }

    // Sets _studentAnswer to what they gave
    public void AnswerQuestion(string studentAnswers)
    {
        _studentAnswers.Add(studentAnswers);
    }
    // Checks if student answered correctly
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
}