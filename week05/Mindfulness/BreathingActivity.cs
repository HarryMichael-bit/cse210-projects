public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by guiding you through breathing exercises.") { }

    public override void Run()
    {
        StartActivity();
        for (int i = 0; i < _duration; i += 2)
        {
            Console.WriteLine("Breathe in...");
            Countdown.Show(1);
            Console.WriteLine("Breathe out...");
            Countdown.Show(1);
        }
        EndActivity();
        Console.WriteLine("Well done! You completed the breathing activity.");
    }
}