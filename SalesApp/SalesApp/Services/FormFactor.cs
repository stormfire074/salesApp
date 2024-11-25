using SalesApp.Shared.Services;

namespace SalesApp.Services
{

    public class FormFactor : IFormFactor
    {
        // Properties
        public bool IsAndroid => DeviceInfo.Platform == DevicePlatform.Android;
        public bool IsIOS => DeviceInfo.Platform == DevicePlatform.iOS || DeviceInfo.Platform == DevicePlatform.MacCatalyst;
        public bool IsWindows => DeviceInfo.Platform == DevicePlatform.WinUI;
        public bool Web => DeviceInfo.Platform == DevicePlatform.Tizen || DeviceInfo.Platform == DevicePlatform.Unknown; // Adjust as needed for Web

        // Methods
        public string GetFormFactor()
        {
            return DeviceInfo.Idiom.ToString(); // Returns "Phone", "Tablet", "Desktop", etc.
        }

        public string GetPlatform()
        {
            return $"{DeviceInfo.Platform} - {DeviceInfo.VersionString}"; // Returns platform and version
        }

        public string GetPlatformType()
        {
            return DeviceInfo.Platform.ToString(); // Returns platform as a string, e.g., "Android", "iOS", etc.
        }
    }

}
