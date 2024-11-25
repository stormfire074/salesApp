// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.ContextMenu
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class ContextMenu : ComponentBase, IDisposable
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-context-menu");
      __builder.AddAttribute(2, "style", "display: flex; flex-direction: column; width: " + this.Width + "; height: " + this.Height);
      __builder.AddAttribute<MouseEventArgs>(3, "oncontextmenu", EventCallback.Factory.Create<MouseEventArgs>((object) this, new Func<MouseEventArgs, Task>(this.HandleContextMenu)));
      __builder.AddEventPreventDefaultAttribute(4, "oncontextmenu", true);
      __builder.AddAttribute(5, "b-jlvob8plou");
      if (!InitializeSysinfocus.IsLicensed)
        __builder.AddMarkupContent(6, "<small class=\"mtb1\" b-jlvob8plou>You are using a trial version.</small>");
      __builder.AddContent(7, this.Text);
      if (this.ShowContent)
        __builder.AddContent(8, this.ChildContent);
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    string? Text { get; set; } = "Right click here";

    [Parameter]
    public string? Width { get; set; } = "300px";

    [Parameter]
    public string? Height { get; set; } = "100px";

    [Parameter]
    public EventCallback<(double x, double y)> OnContextMenu { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public bool ShowContent { get; set; }

    private async Task HandleContextMenu(MouseEventArgs args)
    {
      this.ShowContent = true;
      await this.OnContextMenu.InvokeAsync((args.ClientX, args.ClientY));
    }

    protected override void OnInitialized()
    {
      this.sm.StateChanged += new NotifyStateChanged(this.GetState);
    }

    private void GetState(object sender, object state)
    {
      if (!(state.ToString() == "mouseup"))
        return;
      this.ShowContent = false;
      this.StateHasChanged();
    }

    void IDisposable.Dispose() => this.sm.StateChanged -= new NotifyStateChanged(this.GetState);

    [Inject]
    private IJSRuntime jsr { get; set; } = (IJSRuntime) null;

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
