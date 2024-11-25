// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Carousel
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class Carousel : ComponentBase
  {
    private bool showPrev;
    private bool showNext;
    private double scrollWidth;
    private double scrollHeight;
    private string? _style;

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "id", this.Id);
      __builder.AddAttribute(2, "class", "sbc-carousel");
      __builder.AddAttribute(3, "style", "--vertical: " + (this.ShowVertical ? "column" : "row"));
      __builder.AddAttribute(4, "b-sllfrs81ih");
      __builder.OpenComponent<Button>(5);
      __builder.AddComponentParameter(6, "Icon", (object) "arrow_back");
      __builder.AddComponentParameter(7, "Type", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<ButtonType>(ButtonType.Icon));
      __builder.AddComponentParameter(8, "Style", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<string>("border-radius: 50%;" + (this.ShowVertical ? "transform: rotate(90deg)" : (string) null)));
      __builder.AddComponentParameter(9, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, new Func<Task>(this.HandlePrevious))));
      __builder.AddComponentParameter(10, "Disabled", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<bool>(this.showPrev));
      __builder.CloseComponent();
      __builder.AddMarkupContent(11, "\r\n    ");
      __builder.OpenElement(12, "div");
      __builder.AddAttribute(13, "class", "sbc-carousel-content");
      __builder.AddAttribute(14, "style", this._style);
      __builder.AddAttribute(15, "b-sllfrs81ih");
      __builder.AddContent(16, this.ChildContent);
      __builder.CloseElement();
      __builder.AddMarkupContent(17, "\r\n    ");
      __builder.OpenComponent<Button>(18);
      __builder.AddComponentParameter(19, "Icon", (object) "arrow_forward");
      __builder.AddComponentParameter(20, "Type", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<ButtonType>(ButtonType.Icon));
      __builder.AddComponentParameter(21, "Style", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<string>("border-radius: 50%;" + (this.ShowVertical ? "transform: rotate(90deg)" : (string) null)));
      __builder.AddComponentParameter(22, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, new Func<Task>(this.HandleNext))));
      __builder.AddComponentParameter(23, "Disabled", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<bool>(this.showNext));
      __builder.CloseComponent();
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    string? Id { get; set; }

    [Parameter]
    public string? ObjectFit { get; set; }

    [Parameter]
    public double Width { get; set; }

    [Parameter]
    public double Height { get; set; }

    [Parameter]
    public bool ShowNavigation { get; set; }

    [Parameter]
    public bool ShowVertical { get; set; }

    [Parameter]
    public RenderFragment ChildContent { get; set; }

    protected override void OnParametersSet()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(41, 3);
      interpolatedStringHandler.AppendLiteral("--width: ");
      interpolatedStringHandler.AppendFormatted<double>(this.Width);
      interpolatedStringHandler.AppendLiteral("px; --height: ");
      interpolatedStringHandler.AppendFormatted<double>(this.Height);
      interpolatedStringHandler.AppendLiteral("px; --object-fit: ");
      interpolatedStringHandler.AppendFormatted(this.ObjectFit);
      this._style = interpolatedStringHandler.ToStringAndClear();
    }

    private async Task GetScrollWidth()
    {
      ValueTask<double> valueTask;
      if (this.scrollWidth == 0.0)
      {
        valueTask = this.jsr.InvokeAsync<double>("eval", (object) ("document.querySelector('#" + this.Id + " .sbc-carousel-content')?.scrollWidth"));
        double num = await valueTask;
        this.scrollWidth = num;
      }
      if (this.scrollHeight != 0.0)
        return;
      valueTask = this.jsr.InvokeAsync<double>("eval", (object) ("document.querySelector('#" + this.Id + " .sbc-carousel-content')?.scrollHeight"));
      double num1 = await valueTask;
      this.scrollHeight = num1;
    }

    private async Task HandlePrevious()
    {
      await this.GetScrollWidth();
      double isZero = 0.0;
      if (this.ShowVertical)
      {
        IJSRuntime jsr = this.jsr;
        object[] objArray = new object[1];
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(65, 2);
        interpolatedStringHandler.AppendLiteral("document.querySelector('#");
        interpolatedStringHandler.AppendFormatted(this.Id);
        interpolatedStringHandler.AppendLiteral(" .sbc-carousel-content')?.scrollBy(0, -");
        interpolatedStringHandler.AppendFormatted<double>(this.Height);
        interpolatedStringHandler.AppendLiteral(")");
        objArray[0] = (object) interpolatedStringHandler.ToStringAndClear();
        await jsr.InvokeVoidAsync("eval", objArray);
        double num = await this.jsr.InvokeAsync<double>("eval", (object) ("document.querySelector('#" + this.Id + " .sbc-carousel-content')?.scrollTop"));
        isZero = num - this.Height;
      }
      else
      {
        IJSRuntime jsr = this.jsr;
        object[] objArray = new object[1];
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(64, 2);
        interpolatedStringHandler.AppendLiteral("document.querySelector('#");
        interpolatedStringHandler.AppendFormatted(this.Id);
        interpolatedStringHandler.AppendLiteral(" .sbc-carousel-content')?.scrollBy(-");
        interpolatedStringHandler.AppendFormatted<double>(this.Width);
        interpolatedStringHandler.AppendLiteral(",0)");
        objArray[0] = (object) interpolatedStringHandler.ToStringAndClear();
        await jsr.InvokeVoidAsync("eval", objArray);
        double num = await this.jsr.InvokeAsync<double>("eval", (object) ("document.querySelector('#" + this.Id + " .sbc-carousel-content')?.scrollLeft"));
        isZero = num - this.Width;
      }
      this.showPrev = isZero <= 0.0;
      this.showNext = false;
    }

    private async Task HandleNext()
    {
      await this.GetScrollWidth();
      double isZero = 0.0;
      if (this.ShowVertical)
      {
        IJSRuntime jsr = this.jsr;
        object[] objArray = new object[1];
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(64, 2);
        interpolatedStringHandler.AppendLiteral("document.querySelector('#");
        interpolatedStringHandler.AppendFormatted(this.Id);
        interpolatedStringHandler.AppendLiteral(" .sbc-carousel-content')?.scrollBy(0, ");
        interpolatedStringHandler.AppendFormatted<double>(this.Height);
        interpolatedStringHandler.AppendLiteral(")");
        objArray[0] = (object) interpolatedStringHandler.ToStringAndClear();
        await jsr.InvokeVoidAsync("eval", objArray);
        double num = await this.jsr.InvokeAsync<double>("eval", (object) ("document.querySelector('#" + this.Id + " .sbc-carousel-content')?.scrollTop"));
        isZero = num + this.Height * 2.0;
        this.showNext = isZero >= this.scrollHeight;
      }
      else
      {
        IJSRuntime jsr = this.jsr;
        object[] objArray = new object[1];
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(63, 2);
        interpolatedStringHandler.AppendLiteral("document.querySelector('#");
        interpolatedStringHandler.AppendFormatted(this.Id);
        interpolatedStringHandler.AppendLiteral(" .sbc-carousel-content')?.scrollBy(");
        interpolatedStringHandler.AppendFormatted<double>(this.Width);
        interpolatedStringHandler.AppendLiteral(",0)");
        objArray[0] = (object) interpolatedStringHandler.ToStringAndClear();
        await jsr.InvokeVoidAsync("eval", objArray);
        double num = await this.jsr.InvokeAsync<double>("eval", (object) ("document.querySelector('#" + this.Id + " .sbc-carousel-content')?.scrollLeft"));
        isZero = num + this.Width * 2.0;
        this.showNext = isZero >= this.scrollWidth;
      }
      this.showPrev = false;
    }

    [Inject]
    private IJSRuntime jsr { get; set; }

    [Inject]
    private StateManager sm { get; set; }

    public Carousel()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
      interpolatedStringHandler.AppendLiteral("carousel-");
      interpolatedStringHandler.AppendFormatted<Guid>(Guid.NewGuid());
      // ISSUE: reference to a compiler-generated field
      this.Id = interpolatedStringHandler.ToStringAndClear();
      // ISSUE: reference to a compiler-generated field
      this.ObjectFit = "cover";
      // ISSUE: reference to a compiler-generated field
      this.Width = 500.0;
      // ISSUE: reference to a compiler-generated field
      this.Height = 500.0;
      // ISSUE: reference to a compiler-generated field
      this.ChildContent = (RenderFragment) null;
      this.showPrev = true;
      this.scrollWidth = 0.0;
      this.scrollHeight = 0.0;
      // ISSUE: reference to a compiler-generated field
      this.jsr = (IJSRuntime) null;
      // ISSUE: reference to a compiler-generated field
      this.sm = (StateManager) null;
      // ISSUE: explicit constructor call
      base.OnInitialized();
    }
  }
}
