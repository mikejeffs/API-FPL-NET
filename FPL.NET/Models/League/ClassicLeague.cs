using System.Collections.Generic;

namespace FPL.NET.Models.League
{
    public sealed class ClassicLeague
    {
        /// <summary>
        /// ClassicLeague unique identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the league.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Determines if the league is invite-only.
        /// </summary>
        public bool Closed { get; set; }

        /// <summary>
        /// ???
        /// </summary>
        public string Rank { get; set; }

        /// <summary>
        /// The maximum number of participants for the league.
        /// </summary>
        public string MaxEntries { get; set; }

        /// <summary>
        /// ???
        /// </summary>
        public string LeagueType { get; set; }

        /// <summary>
        /// The gameweek in which the league is to start operating.
        /// </summary>
        public string StartEvent { get; set; }

        /// <summary>
        /// Gets or sets the users that belong to this classic league.
        /// </summary>
        public ClassicLeagueMapping.ClassicLeagueStandings Standings { get; set; }
    }
}