using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using FPL.NET.Http;

namespace API.FPL.NET.Http
{
    public static class ResponseFactory
    {
        public static IResponse Get(HttpResponseMessage response, string content, List<Cookie> cookies = null)
        {
	        var serviceResponse = new ServiceResponse
            {
                Ok = (response.StatusCode == HttpStatusCode.OK),
                Status = (int) response.StatusCode,
                Url = response.RequestMessage.RequestUri,
                Content = content,
            };
            
            foreach (var restResponseCookie in cookies)
            {
                serviceResponse.CookieJar.Add(new Cookie(restResponseCookie.Name, restResponseCookie.Value, restResponseCookie.Path, restResponseCookie.Domain));
            }

            return serviceResponse;
        }
    }
}
