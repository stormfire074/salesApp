// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.ActivityLog
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System.Collections.Generic;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class ActivityLog : ComponentBase
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      if (this.Items == null)
        return;
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-activity-log " + this.Class);
      __builder.AddAttribute(2, "style", this.Style);
      __builder.AddAttribute(3, "b-wsnmzwy8v6");
      if (!InitializeSysinfocus.IsLicensed)
        __builder.AddMarkupContent(4, "<small class=\"mtb05\" b-wsnmzwy8v6>You are using a trial version.</small>");
      int num1 = 0;
      string str = "fade-in";
      foreach (Log log in (IEnumerable<Log>) this.Items)
      {
        ++num1;
        int num2 = num1 + 1;
        if (this.Animate)
          str = num1 % 2 == 0 ? "slide-in" : "slide-out";
        __builder.OpenElement(5, "div");
        __builder.AddAttribute(6, "class", "sbc-log " + str);
        __builder.AddAttribute(7, "style", "--delay:" + (num1 * 100).ToString() + "ms");
        __builder.AddAttribute(8, "b-wsnmzwy8v6");
        __builder.OpenElement(9, "div");
        __builder.AddAttribute(10, "class", "flex-col g4 jcc aife data ra");
        __builder.AddAttribute(11, "b-wsnmzwy8v6");
        __builder.OpenElement(12, "small");
        __builder.AddAttribute(13, "b-wsnmzwy8v6");
        __builder.OpenElement(14, "b");
        __builder.AddAttribute(15, "b-wsnmzwy8v6");
        __builder.AddContent(16, log.User);
        __builder.CloseElement();
        __builder.CloseElement();
        __builder.AddMarkupContent(17, "\r\n                    ");
        __builder.OpenElement(18, "small");
        __builder.AddAttribute(19, "class", "muted-color");
        __builder.AddAttribute(20, "b-wsnmzwy8v6");
        __builder.AddContent(21, log.ActivityOn.ToString(this.Format));
        __builder.CloseElement();
        __builder.CloseElement();
        __builder.AddMarkupContent(22, "\r\n                ");
        __builder.OpenElement(23, "img");
        __builder.AddAttribute(24, "src", log.Avatar);
        __builder.AddAttribute(25, "b-wsnmzwy8v6");
        __builder.CloseElement();
        __builder.AddMarkupContent(26, "\r\n                ");
        __builder.OpenElement(27, "div");
        __builder.AddAttribute(28, "class", "flex-col g4 jcc data la");
        __builder.AddAttribute(29, "b-wsnmzwy8v6");
        __builder.OpenElement(30, "small");
        __builder.AddAttribute(31, "b-wsnmzwy8v6");
        __builder.OpenElement(32, "b");
        __builder.AddAttribute(33, "b-wsnmzwy8v6");
        __builder.AddContent(34, log.Title);
        __builder.CloseElement();
        __builder.CloseElement();
        __builder.AddMarkupContent(35, "\r\n                    ");
        __builder.OpenElement(36, "small");
        __builder.AddAttribute(37, "class", "muted-color");
        __builder.AddAttribute(38, "b-wsnmzwy8v6");
        __builder.AddContent(39, log.Description);
        __builder.CloseElement();
        __builder.CloseElement();
        __builder.CloseElement();
      }
      __builder.CloseElement();
    }

    [Parameter]
    public bool Animate { get; set; }

    [Parameter]
    public 
    #nullable enable
    ICollection<Log>? Items { get; set; }

    [Parameter]
    public string Format { get; set; } = "dd MMM, yyyy @ hh:mm tt";

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
