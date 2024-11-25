// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.MenubarItem
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class MenubarItem : ComponentBase
  {
    private ElementReference btn = new ElementReference();

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-menubar-item");
      __builder.OpenElement(2, "button");
      __builder.AddAttribute(3, "class", "sbc-menu-button");
      __builder.AddAttribute<MouseEventArgs>(4, "onmouseover", EventCallback.Factory.Create<MouseEventArgs>((object) this, new Func<Task>(this.SetFocus)));
      __builder.AddElementReferenceCapture(5, (Action<ElementReference>) (__value => this.btn = __value));
      __builder.AddContent(6, this.Root);
      __builder.CloseElement();
      __builder.AddMarkupContent(7, "\r\n    ");
      __builder.AddContent(8, this.ChildContent);
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    string? Root { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    private async Task SetFocus() => await this.btn.FocusAsync();

    [Inject]
    private IJSRuntime jsr { get; set; } = (IJSRuntime) null;

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
