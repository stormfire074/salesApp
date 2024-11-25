// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Scheduler
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Runtime.CompilerServices;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class Scheduler : ComponentBase
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "id", this.Id);
      __builder.AddAttribute(2, "class", "sbc-scheduler " + this.Class);
      __builder.AddAttribute(3, "style", "width:" + this.Width + ";height:" + this.Height + ";" + this.Style);
      __builder.AddAttribute(4, "b-i4xv79ku48");
      if (this.Type == ViewType.Week || this.Type == ViewType.WorkWeek)
      {
        __builder.OpenComponent<WeekView>(5);
        __builder.AddComponentParameter(6, "Start", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<DateTime>(this.Start));
        __builder.AddComponentParameter(7, "Type", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<ViewType>(this.Type));
        __builder.CloseComponent();
      }
      __builder.CloseElement();
    }

    [Parameter]
    public ViewType Type { get; set; }

    [Parameter]
    public DateTime Start { get; set; }

    [Parameter]
    public 
    #nullable enable
    string Id { get; set; }

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Parameter]
    public string Width { get; set; }

    [Parameter]
    public string Height { get; set; }

    [Inject]
    private StateManager sm { get; set; }

    public Scheduler()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
      interpolatedStringHandler.AppendLiteral("sch-");
      interpolatedStringHandler.AppendFormatted<Guid>(Guid.NewGuid());
      // ISSUE: reference to a compiler-generated field
      this.Id = interpolatedStringHandler.ToStringAndClear();
      // ISSUE: reference to a compiler-generated field
      this.Width = "100%";
      // ISSUE: reference to a compiler-generated field
      this.Height = "600px";
      // ISSUE: reference to a compiler-generated field
      this.sm = (StateManager) null;
      // ISSUE: explicit constructor call
      base.OnInitialized();
    }
  }
}
