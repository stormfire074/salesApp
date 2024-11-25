// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Lottie
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
  public class Lottie : ComponentBase
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-lottie " + this.Class);
      __builder.AddAttribute(2, "style", "width:" + this.Width + ";height:" + this.Height + ";" + this.Style);
      __builder.AddAttribute(3, "id", this.Id);
      __builder.AddAttribute(4, "b-nhwoakmm5v");
      if (!InitializeSysinfocus.IsLicensed)
        __builder.AddMarkupContent(5, "<small class=\"mtb1 ta-center\" b-nhwoakmm5v>You are using a trial version.</small>");
      __builder.OpenElement(6, "lottie-player");
      __builder.AddAttribute(7, "src", this.Source);
      __builder.AddAttribute(8, "background", this.Background);
      __builder.AddAttribute(9, "speed", (object) this.Speed);
      __builder.AddAttribute(10, "style", "width: 100%; height: 100%");
      __builder.AddAttribute(11, "direction", this.Direction);
      __builder.AddAttribute(12, "mode", this.Mode);
      __builder.AddAttribute(13, "b-nhwoakmm5v");
      __builder.CloseElement();
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    string? Id { get; set; }

    [Parameter]
    public string? Source { get; set; }

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public string? Width { get; set; }

    [Parameter]
    public string? Height { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Parameter]
    public string? Background { get; set; }

    [Parameter]
    public double Speed { get; set; }

    [Parameter]
    public string Direction { get; set; }

    [Parameter]
    public string Mode { get; set; }

    [Parameter]
    public bool Loop { get; set; }

    [Parameter]
    public bool AutoPlay { get; set; }

    [Parameter]
    public bool Controls { get; set; }

    protected override async Task OnInitializedAsync()
    {
      if (this.sm.GetFromState((object) "LOTTIE_JS") is bool)
        return;
      this.sm.Publish((object) "LOTTIE_JS", (object) true);
      await this.be.AddScript(InitializeSysinfocus.LOTTIE_JS);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
      if (!firstRender)
        return;
      if (this.Loop)
        await this.be.EvalVoid((object) ("document.querySelector('#" + this.Id + " lottie-player').setAttribute('loop', true)"));
      if (this.Controls)
        await this.be.EvalVoid((object) ("document.querySelector('#" + this.Id + " lottie-player').setAttribute('controls', true)"));
      if (this.AutoPlay)
        await this.be.EvalVoid((object) ("document.querySelector('#" + this.Id + " lottie-player').setAttribute('autoplay', true)"));
    }

    [Inject]
    private BrowserExtensions be { get; set; }

    [Inject]
    private StateManager sm { get; set; }

    public Lottie()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
      interpolatedStringHandler.AppendLiteral("lt-");
      interpolatedStringHandler.AppendFormatted<Guid>(Guid.NewGuid());
      // ISSUE: reference to a compiler-generated field
      this.Id = interpolatedStringHandler.ToStringAndClear();
      // ISSUE: reference to a compiler-generated field
      this.Width = "300px";
      // ISSUE: reference to a compiler-generated field
      this.Height = "300px";
      // ISSUE: reference to a compiler-generated field
      this.Background = "transparent";
      // ISSUE: reference to a compiler-generated field
      this.Speed = 1.0;
      // ISSUE: reference to a compiler-generated field
      this.Direction = "1";
      // ISSUE: reference to a compiler-generated field
      this.Mode = "normal";
      // ISSUE: reference to a compiler-generated field
      this.Loop = true;
      // ISSUE: reference to a compiler-generated field
      this.AutoPlay = true;
      // ISSUE: reference to a compiler-generated field
      this.be = (BrowserExtensions) null;
      // ISSUE: reference to a compiler-generated field
      this.sm = (StateManager) null;
      // ISSUE: explicit constructor call
      base.OnInitialized();
    }
  }
}
