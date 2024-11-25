// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.TimePicker
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class TimePicker : ComponentBase
  {
    private int[] hours;
    private int[] minutes;
    private int hour;
    private int minute;

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-timepicker " + this.Class);
      __builder.AddAttribute(2, "style", this.Style);
      __builder.AddAttribute(3, "b-93c41n6ujy");
      __builder.OpenComponent<Select<int>>(4);
      __builder.AddComponentParameter(5, "Display", (object) (Func<int, string>) (x => x.ToString("00")));
      __builder.AddComponentParameter(6, "Items", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<ICollection<int>>((ICollection<int>) this.hours));
      __builder.AddComponentParameter(7, "Width", (object) "50px");
      __builder.AddComponentParameter(8, "ListWidth", (object) "75px");
      __builder.AddComponentParameter(9, "SelectedItem", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<int>(this.hour));
      __builder.AddComponentParameter(10, "OnItemSelect", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback<int>>(EventCallback.Factory.Create<int>((object) this, (Func<int, Task>) (x => this.Update(x, this.minute)))));
      __builder.AddComponentParameter(11, "HideIcon", (object) true);
      __builder.CloseComponent();
      __builder.AddMarkupContent(12, " :\r\n    ");
      __builder.OpenComponent<Select<int>>(13);
      __builder.AddComponentParameter(14, "Display", (object) (Func<int, string>) (x => x.ToString("00")));
      __builder.AddComponentParameter(15, "Items", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<ICollection<int>>((ICollection<int>) this.minutes));
      __builder.AddComponentParameter(16, "Width", (object) "50px");
      __builder.AddComponentParameter(17, "ListWidth", (object) "75px");
      __builder.AddComponentParameter(18, "SelectedItem", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<int>(this.minute));
      __builder.AddComponentParameter(19, "OnItemSelect", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback<int>>(EventCallback.Factory.Create<int>((object) this, (Func<int, Task>) (x => this.Update(this.hour, x)))));
      __builder.AddComponentParameter(20, "HideIcon", (object) true);
      __builder.CloseComponent();
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    string? Id { get; set; }

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Parameter]
    public DateTime? Time { get; set; }

    [Parameter]
    public EventCallback<DateTime?> TimeChanged { get; set; }

    protected override void OnInitialized()
    {
      if (!this.Time.HasValue)
        return;
      this.hour = this.Time.Value.Hour;
      this.minute = this.Time.Value.Minute;
    }

    private async Task Update(int h, int m)
    {
      this.hour = h;
      this.minute = m;
      DateTime now;
      if (!this.Time.HasValue)
      {
        now = DateTime.Now;
        this.Time = new DateTime?(now.Date);
      }
      DateTime? time = this.Time;
      now = time.Value;
      int year = now.Year;
      time = this.Time;
      now = time.Value;
      int month = now.Month;
      time = this.Time;
      now = time.Value;
      int day = now.Day;
      int hour = this.hour;
      int minute = this.minute;
      this.Time = new DateTime?(new DateTime(year, month, day, hour, minute, 0));
      await this.TimeChanged.InvokeAsync(this.Time);
    }

    [Inject]
    private StateManager sm { get; set; }

    public TimePicker()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
      interpolatedStringHandler.AppendLiteral("tp-");
      interpolatedStringHandler.AppendFormatted<Guid>(Guid.NewGuid());
      // ISSUE: reference to a compiler-generated field
      this.Id = interpolatedStringHandler.ToStringAndClear();
      this.hours = Enumerable.Range(0, 24).ToArray<int>();
      this.minutes = Enumerable.Range(0, 60).ToArray<int>();
      // ISSUE: reference to a compiler-generated field
      this.sm = (StateManager) null;
      // ISSUE: explicit constructor call
      base.OnInitialized();
    }
  }
}
