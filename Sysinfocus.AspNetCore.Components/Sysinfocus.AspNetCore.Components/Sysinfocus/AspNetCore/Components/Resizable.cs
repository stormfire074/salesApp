// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Resizable
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
  public class Resizable : ComponentBase
  {
    private string? id;

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-resizable " + (this.ShowBorder ? "res-border" : "no-res-border") + " " + (this.Vertical ? "vertical" : (string) null));
      __builder.AddAttribute(2, "id", this.id);
      __builder.AddAttribute(3, "style", "width: " + this.Width + "; height: " + this.Height + "; " + this.Style);
      __builder.AddAttribute(4, "b-mlngf8w2y0");
      if (!this.Vertical)
      {
        __builder.OpenElement(5, "div");
        __builder.AddAttribute(6, "class", "pane left");
        __builder.AddAttribute(7, "style", "width: 50%");
        __builder.AddAttribute(8, "b-mlngf8w2y0");
        __builder.AddContent(9, this.LeftOrTopContent);
        __builder.CloseElement();
        __builder.AddMarkupContent(10, "\r\n        ");
        __builder.OpenElement(11, "div");
        __builder.AddAttribute(12, "class", "pane right");
        __builder.AddAttribute(13, "style", "width: 50%");
        __builder.AddAttribute(14, "b-mlngf8w2y0");
        __builder.AddContent(15, this.RightOrBottomContent);
        __builder.AddMarkupContent(16, "\r\n            <div class=\"hGutter\" b-mlngf8w2y0></div>");
        __builder.CloseElement();
      }
      else
      {
        __builder.OpenElement(17, "div");
        __builder.AddAttribute(18, "class", "vPane top");
        __builder.AddAttribute(19, "style", "height: 50%");
        __builder.AddAttribute(20, "b-mlngf8w2y0");
        __builder.AddContent(21, this.LeftOrTopContent);
        __builder.CloseElement();
        __builder.AddMarkupContent(22, "\r\n        ");
        __builder.OpenElement(23, "div");
        __builder.AddAttribute(24, "class", "vPane bottom");
        __builder.AddAttribute(25, "style", "height: 50%");
        __builder.AddAttribute(26, "b-mlngf8w2y0");
        __builder.AddContent(27, this.RightOrBottomContent);
        __builder.AddMarkupContent(28, "\r\n            <div class=\"vGutter\" b-mlngf8w2y0></div>");
        __builder.CloseElement();
      }
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    string? Width { get; set; }

    [Parameter]
    public string? Height { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Parameter]
    public RenderFragment? LeftOrTopContent { get; set; }

    [Parameter]
    public RenderFragment? RightOrBottomContent { get; set; }

    [Parameter]
    public bool Vertical { get; set; }

    [Parameter]
    public bool ShowBorder { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
      string script = string.Empty;
      if (!this.Vertical)
      {
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(756, 3);
        interpolatedStringHandler.AppendLiteral("const leftPane = document.querySelector('#");
        interpolatedStringHandler.AppendFormatted(this.id);
        interpolatedStringHandler.AppendLiteral(" .left');const rightPane = document.querySelector('#");
        interpolatedStringHandler.AppendFormatted(this.id);
        interpolatedStringHandler.AppendLiteral(" .right');const hgutter = document.querySelector('#");
        interpolatedStringHandler.AppendFormatted(this.id);
        interpolatedStringHandler.AppendLiteral(" .hGutter');\r\n                function hResizer(e) {\r\n                    window.addEventListener('mousemove', mousemove); window.addEventListener('mouseup', mouseup);\r\n                    let prevX = e.x; const leftPanel = leftPane.getBoundingClientRect();\r\n                    function mousemove(e) { let newX = prevX - e.x; leftPane.style.width = leftPanel.width - newX + 'px'; }\r\n                    function mouseup() { window.removeEventListener('mousemove', mousemove); window.removeEventListener('mouseup', mouseup); }\r\n                }\r\n                hgutter.addEventListener('mousedown', hResizer);");
        script = interpolatedStringHandler.ToStringAndClear();
      }
      else
      {
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(808, 3);
        interpolatedStringHandler.AppendLiteral("const topPane = document.querySelector('#");
        interpolatedStringHandler.AppendFormatted(this.id);
        interpolatedStringHandler.AppendLiteral(" .top'); const bottomPane = document.querySelector('#");
        interpolatedStringHandler.AppendFormatted(this.id);
        interpolatedStringHandler.AppendLiteral(" .bottom'); const vgutter = document.querySelector('#");
        interpolatedStringHandler.AppendFormatted(this.id);
        interpolatedStringHandler.AppendLiteral(" .vGutter');\r\n                function vResizer(e) {\r\n                    window.addEventListener('mousemove', mousemove); window.addEventListener('mouseup', mouseup);\r\n                    let prevY = e.y; const topPanel = topPane.getBoundingClientRect();\r\n                    function mousemove(e) { let newY = prevY - e.y; topPane.style.minHeight = 'fit-content !important'; topPane.style.height = topPanel.height - newY + 'px'; }\r\n                    function mouseup() { window.removeEventListener('mousemove', mousemove); window.removeEventListener('mouseup', mouseup); }\r\n                }\r\n                vgutter.addEventListener('mousedown', vResizer);");
        script = interpolatedStringHandler.ToStringAndClear();
      }
      await this.jsr.InvokeVoidAsync("eval", (object) script);
      script = (string) null;
    }

    [Inject]
    private IJSRuntime jsr { get; set; }

    [Inject]
    private StateManager sm { get; set; }

    public Resizable()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
      interpolatedStringHandler.AppendLiteral("rsz-");
      interpolatedStringHandler.AppendFormatted<Guid>(Guid.NewGuid());
      this.id = interpolatedStringHandler.ToStringAndClear();
      // ISSUE: reference to a compiler-generated field
      this.jsr = (IJSRuntime) null;
      // ISSUE: reference to a compiler-generated field
      this.sm = (StateManager) null;
      // ISSUE: explicit constructor call
      base.OnInitialized();
    }
  }
}
