using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using SalesApp.Services;
using SalesApp.Shared;
using SalesApp.Shared.APIs.Static;
using SalesApp.Shared.Components;
using SalesApp.Shared.DependencyServices;
using SalesApp.Shared.Services;
using Syncfusion.Blazor;
using Sysinfocus.AspNetCore.Components;
namespace SalesApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzU3ODU1N0AzMjM3MmUzMDJlMzBXdEUzblJ0aktTUWNlWHdqbHZ5TnAvOVlVeEhHSGExbGt4NGNsd0thNWdrPQ==");

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            
            builder.Services.AddSyncfusionBlazor();
            builder.Services.AddSingleton<AppState>();
            builder.Services.AddScoped<NavState>();
            builder.Services.AddSingleton<ToastService>();
            builder.Services.AddTransient<IHttpClientHelper, HttpClientHelper>();
            var test = SalesApp.Shared.KeyGenerator.LicenseKeyGenerator.GenerateKey();
            builder.Services.AddSysinfocus(test, jsCssFromCDN:true);



            // Add device-specific services used by the SalesApp.Shared project
            builder.Services.AddSingleton<IFormFactor, FormFactor>();

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
