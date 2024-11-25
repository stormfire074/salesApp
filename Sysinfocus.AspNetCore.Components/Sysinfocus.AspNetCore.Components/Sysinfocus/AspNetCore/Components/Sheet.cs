// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Sheet
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.CompilerServices;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class Sheet : ComponentBase
  {
    private string? show = nameof (show);
    private string? style;

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      if (!this.Show)
        return;
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-sheet");
      __builder.AddAttribute(2, "style", this.Style);
      __builder.AddAttribute(3, "b-aheysmy87t");
      __builder.OpenElement(4, "div");
      __builder.AddAttribute(5, "class", "sbc-sheet-overlay");
      __builder.AddAttribute<MouseEventArgs>(6, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, new Func<Task>(this.HandleCloseSheet)));
      __builder.AddAttribute(7, "b-aheysmy87t");
      __builder.CloseElement();
      __builder.AddMarkupContent(8, "\r\n    ");
      __builder.OpenElement(9, "div");
      __builder.AddAttribute(10, "class", "sbc-sheet-container" + (this.Show ? " " + this.show : (string) null));
      __builder.AddAttribute(11, "style", this.style);
      __builder.AddAttribute(12, "b-aheysmy87t");
      __builder.CloseElement();
      __builder.AddMarkupContent(13, "\r\n    ");
      __builder.OpenElement(14, "div");
      __builder.AddAttribute(15, "class", "sbc-sheet-content" + (this.Show ? " x" + this.show : (string) null));
      __builder.AddAttribute(16, "style", this.style);
      __builder.AddAttribute(17, "b-aheysmy87t");
      if (!InitializeSysinfocus.IsLicensed)
        __builder.AddMarkupContent(18, "<small class=\"mtb1\" b-aheysmy87t>You are using a trial version.</small>");
      __builder.AddContent(19, this.ChildContent);
      if (this.ShowClose)
      {
        __builder.OpenComponent<Button>(20);
        __builder.AddComponentParameter(21, "Icon", (object) "close");
        __builder.AddComponentParameter(22, "Type", (object) RuntimeHelpers.TypeCheck<ButtonType>(ButtonType.Ghost));
        __builder.AddComponentParameter(23, "Class", (object) "show-close");
        __builder.AddComponentParameter(24, "OnClick", (object) RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, new Func<Task>(this.HandleCloseSheet))));
        __builder.CloseComponent();
      }
      __builder.CloseElement();
      __builder.CloseElement();
    }

    [Parameter]
    [EditorRequired]
    public 
    #nullable enable
    RenderFragment ChildContent { get; set; } = (RenderFragment) null;

    [Parameter]
    public bool Show { get; set; }

    [Parameter]
    public bool ShowFromLeft { get; set; }

    [Parameter]
    public bool ShowClose { get; set; } = true;

    [Parameter]
    public string? Style { get; set; }

    [Parameter]
    public string Width { get; set; } = "384px";

    [Parameter]
    public EventCallback OnClose { get; set; }

    protected override void OnParametersSet()
    {
      this.style = "max-width: " + this.Width + ";";
      this.style += this.ShowFromLeft ? "left: 0;--from: -100%;" : "right: 0; --from: 100%;";
    }

    private async Task HandleCloseSheet()
    {
      this.show = "hide";
      await Task.Delay(300);
      this.Show = false;
      this.show = "show";
      await this.OnClose.InvokeAsync();
    }

    public async Task Close() => await this.HandleCloseSheet();

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
