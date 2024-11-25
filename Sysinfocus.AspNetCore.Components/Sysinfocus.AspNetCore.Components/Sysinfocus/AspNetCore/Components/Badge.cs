// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Badge
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class Badge : ComponentBase
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-badge " + this.Class + " " + this.Type.ToString().ToLower());
      __builder.AddAttribute(2, "style", this.Style);
      __builder.AddAttribute<MouseEventArgs>(3, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, this.OnClick));
      __builder.AddAttribute(4, "b-l2s21howrn");
      __builder.AddContent(5, this.Text);
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    string? Text { get; set; }

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Parameter]
    public BadgeType Type { get; set; } = BadgeType.Default;

    [Parameter]
    public EventCallback OnClick { get; set; }

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
