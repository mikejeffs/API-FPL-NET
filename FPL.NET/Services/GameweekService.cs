using System.Net.Http;

namespace FPL.NET.Services
{
    public class GameweekService : BaseService
    {
        public GameweekService(HttpClient httpClient) : base(httpClient)
        {
            _baseApiUrl += "event/";
        }

        // TODO: The following endpoints are not currently available as of 13/07/19 as the season has not started yet.
        // This data is not relevant for my purposes. If someone wants these implemented in the future then I will do so.

        // /events

        // /events/{id}/live

        // /fixtures/?event={eventId}
    }
}