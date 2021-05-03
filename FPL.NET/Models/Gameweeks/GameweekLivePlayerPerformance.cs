using System.Collections.Generic;

namespace FPL.NET.Models.Gameweeks
{
    /// <summary>
    /// Data on player performance for a gameweek.
    /// </summary>
    public sealed class GameweekLivePlayerPerformance
    {
        /// <summary>
        /// Players unique identifier.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Players stats
        /// </summary>
        public GameweekLiveStats Stats { get; set; }
        
        // public List<GameweekLiveExplain> Explain { get; set; } // FIXME doesn't work.

        public class GameweekLiveStats
        {
            public int Minutes { get; set; }
            
            public int GoalsScored { get; set; }
            
            public int Assists { get; set; }
            
            public int CleanSheets { get; set; }
            
            public int GoalsConceded { get; set; }
            
            public int OwnGoals { get; set; }
            
            public int PenaltiesSaves { get; set; }
            
            public int PenaltiesMissed { get; set; }
            
            public int YellowCards { get; set; }
            
            public int RedCards { get; set; }
            
            public int Saves { get; set; }
            
            public int Bonus { get; set; }
            
            public int Bps { get; set; }
            
            public string Influence { get; set; }
            
            public string Creativity { get; set; }
            
            public string Threat { get; set; }
            
            public string IctIndex { get; set; }
            
            public int TotalPoints { get; set; }
            
            public bool InDreamTeam { get; set; }
        }

        public class GameweekLiveExplain
        {
            public int Fixture { get; set; }
            public ExplainStats Stats { get; set; }

            public class ExplainStats
            {
                public string Identifier { get; set; }
                public int Points { get; set; }
                public int Value { get; set; }
            }
        }
    }
}