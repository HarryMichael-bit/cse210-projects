namespace EternalQuest
{
    public abstract class Goal
    {
        protected string _shortName;
        protected string _description;
        protected int _points;

        // Expose points as a read-only property
        public int Points => _points;

        protected Goal(string name, string description, int points)
        {
            _shortName = name;
            _description = description;
            _points = points;
        }

        public abstract void RecordEvent();
        public abstract bool IsComplete();
        public abstract string GetDetailsString();
        public abstract string GetStringRepresentation();
    }
}