using System;
using FPL.NET.Http;
using RestSharp;

namespace API.FPL.NET.Http
{
    public class ResponseFactory
    {
        public static IResponse Get(IRestResponse response)
        {
            return new ServiceResponse
            {
                Ok = (response.StatusCode == System.Net.HttpStatusCode.OK),
                Status = (int)response.StatusCode,
                Url = response.ResponseUri,
                Content = response.Content,
            };
        }
    }
}
