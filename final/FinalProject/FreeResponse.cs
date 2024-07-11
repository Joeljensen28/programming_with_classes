public class FreeResponse : Question
{
    // The free response answer the student gave
    private string _studentAnswer;
    // Must be manually set to true or false by the teacher
    private bool _answeredCorrectly;

    public FreeResponse(string question, int points) : base(question, points){}

    public override void CheckAnswer()
    {
        Console.WriteLine("");
    }
}