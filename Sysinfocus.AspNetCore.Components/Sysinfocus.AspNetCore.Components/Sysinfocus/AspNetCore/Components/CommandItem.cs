// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.CommandItem
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
  public class CommandItem : ComponentBase
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "button");
      __builder.AddAttribute(1, "id", "command-item-" + this.Id);
      __builder.AddAttribute(2, "class", "sbc-command-item " + (this.Selected ? "selected" : (string) null));
      __builder.AddAttribute<MouseEventArgs>(3, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, new Func<Task>(this.HandleClick)));
      __builder.AddAttribute<KeyboardEventArgs>(4, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Func<KeyboardEventArgs, Task>(this.HandleKeyDown)));
      __builder.AddAttribute(5, "accesskey", this.Item.Shortcut);
      __builder.AddAttribute(6, "b-2ooujjy23m");
      __builder.OpenElement(7, "div");
      __builder.AddAttribute(8, "class", "sbc-command-item-name");
      __builder.AddAttribute(9, "b-2ooujjy23m");
      __builder.OpenElement(10, "span");
      __builder.AddAttribute(11, "class", "material-symbols-outlined");
      __builder.AddAttribute(12, "b-2ooujjy23m");
      __builder.AddContent(13, this.Item.Icon);
      __builder.CloseElement();
      __builder.AddMarkupContent(14, "\r\n        ");
      __builder.AddContent(15, this.Item.Name);
      __builder.CloseElement();
      if (this.Item.Shortcut != null)
      {
        __builder.OpenElement(16, "small");
        __builder.AddAttribute(17, "b-2ooujjy23m");
        __builder.AddContent(18, this.AltIcon);
        __builder.AddContent(19, " ");
        __builder.AddContent(20, this.Item.Shortcut);
        __builder.CloseElement();
      }
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    string? Id { get; set; }

    [Parameter]
    [EditorRequired]
    public CommandOption Item { get; set; } = (CommandOption) null;

    [Parameter]
    public bool Selected { get; set; }

    [Parameter]
    public EventCallback<CommandOption?> OnClick { get; set; }

    [Parameter]
    public string AltIcon { get; set; } = string.Empty;

    private async Task HandleClick() => await this.OnClick.InvokeAsync(this.Item);

    private async Task HandleKeyDown(KeyboardEventArgs args)
    {
      if (args.Key == "Escape")
      {
        await this.OnClick.InvokeAsync((CommandOption) null);
      }
      else
      {
        if (!(args.Key == "Enter"))
          return;
        await this.OnClick.InvokeAsync(this.Item);
      }
    }

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
