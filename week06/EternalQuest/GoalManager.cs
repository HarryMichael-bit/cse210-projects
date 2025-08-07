using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals = new List<Goal>();
        private int _score = 0;
        private Random _rand = new Random();

        // A handful of motivational quotes to display
        private static readonly string[] _quotes = new[]
        {
            "Keep going you're closer than you think!",
            "Every step counts. Well done!",
            "Your consistency is your superpower!."
        };

        public void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Current Score: {_score}\n");
                Console.WriteLine(
                    "1. Create Goal\n" +
                    "2. List Goal Names\n" +
                    "3. List Goal Details\n" +
                    "4. Record Event\n" +
                    "5. Save Goals\n" +
                    "6. Load Goals\n" +
                    "7. Quit"
                );
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": CreateGoal(); break;
                    case "2": ListGoalNames(); break;
                    case "3": ListGoalDetails(); break;
                    case "4": RecordEvent(); break;
                    case "5": SaveGoals(); break;
                    case "6": LoadGoals(); break;
                    case "7": return;
                    default:
                        Console.WriteLine("Please enter a valid option (1-7)");
                        break;
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }

        private void DisplayPlayerInfo()
        {
            Console.WriteLine($"Current Score: {_score}\n");
        }

        private void ListGoalNames()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals created yet.");
                return;
            }

            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }

        private void ListGoalDetails()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals created yet.");
                return;
            }

            foreach (var goal in _goals)
            {
                Console.WriteLine(goal.GetDetailsString());
            }
        }

        private void CreateGoal()
        {
            Console.WriteLine("Select goal type:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Choice: ");
            string type = Console.ReadLine();

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Description: ");
            string desc = Console.ReadLine();

            Console.WriteLine("Points on completion: ");
            int pts = int.Parse(Console.ReadLine());

            switch (type)
            {
                case "1":
                    _goals.Add(new SimpleGoal(name, desc, pts));
                    break;
                case "2":
                    _goals.Add(new EternalGoal(name, desc, pts.ToString()));
                    break;
                case "3":
                    Console.Write("Required completions: ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("Bonus points on completion: ");
                    int bonus = int.Parse(Console.ReadLine());
                    _goals.Add(new ChecklistGoal(name, desc, pts, target, bonus));
                    break;
                default:
                    Console.WriteLine("Invalid goal type.");
                    break;
            }
        }

        private void RecordEvent()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals to record. Create one first.");
                return;
            }

            ListGoalNames();
            Console.Write("Enter goal number: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index < 0 || index >= _goals.Count)
            {
                Console.WriteLine("Invalid goal number");
                return;
            }

            Goal goal = _goals[index];
            goal.RecordEvent();

            int earned = goal.Points;
            if (goal is ChecklistGoal cg && cg.IsComplete())
            {
                // add bonus only once
                earned += cg.BonusPoints;
            }

            _score += earned;
            Console.WriteLine($"\nYou earned {earned} point(s)!");

            // show a random motivational quote
            string quote = _quotes[_rand.Next(_quotes.Length)];
            Console.WriteLine($"\"{quote}\"\n");
        }

        private void SaveGoals()
        {
            using var writer = new StreamWriter("goals.txt");
            writer.WriteLine(_score);
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
            Console.WriteLine("Goals saved to goals.txt");
        }

        private void LoadGoals()
        {
            if (!File.Exists("goals.txt"))
            {
                Console.WriteLine("No save file found.");
                return;
            }

            _goals.Clear();
            string[] lines = File.ReadAllLines("goals.txt");
            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':', 2);
                string type = parts[0];
                string[] data = parts[1].Split('|');

                switch (type)
                {
                    case "SimpleGoal":
                        var sg = new SimpleGoal(
                         data[0],
                         data[1],
                         int.Parse(data[2])
                     );
                        if (bool.Parse(data[3]))
                            sg.RecordEvent();
                        _goals.Add(sg);
                        break;

                    case "EternalGoal":
                        _goals.Add(new EternalGoal(
                            data[0],
                            data[1],
                            data[2]
                        ));
                        break;

                    case "ChecklistGoal":
                        var cg = new ChecklistGoal(
                            data[0],
                            data[1],
                            int.Parse(data[2]),
                            int.Parse(data[3]),
                            int.Parse(data[4])
                        );
                        int completed = int.Parse(data[5]);
                        for (int j = 0; j < completed; j++)
                            cg.RecordEvent();
                        _goals.Add(cg);
                        break;
                }
            }

            Console.WriteLine("Goals loaded from goals.txt");
        }
    }
}