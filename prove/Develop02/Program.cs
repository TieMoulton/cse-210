using System;
using System.Collections.Generic;
using System.IO;

class JournalProgram
{
    static Journal journal = new Journal();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice (1-5): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry();
                    break;

                case "2":
                    DisplayJournal();
                    break;

                case "3":
                    SaveJournal();
                    break;

                case "4":
                    LoadJournal();
                    break;

                case "5":
                    Console.WriteLine("Exiting the program. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }

            // Add a line break for better readability
            Console.WriteLine();
        }
    }

    static void WriteNewEntry()
    {
        PromptGenerator promptGenerator = new PromptGenerator();
        string prompt = promptGenerator.GetRandomPrompt();

        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        JournalEntry newEntry = new JournalEntry(DateTime.Now, prompt, response);
        journal.AddEntry(newEntry);

        Console.WriteLine("Entry added successfully!");
    }

    static void DisplayJournal()
    {
        Console.WriteLine("Journal Entries:");
        foreach (JournalEntry entry in journal.Entries)
        {
            Console.WriteLine(entry);
        }
    }

    static void SaveJournal()
    {
        Console.Write("Enter the filename to save the journal: ");
        string filename = Console.ReadLine();

        try
        {
            journal.SaveToFile(filename);
            Console.WriteLine("Journal saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving the journal: {ex.Message}");
        }
    }

    static void LoadJournal()
    {
        Console.Write("Enter the filename to load the journal from: ");
        string filename = Console.ReadLine();

        try
        {
            journal.LoadFromFile(filename);
            Console.WriteLine("Journal loaded successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading the journal: {ex.Message}");
        }
    }
}

class Journal
{
    public List<JournalEntry> Entries { get; } = new List<JournalEntry>();

    public void AddEntry(JournalEntry entry)
    {
        Entries.Add(entry);
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (JournalEntry entry in Entries)
            {
                writer.WriteLine(entry.ToString());
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        List<JournalEntry> loadedEntries = new List<JournalEntry>();

        using (StreamReader reader = new StreamReader(filename))
        {
            while (!reader.EndOfStream)
            {
                string entryString = reader.ReadLine();
                JournalEntry entry = JournalEntry.Parse(entryString);
                loadedEntries.Add(entry);
            }
        }

        Entries.Clear();
        Entries.AddRange(loadedEntries);
    }
}

class JournalEntry
{
    public DateTime Date { get; }
    public string Prompt { get; }
    public string Response { get; }

    public JournalEntry(DateTime date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    public override string ToString()
    {
        return $"Date: {Date}, Prompt: {Prompt}, Response: {Response}";
    }

    public static JournalEntry Parse(string entryString)
    {
        string[] parts = entryString.Split(',');
        DateTime date = DateTime.Parse(parts[0].Substring(parts[0].IndexOf(':') + 2));
        string prompt = parts[1].Substring(parts[1].IndexOf(':') + 2);
        string response = parts[2].Substring(parts[2].IndexOf(':') + 2);
        return new JournalEntry(date, prompt, response);
    }
}

class PromptGenerator
{
    private string[] prompts = {
        "Write about a memorable moment from your childhood.",
        "Describe a goal you want to achieve in the next year.",
        "What is your favorite book and why?",
        "If you could travel anywhere in the world, where would you go?",
        "What is a skill you would like to learn and why?",
        // Add more prompts as needed
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int randomIndex = random.Next(0, prompts.Length);
        return prompts[randomIndex];
    }
}