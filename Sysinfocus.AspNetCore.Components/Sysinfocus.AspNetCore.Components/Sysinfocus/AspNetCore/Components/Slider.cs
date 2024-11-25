// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Slider
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
  public class Slider : ComponentBase
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-slider " + this.Class);
      __builder.AddAttribute(2, "style", this.Style);
      __builder.AddAttribute(3, "b-31m14i83ff");
      __builder.OpenElement(4, "input");
      __builder.AddAttribute(5, "type", "range");
      __builder.AddAttribute(6, "min", (object) this.Min);
      __builder.AddAttribute(7, "max", (object) this.Max);
      __builder.AddAttribute(8, "step", (object) this.Step);
      __builder.AddAttribute<ChangeEventArgs>(9, "oninput", EventCallback.Factory.Create<ChangeEventArgs>((object) this, new Func<ChangeEventArgs, Task>(this.HandleChange)));
      __builder.AddAttribute(10, "value", BindConverter.FormatValue(this.Value));
      __builder.AddAttribute<ChangeEventArgs>(11, "onchange", EventCallback.Factory.CreateBinder((object) this, (Action<double>) (__value => this.Value = __value), this.Value));
      __builder.SetUpdatesAttributeName("value");
      __builder.AddAttribute(12, "b-31m14i83ff");
      __builder.CloseElement();
      __builder.AddMarkupContent(13, "\r\n    ");
      __builder.OpenElement(14, "div");
      __builder.AddAttribute(15, "class", "sbc-slider-complete");
      __builder.AddAttribute(16, "style", "--width: " + this.GetValue());
      __builder.AddAttribute(17, "b-31m14i83ff");
      __builder.CloseElement();
      __builder.CloseElement();
    }

    [Parameter]
    public double Min { get; set; } = 0.0;

    [Parameter]
    public double Max { get; set; } = 100.0;

    [Parameter]
    public double Step { get; set; } = 1.0;

    [Parameter]
    public double Value { get; set; } = 0.0;

    [Parameter]
    public 
    #nullable enable
    string? Class { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Parameter]
    public EventCallback<double> OnChange { get; set; }

    private string GetValue()
    {
      double num = this.Value / this.Max * 100.0;
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 2);
      interpolatedStringHandler.AppendLiteral("calc(");
      interpolatedStringHandler.AppendFormatted<double>(num);
      interpolatedStringHandler.AppendLiteral("% + ");
      interpolatedStringHandler.AppendFormatted<double>(0.0 * num);
      interpolatedStringHandler.AppendLiteral("px)");
      return interpolatedStringHandler.ToStringAndClear();
    }

    private async Task HandleChange(ChangeEventArgs args)
    {
      double value = Convert.ToDouble(args.Value);
      await this.OnChange.InvokeAsync(value);
    }

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
