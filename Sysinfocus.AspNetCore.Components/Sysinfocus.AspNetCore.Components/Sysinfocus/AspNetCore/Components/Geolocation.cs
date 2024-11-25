// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Geolocation
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class Geolocation : ComponentBase, IDisposable
  {
    private MapLocation? _lastLocation;
    private static StateManager? smx;

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
    }

    [Parameter]
    public bool EnableHighAccuracy { get; set; }

    [Parameter]
    public double MaximumAge { get; set; } = 30000.0;

    [Parameter]
    public double Timeout { get; set; } = 27000.0;

    [Parameter]
    public bool EnableLocationUpdates { get; set; }

    [Parameter]
    public EventCallback<
    #nullable enable
    MapLocation> OnLocationReceived { get; set; }

    [Parameter]
    public EventCallback<string> OnLocationError { get; set; }

    protected override async Task OnInitializedAsync()
    {
      Geolocation.smx = new StateManager();
      Geolocation.smx.StateChanged += new NotifyStateChanged(this.GetChangedState);
      string eha = this.EnableHighAccuracy ? "true" : "false";
      string ul = this.EnableLocationUpdates ? "watchID = navigator.geolocation.watchPosition(success, error, options);" : (string) null;
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(786, 7);
      interpolatedStringHandler.AppendLiteral("const options = {enableHighAccuracy: ");
      interpolatedStringHandler.AppendFormatted(eha);
      interpolatedStringHandler.AppendLiteral(", maximumAge: ");
      interpolatedStringHandler.AppendFormatted<double>(this.MaximumAge);
      interpolatedStringHandler.AppendLiteral(", timeout: ");
      interpolatedStringHandler.AppendFormatted<double>(this.Timeout);
      interpolatedStringHandler.AppendLiteral(" }; let watchID;\r\nif ('geolocation' in navigator) { navigator.geolocation.getCurrentPosition(success, error, options); ");
      interpolatedStringHandler.AppendFormatted(ul);
      interpolatedStringHandler.AppendLiteral(" }\r\nelse { DotNet.invokeMethodAsync('");
      interpolatedStringHandler.AppendFormatted(ComponentExtension.ASSEMBLY_NAME);
      interpolatedStringHandler.AppendLiteral("', 'LocationError', 'Sorry, location service unavailable. Reset and allow permission to use this service.') }\r\nfunction success(p) { try { DotNet.invokeMethodAsync('");
      interpolatedStringHandler.AppendFormatted(ComponentExtension.ASSEMBLY_NAME);
      interpolatedStringHandler.AppendLiteral("', 'UpdateLocation', p.coords.latitude, p.coords.longitude) } catch (err) { console.log(err) } }\r\nfunction error() { try { DotNet.invokeMethodAsync('");
      interpolatedStringHandler.AppendFormatted(ComponentExtension.ASSEMBLY_NAME);
      interpolatedStringHandler.AppendLiteral("', 'LocationError', 'Sorry, no location available. Reset and allow permission to use this service.') } catch (err) { console.log(err) } }\r\nfunction getWatchID() { return watchID }\r\nfunction clearWatchID(id) { return navigator.geolocation.clearWatch(id) }");
      string scp = interpolatedStringHandler.ToStringAndClear();
      await this.be.EvalVoid((object) scp);
      eha = (string) null;
      ul = (string) null;
      scp = (string) null;
    }

    private async void GetChangedState(object? sender, object? value)
    {
      if (sender?.ToString() == "UpdateLocation")
      {
        (double, double) loc = ((double, double)) value;
        MapLocation curLocation = new MapLocation(loc.Item1, loc.Item2);
        if (curLocation == this._lastLocation)
          return;
        this._lastLocation = curLocation;
        await this.OnLocationReceived.InvokeAsync(new MapLocation(loc.Item1, loc.Item2));
        loc = (0,0);
        curLocation = (MapLocation) null;
      }
      else
      {
        if (!(sender?.ToString() == "LocationError"))
          return;
        await this.OnLocationError.InvokeAsync(value.ToString());
      }
    }

    public static double DistanceKilometers(MapLocation from, MapLocation to)
    {
      double radians1 = DegreesToRadians(from.Latitude);
      double radians2 = DegreesToRadians(from.Longitude);
      double radians3 = DegreesToRadians(to.Latitude);
      double radians4 = DegreesToRadians(to.Longitude);
      double num1 = radians3 - radians1;
      double num2 = radians4 - radians2;
      double d = Math.Pow(Math.Sin(num1 / 2.0), 2.0) + Math.Cos(radians1) * Math.Cos(radians3) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);
      return 6371.0 * (2.0 * Math.Atan2(Math.Sqrt(d), Math.Sqrt(1.0 - d)));

      static double DegreesToRadians(double degrees) => degrees * (Math.PI / 180.0);
    }

    public static double DistanceMiles(MapLocation from, MapLocation to)
    {
      double radians1 = DegreesToRadians(from.Latitude);
      double radians2 = DegreesToRadians(from.Longitude);
      double radians3 = DegreesToRadians(to.Latitude);
      double radians4 = DegreesToRadians(to.Longitude);
      double num1 = radians3 - radians1;
      double num2 = radians4 - radians2;
      double d = Math.Pow(Math.Sin(num1 / 2.0), 2.0) + Math.Cos(radians1) * Math.Cos(radians3) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);
      return 3958.8 * (2.0 * Math.Atan2(Math.Sqrt(d), Math.Sqrt(1.0 - d)));

      static double DegreesToRadians(double degrees) => degrees * (Math.PI / 180.0);
    }

    [JSInvokable]
    public static Task UpdateLocation(double lat, double lng)
    {
      if (Geolocation.smx != null)
        Geolocation.smx.Publish((object) nameof (UpdateLocation), (object) (lat, lng));
      return Task.CompletedTask;
    }

    [JSInvokable]
    public static Task LocationError(string msg)
    {
      if (Geolocation.smx != null)
        Geolocation.smx.Publish((object) nameof (LocationError), (object) msg);
      return Task.CompletedTask;
    }

    public async Task<object> GetWatchID()
    {
      object watchId = await this.be.EvalGet<object>((object) "getWatchID");
      return watchId;
    }

    public async Task ClearWatchID(object id)
    {
      await this.be.EvalVoid((object) "clearWatchID", id);
    }

    void IDisposable.Dispose()
    {
      if (Geolocation.smx == null)
        return;
      Geolocation.smx.StateChanged -= new NotifyStateChanged(this.GetChangedState);
    }

    [Inject]
    private BrowserExtensions be { get; set; } = (BrowserExtensions) null;

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
