namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _targetCount;
        private int _currentCount;
        private int _bonus;

        public int BonusPoints => _bonus;

        public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
            : base(name, description, points)
        {
            _targetCount = targetCount;
            _currentCount = 0;
            _bonus = bonus;
        }

        public override void RecordEvent()
        {
            _currentCount++;
        }

        public override bool IsComplete() => _currentCount >= _targetCount;

        public override string GetDetailsString() => $"[{(IsComplete() ? "X" : " ")}] {_shortName} ({_description}) -- Completed {_currentCount}/{_targetCount}";

        public override string GetStringRepresentation() => $"ChecklistGoal:{_shortName}|{_description}|{_points}|{_targetCount}|{_bonus}|{_currentCount}";
        
    }
}