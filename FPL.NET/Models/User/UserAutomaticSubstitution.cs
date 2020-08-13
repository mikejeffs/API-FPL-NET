namespace FPL.NET.Models.User
{
    public sealed class UserAutomaticSubstitution
    {
        /// <summary>
        /// Gets or sets the player id brought in from the bench and into the team.
        /// </summary>
        public int ElementIn { get; set; }

        /// <summary>
        /// Gets or sets the player id who did not play and sends them to the bench.
        /// </summary>
        public int ElementOut { get; set; }
    }
}