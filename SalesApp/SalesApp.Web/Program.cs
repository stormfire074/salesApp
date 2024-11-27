using Microsoft.AspNetCore.Components;
using Radzen;
using SalesApp.Shared;
using SalesApp.Shared.APIs.Static;
using SalesApp.Shared.DependencyServices;
using SalesApp.Shared.KeyGenerator;
using SalesApp.Shared.Services;
using SalesApp.Web.Components;
using SalesApp.Web.Services;
using Syncfusion.Blazor;
using Sysinfocus.AspNetCore.Components;

var builder = WebApplication.CreateBuilder(args);
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzU3ODU1N0AzMjM3MmUzMDJlMzBXdEUzblJ0aktTUWNlWHdqbHZ5TnAvOVlVeEhHSGExbGt4NGNsd0thNWdrPQ==");
builder.Services.AddSyncfusionBlazor();
builder.Services.AddSingleton<AppState>();
builder.Services.AddScoped<NavState>();
builder.Services.AddTransient<IHttpClientHelper, HttpClientHelper>();
builder.Services.AddScoped<NavigationManager>(sp => sp.GetRequiredService<NavigationManager>());
builder.Services.AddScoped<CustomNavigationManager>();
builder.Services.AddSingleton<ToastService>();
builder.Services.AddSingleton(typeof(DataService<>));

builder.Services.AddSysinfocus(LicenseKeyGenerator.GenerateKey(),jsCssFromCDN:true);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddRadzenComponents();

// Add device-specific services used by the SalesApp.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(SalesApp.Shared._Imports).Assembly);

app.Run();
