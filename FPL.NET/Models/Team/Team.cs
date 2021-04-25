namespace FPL.NET.Models
{
    public class Team
    {
        public int Id { get; set; }
        public EventFixture CurrentEventFixture { get; set; }
        public EventFixture NextEventFixture { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public string ShortName { get; set; }
        public bool Unavailable { get; set; }
        public int Strength { get; set; }
        public int Position { get; set; }
        public int Played { get; set; }
        public int Win { get; set; }
        public int Loss { get; set; }
        public int Draw { get; set; }
        public int Points { get; set; }
        // public ?? Form { get; set; }
        public string LinkUrl { get; set; }
        public int StrengthOverallHome { get; set; }
        public int StrengthOverallAway { get; set; }
        public int StrengthAttackHome { get; set; }
        public int StrengthAttackAway { get; set; }
        public int StrengthDefenceHome { get; set; }
        public int StrengthDefenceAway { get; set; }
        public int TeamDivision { get; set; }

        public class EventFixture
        {
            public bool IsHome { get; set; }
            public int Month { get; set; }
            public int EventDay { get; set; }
            public int Id { get; set; }
            public int Day { get; set; }
            public int Opponent { get; set; }
        }
    }
}