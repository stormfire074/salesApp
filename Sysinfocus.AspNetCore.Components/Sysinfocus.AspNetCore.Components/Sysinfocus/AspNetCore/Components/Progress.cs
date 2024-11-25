// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Progress
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class Progress : ComponentBase
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-percent-container");
      __builder.AddAttribute(2, "b-4ch6subpbl");
      __builder.OpenElement(3, "div");
      __builder.AddAttribute(4, "class", "sbc-progress");
      __builder.AddAttribute(5, "style", "background-color: " + this.Background + "; height: " + this.Height + "; border-radius: " + this.Height);
      __builder.AddAttribute(6, "b-4ch6subpbl");
      __builder.OpenElement(7, "div");
      __builder.AddAttribute(8, "class", "sbc-progress-completed");
      __builder.AddAttribute(9, "style", "background-color: " + this.Foreground + "; width: " + this.Percent.ToString() + "%");
      __builder.AddAttribute(10, "b-4ch6subpbl");
      __builder.CloseElement();
      __builder.CloseElement();
      __builder.AddMarkupContent(11, "\r\n    ");
      __builder.OpenElement(12, "small");
      __builder.AddAttribute(13, "b-4ch6subpbl");
      __builder.AddContent(14, (object) this.Percent);
      __builder.AddContent(15, " %");
      __builder.CloseElement();
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    string Background { get; set; } = "var(--btn-secondary-bg)";

    [Parameter]
    public string Foreground { get; set; } = "var(--btn-secondary-fg)";

    [Parameter]
    public string Height { get; set; } = "8px";

    [Parameter]
    public int Percent { get; set; } = 25;

    [Parameter]
    public bool ShowLabel { get; set; } = true;

    protected override void OnParametersSet()
    {
      if (this.Percent <= 100)
        return;
      this.Percent = 100;
    }

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
