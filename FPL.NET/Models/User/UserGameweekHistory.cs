using System.Collections.Generic;

namespace FPL.NET.Models.User
{
    public sealed class UserGameweekHistory
    {
        public List<GameweekHistory> Current { get; set; }

        public class GameweekHistory
        {
            /// <summary>
            /// Gameweek number.
            /// </summary>
            public int Event { get; set; }
            
            /// <summary>
            /// number of points accumulated by the user for the gameweek.
            /// </summary>
            public int Points { get; set; }
            
            /// <summary>
            /// Total number of points accumulated by the user so far.
            /// </summary>
            public int TotalPoints { get; set; }
            
            /// <summary>
            /// Users gameweek ranking at the end of a gameweek.
            /// </summary>
            public int Rank { get; set; }
            
            /// <summary>
            /// ???
            /// </summary>
            public int RankSort { get; set; }
            
            /// <summary>
            /// Users overall global rank at the end of a gameweek.
            /// </summary>
            public int OverallRank { get; set; }

            
            /// <summary>
            /// Value left in the bank (not spent on players in the users team).
            /// </summary>
            public int Bank { get; set; }
            
            /// <summary>
            /// Total team value.
            /// </summary>
            public int Value { get; set; }
            
            /// <summary>
            /// The number of transfers made for the gameweek.
            /// </summary>
            public int EventTransfers { get; set; }
            
            /// <summary>
            /// The cost in points for the transfers made.
            /// </summary>
            public int EventTransfersCost { get; set; }

            /// <summary>
            /// Total number of points left on the bench for a gameweek.
            /// </summary>
            public int PointsOnBench { get; set; }





        }
    }
}