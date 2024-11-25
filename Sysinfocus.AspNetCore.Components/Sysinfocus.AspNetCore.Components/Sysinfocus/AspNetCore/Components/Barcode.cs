// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Barcode
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
  public class Barcode : ComponentBase
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      if (!InitializeSysinfocus.IsLicensed)
      {
        __builder.OpenElement(0, "div");
        __builder.AddAttribute(1, "class", "flex-col g0 jcc aic");
        __builder.AddMarkupContent(2, "<small class=\"mtb05\">You are using a trial version.</small>\r\n        ");
        __builder.OpenElement(3, "svg");
        __builder.AddAttribute(4, "id", this.Id);
        __builder.AddAttribute(5, "class", this.Class);
        __builder.AddAttribute(6, "style", this.Style);
        __builder.CloseElement();
        __builder.CloseElement();
      }
      else
      {
        __builder.OpenElement(7, "svg");
        __builder.AddAttribute(8, "id", this.Id);
        __builder.AddAttribute(9, "class", this.Class);
        __builder.AddAttribute(10, "style", this.Style);
        __builder.CloseElement();
      }
    }

    [Parameter]
    public 
    #nullable enable
    string? Id { get; set; }

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public double? Width { get; set; }

    [Parameter]
    public double? Height { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Parameter]
    [EditorRequired]
    public string Text { get; set; }

    [Parameter]
    public string LineColor { get; set; }

    [Parameter]
    public bool DisplayValue { get; set; }

    [Parameter]
    public BarcodeFormat Format { get; set; }

    protected override async Task OnInitializedAsync()
    {
      if (!(this.sm.GetFromState((object) "BARCODE_JS") is bool))
      {
        this.sm.Publish((object) "BARCODE_JS", (object) true);
        await this.be.AddScript(InitializeSysinfocus.BARCODE_JS);
      }
      await this.Generate();
    }

    public async Task Generate()
    {
      await Task.Delay(500);
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(84, 7);
      interpolatedStringHandler.AppendLiteral("JsBarcode('#");
      interpolatedStringHandler.AppendFormatted(this.Id);
      interpolatedStringHandler.AppendLiteral("', '");
      interpolatedStringHandler.AppendFormatted(this.Text);
      interpolatedStringHandler.AppendLiteral("', { format: '");
      interpolatedStringHandler.AppendFormatted(this.Format.ToString().ToLowerInvariant());
      interpolatedStringHandler.AppendLiteral("', lineColor: '");
      interpolatedStringHandler.AppendFormatted(this.LineColor);
      interpolatedStringHandler.AppendLiteral("', width: ");
      interpolatedStringHandler.AppendFormatted<double?>(this.Width);
      interpolatedStringHandler.AppendLiteral(", height: ");
      interpolatedStringHandler.AppendFormatted<double?>(this.Height);
      interpolatedStringHandler.AppendLiteral(", displayValue: ");
      interpolatedStringHandler.AppendFormatted(this.DisplayValue ? "true" : "false");
      interpolatedStringHandler.AppendLiteral(" })");
      string scp = interpolatedStringHandler.ToStringAndClear();
      await this.be.EvalVoid((object) scp);
      scp = (string) null;
    }

    [Inject]
    private BrowserExtensions be { get; set; }

    [Inject]
    private StateManager sm { get; set; }

    public Barcode()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
      interpolatedStringHandler.AppendLiteral("qrc-");
      interpolatedStringHandler.AppendFormatted<Guid>(Guid.NewGuid());
      // ISSUE: reference to a compiler-generated field
      this.Id = interpolatedStringHandler.ToStringAndClear();
      // ISSUE: reference to a compiler-generated field
      this.Width = new double?(2.0);
      // ISSUE: reference to a compiler-generated field
      this.Height = new double?(60.0);
      // ISSUE: reference to a compiler-generated field
      this.Text = string.Empty;
      // ISSUE: reference to a compiler-generated field
      this.LineColor = "black";
      // ISSUE: reference to a compiler-generated field
      this.DisplayValue = true;
      // ISSUE: reference to a compiler-generated field
      this.Format = BarcodeFormat.Code128;
      // ISSUE: reference to a compiler-generated field
      this.be = (BrowserExtensions) null;
      // ISSUE: reference to a compiler-generated field
      this.sm = (StateManager) null;
      // ISSUE: explicit constructor call
      base.OnInitialized();
    }
  }
}
