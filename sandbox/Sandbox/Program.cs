using System;

class Program
{
    static void Main(string[] args)
    {
        Person person = new Person();
        person._givenName = "Joseph";
        person._familyName = "Smith";
        person.ShowEasternName();
        person.ShowWesternName();
    }
}