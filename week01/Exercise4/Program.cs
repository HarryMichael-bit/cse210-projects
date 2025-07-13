using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a series of numbers. Type 0 to finish and calculate the result.");

        int userNumber = -1;
        while (userNumber != 0)
        {
            Console.Write("Enter a number (0 to quit): ");
            string userResponse = Console.ReadLine();
            userNumber = int.Parse(userResponse);

            // Only add the number to the list if it is not 0
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
                Console.WriteLine($"Added {userNumber} to the list.");
            }
        }

        // 1: Compute the sum of the numbers
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

        // 2: Compute the average of the numbers
        // Cast sum to float to ensure floating-point division for a precise average
        // Without this, integer division would truncate decimals
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // 3: Find the maximum number
        // Iterate through the list to find the maximum value
        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                // Update max if a larger number is found
                max = number;
            }
        }
        Console.WriteLine($"The maximum is: {max}");
    }
}