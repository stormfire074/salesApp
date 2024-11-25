// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Separator
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class Separator : ComponentBase
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      if (this.Vertical)
      {
        __builder.OpenElement(0, "div");
        __builder.AddAttribute(1, "class", "sbc-separator-vertical " + this.Class);
        __builder.AddAttribute(2, "style", this.Style);
        __builder.AddAttribute(3, "b-a729lixv8b");
        __builder.CloseElement();
      }
      else
      {
        __builder.OpenElement(4, "div");
        __builder.AddAttribute(5, "class", "sbc-separator-horizontal " + this.Class);
        __builder.AddAttribute(6, "style", this.Style);
        __builder.AddAttribute(7, "b-a729lixv8b");
        __builder.CloseElement();
      }
    }

    [Parameter]
    public bool Vertical { get; set; }

    [Parameter]
    public 
    #nullable enable
    string? Class { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
