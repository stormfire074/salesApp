// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Icon
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
  public class Icon : ComponentBase
  {
    private string? style;
    private bool pd;

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "span");
      __builder.AddAttribute(1, "id", this.Id);
      __builder.AddAttribute(2, "accesskey", this.AccessKey);
      __builder.AddAttribute(3, "tabindex", "0");
      __builder.AddAttribute(4, "class", "material-symbols-outlined " + (this.OnClick.HasDelegate ? "pointer" : (string) null) + " " + this.Class);
      __builder.AddAttribute(5, "style", this.style);
      __builder.AddAttribute<MouseEventArgs>(6, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, this.OnClick));
      __builder.AddAttribute<KeyboardEventArgs>(7, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Func<KeyboardEventArgs, Task>(this.HandleKeyDown)));
      __builder.AddEventPreventDefaultAttribute(8, "onkeydown", this.pd);
      __builder.AddAttribute(9, "title", this.Tooltip);
      __builder.AddContent(10, this.Name);
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    string Id { get; set; } = "icon-" + Guid.NewGuid().ToString();

    [Parameter]
    public string Name { get; set; } = "info";

    [Parameter]
    public string? AccessKey { get; set; }

    [Parameter]
    public string? Tooltip { get; set; }

    [Parameter]
    public string? Color { get; set; } = "var(--primary-fg)";

    [Parameter]
    public string? Size { get; set; } = "24px";

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public EventCallback<MouseEventArgs> OnClick { get; set; }

    protected override void OnParametersSet()
    {
      string stringAndClear;
      if (!this.Disabled)
      {
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 3);
        interpolatedStringHandler.AppendLiteral("color: ");
        interpolatedStringHandler.AppendFormatted(this.Color);
        interpolatedStringHandler.AppendLiteral("; font-size: ");
        interpolatedStringHandler.AppendFormatted(this.Size);
        interpolatedStringHandler.AppendLiteral("; ");
        interpolatedStringHandler.AppendFormatted(this.Style);
        stringAndClear = interpolatedStringHandler.ToStringAndClear();
      }
      else
      {
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(53, 3);
        interpolatedStringHandler.AppendLiteral("color: ");
        interpolatedStringHandler.AppendFormatted(this.Color);
        interpolatedStringHandler.AppendLiteral("; font-size: ");
        interpolatedStringHandler.AppendFormatted(this.Size);
        interpolatedStringHandler.AppendLiteral("; cursor: default; opacity: 0.5; ");
        interpolatedStringHandler.AppendFormatted(this.Style);
        stringAndClear = interpolatedStringHandler.ToStringAndClear();
      }
      this.style = stringAndClear;
    }

    private async Task HandleKeyDown(KeyboardEventArgs args)
    {
      this.pd = false;
      if (!(args.Key == "Enter") && !(args.Key == " "))
        return;
      this.pd = true;
      RectBounds me = await this.jsr.InvokeAsync<RectBounds>("eval", (object) ("document.querySelector('#" + this.Id + "').getBoundingClientRect()"));
      await this.OnClick.InvokeAsync(new MouseEventArgs()
      {
        ClientX = me.Left + me.Width,
        ClientY = me.Top + me.Height
      });
    }

    [Inject]
    private IJSRuntime jsr { get; set; } = (IJSRuntime) null;

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
