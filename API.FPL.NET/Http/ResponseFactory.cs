using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using FPL.NET.Http;
using RestSharp;

namespace API.FPL.NET.Http
{
    public static class ResponseFactory
    {
        public static IResponse Get(HttpResponseMessage response, List<Cookie> cookies = null)
        {
            var serviceResponse = new ServiceResponse
            {
                Ok = (response.StatusCode == HttpStatusCode.OK),
                Status = (int) response.StatusCode,
                Url = response.RequestMessage.RequestUri,
                Content = response.Content.ToString(),
            };
            foreach (var restResponseCookie in cookies)
            {
                serviceResponse.CookieJar.Add(new Cookie(restResponseCookie.Name, restResponseCookie.Value, restResponseCookie.Path, restResponseCookie.Domain));
            }

            return serviceResponse;
        }

		public static IResponse Post(HttpResponseMessage response)
		{
			// var serviceResponse = new ServiceResponse
			// {
			// 	Ok = (response.StatusCode == HttpStatusCode.OK),
			// 	Status = (int)response.StatusCode,
			// 	Url = response.ResponseUri,
			// 	Content = response.Content,
			// };
			// foreach (var restResponseCookie in response.Cookies)
			// {
			// 	serviceResponse.CookieJar.Add(new Cookie(restResponseCookie.Name, restResponseCookie.Value, restResponseCookie.Path, restResponseCookie.Domain));
			// }
			//
			// return serviceResponse;
			return null;
		}
    }
}
