using Microsoft.AspNetCore.Components;
using SalesApp.Shared.APIs.DTOs;
using System;
using System.Threading.Tasks;

namespace SalesApp.Shared
{
    public class AppState
    {

        public AppState()
        {
        }

        public bool IsLoggedIn { get; set; }
        public TokenResponse Token { get; set; }
      
    }
}
