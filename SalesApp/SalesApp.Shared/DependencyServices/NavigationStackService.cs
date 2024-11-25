using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace SalesApp.Shared.DependencyServices
{
    public class CustomNavigationManager
    {
        private readonly NavigationManager _navigationManager;
        private readonly List<string> _navigationStack = new(); // Backward navigation stack
        private readonly List<string> _forwardStack = new(); // Forward navigation stack
        private readonly AppState _appState;
        public CustomNavigationManager(NavigationManager navigationManager,AppState appState)
        {
            _appState = appState;
            _navigationManager = navigationManager;
        }

        public IReadOnlyList<string> NavigationStack => _navigationStack.AsReadOnly();
        public IReadOnlyList<string> ForwardStack => _forwardStack.AsReadOnly();

        // Navigate to a new page
        public void NavigateTo(string uri, bool forceLoad = false, bool replace = false)
        {
            if (!replace && _navigationManager.Uri != uri)
            {
                _navigationStack.Add(_navigationManager.Uri); // Track the current page before navigating
                _forwardStack.Clear(); // Clear forward stack when navigating to a new page
            }

            _navigationManager.NavigateTo(uri, forceLoad);
        }

        // Navigate back to the previous page
        public void NavigateBack()
        {
            if (_navigationStack.Count > 0)
            {
                var previousPage = _navigationStack[^1];
               
                if (!(_appState.IsLoggedIn && ( _navigationStack[0]==_navigationManager.BaseUri && _navigationStack.Count==1)))
                {
                    _navigationManager.NavigateTo(previousPage);
                    _navigationStack.RemoveAt(_navigationStack.Count - 1);
                    _forwardStack.Add(_navigationManager.Uri); // Add the current page to the forward stack
                }
               
            }
        }

        // Navigate forward to the next page
        public void NavigateForward()
        {
            if (_forwardStack.Count > 0)
            {
                var nextPage = _forwardStack[^1];
                _forwardStack.RemoveAt(_forwardStack.Count - 1);
                _navigationStack.Add(_navigationManager.Uri); // Add the current page to the back stack
                _navigationManager.NavigateTo(nextPage);
            }
        }

        // Clear the navigation stack
        public void ClearNavigationStack()
        {
            _navigationStack.Clear();
            _forwardStack.Clear();
        }

        // Expose the current URL
        public string CurrentUri => _navigationManager.Uri;
    }
}
