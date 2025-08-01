using System.Collections.Generic;

public class ListingActivity : MindfulnessActivity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths you have?",
        "What are things that made you smile today?",
    };

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by listing them.") { }

    public override void Run()
    {
        StartActivity();
        Random rand = new Random();
        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
        Countdown.Show(3);

        Console.WriteLine("Start listing items:");
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                items.Add(input);
            }

            Console.WriteLine($"You listed {items.Count} items!");
            EndActivity();
        }
    }
}