using System;

class Program
{
    static void Main(string[] args)
    {
        Jobs jobs1 = new Jobs();
        jobs1._company = "Del Taco";
        jobs1._jobTitle = "Manage";
        jobs1._startYear = 1706;
        jobs1._endYear = 2020;        
        jobs1.Display();

        Jobs jobs2 = new Jobs();
        jobs2._company = "Google";
        jobs2._jobTitle = "CTO";
        jobs2._startYear = 2020;
        jobs2._endYear = 20224;        
        jobs2.Display();

        Resume r = new Resume();
        r._name = "Logan Krogh";
        r._jobs.Add(jobs1);
        r._jobs.Add(jobs2);
        r.Display();
    }
}