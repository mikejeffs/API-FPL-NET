using System.Collections.Generic;

namespace FPL.NET.Models.User
{
    public class UserAutomaticSubstitutions
    {
        /// <summary>
        /// Gets or sets the automatic subs made for a given gameweek in a users team.
        /// </summary>
        public List<UserAutomaticSubstitution> AutomaticSubs { get; set; }
    }
}