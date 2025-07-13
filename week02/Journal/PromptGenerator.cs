using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> prompts = new List<string>();

    public PromptGenerator()
    {
        prompts = new List<string>
        {
            "What was the best part of your day?",
            "Who did I interact with today?",
            "Did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What challenges did I face today?",
        };
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        return prompts[random.Next(prompts.Count)];
    }

}
