using System.Collections.Generic;

namespace FPL.NET.Models.Gameweeks
{
    public sealed class Gameweek
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Name of the gameweek (Gameweek 1).
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Date time in which no more changes can be made to a users team before the gameweek starts.
        /// </summary>
        public string DeadlineTime { get; set; }
        
        /// <summary>
        /// Average score of all users participating in this gameweek.
        /// </summary>
        public int AverageEntryScore { get; set; }
        
        
        public bool Finished { get; set; }
        
        public bool DataChecked { get; set; }
        
        /// <summary>
        /// User who scored the most points for this gameweek.
        /// </summary>
        public int HighestScoringEntry { get; set; }
        
        
        public long DeadlineTimeEpoch { get; set; }
        
        public int DeadlineTimeGameOffset { get; set; }

        public int HighestScore { get; set; }
        
        public bool IsPrevious { get; set; }
        
        public bool IsCurrent { get; set; }
        
        public bool IsNext { get; set; }
        
        /// <summary>
        /// Most selected player in this gameweek by users.
        /// </summary>
        public int MostSelected { get; set; }
        
        /// <summary>
        /// The player who has been transferred into users teams the most for this gameweek.
        /// </summary>
        public int MostTransferredIn { get; set; }
        
        /// <summary>
        /// The highest scoring player for this gameweek.
        /// </summary>
        public int TopElement { get; set; }
        
        /// <summary>
        /// Id and points scored by the highest scoring player for this gameweek.
        /// </summary>
        public GameweekHighestScoringPlayerInfo TopElementInfo { get; set; }
        
        /// <summary>
        /// Number of total transfers made for this gameweek by all users.
        /// </summary>
        public int TransfersMade { get; set; }
        
        /// <summary>
        /// Player id who has been the selected as captain the most by users for this gameweek
        /// </summary>
        public int MostCaptained { get; set; }
        
        /// <summary>
        /// Player id who has been the selected as vice-captain the most by users for this gameweek
        /// </summary>
        public int MostViceCaptained { get; set; }
        
        public List<GameweekChipPlays> ChipPlays { get; set; }

        public class GameweekHighestScoringPlayerInfo
        {
            /// <summary>
            /// Id of the player.
            /// </summary>
            public int Id { get; set; }
            
            /// <summary>
            /// The number of points the top player accumulated for a given gameweek.
            /// </summary>
            public int Points { get; set; }
        }

        public class GameweekChipPlays
        {
            /// <summary>
            /// The name of the chip played by users during the gameweek.
            /// </summary>
            public string ChipName { get; set; }
            
            /// <summary>
            /// The total number of users who played this chip for this gameweek.
            /// </summary>
            public int NumPlayed { get; set; }
        }
        
    }
}