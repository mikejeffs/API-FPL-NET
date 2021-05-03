using FPL.NET.Models.Fixtures;

namespace FPL.NET.Models.Players
{
    /// <summary>
    /// The fixture in which a player has played (or yet to play) in, with summary stats about the fixture.
    /// </summary>
    public sealed class PlayerSummaryFixture : Fixture
    {
        public string EventName { get; set; }
        
        public int Difficulty { get; set; }
    }
}