// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Input`1
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class Input<TItem> : ComponentBase
  {
    private string? errorMessage;

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-input " + this.Class);
      __builder.AddAttribute(2, "b-9pp4fu6np5");
      if (!string.IsNullOrEmpty(this.Label))
      {
        __builder.OpenElement(3, "label");
        __builder.AddAttribute(4, "for", this.Id);
        __builder.AddAttribute(5, "style", !string.IsNullOrEmpty(this.errorMessage) ? "color: var(--error);" : (string) null);
        __builder.AddAttribute(6, "b-9pp4fu6np5");
        __builder.AddContent(7, this.Label);
        __builder.CloseElement();
      }
      __builder.OpenElement(8, "input");
      __builder.AddAttribute(9, "accesskey", this.AccessKey);
      __builder.AddAttribute(10, "id", this.Id);
      __builder.AddAttribute(11, "style", this.Style);
      __builder.AddAttribute(12, "type", this.Type);
      __builder.AddAttribute(13, "placeholder", this.Placeholder);
      __builder.AddAttribute(14, "readonly", this.ReadOnly);
      __builder.AddAttribute(15, "disabled", this.Disabled);
      __builder.AddAttribute(16, "maxlength", (object) this.MaxLength);
      __builder.AddAttribute(17, "min", (object) this.Min);
      __builder.AddAttribute(18, "max", (object) this.Max);
      __builder.AddAttribute(19, "aria-autocomplete", "none");
      __builder.AddAttribute(20, "spellcheck", "false");
      __builder.AddAttribute<ChangeEventArgs>(21, "oninput", EventCallback.Factory.Create<ChangeEventArgs>((object) this, new Func<ChangeEventArgs, Task>(this.HandleInput)));
      __builder.AddAttribute(22, "autofocus", this.Focus);
      __builder.AddAttribute(23, "name", this.Name);
      __builder.AddAttribute<KeyboardEventArgs>(24, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, this.OnKeyDown));
      __builder.AddAttribute<KeyboardEventArgs>(25, "onkeyup", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, this.OnKeyUp));
      __builder.AddAttribute<FocusEventArgs>(26, "onfocus", EventCallback.Factory.Create<FocusEventArgs>((object) this, this.OnFocus));
      __builder.AddAttribute<FocusEventArgs>(27, "onblur", EventCallback.Factory.Create<FocusEventArgs>((object) this, this.OnBlur));
      __builder.AddAttribute(28, "value", BindConverter.FormatValue<TItem>(this.Value));
      __builder.AddAttribute<ChangeEventArgs>(29, "onchange", EventCallback.Factory.CreateBinder<TItem>((object) this, (Action<TItem>) (__value => this.Value = __value), this.Value));
      __builder.SetUpdatesAttributeName("value");
      __builder.AddAttribute(30, "b-9pp4fu6np5");
      __builder.CloseElement();
      if (!string.IsNullOrEmpty(this.Info))
      {
        __builder.OpenElement(31, "span");
        __builder.AddAttribute(32, "b-9pp4fu6np5");
        __builder.AddContent(33, this.Info);
        __builder.CloseElement();
      }
      if (!string.IsNullOrEmpty(this.errorMessage))
      {
        __builder.OpenElement(34, "p");
        __builder.AddAttribute(35, "style", "color: var(--error); font-size: 14px");
        __builder.AddAttribute(36, "b-9pp4fu6np5");
        __builder.AddContent(37, this.errorMessage);
        __builder.CloseElement();
      }
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    string? Id { get; set; } = "input-" + Guid.NewGuid().ToString().Replace("-", "");

    [Parameter]
    public string? AccessKey { get; set; }

    [Parameter]
    public string? Placeholder { get; set; }

    [Parameter]
    public TItem? Value { get; set; }

    [Parameter]
    public EventCallback<KeyboardEventArgs> OnKeyUp { get; set; }

    [Parameter]
    public EventCallback<KeyboardEventArgs> OnKeyDown { get; set; }

    [Parameter]
    public EventCallback<FocusEventArgs> OnFocus { get; set; }

    [Parameter]
    public EventCallback<FocusEventArgs> OnBlur { get; set; }

    [Parameter]
    public EventCallback<TItem?> ValueChanged { get; set; }

    [Parameter]
    public string Type { get; set; } = "text";

    [Parameter]
    public string? Label { get; set; }

    [Parameter]
    public string? Info { get; set; }

    [Parameter]
    public string? Name { get; set; }

    [Parameter]
    public bool ReadOnly { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public string? Format { get; set; }

    [Parameter]
    public string? Display { get; set; }

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Parameter]
    public int MaxLength { get; set; } = -1;

    [Parameter]
    public TItem? Min { get; set; }

    [Parameter]
    public TItem? Max { get; set; }

    [Parameter]
    public bool Focus { get; set; }

    [Parameter]
    public string? Error { get; set; }

    [CascadingParameter]
    private Dictionary<string, string>? FormErrors { get; set; }

    protected override void OnParametersSet()
    {
      this.errorMessage = (string) null;
      if (this.FormErrors == null || this.Error == null || !this.FormErrors.ContainsKey(this.Error))
        return;
      this.errorMessage = this.FormErrors[this.Error];
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
      if (!firstRender || !this.Focus)
        return;
      await this.jsr.InvokeVoidAsync("eval", (object) ("document.querySelector('#" + this.Id + "')?.focus()"));
    }

    private async Task HandleInput(ChangeEventArgs args)
    {
      if (typeof (TItem).Name.StartsWith("Nullable"))
      {
        string str = Nullable.GetUnderlyingType(typeof (TItem))?.Name;
        object int32;
        switch (str)
        {
          case "Int32":
            int32 = (object) Convert.ToInt32(args.Value);
            break;
          case "Double":
            int32 = (object) Convert.ToDouble(args.Value);
            break;
          case "Decimal":
            int32 = (object) Convert.ToDecimal(args.Value);
            break;
          default:
            int32 = args.Value;
            break;
        }
        object x = int32;
        str = (string) null;
        this.Value = (TItem) x;
        x = (object) null;
      }
      else
      {
        string str = typeof (TItem).Name;
        object int32;
        switch (str)
        {
          case "Int32":
            int32 = (object) Convert.ToInt32(this.ZeroWhenNullOrEmpty(args.Value?.ToString()));
            break;
          case "Double":
            int32 = (object) Convert.ToDouble(this.ZeroWhenNullOrEmpty(args.Value?.ToString()));
            break;
          case "Decimal":
            int32 = (object) Convert.ToDecimal(this.ZeroWhenNullOrEmpty(args.Value?.ToString()));
            break;
          default:
            int32 = args.Value;
            break;
        }
        object y = int32;
        str = (string) null;
        this.Value = (TItem) y;
        y = (object) null;
      }
      this.Display = args.Value?.ToString();
      if (this.Format != null)
        this.Display = string.Format(args.Value?.ToString(), (object) this.Format);
      await this.ValueChanged.InvokeAsync(this.Value);
    }

    private string ZeroWhenNullOrEmpty(string? value)
    {
      return !string.IsNullOrWhiteSpace(value) ? value : "0";
    }

    [Inject]
    private IJSRuntime jsr { get; set; } = (IJSRuntime) null;

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
