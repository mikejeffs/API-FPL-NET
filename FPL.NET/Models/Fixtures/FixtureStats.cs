using System.Collections.Generic;

namespace FPL.NET.Models
{
    public sealed class FixtureStats
    {
        public string Identifier { get; set; }
        
        /// <summary>
        /// Stats for the away team.
        /// </summary>
        public List<FixtureStatsTeamValue> A { get; set; }
        
        /// <summary>
        /// Stats for the home team.
        /// </summary>
        public List<FixtureStatsTeamValue> H { get; set; }

        public class FixtureStatsTeamValue
        {
            /// <summary>
            /// The value of the stat for a given team, i.e. number of goals scored by a player for a team in the fixture, or amount of assists, yellow cards, etc.
            /// </summary>
            public int Value { get; set; }
            
            /// <summary>
            /// Id of the player.
            /// </summary>
            public int Element { get; set; }
        }
    }
}