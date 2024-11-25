// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.TabItem
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class TabItem : ComponentBase
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      int? activeItem = this.Parent?.ActiveItem;
      int num = this.Item;
      if (!(activeItem.GetValueOrDefault() == num & activeItem.HasValue))
        return;
      __builder.AddContent(0, this.ChildContent);
    }

    [CascadingParameter]
    private 
    #nullable enable
    Tabs? Parent { get; set; }

    [Parameter]
    [EditorRequired]
    public int Item { get; set; }

    [Parameter]
    [EditorRequired]
    public RenderFragment ChildContent { get; set; } = (RenderFragment) null;

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
