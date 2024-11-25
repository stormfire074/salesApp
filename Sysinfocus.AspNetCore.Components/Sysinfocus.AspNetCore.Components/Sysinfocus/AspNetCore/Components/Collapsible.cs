// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Collapsible
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.CompilerServices;
using Microsoft.AspNetCore.Components.Rendering;
using System;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class Collapsible : ComponentBase
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "id", this.Id);
      __builder.AddAttribute(2, "class", "sbc-collapsible " + this.Class);
      __builder.AddAttribute(3, "style", this.Style);
      __builder.AddAttribute(4, "b-24u3018pb1");
      __builder.OpenElement(5, "div");
      __builder.AddAttribute(6, "class", "sbc-collapsible-header");
      __builder.AddAttribute(7, "b-24u3018pb1");
      __builder.OpenElement(8, "div");
      __builder.AddAttribute(9, "class", "sbc-collapsible-header-handler");
      __builder.AddAttribute(10, "b-24u3018pb1");
      __builder.AddContent(11, this.Title);
      __builder.AddMarkupContent(12, "\r\n            ");
      __builder.OpenComponent<Button>(13);
      __builder.AddComponentParameter(14, "Icon", (object) "expand_all");
      __builder.AddComponentParameter(15, "Type", (object) RuntimeHelpers.TypeCheck<ButtonType>(ButtonType.Ghost));
      __builder.AddComponentParameter(16, "Size", (object) RuntimeHelpers.TypeCheck<ButtonSize>(ButtonSize.Small));
      __builder.AddComponentParameter(17, "OnClick", (object) RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Action) (() => this.Show = !this.Show))));
      __builder.CloseComponent();
      __builder.CloseElement();
      __builder.AddMarkupContent(18, "\r\n        ");
      __builder.AddContent(19, this.Header);
      __builder.CloseElement();
      if (this.Show)
      {
        __builder.OpenElement(20, "div");
        __builder.AddAttribute(21, "class", "sbc-collapsible-content");
        __builder.AddAttribute(22, "b-24u3018pb1");
        __builder.AddContent(23, this.Content);
        __builder.CloseElement();
      }
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    string? Id { get; set; }

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Parameter]
    public string Title { get; set; } = nameof (Title);

    [Parameter]
    public RenderFragment Header { get; set; } = (RenderFragment) null;

    [Parameter]
    public RenderFragment Content { get; set; } = (RenderFragment) null;

    [Parameter]
    public bool Show { get; set; } = true;

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
