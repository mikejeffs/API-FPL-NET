using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FPL.NET.Models;

namespace FPL.NET.Services
{
    public class TeamService : BaseService
    {
        public TeamService(HttpClient httpClient) : base(httpClient)
        {
            _baseApiUrl += "teams/";
        }
        
        /// <summary>
        /// Returns a teams fixtures (endpoint not available?)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<TeamFixtures>> GetFixtures(int id)
        {
            SetHeaders();
            var response = await _httpClient.GetAsync($"{_baseApiUrl}/{id}"); // TODO: Not tested & endpoint not implemented
            string result = await response.Content.ReadAsStringAsync();
            return DeserialiseObject<List<TeamFixtures>>(result);
        }
        
        /// <summary>
        /// Returns a teams players (endpoint not available?)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<Player>> GetPlayers(int id)
        {
            SetHeaders();
            var response = await _httpClient.GetAsync($"{_baseApiUrl}/{id}"); // TODO: Not tested & endpoint not implemented
            string result = await response.Content.ReadAsStringAsync();
            return DeserialiseObject<List<Player>>(result);
        }
    }
}