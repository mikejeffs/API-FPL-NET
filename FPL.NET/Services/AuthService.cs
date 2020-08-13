using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FPL.NET.Models.DataTransferObjects;

namespace FPL.NET.Services
{
    public class AuthService : BaseService
    {
        private readonly string _loginUrl = "https://users.premierleague.com/accounts/login/";

        public AuthService(HttpClient httpClient) : base(httpClient)
        {
            _headers["Referer"] = "https://fantasy.premierleague.com";
            _headers["Origin"] = "https://fantasy.premierleague.com";
        }

        public async Task<string> Login(LoginDto login)
        {
            var body = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["login"] = login.Login,
                ["password"] = login.Password,
                ["app"] = "plfpl-web",
                ["redirect_uri"] = "https://fantasy.premierleague.com/"
            });

            foreach (var header in _headers)
            {
                _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
            }

            var response = await _httpClient.PostAsync("https://users.premierleague.com/accounts/login/",
                body);

            string resp = await response.Content.ReadAsStringAsync();
            return resp;

        }
    }
}