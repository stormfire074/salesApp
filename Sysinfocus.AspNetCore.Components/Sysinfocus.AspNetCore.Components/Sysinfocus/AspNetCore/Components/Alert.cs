// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Alert
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class Alert : ComponentBase
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-alert " + this.Type.ToString().ToLower() + " " + this.Class);
      __builder.AddAttribute(2, "style", this.Style);
      __builder.AddAttribute(3, "b-ugm5p4ut6w");
      __builder.OpenElement(4, "span");
      __builder.AddAttribute(5, "class", "material-symbols-outlined");
      __builder.AddAttribute(6, "b-ugm5p4ut6w");
      __builder.AddContent(7, this.Icon);
      __builder.CloseElement();
      __builder.AddMarkupContent(8, "\r\n    ");
      __builder.OpenElement(9, "div");
      __builder.AddAttribute(10, "class", "sbc-alert-details");
      __builder.AddAttribute(11, "b-ugm5p4ut6w");
      __builder.OpenElement(12, "div");
      __builder.AddAttribute(13, "class", "sbc-alert-header");
      __builder.AddAttribute(14, "b-ugm5p4ut6w");
      __builder.AddContent(15, this.Title);
      __builder.CloseElement();
      __builder.AddMarkupContent(16, "\r\n        ");
      __builder.OpenElement(17, "div");
      __builder.AddAttribute(18, "class", "sbc-alert-content");
      __builder.AddAttribute(19, "b-ugm5p4ut6w");
      __builder.AddContent(20, this.Description);
      __builder.CloseElement();
      __builder.CloseElement();
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
    public string? Icon { get; set; } = "terminal";

    [Parameter]
    public string Title { get; set; } = nameof (Title);

    [Parameter]
    public string? Description { get; set; } = "Your description goes here...";

    [Parameter]
    public AlertType Type { get; set; } = AlertType.Default;

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
