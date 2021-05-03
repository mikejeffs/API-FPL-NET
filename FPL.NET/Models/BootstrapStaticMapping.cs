using System.Collections.Generic;
using FPL.NET.Models.Gameweeks;

namespace FPL.NET.Models
{
    public sealed class BootstrapStaticMapping
    {
        public List<Gameweek> Events { get; set; }
        
        /// <summary>
        /// Months, i.e. September, plus 'Overall'
        /// </summary>
        public List<Phase> Phases { get; set; }
        
        public List<Team> Teams { get; set; }
        
        public List<Player> Elements { get; set; }
        
        public List<PlayerStats> ElementStats { get; set; }
        
        public List<PlayerPositionTypes> ElementTypes { get; set; }
        
        public TheGameSettings GameSettings { get; set; }

        public class Phase
        {
            public int Id { get; set; }
            
            public string Name { get; set; }
            
            public int StartEvent { get; set; }
            
            public int StopEvent { get; set; }
        }

        public class TheGameSettings
        {
            /// <summary>
            /// Max number of users in a private league.
            /// </summary>
            public int LeagueJoinPrivateMax { get; set; }
            
            /// <summary>
            /// Max number of users in a public league.
            /// </summary>
            public int LeagueJoinPublicMax { get; set; }
            
            /// <summary>
            /// Max number of users in a public classic league.
            /// </summary>
            public int LeagueMaxSizePublicClassic { get; set; }
            
            public int LeagueMaxSizePublicH2H { get; set; }
            
            public int LeagueMaxSizePrivateH2H { get; set; }
            
            public int LeagueMaxKoRoundsPrivateH2H	{ get; set; }
            
            public string LeaguePrefixPublic { get; set; }
            
            public int LeaguePointsH2HWin { get; set; }
            
            public int LeaguePointsH2HLose { get; set; }

            public int LeaguePointsH2HDraw { get; set; }
            
            public bool LeagueKoFirstInsteadOfRandom { get; set; }
            
            public int CupStartEventId { get; set; }
            
            public int CupStopEventId { get; set; }
            
            public string CupQualifyingMethod { get; set; }
            
            public string CupType { get; set; }
            
            public int SquadSquadplay { get; set; }
            
            public int SquadSquadsize { get; set; }
            
            public int SquadTeamLimit { get; set; }
            
            public int SquadTotalSpend { get; set; }
            
            public int UiCurrencyMultiplier { get; set; }
            
            public bool UiUseSpecialShirts { get; set; }
            
            public int[] UiSpecialShirtExclusions { get; set; }
            
            public int StatsFormDays { get; set; }
            
            public bool SysViceCaptainEnabled { get; set; }
            
            public int TransfersCap { get; set; }
            
            public double TransfersSellOnFee { get; set; }
            
            public string Timezone { get; set; }
            
            public List<string> LeagueH2hTiebreakStats { get; set; }

        }

        public class PlayerStats
        {
            public string Label { get; set; }
            
            public string Name { get; set; }
        }

        public class PlayerPositionTypes
        {
            public int Id { get; set; }
            
            public string PluralName { get; set; }
            
            public string PluralNameShort { get; set; }

            public string SingularName { get; set; }
            
            public string SingularNameShort { get; set; }
            
            public int SquadSelect { get; set; }
            
            public int SquadMinPlay { get; set; }

            public int SquadMaxPlay { get; set; }
            
            public bool UiShirtSpecific { get; set; }
            
            public int[] SubPostionsLocked { get; set; }
            
            public int ElementCount { get; set; }
        }
    }
}