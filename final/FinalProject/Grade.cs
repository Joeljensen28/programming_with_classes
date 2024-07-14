public class Grade
{
    private string _letter;
    public void SetLetterGrade(float percent)
    {
        switch (percent)
        {
            case >= 93:
                _letter = "A";
                break;
            case >= 90:
                _letter = "-A";
                break;
            case >= 87:
                _letter = "+B";
                break;
            case >= 83: 
                _letter = "B";
                break;
            case >= 80:
                _letter = "-B";
                break;
            case >= 77:
                _letter = "+C";
                break;
            case >= 73:
                _letter = "C";
                break;
            case >= 70:
                _letter = "-C";
                break;
            case >= 67:
                _letter = "+D";
                break;
            case >= 63:
                _letter = "D";
                break;
            case >= 60:
                _letter = "-D";
                break;
            default:
                _letter = "F";
                break;
        }
    }

    public string GetLetterGrade()
    {
        return _letter;
    }
}