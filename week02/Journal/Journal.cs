using System;
using Microsoft.VisualBasic;
using System.Collections.Generic;

public class Journal
{
    private List<string> entries;

    public Journal()
    {
        entries = new List<string>();
    }

    public void AddEntry(string prompt, string response, string mood)
    {
        string date = DateTime.Now.ToString("yyyy-MM-dd");
        string entry = $"{date} | {prompt} | {response} | {mood}";
        entries.Add(entry);
    }

    public void DisplayJournal()
    {
        foreach (string entry in entries)
        {
            string[] parts = entry.Split('|');
            Console.WriteLine($"Date: {parts[0]}");
            Console.WriteLine($"Prompt: {parts[1]}");
            Console.WriteLine($"Response: {parts[2]}");
            Console.WriteLine($"Mood: {parts[3]}");
            Console.WriteLine("-------------------------------");
        }
    }

    public void SaveToFile(string filename)
    {
        System.IO.File.WriteAllLines(filename, entries);
        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadFromFile(string filename)
    {
        if (System.IO.File.Exists(filename))
        {
            entries = new List<string>(System.IO.File.ReadAllLines(filename));
            Console.WriteLine("Journal loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}