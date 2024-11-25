// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.AlertDialog
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class AlertDialog : ComponentBase
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      if (!this.Show)
        return;
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "id", this.Id);
      __builder.AddAttribute(2, "class", "sbc-alertdialog " + this.Class);
      __builder.AddAttribute(3, "style", this.Style);
      __builder.AddAttribute(4, "b-mwh1mqozj1");
      __builder.AddMarkupContent(5, "<div class=\"sbc-alertdialog-overlay\" b-mwh1mqozj1></div>\r\n    ");
      __builder.OpenElement(6, "div");
      __builder.AddAttribute(7, "class", "sbc-alertdialog-alert show");
      __builder.AddAttribute(8, "style", "width: " + this.Width + ";");
      __builder.AddAttribute(9, "b-mwh1mqozj1");
      if (!InitializeSysinfocus.IsLicensed)
        __builder.AddMarkupContent(10, "<small class=\"mtb05\" b-mwh1mqozj1>You are using a trial version.</small>");
      __builder.OpenElement(11, "div");
      __builder.AddAttribute(12, "class", "sbc-alertdialog-header");
      __builder.AddAttribute(13, "b-mwh1mqozj1");
      __builder.AddContent(14, this.Header);
      __builder.CloseElement();
      __builder.AddMarkupContent(15, "\r\n        ");
      __builder.OpenElement(16, "div");
      __builder.AddAttribute(17, "class", "sbc-alertdialog-content");
      __builder.AddAttribute(18, "b-mwh1mqozj1");
      __builder.AddContent(19, this.Content);
      __builder.CloseElement();
      __builder.AddMarkupContent(20, "\r\n        ");
      __builder.OpenElement(21, "div");
      __builder.AddAttribute(22, "class", "sbc-alertdialog-footer");
      __builder.AddAttribute(23, "b-mwh1mqozj1");
      __builder.AddContent(24, this.Footer);
      __builder.CloseElement();
      __builder.CloseElement();
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    string? Id { get; set; }

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Parameter]
    public bool Show { get; set; }

    [Parameter]
    public string? Width { get; set; }

    [Parameter]
    [EditorRequired]
    public RenderFragment? Header { get; set; }

    [Parameter]
    [EditorRequired]
    public RenderFragment? Content { get; set; }

    [Parameter]
    [EditorRequired]
    public RenderFragment? Footer { get; set; }

    protected override async Task OnParametersSetAsync()
    {
      if (this.Show)
      {
        BrowserExtensions be = this.be;
        object[] objArray = new object[1];
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(137, 2);
        interpolatedStringHandler.AppendLiteral("window.addEventListener('focusin', e => { if (e.target.closest('#");
        interpolatedStringHandler.AppendFormatted(this.Id);
        interpolatedStringHandler.AppendLiteral("') == null) document.querySelector('#");
        interpolatedStringHandler.AppendFormatted(this.Id);
        interpolatedStringHandler.AppendLiteral(" button:first-child')?.focus(); } )");
        objArray[0] = (object) interpolatedStringHandler.ToStringAndClear();
        await be.EvalVoid(objArray);
      }
      await this.be.EvalVoid((object) ("document.querySelector('body').style.overflow = '" + (this.Show ? "hidden" : "auto") + "'"));
    }

    [Inject]
    private BrowserExtensions be { get; set; }

    [Inject]
    private StateManager sm { get; set; }

    public AlertDialog()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(5, 1);
      interpolatedStringHandler.AppendLiteral("aldg-");
      interpolatedStringHandler.AppendFormatted<Guid>(Guid.NewGuid());
      // ISSUE: reference to a compiler-generated field
      this.Id= interpolatedStringHandler.ToStringAndClear();
      // ISSUE: reference to a compiler-generated field
      this.Width = "512px";
      // ISSUE: reference to a compiler-generated field
      this.be = (BrowserExtensions) null;
      // ISSUE: reference to a compiler-generated field
      this.sm = (StateManager) null;
      // ISSUE: explicit constructor call
      base.OnInitialized();
    }
  }
}
