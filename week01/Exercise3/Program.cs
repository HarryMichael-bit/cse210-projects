using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        // Generates a random number between 1 and 100
        int magicNumber = random.Next(1, 101);
        int guess = -1;

        // Loop until the user guesses the magic number
        do
        {
            // Ask the user for their guess
            Console.Write("What is the magic number? ");
            guess = int.Parse(Console.ReadLine());

            // Determine if the guess is higher, lower, or correct using if statements
            if (guess < magicNumber)
            {
                Console.WriteLine("Higher!");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower!");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }

        } while (guess != magicNumber);
    }
}