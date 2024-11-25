// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Tooltip
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class Tooltip : ComponentBase
  {
    private string height;
    private string id;

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-tooltip");
      __builder.AddAttribute(2, "id", this.id);
      __builder.AddAttribute(3, "b-7c9b6xt70x");
      __builder.OpenElement(4, "div");
      __builder.AddAttribute(5, "class", "sbc-tooltip-tip " + (this.ShowBelow ? "bottom" : (string) null));
      __builder.AddAttribute(6, "style", "width: " + this.TipWidth + "; --height: " + this.height);
      __builder.AddAttribute(7, "b-7c9b6xt70x");
      __builder.AddContent(8, this.Tip);
      __builder.CloseElement();
      __builder.AddMarkupContent(9, "\r\n    ");
      __builder.OpenElement(10, "div");
      __builder.AddAttribute(11, "class", "sbc-tooltip-content");
      __builder.AddAttribute(12, "b-7c9b6xt70x");
      __builder.AddContent(13, this.ChildContent);
      __builder.CloseElement();
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    RenderFragment ChildContent { get; set; }

    [Parameter]
    public string Tip { get; set; }

    [Parameter]
    public string TipWidth { get; set; }

    [Parameter]
    public bool ShowBelow { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
      string str = await this.be.EvalGet<string>((object) ("document.querySelector('#" + this.id + "')?.clientHeight + 'px'"));
      this.height = str;
      str = (string) null;
    }

    [Inject]
    private BrowserExtensions be { get; set; }

    [Inject]
    private StateManager sm { get; set; }

    public Tooltip()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
      interpolatedStringHandler.AppendLiteral("tip-");
      interpolatedStringHandler.AppendFormatted<Guid>(Guid.NewGuid());
      this.id = interpolatedStringHandler.ToStringAndClear();
      // ISSUE: reference to a compiler-generated field
      this.be = (BrowserExtensions) null;
      // ISSUE: reference to a compiler-generated field
      this.sm = (StateManager) null;
      // ISSUE: explicit constructor call
      base.OnInitialized();
    }
  }
}
