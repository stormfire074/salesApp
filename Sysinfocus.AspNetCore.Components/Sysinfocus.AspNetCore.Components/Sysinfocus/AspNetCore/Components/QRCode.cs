// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.QRCode
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
  public class QRCode : ComponentBase
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "id", this.Id);
      __builder.AddAttribute(2, "class", this.Class);
      __builder.AddAttribute(3, "style", "width: " + this.Width.ToString() + "px; height: " + this.Height.ToString() + "px; " + this.Style);
      __builder.CloseElement();
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
    public string Background { get; set; }

    [Parameter]
    public string Foreground { get; set; }

    [Parameter]
    public QRCorrectLevel CorrectLevel { get; set; }

    protected override async Task OnInitializedAsync()
    {
      if (!(this.sm.GetFromState((object) "QRCODE_JS") is bool))
      {
        this.sm.Publish((object) "QRCODE_JS", (object) true);
        await this.be.AddScript(InitializeSysinfocus.QRCODE_JS);
      }
      await this.Generate();
    }

    public async Task Update(string text)
    {
      string scp = "qrcode.clear(); qrcode.makeCode('" + text + "')";
      await this.be.EvalVoid((object) scp);
      scp = (string) null;
    }

    public async Task Generate()
    {
      await Task.Delay(500);
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(152, 7);
      interpolatedStringHandler.AppendLiteral("var qrcode = new QRCode(document.getElementById('");
      interpolatedStringHandler.AppendFormatted(this.Id);
      interpolatedStringHandler.AppendLiteral("'), { text: '");
      interpolatedStringHandler.AppendFormatted(this.Text);
      interpolatedStringHandler.AppendLiteral("', width: ");
      interpolatedStringHandler.AppendFormatted<double?>(this.Width);
      interpolatedStringHandler.AppendLiteral(", height: ");
      interpolatedStringHandler.AppendFormatted<double?>(this.Height);
      interpolatedStringHandler.AppendLiteral(", colorDark: '");
      interpolatedStringHandler.AppendFormatted(this.Foreground);
      interpolatedStringHandler.AppendLiteral("', colorLight: '");
      interpolatedStringHandler.AppendFormatted(this.Background);
      interpolatedStringHandler.AppendLiteral("', correctLevel: QRCode.CorrectLevel.");
      interpolatedStringHandler.AppendFormatted<QRCorrectLevel>(this.CorrectLevel);
      interpolatedStringHandler.AppendLiteral("});");
      string scp = interpolatedStringHandler.ToStringAndClear();
      await this.be.EvalVoid((object) scp);
      scp = (string) null;
    }

    [Inject]
    private BrowserExtensions be { get; set; }

    [Inject]
    private StateManager sm { get; set; }

    public QRCode()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
      interpolatedStringHandler.AppendLiteral("qrc-");
      interpolatedStringHandler.AppendFormatted<Guid>(Guid.NewGuid());
      // ISSUE: reference to a compiler-generated field
      this.Id = interpolatedStringHandler.ToStringAndClear();
      // ISSUE: reference to a compiler-generated field
      this.Width = new double?(150.0);
      // ISSUE: reference to a compiler-generated field
      this.Height = new double?(150.0);
      // ISSUE: reference to a compiler-generated field
      this.Text = string.Empty;
      // ISSUE: reference to a compiler-generated field
      this.Background = "white";
      // ISSUE: reference to a compiler-generated field
      this.Foreground = "black";
      // ISSUE: reference to a compiler-generated field
      this.CorrectLevel = QRCorrectLevel.H;
      // ISSUE: reference to a compiler-generated field
      this.be = (BrowserExtensions) null;
      // ISSUE: reference to a compiler-generated field
      this.sm = (StateManager) null;
      // ISSUE: explicit constructor call
      base.OnInitialized();
    }
  }
}
