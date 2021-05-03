using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FPL.NET.Services
{
    public abstract class BaseService
    {
        protected HttpClient _httpClient;
        protected IDictionary<string, string> _headers;
        protected string _baseApiUrl = @"https://fantasy.premierleague.com/api/";
        protected readonly string _bootstrapStaticUrl;
        
        protected BaseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
            };
            
            _headers = new Dictionary<string, string>
            {
                // { "Content-Type", "application/json" },
                { "Accept", "application/json" }
            };

            _bootstrapStaticUrl = _baseApiUrl + "bootstrap-static/";
        }

        protected T DeserialiseObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

		protected void SetHeaders()
		{
			foreach (var header in _headers)
			{
				_httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
			}
		}
    }
}