// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.RadioGroup
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using __Blazor.Sysinfocus.AspNetCore.Components.RadioGroup;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class RadioGroup : ComponentBase
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-radiogroup");
      __builder.AddAttribute(2, "b-r113yzy3kq");
      TypeInference.CreateCascadingValue_0<Sysinfocus.AspNetCore.Components.RadioGroup>(__builder, 3, 4, this, 5, (RenderFragment) (__builder2 => __builder2.AddContent(6, this.ChildContent)));
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    RenderFragment? ChildContent { get; set; }

    [Parameter]
    [EditorRequired]
    public string Name { get; set; } = string.Empty;

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
