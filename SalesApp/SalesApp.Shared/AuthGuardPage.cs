using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Shared
{
    public class AuthGuardedPage : ComponentBase
    {
        [Inject]
        public AppState appstate { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (!appstate.IsLoggedIn)
            {
                NavigationManager.NavigateTo("/", forceLoad: true);
                return;
            }

        }
    }

}
