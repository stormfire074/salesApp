// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Maps
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class Maps : ComponentBase, IDisposable
  {
    private bool mapRendered;
    private static StateManager? smx;
    private const string standard = "L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', { maxZoom: 19 }).addTo(map)";
    private const string esri_worldstreemap = "L.tileLayer('https://server.arcgisonline.com/ArcGIS/rest/services/World_Street_Map/MapServer/tile/{z}/{y}/{x}', { maxZoom: 19 }).addTo(map)";
    private const string esri_worldtopomap = "L.tileLayer('https://server.arcgisonline.com/ArcGIS/rest/services/World_Topo_Map/MapServer/tile/{z}/{y}/{x}', { maxZoom: 19 }).addTo(map)";
    private const string esri_worldimagery = "L.tileLayer('https://server.arcgisonline.com/ArcGIS/rest/services/World_Imagery/MapServer/tile/{z}/{y}/{x}', { maxZoom: 19 }).addTo(map)";

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      if (!InitializeSysinfocus.IsLicensed)
      {
        __builder.OpenElement(0, "div");
        __builder.AddAttribute(1, "class", "flex-col aic g4");
        __builder.AddAttribute(2, "b-upbcs2fybt");
        __builder.AddMarkupContent(3, "<small class=\"mtb1\" b-upbcs2fybt>You are using a trial version.</small>\r\n        ");
        __builder.OpenElement(4, "div");
        __builder.AddAttribute(5, "class", "sbc-maps " + this.Class);
        __builder.AddAttribute(6, "style", "width: " + this.Width + "; height: " + this.Height + "; " + this.Style);
        __builder.AddAttribute(7, "id", this.Id);
        __builder.AddAttribute(8, "b-upbcs2fybt");
        __builder.CloseElement();
        __builder.CloseElement();
      }
      else
      {
        __builder.OpenElement(9, "div");
        __builder.AddAttribute(10, "class", "sbc-maps " + this.Class);
        __builder.AddAttribute(11, "style", "width: " + this.Width + "; height: " + this.Height + "; " + this.Style);
        __builder.AddAttribute(12, "id", this.Id);
        __builder.AddAttribute(13, "b-upbcs2fybt");
        __builder.CloseElement();
      }
    }

    [Parameter]
    public 
    #nullable enable
    string Id { get; set; }

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public string? Height { get; set; }

    [Parameter]
    public string? Width { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Parameter]
    [EditorRequired]
    public double Latitude { get; set; }

    [Parameter]
    [EditorRequired]
    public double Longitude { get; set; }

    [Parameter]
    public int Zoom { get; set; }

    [Parameter]
    public MapView ViewType { get; set; }

    [Parameter]
    public EventCallback<MapLocation> OnClick { get; set; }

    [Parameter]
    public EventCallback<MapMarkerMovedLocation> OnMarkerMoved { get; set; }

    protected override async Task OnInitializedAsync()
    {
      if (!(this.sm.GetFromState((object) "MAPS_JS") is bool))
      {
        this.sm.Publish((object) "MAPS_JS", (object) true);
        ValueTask valueTask = this.be.AddStylesheet(InitializeSysinfocus.MAPS_CSS);
        await valueTask;
        valueTask = this.be.AddScript(InitializeSysinfocus.MAPS_JS, false);
        await valueTask;
      }
      if (Maps.smx == null)
        Maps.smx = new StateManager();
      Maps.smx.StateChanged += new NotifyStateChanged(this.GetStateChanged);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
      if (firstRender || this.mapRendered)
        return;
      this.mapRendered = true;
      await this.RenderMap();
    }

    private async void GetStateChanged(object sender, object values)
    {
      if (sender.ToString() == "HandleMapClick")
      {
        await this.OnClick.InvokeAsync((MapLocation) values);
      }
      else
      {
        if (!(sender.ToString() == "HandleMarkerMoved"))
          return;
        await this.OnMarkerMoved.InvokeAsync((MapMarkerMovedLocation) values);
      }
    }

    private async Task RenderMap()
    {
      string str = this.ViewType.ToString().ToLower();
      string str1;
      switch (str)
      {
        case "esri_worldstreemap":
          str1 = "L.tileLayer('https://server.arcgisonline.com/ArcGIS/rest/services/World_Street_Map/MapServer/tile/{z}/{y}/{x}', { maxZoom: 19 }).addTo(map)";
          break;
        case "esri_worldtopomap":
          str1 = "L.tileLayer('https://server.arcgisonline.com/ArcGIS/rest/services/World_Topo_Map/MapServer/tile/{z}/{y}/{x}', { maxZoom: 19 }).addTo(map)";
          break;
        case "esri_worldimagery":
          str1 = "L.tileLayer('https://server.arcgisonline.com/ArcGIS/rest/services/World_Imagery/MapServer/tile/{z}/{y}/{x}', { maxZoom: 19 }).addTo(map)";
          break;
        default:
          str1 = "L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', { maxZoom: 19 }).addTo(map)";
          break;
      }
      string mapType = str1;
      str = (string) null;
      await Task.Delay(250);
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(390, 7);
      interpolatedStringHandler.AppendLiteral("function markerMoved(id, from, to) { DotNet.invokeMethodAsync('");
      interpolatedStringHandler.AppendFormatted(ComponentExtension.ASSEMBLY_NAME);
      interpolatedStringHandler.AppendLiteral("', 'HandleMarkerMoved', id, `{\"latitude\": ${from.lat}, \"longitude\": ${from.lng} }`, `{\"latitude\": ${to.lat}, \"longitude\": ${to.lng} }`); } function mapClick(e) { DotNet.invokeMethodAsync('");
      interpolatedStringHandler.AppendFormatted(ComponentExtension.ASSEMBLY_NAME);
      interpolatedStringHandler.AppendLiteral("', 'HandleMapClick', e.latlng.lat, e.latlng.lng); } var map = L.map('");
      interpolatedStringHandler.AppendFormatted(this.Id);
      interpolatedStringHandler.AppendLiteral("').setView([");
      interpolatedStringHandler.AppendFormatted<double>(this.Latitude);
      interpolatedStringHandler.AppendLiteral(", ");
      interpolatedStringHandler.AppendFormatted<double>(this.Longitude);
      interpolatedStringHandler.AppendLiteral("], ");
      interpolatedStringHandler.AppendFormatted<int>(this.Zoom);
      interpolatedStringHandler.AppendLiteral("); const tiles = ");
      interpolatedStringHandler.AppendFormatted(mapType);
      interpolatedStringHandler.AppendLiteral("; map.on('click', e => mapClick(e));");
      string scp = interpolatedStringHandler.ToStringAndClear();
      await this.be.EvalVoid((object) scp);
      mapType = (string) null;
      scp = (string) null;
    }

    public static async Task AddMarker(
      IJSRuntime jsr,
      double latitude,
      double longitude,
      int zoom = 10,
      string? label = null,
      bool draggable = false)
    {
      await Task.Delay(50);
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(187, 5);
      interpolatedStringHandler.AppendLiteral("L.marker([");
      interpolatedStringHandler.AppendFormatted<double>(latitude);
      interpolatedStringHandler.AppendLiteral(", ");
      interpolatedStringHandler.AppendFormatted<double>(longitude);
      interpolatedStringHandler.AppendLiteral("], { zoom: ");
      interpolatedStringHandler.AppendFormatted<int>(zoom);
      interpolatedStringHandler.AppendLiteral(", draggable: ");
      interpolatedStringHandler.AppendFormatted(draggable ? "true" : "false");
      interpolatedStringHandler.AppendLiteral(", autoPan: true }).on('move', e => { markerMoved(e.target._leaflet_id, e.oldLatLng, e.latlng) }).on('click', e => mapClick(e)).addTo(map).bindPopup('");
      interpolatedStringHandler.AppendFormatted(label);
      interpolatedStringHandler.AppendLiteral("')");
      string scp = interpolatedStringHandler.ToStringAndClear();
      await jsr.InvokeVoidAsync("eval", (object) scp);
      scp = (string) null;
    }

    public static async Task RemoveMarker(IJSRuntime jsr, double latitude, double longitude)
    {
      await Task.Delay(50);
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(102, 2);
      interpolatedStringHandler.AppendLiteral("Object.values(map._layers).forEach(l => { if (l._latlng?.lat == ");
      interpolatedStringHandler.AppendFormatted<double>(latitude);
      interpolatedStringHandler.AppendLiteral(" && l._latlng?.lng == ");
      interpolatedStringHandler.AppendFormatted<double>(longitude);
      interpolatedStringHandler.AppendLiteral(") l.remove() });");
      string scp = interpolatedStringHandler.ToStringAndClear();
      await jsr.InvokeVoidAsync("eval", (object) scp);
      scp = (string) null;
    }

    public static async Task DrawCircle(
      IJSRuntime jsr,
      double latitude,
      double longitude,
      double radius)
    {
      await Task.Delay(50);
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(27, 3);
      interpolatedStringHandler.AppendLiteral("L.circle([");
      interpolatedStringHandler.AppendFormatted<double>(latitude);
      interpolatedStringHandler.AppendLiteral(", ");
      interpolatedStringHandler.AppendFormatted<double>(longitude);
      interpolatedStringHandler.AppendLiteral("], ");
      interpolatedStringHandler.AppendFormatted<double>(radius);
      interpolatedStringHandler.AppendLiteral(").addTo(map)");
      string scp = interpolatedStringHandler.ToStringAndClear();
      await jsr.InvokeVoidAsync("eval", (object) scp);
      scp = (string) null;
    }

    public static async Task Center(IJSRuntime jsr, double latitute, double longitude, int zoom = 8)
    {
      await Task.Delay(50);
      IJSRuntime jsRuntime = jsr;
      object[] objArray = new object[1];
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 3);
      interpolatedStringHandler.AppendLiteral("map.flyTo([");
      interpolatedStringHandler.AppendFormatted<double>(latitute);
      interpolatedStringHandler.AppendLiteral(", ");
      interpolatedStringHandler.AppendFormatted<double>(longitude);
      interpolatedStringHandler.AppendLiteral("], ");
      interpolatedStringHandler.AppendFormatted<int>(zoom);
      interpolatedStringHandler.AppendLiteral(")");
      objArray[0] = (object) interpolatedStringHandler.ToStringAndClear();
      await jsRuntime.InvokeVoidAsync("eval", objArray);
    }

    public static async Task Execute(IJSRuntime jsr, string code)
    {
      await Task.Delay(50);
      await jsr.InvokeVoidAsync("eval", (object) code);
    }

    public static async Task RenderMap(IJSRuntime jsr, MapView mapView)
    {
      string str = mapView.ToString().ToLower();
      string str1;
      switch (str)
      {
        case "esri_worldstreemap":
          str1 = "L.tileLayer('https://server.arcgisonline.com/ArcGIS/rest/services/World_Street_Map/MapServer/tile/{z}/{y}/{x}', { maxZoom: 19 }).addTo(map)";
          break;
        case "esri_worldtopomap":
          str1 = "L.tileLayer('https://server.arcgisonline.com/ArcGIS/rest/services/World_Topo_Map/MapServer/tile/{z}/{y}/{x}', { maxZoom: 19 }).addTo(map)";
          break;
        case "esri_worldimagery":
          str1 = "L.tileLayer('https://server.arcgisonline.com/ArcGIS/rest/services/World_Imagery/MapServer/tile/{z}/{y}/{x}', { maxZoom: 19 }).addTo(map)";
          break;
        default:
          str1 = "L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', { maxZoom: 19 }).addTo(map)";
          break;
      }
      string mapType = str1;
      str = (string) null;
      await Task.Delay(500);
      string scp = mapType + ";";
      await jsr.InvokeVoidAsync("eval", (object) scp);
      mapType = (string) null;
      scp = (string) null;
    }

    [JSInvokable]
    public static Task HandleMapClick(double lat, double lng)
    {
      MapLocation state = new MapLocation(lat, lng);
      Maps.smx?.Publish((object) nameof (HandleMapClick), (object) state);
      return Task.CompletedTask;
    }

    [JSInvokable]
    public static Task HandleMarkerMoved(int id, string from, string to)
    {
      JsonSerializerOptions options = new JsonSerializerOptions()
      {
        PropertyNameCaseInsensitive = true
      };
      MapLocation FromLocation = JsonSerializer.Deserialize<MapLocation>(from, options);
      MapLocation ToLocation = JsonSerializer.Deserialize<MapLocation>(to, options);
      Maps.smx?.Publish((object) nameof (HandleMarkerMoved), (object) new MapMarkerMovedLocation(id, FromLocation, ToLocation));
      return Task.CompletedTask;
    }

    void IDisposable.Dispose()
    {
      if (Maps.smx == null)
        return;
      Maps.smx.StateChanged -= new NotifyStateChanged(this.GetStateChanged);
    }

    [Inject]
    private BrowserExtensions be { get; set; }

    [Inject]
    private StateManager sm { get; set; }

    public Maps()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
      interpolatedStringHandler.AppendLiteral("map-");
      interpolatedStringHandler.AppendFormatted<Guid>(Guid.NewGuid());
      // ISSUE: reference to a compiler-generated field
      this.Id = interpolatedStringHandler.ToStringAndClear();
      // ISSUE: reference to a compiler-generated field
      this.Height = "300px";
      // ISSUE: reference to a compiler-generated field
      this.Width = "400px";
      // ISSUE: reference to a compiler-generated field
      this.Zoom = 16;
      // ISSUE: reference to a compiler-generated field
      this.ViewType = MapView.Standard;
      // ISSUE: reference to a compiler-generated field
      this.be = (BrowserExtensions) null;
      // ISSUE: reference to a compiler-generated field
      this.sm = (StateManager) null;
      // ISSUE: explicit constructor call
      base.OnInitialized();
    }
  }
}
