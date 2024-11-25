using System.Net.Http;

namespace SalesApp.Shared.APIs.Static
{
    public static class ConstantsHelper
    {
        public static string BaseUrl = "http://202.142.151.18:9950";
    }


    public class HttpClientHelper : IHttpClientHelper
    {
        private readonly HttpClient _httpClient;
        private readonly AppState _appState;

        public HttpClientHelper(AppState appState)
        {
            _appState = appState;

            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(ConstantsHelper.BaseUrl),
            };

            if(appState.IsLoggedIn)
            {
                _httpClient = appState.httpScope;
            }
        }

        public HttpClient HttpClient => _httpClient; // Property to expose HttpClient
    }

    public interface IHttpClientHelper
    {
       public HttpClient HttpClient { get; }
    }

}
