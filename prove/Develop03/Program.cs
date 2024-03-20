using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var scripture = new Scripture("John 3:16", "For God so loved the world, that he gave his only Son, that whoever believes in him should not perish but have eternal life.");
        var scriptureDisplayer = new ScriptureDisplayer(scripture);

        while (!scriptureDisplayer.AllWordsRevealed)
        {
            Console.Clear();
            scriptureDisplayer.Display();

            Console.WriteLine();
            Console.WriteLine("Press Enter to reveal more words or type 'quit' to exit.");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scriptureDisplayer.HideRandomWord();
        }

        Console.WriteLine();
        Console.WriteLine("All words have been revealed. Press Enter to exit.");
        Console.ReadLine();
    }
}

class Scripture
{
    public string Reference { get; }
    public string Text { get; }

    public Scripture(string reference, string text)
    {
        Reference = reference;
        Text = text;
    }

    public List<string> GetWords()
    {
        return Text.Split(' ').ToList();
    }
}

class ScriptureDisplayer
{
    private readonly Scripture _scripture;
    private readonly List<int> _hiddenIndices;

    public bool AllWordsRevealed => _hiddenIndices.Count >= _scripture.GetWords().Count;

    public ScriptureDisplayer(Scripture scripture)
    {
        _scripture = scripture;
        _hiddenIndices = new List<int>();
    }

    public void Display()
    {
        foreach (var word in _scripture.GetWords())
        {
            Console.Write(_hiddenIndices.Contains(_scripture.GetWords().IndexOf(word)) ? new string('*', word.Length) + " " : word + " ");
        }
    }
//
    public void HideRandomWord()
    {
        var words = _scripture.GetWords();
        var rand = new Random();
        int index = rand.Next(words.Count);

        if (!_hiddenIndices.Contains(index))
        {
            _hiddenIndices.Add(index);
        }
    }
}
