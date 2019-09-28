using System;
using System.Net;
using FPL.NET.Http;
using RestSharp;

namespace API.FPL.NET.Http
{
    public class ResponseFactory
    {
        public static IResponse Get(IRestResponse response)
        {
            var serviceResponse = new ServiceResponse
            {
                Ok = (response.StatusCode == System.Net.HttpStatusCode.OK),
                Status = (int) response.StatusCode,
                Url = response.ResponseUri,
                Content = response.Content,
            };
            foreach (var restResponseCookie in response.Cookies)
            {
                serviceResponse.CookieJar.Add(new Cookie(restResponseCookie.Name, restResponseCookie.Value, restResponseCookie.Path, restResponseCookie.Domain));
            }

            return serviceResponse;
        }
    }
}
