using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using FPL.NET.Http;
using RestSharp;

namespace API.FPL.NET.Http
{
    public class HttpService : IHttpService
    {
        private static readonly CookieContainer CookieJar = new CookieContainer();
        private static readonly HttpClient Client;

        static HttpService()
        {
            var httpClientHandler = new HttpClientHandler
            {
                CookieContainer = CookieJar,
                UseCookies = true,
                UseDefaultCredentials = false
            };
            Client = new HttpClient(httpClientHandler);
        }
        
        
        public async Task<IObservable<IResponse>> Get(string url, IDictionary<string, string> headers = null)
        {
            // var cookieJar = new CookieContainer();
            // var handler = new HttpClientHandler
            // {
            //     CookieContainer = cookieJar,
            //     UseCookies = true,
            //     UseDefaultCredentials = false
            // };

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(url, UriKind.Absolute),
                Method = HttpMethod.Get,
                //Headers = headers
            };

            // if (headers != null)
            // {
            //     foreach (var kvp in headers)
            //     {
            //         request.Headers.Add(kvp.Key, kvp.Value);
            //     }
            // }
            
            var cancellationTokenSource = new CancellationTokenSource();
            
            HttpResponseMessage response =
                await Client.GetAsync(request.RequestUri, cancellationTokenSource.Token);
            List<Cookie> cookies = CookieJar.GetCookies(request.RequestUri).Cast<Cookie>().ToList();
            return Observable.Start(() => ResponseFactory.Get(response, cookies));

            // using (var client = new HttpClient(handler))
            // {
            //     HttpResponseMessage response =
            //         await client.GetAsync(request.RequestUri, cancellationTokenSource.Token);
            //     List<Cookie> cookies = cookieJar.GetCookies(request.RequestUri).Cast<Cookie>().ToList();
            //     return Observable.Start(() => ResponseFactory.Get(response, cookies));
            //     
            //     // HttpResponseMessage response = await client.SendAsync(request, cancellationTokenSource.Token);
            // }
        }

        public async Task<IObservable<IResponse>> Post(string url, object body, IDictionary<string, string> headers = null)
        {
   //          Uri uri = new Uri(url, UriKind.Absolute);
   //          var client = new RestClient(uri);
   //          var request = new RestRequest(Method.POST);
   //          var cancellationTokenSource = new CancellationTokenSource();
   //
   //          if (options != null)
   //          {
   //              foreach (var kvp in options.RequestHeaders.GetHeaders())
   //              {
   //                  request.AddHeader(kvp.Key, kvp.Value);
   //              }
   //          }
			// client.FollowRedirects = true;
   //          IRestResponse response = await client.ExecutePostTaskAsync(request, cancellationTokenSource.Token);
   //          return Observable.Start(() => ResponseFactory.Post(response));
   return null;
        }
    }
}
