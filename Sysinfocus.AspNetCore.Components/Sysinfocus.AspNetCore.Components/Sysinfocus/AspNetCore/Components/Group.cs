// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Group
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class Group : ComponentBase
  {
    private string? errorMessage;

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-group");
      __builder.AddAttribute(2, "id", this.Id);
      __builder.AddAttribute(3, "title", this.Tooltip);
      __builder.AddAttribute(4, "b-l5eahwxxm4");
      if (!string.IsNullOrEmpty(this.Label))
      {
        __builder.OpenElement(5, "label");
        __builder.AddAttribute(6, "for", this.Id);
        __builder.AddAttribute(7, "style", !string.IsNullOrEmpty(this.errorMessage) ? "color: var(--error);" : (string) null);
        __builder.AddAttribute(8, "b-l5eahwxxm4");
        __builder.AddContent(9, this.Label);
        __builder.CloseElement();
      }
      __builder.AddContent(10, this.ChildContent);
      if (!string.IsNullOrEmpty(this.Info))
      {
        __builder.OpenElement(11, "span");
        __builder.AddAttribute(12, "b-l5eahwxxm4");
        __builder.AddContent(13, this.Info);
        __builder.CloseElement();
      }
      if (!string.IsNullOrEmpty(this.errorMessage))
      {
        __builder.OpenElement(14, "p");
        __builder.AddAttribute(15, "style", "color: var(--error); font-size: 14px");
        __builder.AddAttribute(16, "b-l5eahwxxm4");
        __builder.AddContent(17, this.errorMessage);
        __builder.CloseElement();
      }
      __builder.CloseElement();
    }

    [Parameter]
    [EditorRequired]
    public 
    #nullable enable
    RenderFragment ChildContent { get; set; }

    [Parameter]
    public string? Id { get; set; }

    [Parameter]
    public string? Label { get; set; }

    [Parameter]
    public string? Tooltip { get; set; }

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public string? Info { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Parameter]
    public string? Error { get; set; }

    [CascadingParameter]
    private Dictionary<string, string>? FormErrors { get; set; }

    protected override void OnParametersSet()
    {
      this.errorMessage = (string) null;
      if (this.FormErrors == null || this.Error == null || !this.FormErrors.ContainsKey(this.Error))
        return;
      this.errorMessage = this.FormErrors[this.Error];
    }

    [Inject]
    private StateManager sm { get; set; }

    public Group()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
      interpolatedStringHandler.AppendLiteral("grp-");
      interpolatedStringHandler.AppendFormatted<Guid>(Guid.NewGuid());
      // ISSUE: reference to a compiler-generated field
      this.Id = interpolatedStringHandler.ToStringAndClear();
      // ISSUE: reference to a compiler-generated field
      this.sm = (StateManager) null;
      // ISSUE: explicit constructor call
      base.OnInitialized();
    }
  }
}
