// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Label
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class Label : ComponentBase
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "label");
      __builder.AddAttribute(1, "for", this.Disabled ? (string) null : this.For);
      __builder.AddAttribute(2, "class", "sbc-label" + (this.Emphasized ? " bold" : (string) null) + " " + (this.Disabled ? " disabled" : (string) null) + " " + this.Class);
      __builder.AddAttribute(3, "b-wsbd6ex0bf");
      __builder.AddContent(4, this.Text);
      if (this.Info != null)
      {
        __builder.OpenElement(5, "span");
        __builder.AddAttribute(6, "class", "sbc-label-info");
        __builder.AddAttribute(7, "b-wsbd6ex0bf");
        __builder.AddContent(8, this.Info);
        __builder.CloseElement();
      }
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    string? For { get; set; }

    [Parameter]
    public string? Text { get; set; }

    [Parameter]
    public string? Info { get; set; }

    [Parameter]
    public bool Emphasized { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public string? Class { get; set; }

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
