using System;
using System.Threading;

public abstract class MindfulnessActivity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public MindfulnessActivity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void StartActivity()
    {
        Console.WriteLine($"Welcome to the {_name} activity!");
        Console.WriteLine(_description);
        Console.Write("Please enter the duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        Spinner.Show(3);
    }

    public void EndActivity()
    {
        Console.WriteLine("Well done! You have completed the activity.");
        Console.WriteLine($"You spent {_duration} seconds on this activity.");
        Spinner.Show(3);
    }

    public abstract void Run();
}