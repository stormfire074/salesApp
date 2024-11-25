// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Drawer
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
  public class Drawer : ComponentBase
  {
    private string? show;

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      if (!this.Show)
        return;
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-drawer");
      __builder.AddAttribute(2, "b-tnp5clhn05");
      __builder.OpenElement(3, "div");
      __builder.AddAttribute(4, "class", "sbc-drawer-overlay");
      __builder.AddAttribute<MouseEventArgs>(5, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, new Func<Task>(this.ToggleShow)));
      __builder.AddAttribute(6, "b-tnp5clhn05");
      __builder.CloseElement();
      __builder.AddMarkupContent(7, "\r\n    ");
      __builder.OpenElement(8, "div");
      __builder.AddAttribute(9, "class", "sbc-drawer-content " + this.show);
      __builder.AddAttribute(10, "b-tnp5clhn05");
      __builder.OpenElement(11, "div");
      __builder.AddAttribute(12, "class", "sbc-drawer-close");
      __builder.AddAttribute<MouseEventArgs>(13, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, new Func<Task>(this.ToggleShow)));
      __builder.AddAttribute(14, "b-tnp5clhn05");
      __builder.CloseElement();
      __builder.AddMarkupContent(15, "\r\n        ");
      __builder.AddContent(16, this.ChildContent);
      if (!InitializeSysinfocus.IsLicensed)
        __builder.AddMarkupContent(17, "<small class=\"mtb1\" b-tnp5clhn05>You are using a trial version.</small>");
      __builder.CloseElement();
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    RenderFragment? ChildContent { get; set; }

    [Parameter]
    public EventCallback OnClose { get; set; }

    [Parameter]
    public bool Show { get; set; }

    protected override async Task OnInitializedAsync() => await this.ToggleShow();

    private async Task ToggleShow()
    {
      if (this.show == null || this.show == "hide")
      {
        this.show = "show";
      }
      else
      {
        this.show = "hide";
        await Task.Delay(300);
        this.Show = false;
        await this.OnClose.InvokeAsync();
        this.show = "show";
      }
    }

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
