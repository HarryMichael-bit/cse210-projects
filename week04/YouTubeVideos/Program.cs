using System;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        List<Video> videos = new List<Video>();

        Video video1 = new Video("C# Programming Tutorial", "Michael Asamoah", 3600);
        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "I learned a lot!"));
        videos.Add(video1);

        Video video2 = new Video("Undertanding Abstraction in OOP", "CodingCraft", 520);
        video2.AddComment(new Comment("Dave", "This is a great explanation of abstraction."));
        video2.AddComment(new Comment("Eve", "I love how you explained this concept!"));
        video2.AddComment(new Comment("Frank", "Very clear and concise."));
        videos.Add(video2);

        Video video3 = new Video("Unity Game Development", "GameDevGuru", 7200);
        video3.AddComment(new Comment("Grace", "Awesome game development tips!"));
        video3.AddComment(new Comment("Heidi", "I can't wait to try these techniques!"));
        video3.AddComment(new Comment("Ivan", "This is exactly what I needed for my project."));
        videos.Add(video3);

        // Display video information and comments
        foreach (Video v in videos)
        {
            Console.WriteLine($"Title: {v.Title}");
            Console.WriteLine($"Author: {v.Author}");
            Console.WriteLine($"Length: {v.Length} seconds");
            Console.WriteLine($"Number of Comments: {v.GetNumberOfComments()}");

            foreach (Comment c in v.GetComments())
            {
                Console.WriteLine($" - {c.CommenterName}: {c.Text}");
            }
            Console.WriteLine("-----------------------------------");
        }

    }
}