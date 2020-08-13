namespace FPL.NET.Models.User
{
    public sealed class UserPlayerPick
    {
        /// <summary>
        /// Gets or sets the player id.
        /// </summary>
        public int Element { get; set; }

        /// <summary>
        /// Gets or sets the player team position.
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// Gets or sets the players points multiplier.
        /// </summary>
        public int Multiplier { get; set; }

        /// <summary>
        /// Gets or sets a player to be captain of the team.
        /// </summary>
        public bool IsCaptain { get; set; }

        /// <summary>
        /// Gets or sets a player to be vice-captain of the team.
        /// </summary>
        public bool IsViceCaptain { get; set; }
    }
}