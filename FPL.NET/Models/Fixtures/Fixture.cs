using System.Collections.Generic;

namespace FPL.NET.Models.Fixtures
{
    public class Fixture
    {
        /// <summary>
        /// Unique identifier of the fixture.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Fixture code.
        /// </summary>
        public int Code { get; set; }
        
        /// <summary>
        /// The gameweek number (1 - 38)
        /// </summary>
        public int Event { get; set; }
        
        /// <summary>
        /// Whether the fixture has completed or not.
        /// </summary>
        public bool Finished { get; set; }
        
        /// <summary>
        /// Fixture has provisionally finished or not.
        /// </summary>
        public bool FinishedProvisional { get; set; }
        
        /// <summary>
        /// DateTime in which the fixture started.
        /// </summary>
        public string KickoffTime { get; set; }
        
        /// <summary>
        /// How long the fixture lasted for in minutes.
        /// </summary>
        public int Minutes { get; set; }
        
        public bool ProvisionalStartTime { get; set; }
        
        /// <summary>
        /// Whether the fixture has started or not.
        /// </summary>
        public bool Started { get; set; }
        
        /// <summary>
        /// The id of the away team in the fixture.
        /// </summary>
        public int TeamA { get; set; }
        
        /// <summary>
        /// The goals scored by the away team in the fixture.
        /// </summary>
        public int TeamAScore { get; set; }
        
        /// <summary>
        /// The id of the home team in the fixture.
        /// </summary>
        public int TeamH { get; set; }
        
        /// <summary>
        /// The goals scored by the home team in the fixture.
        /// </summary>
        public int TeamHScore { get; set; }
        
        /// <summary>
        /// Fixture stats for both teams.
        /// </summary>
        public List<FixtureStats> Stats { get; set; }
        
        /// <summary>
        /// The difficulty of this team for the other team.
        /// </summary>
        public int TeamHDifficulty { get; set; }
        
        /// <summary>
        /// The difficulty of this team for the other team.
        /// </summary>
        public int TeamADifficulty { get; set; }
        
        /// <summary>
        /// ???
        /// </summary>
        public int PulseId { get; set; }
        
    }
}