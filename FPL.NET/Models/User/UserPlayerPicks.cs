using System.Collections.Generic;

namespace FPL.NET.Models.User
{
    public sealed class UserPlayerPicks
    {
        /// <summary>
        /// Gets or sets the picks of a users team for a given game week.
        /// </summary>
        public List<UserPlayerPick> Picks { get; set; }
    }
}