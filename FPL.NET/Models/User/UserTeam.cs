namespace FPL.NET.Models.User
{
    /// <summary>
    /// The users fantasy team. Not be confused with a real life team, or 'club'.
    /// </summary>
    public sealed class UserTeam
    {
        /// <summary>
        /// The players that compose the users fantasy team.
        /// </summary>
        // public Player[] Picks { get; set; }

        /// <summary>
        /// Collection of chips available to the user.
        /// </summary>
        public Chip[] Chips { get; set; }

        /// <summary>
        /// Transfers made by the user for their team.
        /// </summary>
        public UserTeamTransfer[] Transfers { get; set; }

        // Defined as a public inner class as it won't likely by used elsewhere.
        public sealed class UserTeamTransfer
        {
            /// <summary>
            /// The cost of making a transfer (i.e. -4 for making one transfer.
            /// </summary>
            public int Cost { get; set; }

            /// <summary>
            /// The number of free transfers available to the users team.
            /// </summary>
            public string Status { get; set; }

            /// <summary>
            /// The maximum limit of transfers that can be made?
            /// </summary>
            public int Limit { get; set; }

            /// <summary>
            /// The number of transfers made.
            /// </summary>
            public int Made { get; set; }

            /// <summary>
            /// The amount of money left in the bank (ITB).
            /// </summary>
            public int Bank { get; set; }

            /// <summary>
            /// The total value of the users team. (Starting default is 100 million)
            /// </summary>
            public int Value { get; set; }
        }
    }
}