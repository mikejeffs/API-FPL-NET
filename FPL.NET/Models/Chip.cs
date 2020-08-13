namespace FPL.NET.Models
{
    /// <summary>
    /// This can be used to enhance a users team points accumulation for a given game week.
    /// Alternatively, it can be used to radically change a users team between game weeks.
    /// </summary>
    public class Chip
    {
        /// <summary>
        /// States whether the chip is available to play or not.
        /// </summary>
        public string StatusForEntry { get; set; }

        /// <summary>
        /// The game week in which a chip is played.
        /// </summary>
        public string[] PlayedByEntry { get; set; }

        /// <summary>
        /// The name of the chip. (e.g. 'boost' = Bench Boost.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The number of times that a chip can be activated.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// The first game week in which the chip can be activated in.
        /// </summary>
        public int StartEvent { get; set; }

        /// <summary>
        /// The last game week in which the chip can be activated in.
        /// </summary>
        public int StopEvent { get; set; }

        /// <summary>
        /// The type of chip.
        /// </summary>
        public string ChipType { get; set; }
    }
}