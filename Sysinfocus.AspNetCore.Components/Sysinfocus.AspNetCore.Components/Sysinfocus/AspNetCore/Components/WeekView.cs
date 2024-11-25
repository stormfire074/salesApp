// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.WeekView
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class WeekView : ComponentBase
  {
    private int columns = 5;
    private List<Schedule> schedules = new List<Schedule>();

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "table");
      __builder.OpenElement(1, "thead");
      __builder.OpenElement(2, "tr");
      __builder.AddMarkupContent(3, "<th style=\"width: 70px\">&nbsp;</th>");
      DateTime dateTime1;
      for (int index = 0; index < this.columns; ++index)
      {
        dateTime1 = this.Start;
        DateTime dateTime2 = dateTime1.AddDays((double) index);
        __builder.OpenElement(4, "th");
        __builder.AddContent(5, dateTime2.DayOfWeek.ToString().Substring(0, 3));
        __builder.AddMarkupContent(6, "<br>");
        __builder.OpenElement(7, "b");
        __builder.AddContent(8, dateTime2.ToString("dd"));
        __builder.CloseElement();
        __builder.CloseElement();
      }
      __builder.CloseElement();
      __builder.CloseElement();
      __builder.AddMarkupContent(9, "\r\n    ");
      __builder.OpenElement(10, "tbody");
      for (int index1 = 0; index1 < this.schedules.Count / this.columns; index1 += 2)
      {
        Schedule schedule = this.schedules[index1];
        __builder.OpenElement(11, "tr");
        RenderTreeBuilder renderTreeBuilder1 = __builder;
        dateTime1 = schedule.On;
        int hour1 = dateTime1.Hour;
        dateTime1 = DateTime.Now;
        int hour2 = dateTime1.Hour;
        string str1;
        if (hour1 == hour2)
        {
          dateTime1 = DateTime.Now;
          if (dateTime1.Minute < 30)
          {
            str1 = "currentTime";
            goto label_8;
          }
        }
        str1 = (string) null;
label_8:
        renderTreeBuilder1.AddAttribute(12, "class", str1);
        __builder.OpenElement(13, "td");
        __builder.AddAttribute(14, "rowspan", "2");
        __builder.AddAttribute(15, "class", "time");
        RenderTreeBuilder renderTreeBuilder2 = __builder;
        dateTime1 = this.schedules[index1].On;
        string textContent = dateTime1.ToString("h tt");
        renderTreeBuilder2.AddContent(16, textContent);
        __builder.CloseElement();
        for (int index2 = 0; index2 < this.columns; ++index2)
        {
          Schedule sc = this.schedules[index1 + index2 * 48];
          __builder.OpenElement(17, "td");
          __builder.AddAttribute(18, "tabindex", "0");
          __builder.AddAttribute(19, "class", sc.IsMarked ? "mark" : (string) null);
          __builder.AddAttribute(20, "id", (object) sc.Id);
          __builder.AddAttribute<MouseEventArgs>(21, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, (Func<Task>) (() => this.Toggle(sc))));
          __builder.CloseElement();
        }
        __builder.CloseElement();
        __builder.AddMarkupContent(22, "\r\n            ");
        __builder.OpenElement(23, "tr");
        RenderTreeBuilder renderTreeBuilder3 = __builder;
        dateTime1 = schedule.On;
        int hour3 = dateTime1.Hour;
        dateTime1 = DateTime.Now;
        int hour4 = dateTime1.Hour;
        string str2;
        if (hour3 == hour4)
        {
          dateTime1 = DateTime.Now;
          if (dateTime1.Minute >= 30)
          {
            str2 = "currentTime";
            goto label_15;
          }
        }
        str2 = (string) null;
label_15:
        renderTreeBuilder3.AddAttribute(24, "class", str2);
        for (int index3 = 0; index3 < this.columns; ++index3)
        {
          Schedule sc1 = this.schedules[index1 + index3 * 48 + 1];
          __builder.OpenElement(25, "td");
          __builder.AddAttribute(26, "tabindex", "0");
          __builder.AddAttribute(27, "class", sc1.IsMarked ? "mark" : (string) null);
          __builder.AddAttribute(28, "id", (object) sc1.Id);
          __builder.AddAttribute<MouseEventArgs>(29, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, (Func<Task>) (() => this.Toggle(sc1))));
          __builder.CloseElement();
        }
        __builder.CloseElement();
      }
      __builder.CloseElement();
      __builder.CloseElement();
    }

    [Parameter]
    public ViewType Type { get; set; } = ViewType.WorkWeek;

    [Parameter]
    public DateTime Start { get; set; } = DateTime.Now;

    [Inject]
    private 
    #nullable enable
    BrowserExtensions BrowserExtensions { get; set; } = (BrowserExtensions) null;

    protected override void OnParametersSet()
    {
      int num;
      switch (this.Type)
      {
        case ViewType.Week:
          num = 7;
          break;
        case ViewType.WorkWeek:
          num = 5;
          break;
        default:
          num = 0;
          break;
      }
      this.columns = num;
      this.schedules = this.GetWeekSchedule(this.Start);
    }

    private List<Schedule> GetWeekSchedule(DateTime start)
    {
      int columns = this.columns;
      List<Schedule> weekSchedule = new List<Schedule>();
      DateTime dateTime = new DateTime(start.Year, start.Month, start.Day, 0, 0, 0);
      for (int index = 0; index < 48 * this.columns; ++index)
      {
        weekSchedule.Add(new Schedule()
        {
          Id = Guid.NewGuid(),
          On = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 0)
        });
        dateTime = dateTime.AddMinutes(30.0);
      }
      return weekSchedule;
    }

    private async Task Toggle(Schedule schedule)
    {
      schedule.IsMarked = !schedule.IsMarked;
      if (schedule.IsMarked)
        return;
      await this.BrowserExtensions.EvalVoid((object) "document.activeElement = null");
    }

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
