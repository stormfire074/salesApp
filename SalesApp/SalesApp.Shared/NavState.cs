using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace SalesApp.Shared
{
    public class NavState
    {
        private readonly NavigationManager navigationManager;

        public NavState(NavigationManager navigationManager)
        {
            this.navigationManager = navigationManager;
        }


        public event Func<Task>? OnChangeAsync;

        private bool isDrawerOpen;
        public bool IsDrawerOpen
        {
            get => isDrawerOpen;
            set
            {
                if (isDrawerOpen != value)
                {
                    isDrawerOpen = value;
                    NotifyStateChangedAsync();
                }
            }
        }

        private async void NotifyStateChangedAsync()
        {
            if (OnChangeAsync != null)
            {
                foreach (var handler in OnChangeAsync.GetInvocationList())
                {
                    try
                    {
                        var taskHandler = handler.DynamicInvoke() as Task;
                        if (taskHandler != null)
                        {
                            await taskHandler;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error notifying state change: {ex.Message}");
                    }
                }
            }
        }
    }
}
