namespace SalesApp.Shared.Services
{
    public interface IFormFactor
    {
        // Platform Detection Properties (Get-only)
        bool IsAndroid { get; }
        bool IsIOS { get; }
        bool IsWindows { get; }
        bool Web { get; }

        // Methods
        string GetFormFactor(); // Determines the device's form factor (Phone, Tablet, Desktop, etc.)
        string GetPlatform();   // Returns the platform and version (e.g., Android 12.0)
        string GetPlatformType(); // Returns the platform type as a string (e.g., Android, iOS, Windows)
    }


}
