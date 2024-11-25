// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Tabs
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using __Blazor.Sysinfocus.AspNetCore.Components.Tabs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class Tabs : ComponentBase
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-tabs-container " + (this.ShowVertical ? "vertical-tabs" : (string) null) + " " + this.Class);
      __builder.AddAttribute(2, "style", this.Style);
      __builder.AddAttribute(3, "b-de2pj2huiq");
      __builder.OpenElement(4, "div");
      __builder.AddAttribute(5, "class", "sbc-tabs");
      __builder.AddAttribute(6, "b-de2pj2huiq");
      int num = 0;
      foreach (string textContent in this.Items)
      {
        int index = num;
        __builder.OpenElement(7, "button");
        __builder.AddAttribute(8, "class", index == this.ActiveItem ? "active" : (string) null);
        __builder.AddAttribute<MouseEventArgs>(9, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, (Func<Task>) (async () => await this.HandleTabChange(index))));
        __builder.AddAttribute(10, "b-de2pj2huiq");
        __builder.AddContent(11, textContent);
        __builder.CloseElement();
        ++num;
      }
      __builder.CloseElement();
      __builder.AddMarkupContent(12, "    \r\n    ");
      __builder.OpenElement(13, "div");
      __builder.AddAttribute(14, "class", "sbc-tabs-items");
      __builder.AddAttribute(15, "b-de2pj2huiq");
      TypeInference.CreateCascadingValue_0<Sysinfocus.AspNetCore.Components.Tabs>(__builder, 16, 17, this, 18, (RenderFragment) (__builder2 => __builder2.AddContent(19, this.ChildContent)));
      if (!InitializeSysinfocus.IsLicensed)
        __builder.AddMarkupContent(20, "<small class=\"mtb1 ta-center\" b-de2pj2huiq>You are using a trial version.</small>");
      __builder.CloseElement();
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    string[] Items { get; set; } = Array.Empty<string>();

    [Parameter]
    public int ActiveItem { get; set; } = -1;

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Parameter]
    public bool ShowVertical { get; set; }

    [Parameter]
    public EventCallback<int> OnTabChange { get; set; }

    [Parameter]
    [EditorRequired]
    public RenderFragment ChildContent { get; set; } = (RenderFragment) null;

    private async Task HandleTabChange(int index)
    {
      this.ActiveItem = index;
      await this.OnTabChange.InvokeAsync(index);
    }

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
