// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.CodeScanner
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class CodeScanner : ComponentBase, IAsyncDisposable
  {
    private bool isStarted;
    private List<CodeScanner.CameraDevice>? devices;
    private CodeScanner.CameraDevice? selectedDevice;
    private static StateManager? smx;
    private string height;

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-codescanner " + this.Class);
      __builder.AddAttribute(2, "style", "width: " + this.Width + "; height: " + this.Height + "; " + this.Style);
      __builder.AddAttribute(3, "id", this.Id);
      __builder.AddAttribute(4, "b-m5twf75skj");
      if (!InitializeSysinfocus.IsLicensed)
        __builder.AddMarkupContent(5, "<small class=\"mtb05\" b-m5twf75skj>You are using a trial version.</small>");
      __builder.OpenElement(6, "video");
      __builder.AddAttribute(7, "id", "video");
      __builder.AddAttribute(8, "style", "object-fit: cover; width: 100%; height: " + this.height + "; border: 1px solid gray");
      __builder.AddAttribute(9, "autoplay");
      __builder.AddAttribute(10, "muted");
      __builder.AddAttribute(11, "playsinline");
      __builder.AddAttribute(12, "b-m5twf75skj");
      __builder.CloseElement();
      if (this.Controls)
      {
        __builder.OpenElement(13, "div");
        __builder.AddAttribute(14, "class", "flex jcc");
        __builder.AddAttribute(15, "b-m5twf75skj");
        if (this.devices != null)
        {
          __builder.OpenComponent<Select<CodeScanner.CameraDevice>>(16);
          __builder.AddComponentParameter(17, "Items", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<ICollection<CodeScanner.CameraDevice>>((ICollection<CodeScanner.CameraDevice>) this.devices));
          __builder.AddComponentParameter(18, "Display", (object) (Func<CodeScanner.CameraDevice, string>) (x => x.Label));
          __builder.AddComponentParameter(19, "SelectedItem", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<CodeScanner.CameraDevice>(this.selectedDevice));
          __builder.AddComponentParameter(20, "OnItemSelect", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback<CodeScanner.CameraDevice>>(EventCallback.Factory.Create<CodeScanner.CameraDevice>((object) this, (Action<CodeScanner.CameraDevice>) (x => this.selectedDevice = x))));
          __builder.CloseComponent();
          __builder.AddMarkupContent(21, "            \r\n                ");
          __builder.OpenComponent<Button>(22);
          __builder.AddComponentParameter(23, "Text", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<string>(this.isStarted ? "Stop" : "Start"));
          __builder.AddComponentParameter(24, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, new Func<Task>(this.HandleStartStop))));
          __builder.CloseComponent();
        }
        __builder.CloseElement();
      }
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    string Id { get; set; }

    [Parameter]
    public string Width { get; set; }

    [Parameter]
    public string Height { get; set; }

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Parameter]
    public bool StartCamera { get; set; }

    [Parameter]
    public bool Controls { get; set; }

    [Parameter]
    public EventCallback<string> OnCodeDetected { get; set; }

    [Parameter]
    public EventCallback<string> OnError { get; set; }

    protected override async Task OnInitializedAsync()
    {
      if (!(this.sm.GetFromState((object) "CODESCANNER_JS") is bool))
      {
        this.sm.Publish((object) "CODESCANNER_JS", (object) true);
        await this.be.AddScript(InitializeSysinfocus.CODESCANNER_JS);
      }
      if (CodeScanner.smx == null)
        CodeScanner.smx = new StateManager();
      CodeScanner.smx.StateChanged += new NotifyStateChanged(this.GetStateChanged);
      await Task.Delay(1000);
      string scp = "const codeReader = new ZXing.BrowserMultiFormatReader(); let vid; async function getVideos() { let devices = ''; vid = await codeReader.listVideoInputDevices(); if (vid.length >= 1) { vid.forEach(e => { devices += e.label + '|' + e.deviceId + ',' }) } return devices; } getVideos(); function startCamera(id) { if (id == 'undefined') id = vid[0].deviceId; codeReader.decodeFromVideoDevice(id, 'video', (result, err) => { if (result) DotNet.invokeMethodAsync('" + ComponentExtension.ASSEMBLY_NAME + "', 'GetResult', result.text); if (err && !(err instanceof ZXing.NotFoundException)) { console.log(err); DotNet.invokeMethodAsync('" + ComponentExtension.ASSEMBLY_NAME + "', 'GetError', err); } })} async function stopCamera() { codeReader.reset() } ";
      string x = await this.be.EvalGet<string>((object) scp);
      string[] allDevices = ((IEnumerable<string>) x.Split(',')).SkipLast<string>(1).ToArray<string>();
      this.devices = new List<CodeScanner.CameraDevice>();
      string[] strArray = allDevices;
      for (int index = 0; index < strArray.Length; ++index)
      {
        string d = strArray[index];
        string[] s = d.Split('|');
        this.devices.Add(new CodeScanner.CameraDevice(s[0], s[1]));
        s = (string[]) null;
        d = (string) null;
      }
      strArray = (string[]) null;
      this.selectedDevice = this.devices[0];
      scp = (string) null;
      x = (string) null;
      allDevices = (string[]) null;
    }

    protected override async Task OnParametersSetAsync()
    {
      this.height = this.Controls ? "calc(100% - 50px)" : "100%";
      if (this.devices == null)
        return;
      if (this.StartCamera)
        await this.Start();
      else
        await this.Stop();
    }

    private async void GetStateChanged(object sender, object values)
    {
      if (sender.ToString() == "HandleScanCodeDetection")
      {
        await this.OnCodeDetected.InvokeAsync(values.ToString());
      }
      else
      {
        if (!(sender.ToString() == "HandleScanCodeError"))
          return;
        await this.OnError.InvokeAsync(values.ToString());
      }
    }

    private async Task HandleStartStop()
    {
      if (!this.isStarted)
        await this.be.EvalVoid((object) ("startCamera('" + this.selectedDevice?.DeviceID + "')"));
      else
        await this.be.EvalVoid((object) "stopCamera()");
      this.isStarted = !this.isStarted;
    }

    public async Task Start()
    {
      if (!this.isStarted)
        await this.be.EvalVoid((object) ("startCamera('" + this.selectedDevice?.DeviceID + "')"));
      this.isStarted = true;
    }

    public async Task Stop()
    {
      if (this.isStarted)
        await this.be.EvalVoid((object) "stopCamera()");
      this.isStarted = false;
    }

    [JSInvokable]
    public static void GetResult(string result)
    {
      CodeScanner.smx?.Publish((object) "HandleScanCodeDetection", (object) result);
    }

    [JSInvokable]
    public static void GetError(string err)
    {
      CodeScanner.smx?.Publish((object) "HandleScanCodeError", (object) err);
    }

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
      if (this.isStarted)
        await this.Stop();
      if (CodeScanner.smx == null)
        return;
      CodeScanner.smx.StateChanged -= new NotifyStateChanged(this.GetStateChanged);
    }

    [Inject]
    private BrowserExtensions be { get; set; }

    [Inject]
    private StateManager sm { get; set; }

    public CodeScanner()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
      interpolatedStringHandler.AppendLiteral("cs-");
      interpolatedStringHandler.AppendFormatted<Guid>(Guid.NewGuid());
      // ISSUE: reference to a compiler-generated field
      this.Id = interpolatedStringHandler.ToStringAndClear();
      // ISSUE: reference to a compiler-generated field
      this.Width = "600px";
      // ISSUE: reference to a compiler-generated field
      this.Height = "400px";
      // ISSUE: reference to a compiler-generated field
      this.Controls = true;
      this.height = "100%";
      // ISSUE: reference to a compiler-generated field
      this.be = (BrowserExtensions) null;
      // ISSUE: reference to a compiler-generated field
      this.sm = (StateManager) null;
      // ISSUE: explicit constructor call
      base.OnInitialized();
    }

    private record CameraDevice(string Label, string? DeviceID);
  }
}
