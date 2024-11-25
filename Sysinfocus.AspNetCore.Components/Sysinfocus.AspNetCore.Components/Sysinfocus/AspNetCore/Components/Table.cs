// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Table
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Runtime.CompilerServices;
using System.Text;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class Table : ComponentBase
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-table " + this.Class);
      __builder.AddAttribute(2, "style", this.Style);
      __builder.AddAttribute(3, "b-j45b6ih47o");
      __builder.OpenElement(4, "table");
      __builder.AddAttribute(5, "class", "sbc-table-table " + (this.ShowVerticalBorder ? "verticalBorder" : (string) null) + " " + (!this.OverflowWrap ? "nowrap" : (string) null));
      __builder.AddAttribute(6, "id", this.Id);
      __builder.AddAttribute(7, "b-j45b6ih47o");
      if (this.TableHeader != null)
      {
        __builder.OpenElement(8, "thead");
        __builder.AddAttribute(9, "class", this.StickyHeader ? "sticky-header" : (string) null);
        __builder.AddAttribute(10, "b-j45b6ih47o");
        __builder.AddContent(11, this.TableHeader);
        __builder.CloseElement();
      }
      __builder.OpenElement(12, "tbody");
      __builder.AddAttribute(13, "class", this.ShowLastRowBorder ? (string) null : "lastBorder");
      __builder.AddAttribute(14, "b-j45b6ih47o");
      __builder.AddContent(15, this.TableBody);
      __builder.CloseElement();
      if (this.TableFooter != null)
      {
        __builder.OpenElement(16, "tfoot");
        __builder.AddAttribute(17, "class", this.StickyFooter ? "sticky-footer" : (string) null);
        __builder.AddAttribute(18, "b-j45b6ih47o");
        __builder.AddContent(19, this.TableFooter);
        __builder.CloseElement();
      }
      __builder.CloseElement();
      if (this.FreezeColumnWidths != null)
      {
        StringBuilder stringBuilder1 = new StringBuilder();
        for (int index = 0; index < this.FreezeColumnWidths.Length; ++index)
        {
          StringBuilder stringBuilder2 = stringBuilder1;
          StringBuilder stringBuilder3 = stringBuilder2;
          StringBuilder.AppendInterpolatedStringHandler interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(139, 5, stringBuilder2);
          interpolatedStringHandler.AppendLiteral("#");
          interpolatedStringHandler.AppendFormatted(this.Id);
          interpolatedStringHandler.AppendLiteral(" th:nth-child(");
          interpolatedStringHandler.AppendFormatted<int>(index + 1);
          interpolatedStringHandler.AppendLiteral("), #");
          interpolatedStringHandler.AppendFormatted(this.Id);
          interpolatedStringHandler.AppendLiteral(" td:nth-child(");
          interpolatedStringHandler.AppendFormatted<int>(index + 1);
          interpolatedStringHandler.AppendLiteral(") { position: sticky; background-color: var(--table-header); outline-offset: -1px; left: ");
          interpolatedStringHandler.AppendFormatted<int>(this.FreezeColumnWidths[index]);
          interpolatedStringHandler.AppendLiteral("px; z-index: 2 } ");
          ref StringBuilder.AppendInterpolatedStringHandler local = ref interpolatedStringHandler;
          stringBuilder3.Append(ref local);
        }
        __builder.OpenElement(20, "style");
        __builder.AddAttribute(21, "b-j45b6ih47o");
        __builder.AddContent(22, stringBuilder1.ToString());
        __builder.CloseElement();
      }
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    int[]? FreezeColumnWidths { get; set; }

    [Parameter]
    public string? Id { get; set; }

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Parameter]
    public bool OverflowWrap { get; set; }

    [Parameter]
    public bool Show { get; set; }

    [Parameter]
    public bool ShowVerticalBorder { get; set; }

    [Parameter]
    public bool ShowLastRowBorder { get; set; }

    [Parameter]
    public bool StickyHeader { get; set; }

    [Parameter]
    public bool StickyFooter { get; set; }

    [Parameter]
    public RenderFragment? TableHeader { get; set; }

    [Parameter]
    public RenderFragment? TableBody { get; set; }

    [Parameter]
    public RenderFragment? TableFooter { get; set; }

    [Inject]
    private StateManager sm { get; set; }

    public Table()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
      interpolatedStringHandler.AppendLiteral("tbl-");
      interpolatedStringHandler.AppendFormatted<Guid>(Guid.NewGuid());
      // ISSUE: reference to a compiler-generated field
      this.Id = interpolatedStringHandler.ToStringAndClear();
      // ISSUE: reference to a compiler-generated field
      this.Show = true;
      // ISSUE: reference to a compiler-generated field
      this.StickyHeader = true;
      // ISSUE: reference to a compiler-generated field
      this.StickyFooter = true;
      // ISSUE: reference to a compiler-generated field
      this.sm = (StateManager) null;
      // ISSUE: explicit constructor call
      base.OnInitialized();
    }
  }
}
