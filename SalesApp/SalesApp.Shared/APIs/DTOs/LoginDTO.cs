using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Shared.APIs.DTOs
{
    public class TokenRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class TokenResponse
    {
        public string access_token { get; set; }
        public long expires_in { get; set; }
    }
}
