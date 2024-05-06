using System;
using System.Net.Http.Headers;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new();
        job1._company = "Macrohard";
        job1._jobTitle = "Hardware Reverse Engineer";
        job1._startYear = "1934";
        job1._endYear = "2096";

        Job job2 = new();
        job2._company = "Spacing Guild";
        job2._jobTitle = "Certified Mentat";
        job2._startYear = "1100";
        job2._endYear = "30021";

        Resume myResume = new();
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume._name = "Leto Atreides II";
        
        myResume.DisplayResume();
    }
}