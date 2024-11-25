// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Signature
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
  public class Signature : ComponentBase
  {
    private string script;

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "id", this.Id);
      __builder.AddAttribute(2, "class", "sbc-signature-pad");
      __builder.AddAttribute(3, "style", "width: " + this.Width + "; height: " + this.Height + "; " + this.Style);
      __builder.AddAttribute(4, "b-p0e6o0899p");
      __builder.OpenElement(5, "canvas");
      __builder.AddAttribute(6, "tabindex", "0");
      __builder.AddAttribute(7, "id", this.Id + "-canvas");
      __builder.AddAttribute(8, "height", this.Height);
      __builder.AddAttribute(9, "width", this.Width);
      __builder.AddAttribute(10, "class", "signature-pad");
      __builder.AddAttribute(11, "style", !this.ShowControls ? "pointer-events: none" : (string) null);
      __builder.AddAttribute(12, "b-p0e6o0899p");
      __builder.CloseElement();
      if (!InitializeSysinfocus.IsLicensed)
        __builder.AddMarkupContent(13, "<small class=\"mtb05 ta-center\" b-p0e6o0899p>You are using a trial version.</small>");
      if (this.ShowControls)
      {
        __builder.OpenElement(14, "div");
        __builder.AddAttribute(15, "class", "flex g4 jcc");
        __builder.AddAttribute(16, "b-p0e6o0899p");
        __builder.OpenComponent<Button>(17);
        __builder.AddComponentParameter(18, "Icon", (object) "check");
        __builder.AddComponentParameter(19, "Style", (object) "padding: 6px");
        __builder.AddComponentParameter(20, "Type", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<ButtonType>(ButtonType.Outline));
        __builder.AddComponentParameter(21, "Size", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<ButtonSize>(ButtonSize.Small));
        __builder.AddComponentParameter(22, "Tooltip", (object) "Accept");
        __builder.AddComponentParameter(23, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, new Func<Task>(this.AcceptSignature))));
        __builder.CloseComponent();
        __builder.AddMarkupContent(24, "\r\n        ");
        __builder.OpenComponent<Button>(25);
        __builder.AddComponentParameter(26, "Icon", (object) "close");
        __builder.AddComponentParameter(27, "Style", (object) "padding: 6px");
        __builder.AddComponentParameter(28, "Type", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<ButtonType>(ButtonType.Outline));
        __builder.AddComponentParameter(29, "Size", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<ButtonSize>(ButtonSize.Small));
        __builder.AddComponentParameter(30, "Tooltip", (object) "Clear");
        __builder.AddComponentParameter(31, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, new Func<Task>(this.ClearSignature))));
        __builder.CloseComponent();
        __builder.CloseElement();
      }
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    string? Id { get; set; }

    [Parameter]
    public string? BackgroundColor { get; set; }

    [Parameter]
    public string? InkColor { get; set; }

    [Parameter]
    public int? StrokeWidth { get; set; }

    [Parameter]
    public string? Width { get; set; }

    [Parameter]
    public string? Height { get; set; }

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Parameter]
    public bool ShowControls { get; set; }

    [Parameter]
    public EventCallback<string?> OnAccept { get; set; }

    [Parameter]
    public EventCallback OnClear { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
      if (!firstRender)
        return;
      await this.be.EvalVoid((object) this.script);
      await this.be.JSVoid("initSignaturePad", (object) ("#" + this.Id + " canvas"), (object) this.BackgroundColor, (object) this.InkColor, (object) this.StrokeWidth);
    }

    private async Task AcceptSignature()
    {
      string result = await this.be.JSGet<string>("acceptSignature", (object) ("#" + this.Id + " canvas"));
      await this.OnAccept.InvokeAsync(result);
      result = (string) null;
    }

    private async Task ClearSignature()
    {
      await this.be.JSVoid("clearPad", (object) ("#" + this.Id + " canvas"));
      await this.OnClear.InvokeAsync();
    }

    [Inject]
    private BrowserExtensions be { get; set; }

    [Inject]
    private StateManager sm { get; set; }

    public Signature()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
      interpolatedStringHandler.AppendLiteral("sgn-");
      interpolatedStringHandler.AppendFormatted<Guid>(Guid.NewGuid());
      // ISSUE: reference to a compiler-generated field
      this.Id = interpolatedStringHandler.ToStringAndClear();
      // ISSUE: reference to a compiler-generated field
      this.BackgroundColor = "white";
      // ISSUE: reference to a compiler-generated field
      this.InkColor = "black";
      // ISSUE: reference to a compiler-generated field
      this.StrokeWidth = new int?(2);
      // ISSUE: reference to a compiler-generated field
      this.Width = "auto";
      // ISSUE: reference to a compiler-generated field
      this.Height = "100px";
      // ISSUE: reference to a compiler-generated field
      this.ShowControls = true;
      this.script = "function initSignaturePad(e,t=\"white\",n=\"black\",i=2){let r=document.querySelector(e),o=r.getContext(\"2d\");o.lineWidth=i,o.backgroundColor=t,o.strokeStyle=n,o.lineJoin=o.lineCap=\"round\";let a=!1,l,d,c=e=>[l=e.clientX-e.target.getBoundingClientRect().x,d=e.clientY-e.target.getBoundingClientRect().y],u=e=>{a=!0,o.beginPath();let[t,n]=c(e);o.moveTo(t,n)},g=()=>{a=!1},s=e=>{if(!a)return;let[t,n]=c(e);o.lineTo(t,n),o.stroke()};r.addEventListener(\"touchmove\",e=>e.preventDefault()),r.addEventListener(\"pointerdown\",u,{passive:!0}),r.addEventListener(\"pointerup\",g,{passive:!0}),r.addEventListener(\"pointermove\",s,{passive:!0})}function clearPad(e){let t=document.querySelector(e),n=t.getContext(\"2d\");n.clearRect(0,0,t.width,t.height)}function acceptSignature(e){let t=document.querySelector(e);return t.toDataURL(\"image/png\",1)}";
      // ISSUE: reference to a compiler-generated field
      this.be = (BrowserExtensions) null;
      // ISSUE: reference to a compiler-generated field
      this.sm = (StateManager) null;
      // ISSUE: explicit constructor call
      base.OnInitialized();
    }
  }
}
