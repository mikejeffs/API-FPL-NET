namespace FPL.NET.Models.League
{
    public sealed class LeagueUser
    {
        // {"id":1626433,"event_total":0,"player_name":"Mike Pratt","rank":1,"last_rank":1,"rank_sort":1,"total":352,"entry":12710,"entry_name":"Klopptimus Prime 6⭐️"}

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public int Entry { get; set; }
        
        /// <summary>
        /// Gets or sets the users team name.
        /// </summary>
        public string EntryName { get; set; }

        /// <summary>
        /// Gets or sets the users name.
        /// </summary>
        public string PlayerName { get; set; }

        /// <summary>
        /// Gets or sets the gameweek total points accumulated by the user.
        /// </summary>
        public int EventTotal { get; set; }

        /// <summary>
        /// The users current rank in this league.
        /// </summary>
        public string Rank { get; set; }

        /// <summary>
        /// The users rank in the previous game week for this league.
        /// </summary>
        public string LastRank { get; set; }

        /// <summary>
        /// Gets or sets the total number of points accumulated by the user to date.
        /// </summary>
        public int Total { get; set; }
    }
}