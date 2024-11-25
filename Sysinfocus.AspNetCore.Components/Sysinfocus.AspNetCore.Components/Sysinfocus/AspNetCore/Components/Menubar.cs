// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Menubar
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class Menubar : ComponentBase
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-menubar");
      __builder.AddAttribute(2, "b-7nv3jrqc85");
      __builder.AddContent(3, this.ChildContent);
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    RenderFragment? ChildContent { get; set; }

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
