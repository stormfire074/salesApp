// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Checkbox
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class Checkbox : ComponentBase
  {
    private string? _class;
    private bool pd;

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-checkbox");
      __builder.AddAttribute(2, "title", this.Tooltip);
      __builder.AddAttribute(3, "b-ix9et0c73c");
      __builder.OpenElement(4, "div");
      __builder.AddAttribute(5, "tabindex", (object) (this.Disabled ? -1 : 0));
      __builder.AddAttribute(6, "class", this._class);
      __builder.AddAttribute(7, "style", this.Style);
      __builder.AddAttribute<KeyboardEventArgs>(8, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Func<KeyboardEventArgs, Task>(this.HandleKeyDown)));
      __builder.AddAttribute<MouseEventArgs>(9, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, new Func<Task>(this.Toggle)));
      __builder.AddEventPreventDefaultAttribute(10, "onkeydown", this.pd);
      __builder.AddAttribute(11, "b-ix9et0c73c");
      __builder.OpenElement(12, "input");
      __builder.AddAttribute(13, "accesskey", this.AccessKey);
      __builder.AddAttribute(14, "type", "checkbox");
      __builder.AddAttribute(15, "checked", this.Checked);
      __builder.AddAttribute(16, "disabled", this.Disabled);
      __builder.AddAttribute(17, "id", this.Id);
      __builder.AddAttribute(18, "name", this.Name);
      __builder.AddAttribute(19, "b-ix9et0c73c");
      __builder.CloseElement();
      if (this.Checked)
      {
        __builder.OpenElement(20, "div");
        __builder.AddAttribute(21, "class", "tick-mark");
        __builder.AddAttribute(22, "b-ix9et0c73c");
        __builder.AddContent(23, Icons.TICK_ICON);
        __builder.CloseElement();
      }
      __builder.CloseElement();
      if (!string.IsNullOrEmpty(this.Label))
      {
        __builder.OpenElement(24, "label");
        __builder.AddAttribute(25, "tabindex", "-1");
        __builder.AddAttribute(26, "for", this.Id);
        __builder.AddAttribute<KeyboardEventArgs>(27, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Func<KeyboardEventArgs, Task>(this.HandleKeyDown)));
        __builder.AddEventPreventDefaultAttribute(28, "onkeydown", this.pd);
        __builder.AddAttribute(29, "b-ix9et0c73c");
        __builder.AddContent(30, this.Label);
        __builder.CloseElement();
      }
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    string? Id { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public string? AccessKey { get; set; }

    [Parameter]
    public string? Label { get; set; }

    [Parameter]
    public string? Tooltip { get; set; }

    [Parameter]
    public bool Checked { get; set; }

    [Parameter]
    public string? Name { get; set; }

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Parameter]
    public EventCallback<bool> OnClick { get; set; }

    protected override void OnParametersSet()
    {
      this._class = "checkbox-wrapper ".AppendTo(this.Checked ? " checked" : (string) null).AppendTo(this.Disabled ? " disabled" : (string) null).AppendTo(" " + this.Class);
    }

    private async Task Toggle()
    {
      if (this.Disabled)
        return;
      this.Checked = !this.Checked;
      this._class = "checkbox-wrapper ".AppendTo(this.Checked ? " checked" : (string) null).AppendTo(this.Disabled ? " disabled" : (string) null).AppendTo(" " + this.Class);
      await this.OnClick.InvokeAsync(this.Checked);
    }

    private async Task HandleKeyDown(KeyboardEventArgs args)
    {
      this.pd = false;
      if (!(args.Key == "Enter") && !(args.Key == " "))
        return;
      this.pd = true;
      await this.Toggle();
    }

    [Inject]
    private StateManager sm { get; set; }

    public Checkbox()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
      interpolatedStringHandler.AppendLiteral("chk-");
      interpolatedStringHandler.AppendFormatted<Guid>(Guid.NewGuid());
      // ISSUE: reference to a compiler-generated field
      this.Id = interpolatedStringHandler.ToStringAndClear();
      // ISSUE: reference to a compiler-generated field
      this.sm = (StateManager) null;
      // ISSUE: explicit constructor call
      base.OnInitialized();
    }
  }
}
