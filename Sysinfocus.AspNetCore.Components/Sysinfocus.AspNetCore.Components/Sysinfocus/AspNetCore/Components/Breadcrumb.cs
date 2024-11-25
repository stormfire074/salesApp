// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Breadcrumb
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class Breadcrumb : ComponentBase
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      if (!this.Show)
        return;
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-breadcrumb");
      __builder.AddAttribute(2, "b-gqs9kpqssi");
      int num = 0;
      foreach (Breadcrumb.BreadcrumbModel breadcrumbModel in (IEnumerable<Breadcrumb.BreadcrumbModel>) this.Items)
      {
        if (this.Items.Count - 1 != num)
        {
          __builder.OpenElement(3, "a");
          __builder.AddAttribute(4, "class", "sbc-breadcrumb-item");
          __builder.AddAttribute(5, "href", breadcrumbModel.Url);
          __builder.AddAttribute(6, "b-gqs9kpqssi");
          __builder.AddContent(7, (MarkupString) breadcrumbModel.Name);
          __builder.CloseElement();
          if (this.Separator.StartsWith(' '))
          {
            __builder.OpenElement(8, "span");
            __builder.AddAttribute(9, "class", "sbc-breadcrumb-separator");
            __builder.AddAttribute(10, "b-gqs9kpqssi");
            __builder.AddContent(11, this.Separator);
            __builder.CloseElement();
          }
          else
          {
            __builder.OpenElement(12, "span");
            __builder.AddAttribute(13, "class", "material-symbols-outlined");
            __builder.AddAttribute(14, "b-gqs9kpqssi");
            __builder.AddContent(15, this.Separator);
            __builder.CloseElement();
          }
        }
        else
        {
          __builder.OpenElement(16, "b");
          __builder.AddAttribute(17, "class", "current-item");
          __builder.AddAttribute(18, "b-gqs9kpqssi");
          __builder.AddContent(19, breadcrumbModel.Name);
          __builder.CloseElement();
        }
        ++num;
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
    public string? Separator { get; set; } = "chevron_right";

    [Parameter]
    public bool Show { get; set; } = true;

    [Parameter]
    [EditorRequired]
    public ICollection<Breadcrumb.BreadcrumbModel> Items { get; set; } = (ICollection<Breadcrumb.BreadcrumbModel>) new List<Breadcrumb.BreadcrumbModel>();

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;

    public record BreadcrumbModel(string Name)
    {
      public string? Url { get; set; }

      [CompilerGenerated]
      protected virtual bool PrintMembers(StringBuilder builder)
      {
        RuntimeHelpers.EnsureSufficientExecutionStack();
        builder.Append("Name = ");
        builder.Append((object) this.Name);
        builder.Append(", Url = ");
        builder.Append((object) this.Url);
        return true;
      }
    }
  }
}
