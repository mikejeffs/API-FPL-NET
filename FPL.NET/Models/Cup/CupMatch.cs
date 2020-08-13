
namespace FPL.NET.Models.Cup
{
	public sealed class CupMatch
	{
		/// <summary>
		/// Unique identifier for this match.
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// User entry one's unique identifier (what a dumb name though!)
		/// </summary>
		public int Entry1Entry { get; set; }
      
		/// <summary>
		/// User entry one's team name.
		/// </summary>
		public string Entry1Name { get; set; }

		/// <summary>
		/// User entry one's name.
		/// </summary>
		public string Entry1PlayerName { get; set; }

		/// <summary>
		/// The number of points that user entry one got for the game week.
		/// </summary>
		public int Entry1Points { get; set; }

		/// <summary>
		/// Boolean flag to see if the user won the round.
		/// </summary>
		public bool Entry1Win { get; set; }

		/// <summary>
		/// Boolean flag to see if the user lost the round.
		/// </summary>
		public bool Entry1Loss { get; set; }

		/// <summary>
		/// Boolean flag to see if the user drew the round. (Facepalm)
		/// </summary>
		public bool Entry1Draw { get; set; }

		/// <summary>
		/// The number of round victories that entry one has in the FPL cup.
		/// </summary>
		public int Entry1Total { get; set; }

		/// <summary>
		/// User entry two's unique identifier (what a dumb name though!)
		/// </summary>
		public int Entry2Entry { get; set; }

		/// <summary>
		/// User entry two's team name.
		/// </summary>
		public string Entry2Name { get; set; }

		/// <summary>
		/// User entry two's name.
		/// </summary>
		public string Entry2PlayerName { get; set; }

		/// <summary>
		/// The number of points that user entry two got for the game week.
		/// </summary>
		public int Entry2Points { get; set; }

		/// <summary>
		/// Boolean flag to see if the user won the round.
		/// </summary>
		public bool Entry2Win { get; set; }

		/// <summary>
		/// Boolean flag to see if the user lost the round.
		/// </summary>
		public bool Entry2Loss { get; set; }

		/// <summary>
		/// Boolean flag to see if the user drew the round. (Facepalm)
		/// </summary>
		public bool Entry2Draw { get; set; }

		/// <summary>
		/// The number of round victories that entry two has in the FPL cup.
		/// </summary>
		public int Entry2Total { get; set; }

		/// <summary>
		/// Whether the match is a knockout round in the FPL cup.
		/// </summary>
		public bool IsKnockout { get; set; }
   
		/// <summary>
		/// The unique identifier for the user entry that won the match.
		/// </summary>
		public int Winner { get; set; }

		/// <summary>
		/// No idea what this is used for.
		/// </summary>
		public string SeedValue { get; set; }

		/// <summary>
		/// The gameweek in which the match occurred in.
		/// </summary>
		public int Event { get; set; }

		/// <summary>
		/// Used to determine who goes through to the next round in the FPL cup in the event 
		/// of a draw.
		/// </summary>
		public string Tiebreak { get; set; }
	}
}
