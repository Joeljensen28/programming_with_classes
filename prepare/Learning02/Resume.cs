public class Job
{
    public string _company;
    public string _jobTitle;
    public string _startYear;
    public string _endYear;

    public void DisplayJobInfo()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}

public class Resume
{
    public string _name;
    public List<Job> _jobs = new();

    public void DisplayResume()
    {
        Console.WriteLine($"{_name}");
        foreach (Job job in _jobs)
        {
            job.DisplayJobInfo();
        }
    }
}