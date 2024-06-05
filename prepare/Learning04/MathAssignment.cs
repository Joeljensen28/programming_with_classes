using System.Reflection.PortableExecutable;

public class MathAssignment : Assignment
{
    private string _textbookSection;
    string _problems;

    public MathAssignment(string studentName, string topic, string textbookSection, string problems) : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public string GetHomework()
    {
        string homework = $"{_textbookSection} questions {_problems}";
        return homework;
    }
}