using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FPL.NET.Models;
using FPL.NET.Models.Players;

namespace FPL.NET.Services
{
    public sealed class PlayerService : BaseService
    {
        public PlayerService(HttpClient httpService) : base(httpService)
        {
            _baseApiUrl += "element-summary/";
        }
        
        public async Task<PlayerSummaryFixtureMapping> GetPlayerFixtureSummary(int id)
        {
            SetHeaders();
            var response = await _httpClient.GetAsync($"{_baseApiUrl}/{id}/");
            string data = await response.Content.ReadAsStringAsync();
            return DeserialiseObject<PlayerSummaryFixtureMapping>(data);
        }
        
        public async Task<List<Player>> GetPlayers()
        {
            BootstrapStaticMapping data = await GetBootstrapStaticData();
            return data.Elements;
        }
    }
}