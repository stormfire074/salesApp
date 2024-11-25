// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Skeleton
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class Skeleton : ComponentBase
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-skeleton");
      __builder.AddAttribute(2, "style", "width: " + this.Width + "; height: " + this.Height + "; border-radius: " + this.Radius);
      __builder.AddAttribute(3, "b-rdllu0a49g");
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    string Width { get; set; } = "100%";

    [Parameter]
    public string Height { get; set; } = "16px";

    [Parameter]
    public string Radius { get; set; } = "16px";

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
