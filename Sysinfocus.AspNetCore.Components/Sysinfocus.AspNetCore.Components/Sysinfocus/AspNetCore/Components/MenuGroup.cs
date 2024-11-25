// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.MenuGroup
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class MenuGroup : ComponentBase
  {
    private bool shown;

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      if (!this.Show)
        return;
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "id", this.Id);
      __builder.AddAttribute(2, "class", "sbc-menu-group");
      __builder.AddAttribute(3, "style", this.Style);
      __builder.AddAttribute(4, "b-y1yvki29h8");
      foreach (MenuItemOption menuItemOption in this.Items)
      {
        __builder.OpenComponent<MenuItem>(5);
        __builder.AddComponentParameter(6, "Item", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MenuItemOption>(menuItemOption));
        __builder.AddComponentParameter(7, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback<MenuItemOption>>(EventCallback.Factory.Create<MenuItemOption>((object) this, (Func<MenuItemOption, Task>) (x => this.UpdateMenu(x)))));
        __builder.AddComponentParameter(8, "OnKeyDown", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback<KeyboardEventArgs>>(EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Func<KeyboardEventArgs, Task>(this.HandleKeyDown))));
        __builder.CloseComponent();
      }
      __builder.CloseElement();
    }

    [Parameter]
    [EditorRequired]
    public 
    #nullable enable
    IEnumerable<MenuItemOption> Items { get; set; }

    [Parameter]
    public EventCallback<MenuItemOption?> OnSelect { get; set; }

    [Parameter]
    public string? Id { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Parameter]
    public bool Show { get; set; }

    private async Task UpdateMenu(MenuItemOption menu)
    {
      if (menu.RadioGroup != null)
      {
        foreach (MenuItemOption x in this.Items.Where<MenuItemOption>((Func<MenuItemOption, bool>) (m => m.RadioGroup == menu.RadioGroup && m != menu)))
          x.Checked = false;
      }
      await this.OnSelect.InvokeAsync(menu);
    }

    private async Task HandleKeyDown(KeyboardEventArgs args)
    {
      if (args.Key == "ArrowUp")
        await this.jsr.InvokeVoidAsync("eval", (object) "event.preventDefault(); document.activeElement.previousElementSibling?.focus()");
      else if (args.Key == "ArrowDown")
        await this.jsr.InvokeVoidAsync("eval", (object) "event.preventDefault(); document.activeElement.nextElementSibling?.focus()");
      else if (args.Key == " ")
        await this.jsr.InvokeVoidAsync("eval", (object) "event.preventDefault(); document.activeElement?.click();");
      else if (args.Key == "Escape")
        this.Show = false;
      else if (args.Key == "Home" || args.Key == "PageUp")
      {
        await this.jsr.InvokeVoidAsync("eval", (object) "event.preventDefault(); document.activeElement.parentElement.firstElementChild?.focus()");
      }
      else
      {
        if (!(args.Key == "End") && !(args.Key == "PageDown"))
          return;
        await this.jsr.InvokeVoidAsync("eval", (object) "event.preventDefault(); document.activeElement.parentElement.lastElementChild?.focus()");
      }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
      if (this.Show && !this.shown)
      {
        await Task.Delay(100);
        await this.jsr.InvokeVoidAsync("eval", (object) ("document.querySelector('#" + this.Id + " :first-child')?.focus()"));
        this.shown = true;
      }
      else
      {
        if (this.Show)
          return;
        this.shown = false;
      }
    }

    [Inject]
    private IJSRuntime jsr { get; set; }

    [Inject]
    private StateManager sm { get; set; }

    public MenuGroup()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
      interpolatedStringHandler.AppendLiteral("mg-");
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
