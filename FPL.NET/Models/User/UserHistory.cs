namespace FPL.NET.Models.User
{
    public class UserHistory
    {
        /// <summary>
        /// Users history for the current season in play.
        /// </summary>
        public History[] Current { get; set; }

        /// <summary>
        /// Collection of data of the users previous season(s) performance.
        /// </summary>
        public History[] Past { get; set; }

        /// <summary>
        /// An array of chips used by the user over the course of the current season.
        /// </summary>
        // public object[] Chips { get; set; }

        public class History
        {
            /// <summary>
            /// Name of the season.
            /// </summary>
            public string SeasonName { get; set; }

            /// <summary>
            /// The total number of points that a user accumulated over the course of a season.
            /// </summary>
            public string TotalPoints { get; set; }

            /// <summary>
            /// The overall global rank achieved by a user for the season.
            /// </summary>
            public string Rank { get; set; }
        }
    }
}