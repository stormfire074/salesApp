// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Chart
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
  public class Chart : ComponentBase
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      if (!InitializeSysinfocus.IsLicensed)
      {
        __builder.OpenElement(0, "div");
        __builder.AddAttribute(1, "class", "flex-col jcc");
        __builder.AddAttribute(2, "b-g2zjdrqq2d");
        __builder.AddMarkupContent(3, "<small class=\"mtb05 ta-center\" b-g2zjdrqq2d>You are using a trial version.</small>\r\n        ");
        __builder.OpenElement(4, "div");
        __builder.AddAttribute(5, "class", "sbc-chart");
        __builder.AddAttribute(6, "id", this.Id);
        __builder.AddAttribute(7, "style", "width: " + this.Width + "; height: " + this.Height);
        __builder.AddAttribute(8, "b-g2zjdrqq2d");
        __builder.CloseElement();
        __builder.CloseElement();
      }
      else
      {
        __builder.OpenElement(9, "div");
        __builder.AddAttribute(10, "class", "sbc-chart");
        __builder.AddAttribute(11, "id", this.Id);
        __builder.AddAttribute(12, "style", "width: " + this.Width + "; height: " + this.Height);
        __builder.AddAttribute(13, "b-g2zjdrqq2d");
        __builder.CloseElement();
      }
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
    public string? Option { get; set; }

    [Parameter]
    public string? DataOption { get; set; }

    protected override async Task OnInitializedAsync()
    {
      await this.InitializeCharts();
      await Task.Delay(500);
      await this.RenderChartAsync();
    }

    public async Task RenderAsync()
    {
      string execute = "\r\n        var myChart = echarts.init(document.getElementById('" + this.Id + "'));\r\n        myChart.setOption(option);";
      await this.jsr.InvokeVoidAsync("eval", (object) execute);
      execute = (string) null;
    }

    private async Task RenderChartAsync()
    {
      if (this.DataOption != null)
      {
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(120, 2);
        interpolatedStringHandler.AppendLiteral("\r\n        ");
        interpolatedStringHandler.AppendFormatted(this.DataOption);
        interpolatedStringHandler.AppendLiteral("\r\n            var myChart = echarts.init(document.getElementById('");
        interpolatedStringHandler.AppendFormatted(this.Id);
        interpolatedStringHandler.AppendLiteral("'));\r\n            myChart.setOption(option);");
        string execute = interpolatedStringHandler.ToStringAndClear();
        await this.jsr.InvokeVoidAsync("eval", (object) execute);
        execute = (string) null;
      }
      else
      {
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(138, 2);
        interpolatedStringHandler.AppendLiteral("\r\n            var myChart = echarts.init(document.getElementById('");
        interpolatedStringHandler.AppendFormatted(this.Id);
        interpolatedStringHandler.AppendLiteral("'));\r\n            var option = ");
        interpolatedStringHandler.AppendFormatted(this.Option);
        interpolatedStringHandler.AppendLiteral(";\r\n            myChart.setOption(option);");
        string execute = interpolatedStringHandler.ToStringAndClear();
        await this.jsr.InvokeVoidAsync("eval", (object) execute);
        execute = (string) null;
      }
    }

    private async Task InitializeCharts()
    {
      if (this.sm.GetFromState((object) "ECHARTS_JS") is bool)
        return;
      this.sm.Publish((object) "ECHARTS_JS", (object) true);
      await this.be.AddScript(InitializeSysinfocus.ECHARTS_JS);
    }

    [Inject]
    private BrowserExtensions be { get; set; }

    [Inject]
    private IJSRuntime jsr { get; set; }

    [Inject]
    private StateManager sm { get; set; }

    public Chart()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
      interpolatedStringHandler.AppendLiteral("chart-");
      interpolatedStringHandler.AppendFormatted<Guid>(Guid.NewGuid());
      // ISSUE: reference to a compiler-generated field
      this.Id = interpolatedStringHandler.ToStringAndClear();
      // ISSUE: reference to a compiler-generated field
      this.Width = "500px";
      // ISSUE: reference to a compiler-generated field
      this.Height = "500px";
      // ISSUE: reference to a compiler-generated field
      this.be = (BrowserExtensions) null;
      // ISSUE: reference to a compiler-generated field
      this.jsr = (IJSRuntime) null;
      // ISSUE: reference to a compiler-generated field
      this.sm = (StateManager) null;
      // ISSUE: explicit constructor call
      base.OnInitialized();
    }
  }
}
