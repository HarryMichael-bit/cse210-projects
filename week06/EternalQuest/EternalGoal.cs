namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, string points)
            : base(name, description, int.Parse(points))
        {
        }

        public override void RecordEvent() { }

        public override bool IsComplete() => false;

        public override string GetDetailsString()
        {
            return $"[∞] {_shortName} ({_description})";
        }

        public override string GetStringRepresentation()
        {
            return $"EternalGoal:{_shortName}|{_description}|{_points}";
        }
    }
}
