using System.Net.Http;
using System.Threading.Tasks;
using FPL.NET.Models.League;

namespace FPL.NET.Services
{
    public class ClassicLeagueService : BaseService
    {
        public ClassicLeagueService(HttpClient httpService) : base(httpService)
        {
            _baseApiUrl += "leagues-classic/";
        }

        /// <summary>
        /// Returns the current standings of a classic league.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageNewEntries"></param>
        /// <param name="pageStandings"></param>
        /// <param name="phase"></param>
        /// <returns></returns>
        public async Task<ClassicLeagueMapping> GetStandings(int id, int pageNewEntries = 1, int pageStandings = 1,
            int phase = 1)
        {
            SetHeaders();
            var response = await _httpClient.GetAsync($"{_baseApiUrl}{id}/standings?page_new_entries={pageNewEntries}&page_standings={pageStandings}&phase={phase}");
            string data = await response.Content.ReadAsStringAsync();
            return DeserialiseObject<ClassicLeagueMapping>(data);
        }
    }
}