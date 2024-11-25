// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.ScrollArea
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class ScrollArea : ComponentBase
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      if (this.Horizontal)
      {
        __builder.OpenElement(0, "div");
        __builder.AddAttribute(1, "class", "sbc-scroll-area-horizontal " + this.Class);
        __builder.AddAttribute(2, "style", "gap: " + this.Gap + "; width: " + this.Width + "; height: " + this.Height + "; padding: " + this.Padding + "; " + this.Style);
        __builder.AddAttribute(3, "b-epyu621z5b");
        __builder.AddContent(4, this.ChildContent);
        __builder.CloseElement();
      }
      else
      {
        __builder.OpenElement(5, "div");
        __builder.AddAttribute(6, "class", "sbc-scroll-area-vertical " + this.Class);
        __builder.AddAttribute(7, "style", "gap: " + this.Gap + "; width: " + this.Width + "; height: " + this.Height + "; padding: " + this.Padding + "; " + this.Style);
        __builder.AddAttribute(8, "b-epyu621z5b");
        __builder.AddContent(9, this.ChildContent);
        __builder.CloseElement();
      }
    }

    [Parameter]
    public 
    #nullable enable
    string Width { get; set; } = "200px";

    [Parameter]
    public string Height { get; set; } = "300px";

    [Parameter]
    public string Padding { get; set; } = "1rem";

    [Parameter]
    public string Gap { get; set; } = "8px";

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Parameter]
    public bool Horizontal { get; set; }

    [Parameter]
    [EditorRequired]
    public RenderFragment? ChildContent { get; set; }

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
