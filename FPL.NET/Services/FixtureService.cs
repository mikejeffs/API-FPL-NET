using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FPL.NET.Models;
using FPL.NET.Models.League;

namespace FPL.NET.Services
{
    public class FixtureService : BaseService
    {
        public FixtureService(HttpClient httpService) : base(httpService)
        {
            _baseApiUrl += "fixtures/";
        }
        
        public async Task<List<Fixture>> GetFixtures(int? gameweek = null)
        {
            SetHeaders();
            string url = gameweek != null ? $"{_baseApiUrl}?event={gameweek}" : _baseApiUrl;
            var response = await _httpClient.GetAsync(url);
            string data = await response.Content.ReadAsStringAsync();
            return DeserialiseObject<List<Fixture>>(data);
        }
        
        public async Task<Fixture> GetFixture(int fixtureId)
        {
            SetHeaders();
            var response = await _httpClient.GetAsync(_baseApiUrl);
            string data = await response.Content.ReadAsStringAsync();
            List<Fixture> fixtures = DeserialiseObject<List<Fixture>>(data);
            
            return fixtures.FirstOrDefault(f => f.Id == fixtureId);
        }

        public async Task<FixtureStats> GetPreciseStatsForFixture(int fixtureId, string statIdentifier)
        {
            Fixture fixture = await GetFixture(fixtureId);
            FixtureStats stats = fixture?.Stats.FirstOrDefault(s => s.Identifier == statIdentifier);
            
            return stats;
        }
        
    }
}