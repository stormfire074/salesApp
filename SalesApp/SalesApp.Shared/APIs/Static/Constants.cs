using System.Net.Http;

namespace SalesApp.Shared.APIs.Static
{
    public static class ConstantsHelper
    {
        public static string BaseUrl = "https://192.168.1.8:5000/api";
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
                // Add the Bearer Token
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _appState.Token.access_token);
            }
        }

        public HttpClient HttpClient => _httpClient; // Property to expose HttpClient
    }

    public interface IHttpClientHelper
    {
       public HttpClient HttpClient { get; }
    }

}
