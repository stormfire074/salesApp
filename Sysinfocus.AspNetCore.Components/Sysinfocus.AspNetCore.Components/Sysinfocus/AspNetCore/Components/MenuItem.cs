// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.MenuItem
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class MenuItem : ComponentBase
  {
    private ElementReference _elementReference;

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      if (string.IsNullOrEmpty(this.Item.Text) && InitializeSysinfocus.IsLicensed)
        __builder.AddMarkupContent(0, "<div class=\"sbc-menu_separator\" b-zvobfdt8qz></div>");
      else if (string.IsNullOrEmpty(this.Item.Text))
      {
        __builder.AddMarkupContent(1, "<small class=\"mtb05\" style=\"opacity: 0.2\" b-zvobfdt8qz>You are using a trial version.</small>");
      }
      else
      {
        __builder.OpenElement(2, "button");
        __builder.AddAttribute(3, "tabindex", (object) (this.Item.IsHeader ? -1 : 0));
        __builder.AddAttribute(4, "class", "sbc-menuitem " + (this.Item.IsHeader ? "menu_header" : (string) null));
        __builder.AddAttribute(5, "disabled", this.Item.Disabled);
        __builder.AddAttribute<MouseEventArgs>(6, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, new Func<Task>(this.HandleClick)));
        __builder.AddAttribute<KeyboardEventArgs>(7, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, this.OnKeyDown));
        __builder.AddAttribute(8, "b-zvobfdt8qz");
        __builder.AddElementReferenceCapture(9, (Action<ElementReference>) (__value => this._elementReference = __value));
        if (this.Item.MenuType == Sysinfocus.AspNetCore.Components.MenuType.Checkbox && InitializeSysinfocus.IsLicensed)
        {
          __builder.OpenElement(10, "div");
          __builder.AddAttribute(11, "class", "menu_can_check");
          __builder.AddAttribute(12, "b-zvobfdt8qz");
          if (this.Item.Checked && this.Item.ShowCheckmark)
          {
            __builder.OpenElement(13, "span");
            __builder.AddAttribute(14, "class", "material-symbols-outlined menu_check");
            __builder.AddAttribute(15, "b-zvobfdt8qz");
            __builder.AddContent(16, Icons.TICK_ICON);
            __builder.CloseElement();
          }
          else
            __builder.AddMarkupContent(17, "<span class=\"menu_check\" b-zvobfdt8qz>&nbsp;</span>");
          __builder.OpenElement(18, "span");
          __builder.AddAttribute(19, "class", "menu_text" + (this.Item.IsHeader ? " menu_header" : (string) null));
          __builder.AddAttribute(20, "b-zvobfdt8qz");
          __builder.AddContent(21, this.Item.Text);
          __builder.CloseElement();
          __builder.CloseElement();
        }
        else if (this.Item.MenuType == Sysinfocus.AspNetCore.Components.MenuType.Radio && InitializeSysinfocus.IsLicensed)
        {
          __builder.OpenElement(22, "div");
          __builder.AddAttribute(23, "class", "menu_can_check");
          __builder.AddAttribute(24, "b-zvobfdt8qz");
          if (this.Item.Checked)
            __builder.AddMarkupContent(25, "<span class=\"menu_radio\" b-zvobfdt8qz></span>");
          else
            __builder.AddMarkupContent(26, "<span class=\"menu_check\" b-zvobfdt8qz>&nbsp;</span>");
          __builder.OpenElement(27, "span");
          __builder.AddAttribute(28, "class", "menu_text");
          __builder.AddAttribute(29, "b-zvobfdt8qz");
          __builder.AddContent(30, this.Item.Text);
          __builder.CloseElement();
          __builder.CloseElement();
        }
        else
        {
          __builder.OpenElement(31, "span");
          __builder.AddAttribute(32, "class", "menu_text " + (this.Item.IsHeader ? "menu_header" : (string) null));
          __builder.AddAttribute(33, "b-zvobfdt8qz");
          __builder.AddContent(34, this.Item.Text);
          __builder.CloseElement();
        }
        if (this.Item.Icon != null)
        {
          __builder.OpenElement(35, "span");
          __builder.AddAttribute(36, "class", "material-symbols-outlined menu_icon");
          __builder.AddAttribute(37, "b-zvobfdt8qz");
          __builder.AddContent(38, this.Item.Icon);
          __builder.CloseElement();
        }
        else if (this.Item.Shortcut != null)
        {
          __builder.OpenElement(39, "span");
          __builder.AddAttribute(40, "class", "menu_shortcut");
          __builder.AddAttribute(41, "b-zvobfdt8qz");
          __builder.AddContent(42, this.Item.Shortcut);
          __builder.CloseElement();
        }
        __builder.CloseElement();
      }
    }

    [Parameter]
    public 
    #nullable enable
    MenuItemOption Item { get; set; } = (MenuItemOption) null;

    [Parameter]
    public EventCallback<MenuItemOption> OnClick { get; set; }

    [Parameter]
    public EventCallback<KeyboardEventArgs> OnKeyDown { get; set; }

    private async Task HandleClick()
    {
      if (this.Item.IsHeader)
        return;
      if (this.Item.ShowCheckmark)
        this.Item.Checked = !this.Item.Checked;
      await this.OnClick.InvokeAsync(this.Item);
    }

    public async Task SetFocusAsync()
    {
      await Task.Delay(50);
      await this._elementReference.FocusAsync();
    }

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;

    public enum MenuType
    {
      Normal,
      Checkbox,
      Radio,
    }
  }
}
