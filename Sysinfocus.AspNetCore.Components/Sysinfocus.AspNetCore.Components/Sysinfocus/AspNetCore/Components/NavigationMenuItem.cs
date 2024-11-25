// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.NavigationMenuItem
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class NavigationMenuItem : ComponentBase
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "id", this.Id);
      __builder.AddAttribute(2, "class", "sbc-navigation-menu-item");
      __builder.AddAttribute<MouseEventArgs>(3, "onmouseover", EventCallback.Factory.Create<MouseEventArgs>((object) this, (Func<Task>) (() => this.SetFocus())));
      __builder.AddAttribute<MouseEventArgs>(4, "onmouseout", EventCallback.Factory.Create<MouseEventArgs>((object) this, (Func<Task>) (() => this.CancelFocus())));
      if (this.ChildContent != null)
      {
        __builder.OpenElement(5, "button");
        __builder.AddContent(6, this.Title);
        __builder.AddMarkupContent(7, "<span class=\"material-symbols-outlined\">keyboard_arrow_down</span>");
        __builder.CloseElement();
        __builder.AddMarkupContent(8, "\r\n        ");
        __builder.OpenElement(9, "div");
        __builder.AddAttribute(10, "class", "sbc-navigation-menu-item-details");
        __builder.AddContent(11, this.ChildContent);
        __builder.CloseElement();
      }
      else
      {
        __builder.OpenElement(12, "button");
        __builder.AddAttribute<MouseEventArgs>(13, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, new Action(this.GotoUrl)));
        __builder.AddContent(14, this.Title);
        __builder.CloseElement();
      }
      __builder.CloseElement();
    }

    [CascadingParameter]
    private 
    #nullable enable
    NavigationMenu Parent { get; set; } = (NavigationMenu) null;

    [Parameter]
    public string? Id { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public string? Url { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    private async Task SetFocus()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(206, 3);
      interpolatedStringHandler.AppendLiteral("\r\n            const left = document.querySelector('#");
      interpolatedStringHandler.AppendFormatted(this.Parent.Id);
      interpolatedStringHandler.AppendLiteral("').getBoundingClientRect().left;\r\n            document.querySelector('#");
      interpolatedStringHandler.AppendFormatted(this.Id);
      interpolatedStringHandler.AppendLiteral("').style.left = left+'px';\r\n            document.querySelector('#");
      interpolatedStringHandler.AppendFormatted(this.Id);
      interpolatedStringHandler.AppendLiteral(" button').focus();");
      string scr = interpolatedStringHandler.ToStringAndClear();
      await this.jsr.InvokeVoidAsync("eval", (object) scr);
      scr = (string) null;
    }

    private async Task CancelFocus()
    {
      string scr = "document.activeElement = null";
      await this.jsr.InvokeVoidAsync("eval", (object) scr);
      scr = (string) null;
    }

    private void GotoUrl()
    {
      if (this.Url == null)
        return;
      this.navman.NavigateTo(this.Url);
    }

    [Inject]
    private NavigationManager navman { get; set; } = (NavigationManager) null;

    [Inject]
    private IJSRuntime jsr { get; set; } = (IJSRuntime) null;

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
