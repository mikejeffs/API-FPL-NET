using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FPL.NET.Models.Cup;
using FPL.NET.Models.User;

namespace FPL.NET.Services
{
    public class UserEntryService : BaseService
    {
        private readonly string _userTeamEndpoint;
        private readonly string _watchlistEndpoint;

        public UserEntryService(HttpClient httpClient) : base(httpClient)
        {
            _watchlistEndpoint = _baseApiUrl + "me/";
            _userTeamEndpoint = _baseApiUrl + "my-team/";
            _baseApiUrl += "entry/";
        }

        // entry/{id}
        /// <summary>
        /// Returns a <see cref="FPL.NET.Models.User"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<User>GetUserEntry(int id)
        {
			SetHeaders();
            var response = await _httpClient.GetAsync($"{_baseApiUrl}{id}/");
            string userString = await response.Content.ReadAsStringAsync();
            return DeserialiseObject<User>(userString);
        }

        // entry/{id}/history
        /// <summary>
        /// Returns a <see cref="FPL.NET.Models.User" /> season history
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserHistory> GetUserSeasonHistory(int id)
        {
			SetHeaders();
			var response = await _httpClient.GetAsync($"{_baseApiUrl}/{id}/history");
			string result = await response.Content.ReadAsStringAsync();
			return DeserialiseObject<UserHistory>(result);
        }

        // entry/{id}/event/{eventId}/picks
        /// <summary>
        /// Returns a <see cref="FPL.NET.Models.User" /> player picks for a particular game week
        /// </summary>
        /// <param name="id"></param>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public async Task<UserEventPicks> GetUserPlayerPicksForEvent(int id, int eventId)
        {
			SetHeaders();
			var response = await _httpClient.GetAsync($"{_baseApiUrl}/{id}/event/{eventId}/picks");
			string result = await response.Content.ReadAsStringAsync();
			return DeserialiseObject<UserEventPicks>(result);
		}

        // my-team/{id}
        /// <summary>
        /// Returns a <see cref="FPL.NET.Models.User" /> team
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserTeam> GetUserTeam(int id)
        {
			SetHeaders();
			var response = await _httpClient.GetAsync($"{_userTeamEndpoint}{id}");
			string result = await response.Content.ReadAsStringAsync();
			return DeserialiseObject<UserTeam>(result);
		}

        // {id}/transfers
        /// <summary>
        /// Returns a list of transfers made by a user, either all transfers, or just the transfers for a given game week.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="gameweek"></param>
        /// <returns></returns>
        public async Task<List<UserTransfer>> GetUserTransfers(int id, int? gameweek = null)
        {
			SetHeaders();
			var response = await _httpClient.GetAsync($"{_baseApiUrl}/{id}/transfers/{gameweek}");
			string result = await response.Content.ReadAsStringAsync();
			return DeserialiseObject<List<UserTransfer>>(result);
		}

        // Get Cup /{id}/cup
		public async Task<Cup> GetUserCupStatus(int id)
		{
			SetHeaders();
			var response = await _httpClient.GetAsync($"{_baseApiUrl}/{id}/cup");
			string result = await response.Content.ReadAsStringAsync();
			return DeserialiseObject<Cup>(result);
		}

        // Watchlist /me
        public async Task<UserPlayerWatchlist> GetUserWatchlist()
        {
			SetHeaders();

            var response = await _httpClient.GetAsync(_watchlistEndpoint); // _httpService.Get($"{_baseApiUrl}{id}/", _headers);
            string userString = await response.Content.ReadAsStringAsync();
            return DeserialiseObject<UserPlayerWatchlist>(userString);
        }

        /// <summary>
        /// Returns the active chip used by a user for a given gameweek.
        /// </summary>
        /// <param name="gameweek"></param>
        /// <returns></returns>
        public async Task<UserActiveChip> GetActiveChipForGameweek(int id, int gameweek)
        {
			SetHeaders();
			var response = await _httpClient.GetAsync($"{_baseApiUrl}/{id}/event/{gameweek}/picks");
			string result = await response.Content.ReadAsStringAsync();
			return DeserialiseObject<UserActiveChip>(result);
		}

        /// <summary>
        /// Returns the automatic substitutions made for a users team for a given gameweek.
        /// </summary>
        /// <param name="gameweek"></param>
        /// <returns></returns>
        public async Task<UserAutomaticSubstitutions> GetAutomaticSubstitutionsForGameweek(int id, int gameweek)
        {
			SetHeaders();
			var response = await _httpClient.GetAsync($"{_baseApiUrl}/{id}/event/{gameweek}/picks");
			string result = await response.Content.ReadAsStringAsync();
			return DeserialiseObject<UserAutomaticSubstitutions>(result);
		}

        /// <summary>
        /// Returns the player picks made by a user for a given gameweek.
        /// </summary>
        /// <param name="gameweek"></param>
        /// <returns></returns>
        public async Task<UserPlayerPicks> GetPlayerPicksForGameweek(int id, int gameweek)
        {
			SetHeaders();
			var response = await _httpClient.GetAsync($"{_baseApiUrl}/{id}/event/{gameweek}/picks");
			string result = await response.Content.ReadAsStringAsync();
			return DeserialiseObject<UserPlayerPicks>(result);
		}

        // TODO: get_chips_history - returns {} at the moment.
        // TODO: get_gameweek_history - returns {} at the moment.
        // TODO: get_season_history - returns {} at the moment.
        // TODO: get_latest_transfers() - Requires login functionality to work.
        // TODO: set_captain - Requires post to work.
        // TODO: set_transfer - Requires post to work.
        // TODO: set_substitute - Requires post to work.
        // TODO: set_vice_captain - Requires post to work.

    }
}