// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.NavigationMenu
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using __Blazor.Sysinfocus.AspNetCore.Components.NavigationMenu;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class NavigationMenu : ComponentBase
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "id", this.Id);
      __builder.AddAttribute(2, "class", "sbc-navigation-menu");
      __builder.AddAttribute(3, "b-bkh4qmzm97");
      TypeInference.CreateCascadingValue_0<Sysinfocus.AspNetCore.Components.NavigationMenu>(__builder, 4, 5, this, 6, true, 7, (RenderFragment) (__builder2 => __builder2.AddContent(8, this.ChildContent)));
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    string? Id { get; set; }

    [Parameter]
    public List<NavigationMenuItem>? Items { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Inject]
    private IJSRuntime jsr { get; set; }

    [Inject]
    private StateManager sm { get; set; }

    public NavigationMenu()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
      interpolatedStringHandler.AppendLiteral("nv-");
      interpolatedStringHandler.AppendFormatted<Guid>(Guid.NewGuid());
      // ISSUE: reference to a compiler-generated field
      this.Id = interpolatedStringHandler.ToStringAndClear();
      // ISSUE: reference to a compiler-generated field
      this.jsr = (IJSRuntime) null;
      // ISSUE: reference to a compiler-generated field
      this.sm = (StateManager) null;
      // ISSUE: explicit constructor call
      base.OnInitialized();
    }
  }
}
