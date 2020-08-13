using System.Collections.Generic;

namespace FPL.NET.Models.League
{
    public class ClassicLeagueMapping
    {
        /// <summary>
        /// Gets or sets the classic league details.
        /// </summary>
        public ClassicLeague League { get; set; }

        /// <summary>
        /// Gets or sets the users that belong to this classic league.
        /// </summary>
        public ClassicLeagueStandings Standings { get; set; }

        public sealed class ClassicLeagueStandings
        {
            public int Page { get; set; } // TODO: Support leagues with multiple pages.
            public List<LeagueUser> Results { get; set; }
        }
    }
}