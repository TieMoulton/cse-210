using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Del Taco";
        job1._jobTitle = "manager";
        job1._startYear = 1706;
        job1._endYear = 2020;
       

        Job job2 = new Job();
        job2._company = "apple";
        job2._jobTitle = "manager";
        job2._startYear = 2021;
        job2._endYear = 2024;

        Resume r = new Resume();
        r._name = "Ty moulton";

        r._jobs.Add(job1);
        r._jobs.Add(job2);
        r.Display();
       
    }
}