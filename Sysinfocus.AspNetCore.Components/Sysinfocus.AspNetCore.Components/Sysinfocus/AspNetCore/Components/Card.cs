// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Card
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class Card : ComponentBase
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-card");
      __builder.AddAttribute(2, "style", "max-width: " + this.Width + "; " + this.Style);
      __builder.AddAttribute(3, "b-booeh01of8");
      if (this.CardHeader != null)
      {
        __builder.OpenElement(4, "div");
        __builder.AddAttribute(5, "class", "sbc-card-header");
        __builder.AddAttribute(6, "b-booeh01of8");
        __builder.AddContent(7, this.CardHeader);
        __builder.CloseElement();
      }
      if (this.CardContent != null)
      {
        __builder.OpenElement(8, "div");
        __builder.AddAttribute(9, "class", "sbc-card-content");
        __builder.AddAttribute(10, "b-booeh01of8");
        __builder.AddContent(11, this.CardContent);
        __builder.CloseElement();
      }
      if (this.CardFooter != null)
      {
        __builder.OpenElement(12, "div");
        __builder.AddAttribute(13, "class", "sbc-card-footer");
        __builder.AddAttribute(14, "b-booeh01of8");
        __builder.AddContent(15, this.CardFooter);
        __builder.CloseElement();
      }
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    RenderFragment? CardHeader { get; set; }

    [Parameter]
    public RenderFragment? CardContent { get; set; }

    [Parameter]
    public RenderFragment? CardFooter { get; set; }

    [Parameter]
    public string? Width { get; set; } = "100%";

    [Parameter]
    public string? Style { get; set; }

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
