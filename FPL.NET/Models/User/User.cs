using System.Collections.Generic;

namespace FPL.NET.Models.User
{
    /// <summary>
    /// A fantasy league user account.
    /// </summary>
    public sealed class User
    {
        /// <summary>
        /// Users unique identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The users favourite team, expressed as a number value (i.e. 10 = Liverpool).
        /// </summary>
        public int FavouriteTeam { get; set; }

        /// <summary>
        /// The users first name.
        /// </summary>
        public string PlayerFirstName { get; set; }
       
        /// <summary>
        /// The users surname.
        /// </summary>
        public string PlayerLastName { get; set; }
        
        /// <summary>
        /// The country in which the user resides.
        /// </summary>
        public string PlayerRegionName { get; set; }
        
        /// <summary>
        /// The user overall points.
        /// </summary>
        public string SummaryOverallPoints { get; set; }
        
        /// <summary>
        /// The users overall global ranking.
        /// </summary>
        public string SummaryOverallRank { get; set; }
        
        /// <summary>
        /// The gameweek in which the user started playing.
        /// </summary>
        public string StartedEvent { get; set; }
        
        /// <summary>
        /// The Date/Time in which the user was created.
        /// </summary>
        public string JoinedTime { get; set; }
        
        /// <summary>
        /// The users current gameweek points.
        /// </summary>
        public string SummaryEventPoints { get; set; }
        
        /// <summary>
        /// The users current gameweek rank.
        /// </summary>
        public string SummaryEventRank { get; set; }
        
        /// <summary>
        /// The list of leagues that a user belongs to.
        /// </summary>
        // public ClassicLeagueMapping Leagues { get; set; } // TODO: Fix the json error with this.
        
        /// <summary>
        /// The users team name.
        /// </summary>
        public string Name { get; set; }
    }
}