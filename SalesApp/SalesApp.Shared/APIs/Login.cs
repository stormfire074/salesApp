using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace SalesApp.Shared.APIs
{
    public class LoginController
    {

        HttpClient client;
        public LoginController()
        {
            client = new HttpClient();
        }
        public async Task<int> _Login(string username,string password)
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors) => true
            };

            using var client = new HttpClient(handler);

            var requestPayload = JsonSerializer.Serialize(new { Username = username, Password = password });

            var request = new HttpRequestMessage(HttpMethod.Post, "https://172.16.5.36:5000/api/auth/Login")
            {
                Content = new StringContent(requestPayload, Encoding.UTF8, "application/json")
            };

            var test = await client.SendAsync(request);

            if (test.IsSuccessStatusCode)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
