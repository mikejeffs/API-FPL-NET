using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using FPL.NET.Exceptions;
using FPL.NET.Extensions;
using FPL.NET.Http;
using RestSharp;

namespace API.FPL.NET.Http
{
    public sealed class HttpService : IHttpService
    {
        private readonly CookieContainer _cookieJar = new CookieContainer();
        private readonly HttpClient _client;

        public HttpService()
        {
            var httpClientHandler = new HttpClientHandler
            {
                CookieContainer = _cookieJar,
                UseCookies = true,
                UseDefaultCredentials = false
            };
            _client = new HttpClient(httpClientHandler);
        }
        
        
        public async Task<IObservable<IResponse>> Get(string url, IDictionary<string, string> headers = null)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(url, UriKind.Absolute),
                Method = HttpMethod.Get,
            };

            if (headers != null)
            {
                foreach (var kvp in headers)
                {
                    request.Headers.Add(kvp.Key, kvp.Value);
                }
            }
            
            var cancellationTokenSource = new CancellationTokenSource();
            
            HttpResponseMessage response =
                await _client.SendAsync(request, cancellationTokenSource.Token);
            
            List<Cookie> cookies = _cookieJar.GetCookies(request.RequestUri).Cast<Cookie>().ToList();
            
            string responseContentString = await response.Content.ReadAsStringAsync();
            
            return Observable.Start(() => ResponseFactory.Get(response, responseContentString, cookies));
        }

        public async Task<IObservable<IResponse>> Post(string url, object body, IDictionary<string, string> headers = null)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(url, UriKind.Absolute),
                Method = HttpMethod.Post,
                Content = (HttpContent) body,
            };

            if (headers != null)
            {
                foreach (var kvp in headers)
                {
                    request.Headers.Add(kvp.Key, kvp.Value);
                }
            }
            
            var cancellationTokenSource = new CancellationTokenSource();
            
            HttpResponseMessage response =
                await _client.SendAsync(request, cancellationTokenSource.Token);

            List<Cookie> cookies = _cookieJar.GetAllCookies(); // .GetCookies(request.RequestUri).Cast<Cookie>().ToList();
            bool verifiedCookies = VerifyAuthCookies(cookies, "sessionid", "pl_profile", "csrftoken");
            if (!verifiedCookies)
            {
                throw new FplException("Invalid Cookies!");
            }
            
            string responseContentString = await response.Content.ReadAsStringAsync();
            
            return Observable.Start(() => ResponseFactory.Get(response, responseContentString, cookies));
        }
        
        private bool VerifyAuthCookies(List<Cookie> usersCookies, params string[] cookieNames)
        {
            if (!usersCookies.Any())
            {
                return false;
            }

            foreach (var cookieName in cookieNames)
            {
                if (usersCookies.All(c => c.Name != cookieName))
                {
                    var allCookies = string.Join("\n", usersCookies.OrderBy(c => c.Domain).Select(c => $"[{c.Domain}]{c.Name} : {c.Value}"));
                    var error = $"Missing {cookieName} cookie! Cookies :\n{allCookies}";
                    return false;
                }
            }

            return true;
        }
    }
}
