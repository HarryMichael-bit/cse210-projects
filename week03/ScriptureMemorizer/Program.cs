using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways acknowledge Him, and He will make your paths straight.";
        Scripture scripture = new Scripture(reference, text);

        // Display and loop
        while (!scripture.IsFullyHidden())
        {
            scripture.Display();
            Console.WriteLine("Press Enter to hide more words, or type 'hint' for a clue or 'quit' to exit.");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit") break;

            if (input == "hint")
            {
                scripture.RevealHint();
            }
            else
            {
                scripture.HideRandomWords(3); // or whatever number you're comfortable with
            }
        }

        Console.WriteLine("All words are hidden! Good job!");
    }
}