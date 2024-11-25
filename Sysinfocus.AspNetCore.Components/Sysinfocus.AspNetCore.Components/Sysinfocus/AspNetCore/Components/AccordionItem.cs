// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.AccordionItem
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using System;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class AccordionItem : ComponentBase
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-accordion-item");
      __builder.AddAttribute(2, "style", this.HideBottomBorder ? "border-bottom: none" : (string) null);
      __builder.AddAttribute(3, "b-yn8kze91g8");
      __builder.OpenElement(4, "div");
      __builder.AddAttribute(5, "class", "sbc-accordion-item-header");
      __builder.AddAttribute<MouseEventArgs>(6, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, this.OnClick));
      __builder.AddAttribute(7, "b-yn8kze91g8");
      __builder.AddContent(8, this.Header);
      __builder.AddMarkupContent(9, "\r\n        ");
      __builder.OpenElement(10, "div");
      __builder.AddAttribute(11, "class", "sbc-accordion-item-header-icon " + (this.Show ? "show" : (string) null));
      __builder.AddAttribute(12, "b-yn8kze91g8");
      __builder.AddContent(13, Icons.CHEVRON_DOWN);
      __builder.CloseElement();
      __builder.CloseElement();
      __builder.AddMarkupContent(14, "\r\n    ");
      __builder.OpenElement(15, "div");
      __builder.AddAttribute(16, "class", "sbc-accordion-item-content " + (this.Show ? "show" : "hide"));
      __builder.AddAttribute(17, "style", this.AllowContentSelection ? (string) null : "user-select: none");
      __builder.AddAttribute(18, "b-yn8kze91g8");
      __builder.AddContent(19, this.Content);
      __builder.CloseElement();
      __builder.CloseElement();
    }

    [Parameter]
    public bool Show { get; set; }

    [Parameter]
    public 
    #nullable enable
    RenderFragment? Header { get; set; }

    [Parameter]
    public RenderFragment? Content { get; set; }

    [Parameter]
    public bool AllowContentSelection { get; set; }

    [Parameter]
    public bool HideBottomBorder { get; set; }

    [Parameter]
    public EventCallback OnClick { get; set; }

    protected override void OnInitialized()
    {
      if (this.Header == null)
        throw new ArgumentNullException("Header required for AccordionItem.");
      if (this.Content == null)
        throw new ArgumentNullException("Content required for AccordionItem.");
    }

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
