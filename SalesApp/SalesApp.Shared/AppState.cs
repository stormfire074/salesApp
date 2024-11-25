namespace SalesApp.Shared
{
    public class AppState
    {

        public AppState()
        {
        }

        public bool IsLoggedIn { get; set; }
        public string DatabaseName { get; set; }
        public string DatabaseKey { get; set; }
        public string Username { get; set; }
        public HttpClient httpScope { get; set; }
    }
}
