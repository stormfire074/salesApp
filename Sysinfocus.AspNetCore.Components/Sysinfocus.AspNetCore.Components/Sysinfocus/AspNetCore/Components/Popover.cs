// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Popover
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
  public class Popover : ComponentBase, IDisposable
  {
    private bool renderCompleted;

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      if (!this.Show)
        return;
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "tabindex", "-1");
      __builder.AddAttribute(2, "id", this.Id);
      __builder.AddAttribute(3, "class", "sbc-popover " + this.Class);
      __builder.AddAttribute(4, "style", this.Style);
      __builder.AddAttribute<FocusEventArgs>(5, "onblur", EventCallback.Factory.Create<FocusEventArgs>((object) this, new Action(this.HandleBlur)));
      __builder.AddAttribute<KeyboardEventArgs>(6, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Func<KeyboardEventArgs, Task>(this.HandleKeyDown)));
      __builder.AddAttribute(7, "b-6a62xt4hpz");
      __builder.AddContent(8, this.ChildContent);
      __builder.CloseElement();
      Task.Run((Func<Task>) (async () => await this.UpdatePosition()));
    }

    [Parameter]
    public 
    #nullable enable
    RenderFragment? ChildContent { get; set; }

    [Parameter]
    public string? Id { get; set; }

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Parameter]
    [EditorRequired]
    public string ParentId { get; set; }

    [Parameter]
    public bool Show { get; set; }

    [Parameter]
    public EventCallback<bool> OnClose { get; set; }

    private async void GetState(object sender, object state)
    {
      if (!this.renderCompleted)
        return;
      if (sender.ToString().Contains("Calendar"))
      {
        this.renderCompleted = false;
      }
      else
      {
        if (!(state.ToString() == "mouseup"))
          return;
        if (await this.jsr.InvokeAsync<bool>("eval", (object) ("document.activeElement.closest('#" + this.Id + "') ? true : false")))
          return;
        this.renderCompleted = true;
        this.Show = false;
        await this.OnClose.InvokeAsync(this.Show);
      }
    }

    protected override void OnInitialized()
    {
      this.sm.StateChanged += new NotifyStateChanged(this.GetState);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
      if (!firstRender && this.Show)
        await this.UpdatePosition();
      if (!(this.Show & firstRender))
        return;
      await this.jsr.InvokeVoidAsync("eval", (object) ("document.querySelector('#" + this.Id + " input:first-child')?.focus();"));
    }

    private async Task UpdatePosition()
    {
      if (!this.Show)
        return;
      try
      {
        this.renderCompleted = false;
        ValueTask<double> valueTask1 = this.jsr.InvokeAsync<double>("eval", (object) "window.innerWidth");
        double windowWidth = await valueTask1;
        valueTask1 = this.jsr.InvokeAsync<double>("eval", (object) "window.scrollX");
        double scrollX = await valueTask1;
        valueTask1 = this.jsr.InvokeAsync<double>("eval", (object) "window.scrollY");
        double scrollY = await valueTask1;
        valueTask1 = this.jsr.InvokeAsync<double>("eval", (object) "window.innerHeight");
        double windowHeight = await valueTask1;
        ValueTask<RectBounds> valueTask2 = this.jsr.InvokeAsync<RectBounds>("eval", (object) ("document.querySelector('#" + this.ParentId + "')?.getBoundingClientRect()"));
        RectBounds parent = await valueTask2;
        valueTask2 = this.jsr.InvokeAsync<RectBounds>("eval", (object) ("document.querySelector('#" + this.Id + "')?.getBoundingClientRect()"));
        RectBounds content = await valueTask2;
        double totalHeight = windowHeight - (parent.Bottom + content.Height);
        double toRight = windowWidth - (parent.Left + parent.Width);
        double toLeft = parent.Left;
        double left = toRight > toLeft ? scrollX + parent.Left : scrollX + parent.Right - content.Width;
        double top = parent.Bottom + content.Height > windowHeight ? parent.Top - 4.0 - content.Height : parent.Bottom + 4.0;
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(106, 3);
        interpolatedStringHandler.AppendLiteral("const elm = document.querySelector('#");
        interpolatedStringHandler.AppendFormatted(this.Id);
        interpolatedStringHandler.AppendLiteral("');elm.style.position='fixed';elm.style.top='");
        interpolatedStringHandler.AppendFormatted<double>(top);
        interpolatedStringHandler.AppendLiteral("px';elm.style.left='");
        interpolatedStringHandler.AppendFormatted<double>(left);
        interpolatedStringHandler.AppendLiteral("px';");
        string script = interpolatedStringHandler.ToStringAndClear();
        await this.jsr.InvokeVoidAsync("eval", (object) script);
        this.renderCompleted = true;
        script = (string) null;
      }
      catch
      {
      }
    }

    private async Task HandleKeyDown(KeyboardEventArgs args)
    {
      if (!(args.Key == "Escape"))
        return;
      this.Show = false;
      await this.OnClose.InvokeAsync(this.Show);
    }

    private void HandleBlur() => this.Show = false;

    void IDisposable.Dispose() => this.sm.StateChanged -= new NotifyStateChanged(this.GetState);

    [Inject]
    private IJSRuntime jsr { get; set; }

    [Inject]
    private StateManager sm { get; set; }

    public Popover()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
      interpolatedStringHandler.AppendLiteral("pop-");
      interpolatedStringHandler.AppendFormatted<Guid>(Guid.NewGuid());
      // ISSUE: reference to a compiler-generated field
      this.Id = interpolatedStringHandler.ToStringAndClear();
      // ISSUE: reference to a compiler-generated field
      this.ParentId = string.Empty;
      // ISSUE: reference to a compiler-generated field
      this.jsr = (IJSRuntime) null;
      // ISSUE: reference to a compiler-generated field
      this.sm = (StateManager) null;
      // ISSUE: explicit constructor call
      base.OnInitialized();
    }
  }
}
