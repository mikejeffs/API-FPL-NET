using System;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using FPL.NET.Http;
using RestSharp;

namespace API.FPL.NET.Http
{
    public class HttpService : IHttpService
    {
        public async Task<IObservable<IResponse>> Get(string url, IRequestOptions options = null)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            var cancellationTokenSource = new CancellationTokenSource();

            if (options != null)
            {
                foreach (var kvp in options.RequestHeaders.GetHeaders())
                {
                    request.AddHeader(kvp.Key, kvp.Value);
                }
            }

            IRestResponse response = await client.ExecuteGetTaskAsync(request, cancellationTokenSource.Token);
            return Observable.Start(() => ResponseFactory.Get(response));
        }

        public async Task<IObservable<IResponse>> Post(string url, object body, IRequestOptions options = null)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            var cancellationTokenSource = new CancellationTokenSource();

            if (options != null)
            {
                foreach (var kvp in options.RequestHeaders.GetHeaders())
                {
                    request.AddHeader(kvp.Key, kvp.Value);
                }
            }
			client.FollowRedirects = true;
            IRestResponse response = await client.ExecutePostTaskAsync(request, cancellationTokenSource.Token);
            return Observable.Start(() => ResponseFactory.Post(response));
        }
    }
}
