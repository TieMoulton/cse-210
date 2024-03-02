using System;
using System.Threading;

// Base class for all activities
abstract class Activity
{
    protected string name;
    protected string description;
    protected int duration;

    public Activity(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public abstract void Start();
    public abstract void End();

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

// Breathing activity
class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Start()
    {
        Console.WriteLine($"Starting {name}: {description}");
        Console.WriteLine("Please enter the duration of the activity in seconds:");
        duration = int.Parse(Console.ReadLine());

        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3); // Pause for 3 seconds
        Console.WriteLine("Begin:");

        int remainingTime = duration;
        while (remainingTime > 0)
        {
            Console.WriteLine("Breathe in...");
            ShowSpinner(2); // Pause for 2 seconds

            Console.WriteLine("Breathe out...");
            ShowSpinner(2); // Pause for 2 seconds

            remainingTime -= 4;
        }

        End();
    }

    public override void End()
    {
        Console.WriteLine("Good job! You have completed the Breathing Activity for {0} seconds.", duration);
        ShowSpinner(3); // Pause for 3 seconds
    }
}

// Reflection activity
class ReflectionActivity : Activity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public override void Start()
    {
        Console.WriteLine($"Starting {name}: {description}");
        Console.WriteLine("Please enter the duration of the activity in seconds:");
        duration = int.Parse(Console.ReadLine());

        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3); // Pause for 3 seconds
        Console.WriteLine("Begin:");

        int remainingTime = duration;
        Random rand = new Random();
        while (remainingTime > 0)
        {
            string prompt = prompts[rand.Next(prompts.Length)];
            Console.WriteLine(prompt);
            ShowSpinner(3); // Pause for 3 seconds

            foreach (string question in questions)
            {
                Console.WriteLine(question);
                ShowSpinner(3); // Pause for 3 seconds
            }

            remainingTime -= 24; // 4 seconds per prompt, 3 prompts per iteration
        }

        End();
    }

    public override void End()
    {
        Console.WriteLine("Good job! You have completed the Reflection Activity for {0} seconds.", duration);
        ShowSpinner(3); // Pause for 3 seconds
    }
}

// Listing activity
class ListingActivity : Activity
{
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public override void Start()
    {
        Console.WriteLine($"Starting {name}: {description}");
        Console.WriteLine("Please enter the duration of the activity in seconds:");
        duration = int.Parse(Console.ReadLine());

        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3); // Pause for 3 seconds
        Console.WriteLine("Begin:");

        int remainingTime = duration;
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Length)];
        Console.WriteLine(prompt);
        ShowSpinner(3); // Pause for 3 seconds

        Console.WriteLine("You may now start listing items. Press Enter after each item. Press Enter twice to finish.");

        int itemCount = 0;
        string input = Console.ReadLine();
        while (!string.IsNullOrEmpty(input))
        {
            itemCount++;
            input = Console.ReadLine();
        }

        Console.WriteLine($"You listed {itemCount} items.");
        End();
    }

    public override void End()
    {
        Console.WriteLine("Good job! You have completed the Listing Activity for {0} seconds.", duration);
        ShowSpinner(3); // Pause for 3 seconds
    }
}

// Main program
class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Please choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            int choice = int.Parse(Console.ReadLine());
            Activity activity;

            switch (choice)
            {
                case 1:
                    activity = new BreathingActivity();
                    break;
                case 2:
                    activity = new ReflectionActivity();
                    break;
                case 3:
                    activity = new ListingActivity();
                    break;
                case 4:
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
            }

            activity.Start();
        }
    }
}