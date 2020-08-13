
namespace FPL.NET.Models.Cup
{
	public sealed class CupStatus
	{
		/// <summary>
		/// The game week in which the user qualified for the FPL cup.
		/// </summary>
		public int QualificationEvent { get; set; }

		/// <summary>
		/// The number of teams that qualified for the cup?
		/// </summary>
		public int QualificationNumbers { get; set; }

		/// <summary>
		/// The rank in which the user got to upon qualification for the FPL cup.
		/// </summary>
		public int QualificationRank { get; set; }

		/// <summary>
		/// Whether the user qualified or not.
		/// </summary>
		public string QualificationState { get; set; }
	}
}
