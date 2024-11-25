using SalesApp.Shared.Services;

namespace SalesApp.Web.Services
{
    public class FormFactor : IFormFactor
    {
        public bool IsAndroid { get; } = false;
        public bool IsIOS { get; } = false;
        public bool IsWindows { get;} = false;
        public bool Web { get; } = true; 

        public string GetFormFactor()
        {
            return "Web";
        }

        public string GetPlatform()
        {
            return Environment.OSVersion.ToString();
        }
        public string GetPlatformType()
        {
            return Environment.OSVersion.ToString();
        }
    }
}
 