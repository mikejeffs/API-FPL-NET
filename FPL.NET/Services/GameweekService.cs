using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FPL.NET.Models;
using FPL.NET.Models.Gameweeks;

namespace FPL.NET.Services
{
    public class GameweekService : BaseService
    {
        public GameweekService(HttpClient httpClient) : base(httpClient)
        {
            _baseApiUrl += "event/";
        }
        
        public async Task<List<Gameweek>> GetGameweeks()
        {
            var bootstrapStaticData = await GetBootstrapStaticData();
            return bootstrapStaticData.Events;
        }
        
        public async Task<Gameweek> GetGameweek(int id)
        {
            SetHeaders();
            var response = await _httpClient.GetAsync(_bootstrapStaticUrl);
            string data = await response.Content.ReadAsStringAsync();
            var bootstrapStaticData = DeserialiseObject<BootstrapStaticMapping>(data);
            return bootstrapStaticData.Events.First(g => g.Id == id);
        }
        
        public async Task<GameweekLiveDataMapping> GetGameweekLivePlayerPerformances(int id)
        {
            SetHeaders();
            var response = await _httpClient.GetAsync($"{_baseApiUrl}/{id}/live");
            string data = await response.Content.ReadAsStringAsync();
            return DeserialiseObject<GameweekLiveDataMapping>(data);
        }
    }
}