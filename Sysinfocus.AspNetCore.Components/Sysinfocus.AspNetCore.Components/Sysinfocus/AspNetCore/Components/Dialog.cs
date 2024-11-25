// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Dialog
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class Dialog : ComponentBase
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      if (!this.Show)
        return;
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "id", this.Id);
      __builder.AddAttribute(2, "class", "sbc-dialog " + this.Class);
      __builder.AddAttribute(3, "style", this.Style);
      __builder.AddAttribute<KeyboardEventArgs>(4, "onkeyup", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Func<KeyboardEventArgs, Task>(this.HandleKeyUp)));
      __builder.AddAttribute(5, "b-d4ez2zyrqb");
      __builder.OpenElement(6, "div");
      __builder.AddAttribute(7, "class", "sbc-dialog-overlay");
      __builder.AddAttribute<MouseEventArgs>(8, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, this.OnClose));
      __builder.AddAttribute(9, "b-d4ez2zyrqb");
      __builder.CloseElement();
      __builder.AddMarkupContent(10, "\r\n        ");
      __builder.OpenElement(11, "div");
      __builder.AddAttribute(12, "class", "sbc-dialog-alert show");
      __builder.AddAttribute(13, "style", "width: " + this.Width + ";");
      __builder.AddAttribute(14, "b-d4ez2zyrqb");
      __builder.OpenElement(15, "div");
      __builder.AddAttribute(16, "class", "sbc-dialog-header");
      __builder.AddAttribute(17, "b-d4ez2zyrqb");
      __builder.AddContent(18, this.Header);
      __builder.CloseElement();
      if (this.ShowCloseIcon)
      {
        __builder.OpenComponent<Button>(19);
        __builder.AddComponentParameter(20, "Icon", (object) "close");
        __builder.AddComponentParameter(21, "Type", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<ButtonType>(ButtonType.Icon));
        __builder.AddComponentParameter(22, "Size", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<ButtonSize>(ButtonSize.Small));
        __builder.AddComponentParameter(23, "Class", (object) "nostyle");
        __builder.AddComponentParameter(24, "Style", (object) "position: absolute; right: 4px; top: 12px;");
        __builder.AddComponentParameter(25, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, this.OnClose)));
        __builder.CloseComponent();
      }
      __builder.OpenElement(26, "div");
      __builder.AddAttribute(27, "class", "sbc-dialog-content");
      __builder.AddAttribute(28, "b-d4ez2zyrqb");
      __builder.AddContent(29, this.Content);
      __builder.CloseElement();
      __builder.AddMarkupContent(30, "\r\n            ");
      __builder.OpenElement(31, "div");
      __builder.AddAttribute(32, "class", "sbc-dialog-footer");
      __builder.AddAttribute(33, "b-d4ez2zyrqb");
      __builder.AddContent(34, this.Footer);
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
    public bool ShowCloseIcon { get; set; }

    [Parameter]
    public bool CloseOnEscape { get; set; }

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

    [Parameter]
    public EventCallback OnClose { get; set; }

    protected override async Task OnParametersSetAsync()
    {
      ValueTask valueTask;
      if (this.Show)
      {
        await this.be.SetFocus("#" + this.Id + " .sbc-dialog-content input:first-child");
        BrowserExtensions be = this.be;
        object[] objArray = new object[1];
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(156, 2);
        interpolatedStringHandler.AppendLiteral("window.addEventListener('focusin', e => { if (e.target.closest('#");
        interpolatedStringHandler.AppendFormatted(this.Id);
        interpolatedStringHandler.AppendLiteral("') == null) document.querySelector('#");
        interpolatedStringHandler.AppendFormatted(this.Id);
        interpolatedStringHandler.AppendLiteral(" .sbc-dialog-content input:first-child')?.focus(); } )");
        objArray[0] = (object) interpolatedStringHandler.ToStringAndClear();
        valueTask = be.EvalVoid(objArray);
        await valueTask;
      }
      valueTask = this.be.EvalVoid((object) ("document.querySelector('body').style.overflow = '" + (this.Show ? "hidden" : "auto") + "'"));
      await valueTask;
    }

    private async Task HandleKeyUp(KeyboardEventArgs args)
    {
      if (!this.CloseOnEscape || !(args.Key == "Escape"))
        return;
      await this.OnClose.InvokeAsync();
    }

    [Inject]
    private BrowserExtensions be { get; set; }

    [Inject]
    private StateManager sm { get; set; }

    public Dialog()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(5, 1);
      interpolatedStringHandler.AppendLiteral("aldg-");
      interpolatedStringHandler.AppendFormatted<Guid>(Guid.NewGuid());
      // ISSUE: reference to a compiler-generated field
      this.Id = interpolatedStringHandler.ToStringAndClear();
      // ISSUE: reference to a compiler-generated field
      this.CloseOnEscape = true;
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
