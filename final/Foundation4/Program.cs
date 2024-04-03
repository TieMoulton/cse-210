using System;
using System.Collections.Generic;

class Activity
{
    protected DateTime Date { get; set; }
    protected int Minutes { get; set; }

    public Activity(DateTime date, int minutes)
    {
        Date = date;
        Minutes = minutes;
    }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public virtual string GetSummary()
    {
        return $"{Date:dd MMM yyyy} ({Minutes} min)";
    }
}

class Running : Activity
{
    private double Distance { get; set; }

    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        Distance = distance;
    }

    public override double GetDistance()
    {
        return Distance;
    }

    public override double GetSpeed()
    {
        return Distance / Minutes * 60;
    }

    public override double GetPace()
    {
        return Minutes / Distance;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance: {Distance} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}

class Cycling : Activity
{
    private double Speed { get; set; }

    public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
    {
        Speed = speed;
    }

    public override double GetSpeed()
    {
        return Speed;
    }

    public override double GetPace()
    {
        return 60 / Speed;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Speed: {Speed} kph, Pace: {GetPace()} min per km";
    }
}

class Swimming : Activity
{
    private int Laps { get; set; }

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        Laps = laps;
    }

    public override double GetDistance()
    {
        return Laps * 50 / 1000;
    }

    public override double GetSpeed()
    {
        return GetDistance() / Minutes * 60;
    }

    public override double GetPace()
    {
        return Minutes / GetDistance();
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance: {GetDistance()} km, Speed: {GetSpeed()} kph, Pace: {GetPace()} min per km";
    }
}

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0),
            new Running(new DateTime(2022, 11, 3), 30, 4.8),
            new Cycling(new DateTime(2022, 11, 3), 30, 9.6),
            new Swimming(new DateTime(2022, 11, 3), 30, 20)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
