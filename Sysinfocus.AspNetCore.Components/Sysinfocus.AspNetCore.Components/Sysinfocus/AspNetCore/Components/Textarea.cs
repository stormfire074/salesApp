// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Textarea
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class Textarea : ComponentBase
  {
    private string? errorMessage;

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-textarea " + this.Class);
      __builder.AddAttribute(2, "style", this.Style);
      __builder.AddAttribute(3, "b-t4xl5q84mh");
      if (!string.IsNullOrEmpty(this.Label))
      {
        __builder.OpenElement(4, "label");
        __builder.AddAttribute(5, "for", this.Id);
        __builder.AddAttribute(6, "style", !string.IsNullOrEmpty(this.errorMessage) ? "color: var(--error);" : (string) null);
        __builder.AddAttribute(7, "b-t4xl5q84mh");
        __builder.AddContent(8, this.Label);
        __builder.CloseElement();
      }
      __builder.OpenElement(9, "textarea");
      __builder.AddAttribute(10, "accesskey", this.AccessKey);
      __builder.AddAttribute(11, "id", this.Id);
      __builder.AddAttribute(12, "placeholder", this.Placeholder);
      __builder.AddAttribute(13, "name", this.Name);
      __builder.AddAttribute(14, "readonly", this.ReadOnly);
      __builder.AddAttribute(15, "disabled", this.Disabled);
      __builder.AddAttribute(16, "rows", (object) this.Rows);
      __builder.AddAttribute(17, "aria-autocomplete", "none");
      __builder.AddAttribute(18, "spellcheck", "false");
      __builder.AddAttribute<ChangeEventArgs>(19, "oninput", EventCallback.Factory.Create<ChangeEventArgs>((object) this, new Func<ChangeEventArgs, Task>(this.HandleInput)));
      __builder.AddAttribute(20, "value", BindConverter.FormatValue(this.Text));
      __builder.AddAttribute<ChangeEventArgs>(21, "onchange", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => this.Text = __value), this.Text));
      __builder.SetUpdatesAttributeName("value");
      __builder.AddAttribute(22, "b-t4xl5q84mh");
      __builder.CloseElement();
      if (!string.IsNullOrEmpty(this.Info))
      {
        __builder.OpenElement(23, "span");
        __builder.AddAttribute(24, "b-t4xl5q84mh");
        __builder.AddContent(25, this.Info);
        __builder.CloseElement();
      }
      if (!string.IsNullOrEmpty(this.errorMessage))
      {
        __builder.OpenElement(26, "p");
        __builder.AddAttribute(27, "style", "color: var(--error); font-size: 14px");
        __builder.AddAttribute(28, "b-t4xl5q84mh");
        __builder.AddContent(29, this.errorMessage);
        __builder.CloseElement();
      }
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    string? Id { get; set; } = "textarea-" + Guid.NewGuid().ToString().Replace("-", "");

    [Parameter]
    public string? Placeholder { get; set; }

    [Parameter]
    public string? AccessKey { get; set; }

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Parameter]
    public string? Text { get; set; }

    [Parameter]
    public EventCallback<string?> TextChanged { get; set; }

    [Parameter]
    public string? Label { get; set; }

    [Parameter]
    public string? Info { get; set; }

    [Parameter]
    public string? Name { get; set; }

    [Parameter]
    public int Rows { get; set; } = 3;

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public bool ReadOnly { get; set; }

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

    private async Task HandleInput(ChangeEventArgs args)
    {
      this.Text = (string) args.Value;
      await this.TextChanged.InvokeAsync(this.Text);
    }

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
