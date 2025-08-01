using System.Collections.Generic;

public class ReflectionActivity : MindfulnessActivity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time you did something difficult.",
        "Think of a time you helped someone in need.",
        "Think of a time you showed resilience in the face of adversity.",
    };

    private List<string> _questions = new List<string>
    {
        "Why was this meaningful?",
        "What did you learn from this experience?",
        "How did you feel afterwards?",
    };

    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on your life and the things that matter to you.") { }

    public override void Run()
    {
        StartActivity();
        Random rand = new Random();
        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
        int timeLeft = _duration;

        while (timeLeft > 0)
        {
            Console.WriteLine(_questions[rand.Next(_questions.Count)]);
            Spinner.Show(3);
            timeLeft -= 3;
        }
        EndActivity();
    }
}