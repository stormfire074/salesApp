// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Toggle
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
  public class Toggle : ComponentBase
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "button");
      __builder.AddAttribute(1, "class", "sbc-toggle " + this.Type.ToString().ToLower() + " " + (this.Active ? "active" : (string) null));
      __builder.AddAttribute(2, "disabled", this.Disabled);
      __builder.AddAttribute<MouseEventArgs>(3, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, new Func<Task>(this.HandleToggle)));
      __builder.AddAttribute(4, "b-pi9ukkqm1s");
      __builder.AddContent(5, this.ChildContent);
      __builder.CloseElement();
    }

    [Parameter]
    [EditorRequired]
    public 
    #nullable enable
    RenderFragment? ChildContent { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public bool Active { get; set; }

    [Parameter]
    public Toggle.ToggleType Type { get; set; } = Toggle.ToggleType.Default;

    [Parameter]
    public EventCallback<bool> OnToggle { get; set; }

    private async Task HandleToggle()
    {
      this.Active = !this.Active;
      await this.OnToggle.InvokeAsync(this.Active);
    }

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;

    public enum ToggleType
    {
      Default,
      Outline,
      Small,
      Large,
    }
  }
}
