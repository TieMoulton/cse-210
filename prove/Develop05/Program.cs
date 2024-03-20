using System;
using System.Collections.Generic;


public abstract class Goal
{
    public string Name { get; set; }
    public int Value { get; set; }

    public Goal(string name, int value)
    {
        Name = name;
        Value = value;
    }

    public abstract void RecordEvent();
    public abstract string Progress();
}


public class SimpleGoal : Goal
{
    private bool completed = false;

    public SimpleGoal(string name, int value) : base(name, value)
    {
    }

    public override void RecordEvent()
    {
        completed = true;
    }

    public override string Progress()
    {
        return completed ? "[X]" : "[ ]";
    }
}

public class EternalGoal : Goal
{
    private int count = 0;

    public EternalGoal(string name, int value) : base(name, value)
    {
    }

    public override void RecordEvent()
    {
        count++;
    }

    public override string Progress()
    {
        return $"Completed {count} times";
    }
}


public class ChecklistGoal : Goal
{
    private int count = 0;
    private int requiredCount;

    public ChecklistGoal(string name, int value, int requiredCount) : base(name, value)
    {
        this.requiredCount = requiredCount;
    }

    public override void RecordEvent()
    {
        count++;
    }

    public override string Progress()
    {
        if (count < requiredCount)
        {
            return $"Completed {count}/{requiredCount} times";
        }
        else
        {
            return $"Completed {count}/{requiredCount} times. Bonus achieved!";
        }
    }
}

public class Program
{
    private static List<Goal> goals = new List<Goal>();
    private static int score = 0;

    public static void Main()
    {
    
        goals.Add(new SimpleGoal("Run a marathon", 1000));
        goals.Add(new EternalGoal("Read scriptures", 100));
        goals.Add(new ChecklistGoal("Attend the temple", 50, 10));

        
        goals[0].RecordEvent(); 
        goals[1].RecordEvent(); 
        goals[2].RecordEvent(); 

        
        foreach (var goal in goals)
        {
            Console.WriteLine($"{goal.Name}: {goal.Progress()}");
        }

        
        foreach (var goal in goals)
        {
            score += goal.Value;
        }
        Console.WriteLine($"Total Score: {score}");
    }
}
