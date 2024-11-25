// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Widget
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class Widget : ComponentBase
  {
    private string? styles;

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "id", this.Id);
      __builder.AddAttribute(2, "class", "sbc-widget " + (this.Disabled ? "disabled" : (string) null) + " " + this.Class);
      __builder.AddAttribute(3, "style", this.styles + " " + this.Style);
      __builder.AddAttribute<MouseEventArgs>(4, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, this.OnClick));
      __builder.AddAttribute<FocusEventArgs>(5, "onfocus", EventCallback.Factory.Create<FocusEventArgs>((object) this, this.OnFocus));
      __builder.AddAttribute<FocusEventArgs>(6, "onblur", EventCallback.Factory.Create<FocusEventArgs>((object) this, this.OnLostFocus));
      __builder.AddAttribute(7, "b-yw7iy2bg0d");
      if (this.ChildContent == null)
      {
        if (this.SwapLogoText)
        {
          __builder.OpenComponent<Icon>(8);
          __builder.AddComponentParameter(9, "Name", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<string>(this.Logo));
          __builder.AddComponentParameter(10, "Color", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<string>(this.LogoColor));
          __builder.AddComponentParameter(11, "Size", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<string>(this.LogoSize));
          __builder.CloseComponent();
          __builder.AddContent(12, " ");
          __builder.OpenElement(13, "div");
          __builder.AddAttribute(14, "b-yw7iy2bg0d");
          __builder.AddContent(15, (MarkupString) this.Text);
          __builder.CloseElement();
        }
        else
        {
          __builder.OpenElement(16, "div");
          __builder.AddAttribute(17, "b-yw7iy2bg0d");
          __builder.AddContent(18, (MarkupString) this.Text);
          __builder.CloseElement();
          __builder.AddContent(19, " ");
          __builder.OpenComponent<Icon>(20);
          __builder.AddComponentParameter(21, "Name", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<string>(this.Logo));
          __builder.AddComponentParameter(22, "Color", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<string>(this.LogoColor));
          __builder.AddComponentParameter(23, "Size", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<string>(this.LogoSize));
          __builder.CloseComponent();
        }
      }
      else
        __builder.AddContent(24, this.ChildContent);
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    string? Id { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Parameter]
    public string Text { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public string? Opacity { get; set; }

    [Parameter]
    public string? TextSize { get; set; }

    [Parameter]
    public string? LogoSize { get; set; }

    [Parameter]
    public string? Logo { get; set; }

    [Parameter]
    public string? LogoUrl { get; set; }

    [Parameter]
    public string? Border { get; set; }

    [Parameter]
    public string? Background { get; set; }

    [Parameter]
    public string? BackgroundColor { get; set; }

    [Parameter]
    public string? TextColor { get; set; }

    [Parameter]
    public string? TextAlign { get; set; }

    [Parameter]
    public string? LogoColor { get; set; }

    [Parameter]
    public string? BorderRadius { get; set; }

    [Parameter]
    public string? ColumnGap { get; set; }

    [Parameter]
    public string? RowGap { get; set; }

    [Parameter]
    public string? HorizonalAlign { get; set; }

    [Parameter]
    public string? VerticalAlign { get; set; }

    [Parameter]
    public bool SwapLogoText { get; set; }

    [Parameter]
    public bool FlowVertical { get; set; }

    [Parameter]
    public string? Width { get; set; }

    [Parameter]
    public string? Height { get; set; }

    [Parameter]
    public string? Padding { get; set; }

    [Parameter]
    public EventCallback OnClick { get; set; }

    [Parameter]
    public EventCallback<FocusEventArgs> OnFocus { get; set; }

    [Parameter]
    public EventCallback<FocusEventArgs> OnLostFocus { get; set; }

    protected override async Task OnParametersSetAsync()
    {
      await Task.Delay(10);
      StringBuilder sb = new StringBuilder();
      StringBuilder stringBuilder1 = sb;
      StringBuilder stringBuilder2 = stringBuilder1;
      StringBuilder.AppendInterpolatedStringHandler interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(16, 1, stringBuilder1);
      interpolatedStringHandler.AppendLiteral("flex-direction:");
      interpolatedStringHandler.AppendFormatted(this.FlowVertical ? "column" : "row");
      interpolatedStringHandler.AppendLiteral(";");
      ref StringBuilder.AppendInterpolatedStringHandler local1 = ref interpolatedStringHandler;
      stringBuilder2.Append(ref local1);
      StringBuilder stringBuilder3 = sb;
      StringBuilder stringBuilder4 = stringBuilder3;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(9, 1, stringBuilder3);
      interpolatedStringHandler.AppendLiteral("row-gap:");
      interpolatedStringHandler.AppendFormatted(this.RowGap);
      interpolatedStringHandler.AppendLiteral(";");
      ref StringBuilder.AppendInterpolatedStringHandler local2 = ref interpolatedStringHandler;
      stringBuilder4.Append(ref local2);
      StringBuilder stringBuilder5 = sb;
      StringBuilder stringBuilder6 = stringBuilder5;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(12, 1, stringBuilder5);
      interpolatedStringHandler.AppendLiteral("column-gap:");
      interpolatedStringHandler.AppendFormatted(this.ColumnGap);
      interpolatedStringHandler.AppendLiteral(";");
      ref StringBuilder.AppendInterpolatedStringHandler local3 = ref interpolatedStringHandler;
      stringBuilder6.Append(ref local3);
      StringBuilder stringBuilder7 = sb;
      StringBuilder stringBuilder8 = stringBuilder7;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(17, 1, stringBuilder7);
      interpolatedStringHandler.AppendLiteral("justify-content:");
      interpolatedStringHandler.AppendFormatted(this.FlowVertical ? this.VerticalAlign : this.HorizonalAlign);
      interpolatedStringHandler.AppendLiteral(";");
      ref StringBuilder.AppendInterpolatedStringHandler local4 = ref interpolatedStringHandler;
      stringBuilder8.Append(ref local4);
      StringBuilder stringBuilder9 = sb;
      StringBuilder stringBuilder10 = stringBuilder9;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(13, 1, stringBuilder9);
      interpolatedStringHandler.AppendLiteral("align-items:");
      interpolatedStringHandler.AppendFormatted(this.FlowVertical ? this.HorizonalAlign : this.VerticalAlign);
      interpolatedStringHandler.AppendLiteral(";");
      ref StringBuilder.AppendInterpolatedStringHandler local5 = ref interpolatedStringHandler;
      stringBuilder10.Append(ref local5);
      StringBuilder stringBuilder11 = sb;
      StringBuilder stringBuilder12 = stringBuilder11;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(15, 1, stringBuilder11);
      interpolatedStringHandler.AppendLiteral("border-radius:");
      interpolatedStringHandler.AppendFormatted(this.BorderRadius);
      interpolatedStringHandler.AppendLiteral(";");
      ref StringBuilder.AppendInterpolatedStringHandler local6 = ref interpolatedStringHandler;
      stringBuilder12.Append(ref local6);
      if (this.Background != null)
      {
        StringBuilder stringBuilder13 = sb;
        StringBuilder stringBuilder14 = stringBuilder13;
        interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(12, 1, stringBuilder13);
        interpolatedStringHandler.AppendLiteral("background:");
        interpolatedStringHandler.AppendFormatted(this.Background);
        interpolatedStringHandler.AppendLiteral(";");
        ref StringBuilder.AppendInterpolatedStringHandler local7 = ref interpolatedStringHandler;
        stringBuilder14.Append(ref local7);
      }
      else
      {
        StringBuilder stringBuilder15 = sb;
        StringBuilder stringBuilder16 = stringBuilder15;
        interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(18, 1, stringBuilder15);
        interpolatedStringHandler.AppendLiteral("background-color:");
        interpolatedStringHandler.AppendFormatted(this.BackgroundColor);
        interpolatedStringHandler.AppendLiteral(";");
        ref StringBuilder.AppendInterpolatedStringHandler local8 = ref interpolatedStringHandler;
        stringBuilder16.Append(ref local8);
      }
      StringBuilder stringBuilder17 = sb;
      StringBuilder stringBuilder18 = stringBuilder17;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(8, 1, stringBuilder17);
      interpolatedStringHandler.AppendLiteral("border:");
      interpolatedStringHandler.AppendFormatted(this.Border);
      interpolatedStringHandler.AppendLiteral(";");
      ref StringBuilder.AppendInterpolatedStringHandler local9 = ref interpolatedStringHandler;
      stringBuilder18.Append(ref local9);
      StringBuilder stringBuilder19 = sb;
      StringBuilder stringBuilder20 = stringBuilder19;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(7, 1, stringBuilder19);
      interpolatedStringHandler.AppendLiteral("color:");
      interpolatedStringHandler.AppendFormatted(this.TextColor);
      interpolatedStringHandler.AppendLiteral(";");
      ref StringBuilder.AppendInterpolatedStringHandler local10 = ref interpolatedStringHandler;
      stringBuilder20.Append(ref local10);
      StringBuilder stringBuilder21 = sb;
      StringBuilder stringBuilder22 = stringBuilder21;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(7, 1, stringBuilder21);
      interpolatedStringHandler.AppendLiteral("width:");
      interpolatedStringHandler.AppendFormatted(this.Width);
      interpolatedStringHandler.AppendLiteral(";");
      ref StringBuilder.AppendInterpolatedStringHandler local11 = ref interpolatedStringHandler;
      stringBuilder22.Append(ref local11);
      StringBuilder stringBuilder23 = sb;
      StringBuilder stringBuilder24 = stringBuilder23;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(8, 1, stringBuilder23);
      interpolatedStringHandler.AppendLiteral("height:");
      interpolatedStringHandler.AppendFormatted(this.Height);
      interpolatedStringHandler.AppendLiteral(";");
      ref StringBuilder.AppendInterpolatedStringHandler local12 = ref interpolatedStringHandler;
      stringBuilder24.Append(ref local12);
      StringBuilder stringBuilder25 = sb;
      StringBuilder stringBuilder26 = stringBuilder25;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(11, 1, stringBuilder25);
      interpolatedStringHandler.AppendLiteral("font-size:");
      interpolatedStringHandler.AppendFormatted(this.TextSize);
      interpolatedStringHandler.AppendLiteral(";");
      ref StringBuilder.AppendInterpolatedStringHandler local13 = ref interpolatedStringHandler;
      stringBuilder26.Append(ref local13);
      StringBuilder stringBuilder27 = sb;
      StringBuilder stringBuilder28 = stringBuilder27;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(9, 1, stringBuilder27);
      interpolatedStringHandler.AppendLiteral("opacity:");
      interpolatedStringHandler.AppendFormatted(this.Opacity);
      interpolatedStringHandler.AppendLiteral(";");
      ref StringBuilder.AppendInterpolatedStringHandler local14 = ref interpolatedStringHandler;
      stringBuilder28.Append(ref local14);
      StringBuilder stringBuilder29 = sb;
      StringBuilder stringBuilder30 = stringBuilder29;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(9, 1, stringBuilder29);
      interpolatedStringHandler.AppendLiteral("padding:");
      interpolatedStringHandler.AppendFormatted(this.Padding);
      interpolatedStringHandler.AppendLiteral(";");
      ref StringBuilder.AppendInterpolatedStringHandler local15 = ref interpolatedStringHandler;
      stringBuilder30.Append(ref local15);
      StringBuilder stringBuilder31 = sb;
      StringBuilder stringBuilder32 = stringBuilder31;
      interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(12, 1, stringBuilder31);
      interpolatedStringHandler.AppendLiteral("text-align:");
      interpolatedStringHandler.AppendFormatted(this.TextAlign);
      interpolatedStringHandler.AppendLiteral(";");
      ref StringBuilder.AppendInterpolatedStringHandler local16 = ref interpolatedStringHandler;
      stringBuilder32.Append(ref local16);
      this.styles = sb.ToString();
      sb = (StringBuilder) null;
    }

    [Inject]
    private StateManager sm { get; set; }

    public Widget()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
      interpolatedStringHandler.AppendLiteral("widget-");
      interpolatedStringHandler.AppendFormatted<Guid>(Guid.NewGuid());
      // ISSUE: reference to a compiler-generated field
      this.Id = interpolatedStringHandler.ToStringAndClear();
      // ISSUE: reference to a compiler-generated field
      this.Text = string.Empty;
      // ISSUE: reference to a compiler-generated field
      this.Opacity = "1";
      // ISSUE: reference to a compiler-generated field
      this.TextSize = "18px";
      // ISSUE: reference to a compiler-generated field
      this.LogoSize = "36px";
      // ISSUE: reference to a compiler-generated field
      this.Border = "none";
      // ISSUE: reference to a compiler-generated field
      this.BackgroundColor = "#333";
      // ISSUE: reference to a compiler-generated field
      this.TextColor = "#fff";
      // ISSUE: reference to a compiler-generated field
      this.TextAlign = "center";
      // ISSUE: reference to a compiler-generated field
      this.LogoColor = "#fff";
      // ISSUE: reference to a compiler-generated field
      this.BorderRadius = "1rem";
      // ISSUE: reference to a compiler-generated field
      this.ColumnGap = "1rem";
      // ISSUE: reference to a compiler-generated field
      this.RowGap = "1rem";
      // ISSUE: reference to a compiler-generated field
      this.HorizonalAlign = "center";
      // ISSUE: reference to a compiler-generated field
      this.VerticalAlign = "center";
      // ISSUE: reference to a compiler-generated field
      this.FlowVertical = true;
      // ISSUE: reference to a compiler-generated field
      this.Width = "100px";
      // ISSUE: reference to a compiler-generated field
      this.Height = "100px";
      // ISSUE: reference to a compiler-generated field
      this.Padding = "1rem";
      // ISSUE: reference to a compiler-generated field
      this.sm = (StateManager) null;
      // ISSUE: explicit constructor call
      base.OnInitialized();
    }
  }
}
