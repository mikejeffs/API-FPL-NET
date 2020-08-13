namespace FPL.NET.Models.User
{
    public sealed class UserTransfer
    {
        // {"element_in":460,"element_in_cost":72,"element_out":68,"element_out_cost":63,"entry":91928,"event":6,"time":"2019-09-14T23:15:30.089081Z"},

        /// <summary>
        /// Incoming player.
        /// </summary>
        public int ElementIn { get; set; }

        /// <summary>
        /// The price of the incoming player.
        /// </summary>
        public int ElementInCost { get; set; }

        /// <summary>
        /// Outgoing player.
        /// </summary>
        public int ElementOut { get; set; }

        /// <summary>
        /// The price of the outgoing player.
        /// </summary>
        public int ElementOutCost { get; set; }

        /// <summary>
        /// The gameweek in which this transfer took place.
        /// </summary>
        public int Event { get; set; }

        /// <summary>
        /// The time in which this transfer was made.
        /// </summary>
        public string Time { get; set; }

    }
}