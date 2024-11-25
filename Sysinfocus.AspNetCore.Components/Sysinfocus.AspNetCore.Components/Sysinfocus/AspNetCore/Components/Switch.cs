// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Switch
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
  public class Switch : ComponentBase
  {
    private string? _class;

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-toggle");
      __builder.AddAttribute(2, "b-3wz4cvsirk");
      __builder.OpenElement(3, "div");
      __builder.AddAttribute(4, "class", this._class + " " + (this.Disabled ? "disabled" : (string) null));
      __builder.AddAttribute(5, "style", this.Style);
      __builder.AddAttribute(6, "id", this.Id);
      __builder.AddAttribute<MouseEventArgs>(7, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, new Func<Task>(this.Toggle)));
      __builder.AddAttribute(8, "b-3wz4cvsirk");
      __builder.OpenElement(9, "input");
      __builder.AddAttribute(10, "type", "checkbox");
      __builder.AddAttribute(11, "checked", this.Checked);
      __builder.AddAttribute(12, "disabled", this.Disabled);
      __builder.AddAttribute(13, "name", this.Name);
      __builder.AddAttribute(14, "b-3wz4cvsirk");
      __builder.CloseElement();
      __builder.AddMarkupContent(15, "\r\n        <div class=\"toggle-circle\" b-3wz4cvsirk></div>");
      __builder.CloseElement();
      if (this.Label != null)
      {
        __builder.OpenElement(16, "label");
        __builder.AddAttribute(17, "for", this.Id);
        __builder.AddAttribute(18, "class", "label");
        __builder.AddAttribute<MouseEventArgs>(19, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, new Func<Task>(this.Toggle)));
        __builder.AddAttribute(20, "b-3wz4cvsirk");
        __builder.AddContent(21, this.Label);
        __builder.CloseElement();
      }
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    string? Id { get; set; } = "swt-" + Guid.NewGuid().ToString().Replace("-", "");

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Parameter]
    public string? Name { get; set; }

    [Parameter]
    public string? Label { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public bool Checked { get; set; }

    [Parameter]
    public EventCallback<bool> OnClick { get; set; }

    protected override void OnParametersSet()
    {
      base.OnParametersSet();
      this._class = "toggle-wrapper ".AppendTo(this.Checked ? "checked" : (string) null).AppendTo(" " + this.Class);
    }

    private async Task Toggle()
    {
      this.Checked = !this.Checked;
      this._class = "toggle-wrapper ".AppendTo(this.Checked ? "checked" : (string) null).AppendTo(" " + this.Class);
      await this.OnClick.InvokeAsync(this.Checked);
    }

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
