public class Feedback
{
    // The text content of the feedback
    private string _textContent;
    // When the feedback was given
    private DateTime _time = new();

    public Feedback(string textContent)
    {
        _textContent = textContent;
    }

    public void ShowFeedback()
    {
        Console.WriteLine($"{_time}\n\"{_textContent}\"");
    }
    public void SetTextContent(string textContent)
    {
        _textContent = textContent;
        _time = DateTime.Now;
    }
}