using System.Collections.Generic;

namespace FPL.NET.Models.Cup
{
	public sealed class Cup
	{
		public List<CupMatch> CupMatches { get; set; }

		public CupStatus CupStatus { get; set; }
	}
}
