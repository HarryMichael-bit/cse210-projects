using System;

class Program
{
    static void Main(string[] args)
    {
        // Create jobs using constructor
        Job job1 = new Job("Software Developer", "Microsoft", 2019, 2022);
        Job job2 = new Job("Manager", "Amazon", 2022, 2023);

        // Create resume and assign jobs
        Resume resume = new Resume();
        resume._name = "Michael Asamoah";
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);

        // Display the resume information
        resume.Display();
    }
}