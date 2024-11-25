// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Calendar
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class Calendar : ComponentBase
  {
    private bool pkd;
    private DateTime _date;
    private DateTime _selectedDate;
    private int maxDays;
    private int lastMonthMaxDays;
    private int startDay = -1;
    private int nextMonthStart;

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-date-picker-wrapper");
      __builder.AddAttribute(2, "style", "width: " + this.Width);
      __builder.AddAttribute(3, "b-7d73tkmg3g");
      if (!InitializeSysinfocus.IsLicensed)
        __builder.AddMarkupContent(4, "<small class=\"mtb1\" b-7d73tkmg3g>You are using a trial version.</small>");
      __builder.OpenElement(5, "div");
      __builder.AddAttribute(6, "class", "sbc-date-picker");
      __builder.AddAttribute(7, "id", "dp" + this.Id);
      __builder.AddAttribute(8, "b-7d73tkmg3g");
      __builder.OpenElement(9, "div");
      __builder.AddAttribute(10, "class", "sbc-date-picker-header");
      __builder.AddAttribute(11, "b-7d73tkmg3g");
      __builder.OpenElement(12, "div");
      __builder.AddAttribute(13, "class", "flex g0");
      __builder.AddAttribute(14, "b-7d73tkmg3g");
      __builder.OpenElement(15, "button");
      __builder.AddAttribute(16, "tabindex", "-1");
      __builder.AddAttribute(17, "class", "back sbc-date-picker-left");
      __builder.AddAttribute<MouseEventArgs>(18, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, new Func<Task>(this.HandlePrevYearButton)));
      __builder.AddAttribute(19, "b-7d73tkmg3g");
      __builder.AddMarkupContent(20, "<span class=\"material-symbols-outlined pnyear\" b-7d73tkmg3g>keyboard_double_arrow_left</span>");
      __builder.CloseElement();
      __builder.AddMarkupContent(21, "\r\n                ");
      __builder.OpenElement(22, "button");
      __builder.AddAttribute(23, "tabindex", "-1");
      __builder.AddAttribute(24, "class", "back sbc-date-picker-left");
      __builder.AddAttribute<MouseEventArgs>(25, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, new Func<Task>(this.HandlePrevMonth)));
      __builder.AddAttribute(26, "b-7d73tkmg3g");
      __builder.AddMarkupContent(27, "<span class=\"material-symbols-outlined pnyear\" b-7d73tkmg3g>chevron_left</span>");
      __builder.CloseElement();
      __builder.CloseElement();
      __builder.AddMarkupContent(28, "\r\n            ");
      __builder.OpenElement(29, "p");
      __builder.AddAttribute(30, "tabindex", "-1");
      __builder.AddAttribute(31, "class", "month-year");
      __builder.AddAttribute(32, "b-7d73tkmg3g");
      __builder.AddContent(33, this._date.ToString("MMMM, yyyy"));
      __builder.CloseElement();
      __builder.AddMarkupContent(34, "\r\n            ");
      __builder.OpenElement(35, "div");
      __builder.AddAttribute(36, "class", "flex g0");
      __builder.AddAttribute(37, "b-7d73tkmg3g");
      __builder.OpenElement(38, "button");
      __builder.AddAttribute(39, "tabindex", "-1");
      __builder.AddAttribute(40, "class", "next sbc-date-picker-right");
      __builder.AddAttribute<MouseEventArgs>(41, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, new Func<Task>(this.HandleNextMonth)));
      __builder.AddAttribute(42, "b-7d73tkmg3g");
      __builder.AddMarkupContent(43, "<span class=\"material-symbols-outlined pnyear\" b-7d73tkmg3g>chevron_right</span>");
      __builder.CloseElement();
      __builder.AddMarkupContent(44, "\r\n                ");
      __builder.OpenElement(45, "button");
      __builder.AddAttribute(46, "tabindex", "-1");
      __builder.AddAttribute(47, "class", "next sbc-date-picker-right");
      __builder.AddAttribute<MouseEventArgs>(48, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, new Func<Task>(this.HandleNextYearButton)));
      __builder.AddAttribute(49, "b-7d73tkmg3g");
      __builder.AddMarkupContent(50, "<span class=\"material-symbols-outlined pnyear\" b-7d73tkmg3g>keyboard_double_arrow_right</span>");
      __builder.CloseElement();
      __builder.CloseElement();
      __builder.CloseElement();
      __builder.AddMarkupContent(51, "\r\n        ");
      __builder.OpenElement(52, "div");
      __builder.AddAttribute(53, "class", "sbc-date-picker-content");
      __builder.AddAttribute(54, "b-7d73tkmg3g");
      __builder.OpenElement(55, "div");
      __builder.AddAttribute(56, "class", "sbc-date-picker-weekdays");
      __builder.AddAttribute(57, "b-7d73tkmg3g");
      for (int index = 0; index < 7; ++index)
      {
        __builder.OpenElement(58, "span");
        __builder.AddAttribute(59, "b-7d73tkmg3g");
        __builder.AddContent(60, ((DayOfWeek) index).ToString().Substring(0, 2));
        __builder.CloseElement();
      }
      __builder.CloseElement();
      __builder.AddMarkupContent(61, "\r\n            ");
      __builder.OpenElement(62, "div");
      __builder.AddAttribute(63, "class", "sbc-date-picker-days");
      __builder.AddAttribute(64, "b-7d73tkmg3g");
      this.nextMonthStart = 0;
      for (int index = 0; index < this.startDay; ++index)
      {
        int x = this.lastMonthMaxDays - this.startDay + index + 1;
        __builder.OpenElement(65, "button");
        __builder.AddAttribute(66, "tabindex", "-1");
        __builder.AddAttribute(67, "class", "prev-month");
        __builder.AddAttribute<MouseEventArgs>(68, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, (Func<Task>) (() => this.GotoPrevMonth(x))));
        __builder.AddEventPreventDefaultAttribute(69, "onkeydown", this.pkd);
        __builder.AddAttribute<KeyboardEventArgs>(70, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, (Func<KeyboardEventArgs, Task>) (async xx => await this.HandleKeydown(xx, (Action) (async () => await this.GotoPrevMonth(x))))));
        __builder.AddAttribute(71, "disabled", this.DisablePrevMonthDate(x));
        __builder.AddAttribute(72, "b-7d73tkmg3g");
        __builder.AddContent(73, (object) x);
        __builder.CloseElement();
        ++this.nextMonthStart;
      }
      for (int index = 1; index <= this.maxDays; ++index)
      {
        int y = index;
        __builder.OpenElement(74, "button");
        __builder.AddAttribute(75, "tabindex", "-1");
        RenderTreeBuilder renderTreeBuilder = __builder;
        DateTime date = this._date.Date;
        DateTime? nullable = this.IsValidDate(DateTime.Now.Year, DateTime.Now.Month, y);
        string str = ((nullable.HasValue ? (date == nullable.GetValueOrDefault() ? 1 : 0) : 0) != 0 ? "today" : (string) null) + "\r\n                        " + (this._selectedDate.Date == new DateTime(this._date.Year, this._date.Month, y) ? "selected" : (string) null);
        renderTreeBuilder.AddAttribute(76, "class", str);
        __builder.AddAttribute<MouseEventArgs>(77, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, (Func<Task>) (() => this.SelectDate(y))));
        __builder.AddAttribute<KeyboardEventArgs>(78, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, (Func<KeyboardEventArgs, Task>) (x => this.HandleKeydown(x))));
        __builder.AddEventPreventDefaultAttribute(79, "onkeydown", this.pkd);
        __builder.AddAttribute(80, "disabled", this.DisableCurrentMonthDate(y));
        __builder.AddAttribute(81, "b-7d73tkmg3g");
        __builder.AddContent(82, (object) y);
        __builder.CloseElement();
        ++this.nextMonthStart;
      }
      if (this.nextMonthStart % 7 >= 1)
      {
        for (int index = 1; index <= 7 - this.nextMonthStart % 7; ++index)
        {
          int z = index;
          __builder.OpenElement(83, "button");
          __builder.AddAttribute(84, "tabindex", "-1");
          __builder.AddAttribute(85, "class", "next-month");
          __builder.AddAttribute<MouseEventArgs>(86, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, (Func<Task>) (() => this.GotoNextMonth(z))));
          __builder.AddEventPreventDefaultAttribute(87, "onkeydown", this.pkd);
          __builder.AddAttribute<KeyboardEventArgs>(88, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, (Func<KeyboardEventArgs, Task>) (async x => await this.HandleKeydown(x, (Action) (async () => await this.GotoNextMonth(z))))));
          __builder.AddAttribute(89, "disabled", this.DisableNextMonthDate(z));
          __builder.AddAttribute(90, "b-7d73tkmg3g");
          __builder.AddContent(91, (object) z);
          __builder.CloseElement();
        }
      }
      __builder.CloseElement();
      __builder.CloseElement();
      __builder.CloseElement();
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    string? Id { get; set; } = "btn" + Guid.NewGuid().ToString().Replace("-", "");

    [Parameter]
    public string? Placeholder { get; set; } = "Pick a date";

    [Parameter]
    public bool AllowClear { get; set; }

    [Parameter]
    public bool Show { get; set; }

    [Parameter]
    public string? Format { get; set; }

    [Parameter]
    public string? Width { get; set; } = "100%";

    [Parameter]
    public DateTime? Date { get; set; }

    [Parameter]
    public DateTime? MinDate { get; set; }

    [Parameter]
    public DateTime? MaxDate { get; set; }

    [Parameter]
    public EventCallback<DateTime?> DateChanged { get; set; }

    protected override void OnInitialized()
    {
      this._date = this.Date ?? DateTime.Now;
      this.Init();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
      if (!firstRender)
        return;
      string scp = "function moveElements(n) { const p = document.activeElement.parentElement.childNodes;\r\n                    for (let i = 0; i < p.length; i++) { if (p[i] == document.activeElement) { p[i + n]?.focus(); break; } } }";
      await this.be.EvalVoid((object) scp);
      scp = (string) null;
    }

    private void Init()
    {
      this.startDay = (int) new DateTime(this._date.Year, this._date.Month, 1).DayOfWeek;
      this.maxDays = DateTime.DaysInMonth(this._date.Year, this._date.Month);
      DateTime dateTime = this._date.AddMonths(-1);
      int year = dateTime.Year;
      dateTime = this._date.AddMonths(-1);
      int month = dateTime.Month;
      this.lastMonthMaxDays = DateTime.DaysInMonth(year, month);
    }

    private async Task HandleChangeYear()
    {
      this._date = this._date.AddYears(-1);
      this.Init();
      this.sm.Publish((object) this, (object) "");
      await this.be.EvalVoid((object) "document.querySelector('.sbc-date-picker').parentElement.focus()");
    }

    private async Task HandlePrevMonth()
    {
      this._date = this._date.AddMonths(-1);
      this.Init();
      this.sm.Publish((object) this, (object) "");
      await this.be.EvalVoid((object) "document.querySelector('.sbc-date-picker').parentElement.focus()");
    }

    private async Task HandleNextMonth()
    {
      this._date = this._date.AddMonths(1);
      this.Init();
      this.sm.Publish((object) this, (object) "");
      await this.be.EvalVoid((object) "document.querySelector('.sbc-date-picker').parentElement.focus()");
    }

    private async Task HandlePrevYearButton()
    {
      this._date = this._date.AddYears(-1);
      this.Init();
      this.sm.Publish((object) this, (object) "");
      await this.be.EvalVoid((object) "document.querySelector('.sbc-date-picker').parentElement.focus()");
    }

    private async Task HandleNextYearButton()
    {
      this._date = this._date.AddYears(1);
      this.Init();
      this.sm.Publish((object) this, (object) "");
      await this.be.EvalVoid((object) "document.querySelector('.sbc-date-picker').parentElement.focus()");
    }

    private void HandlePrevYear()
    {
      this._date = this._date.AddYears(-1);
      this.Init();
    }

    private void HandleNextYear()
    {
      this._date = this._date.AddYears(1);
      this.Init();
    }

    private async Task GotoPrevMonth(int d)
    {
      this._date = this._date.AddMonths(-1);
      this.Init();
      this._selectedDate = new DateTime(this._date.Year, this._date.Month, d);
      await this.DateChanged.InvokeAsync(new DateTime?(this._selectedDate));
      await this.be.EvalVoid((object) "document.querySelector('.sbc-date-picker .selected')?.focus()");
    }

    private async Task SelectDate(int d)
    {
      this._selectedDate = new DateTime(this._date.Year, this._date.Month, d);
      await this.DateChanged.InvokeAsync(new DateTime?(this._selectedDate));
      await Task.Delay(10);
      ValueTask valueTask = this.be.EvalVoid((object) "document.querySelector('.sbc-date-picker .selected')?.focus()");
      await valueTask;
      valueTask = this.be.EvalVoid((object) "document.activeElement?.focus()");
      await valueTask;
    }

    private async Task GotoNextMonth(int d)
    {
      this._date = this._date.AddMonths(1);
      this.Init();
      this._selectedDate = new DateTime(this._date.Year, this._date.Month, d);
      await this.DateChanged.InvokeAsync(new DateTime?(this._selectedDate));
      await this.be.EvalVoid((object) "document.querySelector('.sbc-date-picker .selected')?.focus()");
    }

    private async Task HandleKeydown(KeyboardEventArgs args, Action? action = null)
    {
      this.pkd = false;
      if (args.Key == "Enter" || args.Key == "Tab")
      {
        this.pkd = true;
        await this.be.EvalVoid((object) "document.activeElement?.click()");
        await this.be.EvalVoid((object) ("document.querySelector('#" + this.Id + "')?.focus()"));
      }
      else if (args.Key == "Escape")
      {
        this.pkd = true;
        await this.be.EvalVoid((object) ("document.querySelector('#" + this.Id + "')?.focus()"));
      }
      else if (args.Key == "ArrowLeft")
      {
        this.pkd = true;
        await this.be.EvalVoid((object) "document.activeElement?.previousElementSibling?.focus()");
        if (action == null)
          return;
        action();
      }
      else if (args.Key == "ArrowRight")
      {
        this.pkd = true;
        await this.be.EvalVoid((object) "document.activeElement?.nextElementSibling?.focus()");
        if (action == null)
          return;
        action();
      }
      else if (args.Key == "ArrowUp")
      {
        this.pkd = true;
        await this.be.JSVoid("moveElements", (object) -7);
        if (action == null)
          return;
        action();
      }
      else if (args.Key == "ArrowDown")
      {
        this.pkd = true;
        await this.be.JSVoid("moveElements", (object) 7);
        if (action == null)
          return;
        action();
      }
      else if (args.Key == "PageUp")
      {
        this.pkd = true;
        await this.HandlePrevMonth();
        if (action == null)
          return;
        action();
      }
      else if (args.Key == "PageDown")
      {
        this.pkd = true;
        await this.HandleNextMonth();
        if (action == null)
          return;
        action();
      }
      else if (args.Key == "Home")
      {
        this.pkd = true;
        this.HandlePrevYear();
        if (action == null)
          return;
        action();
      }
      else
      {
        if (!(args.Key == "End"))
          return;
        this.pkd = true;
        this.HandleNextYear();
        if (action != null)
          action();
      }
    }

    private async Task HandleClearDate(KeyboardEventArgs? args = null)
    {
      if (args != null && !(args.Key == "Enter") && !(args.Key == " "))
        return;
      this.Date = new DateTime?();
      await this.be.EvalVoid((object) ("event.preventDefault(); document.querySelector('#dp" + this.Id + "').classList.remove('show');"));
      await this.DateChanged.InvokeAsync(this.Date);
    }

    private bool DisablePrevMonthDate(int day)
    {
      DateTime dateTime1=new DateTime();
      ref DateTime local1 = ref dateTime1;
      DateTime dateTime2 = this._date.AddMonths(-1);
      int year = dateTime2.Year;
      dateTime2 = this._date.AddMonths(-1);
      int month = dateTime2.Month;
      int day1 = day;
      local1 = new DateTime(year, month, day1);
      DateTime date1 = dateTime1.Date;
      DateTime? nullable1 = this.MinDate;
      ref DateTime? local2 = ref nullable1;
      DateTime valueOrDefault;
      DateTime? nullable2;
      if (!local2.HasValue)
      {
        nullable2 = new DateTime?();
      }
      else
      {
        valueOrDefault = local2.GetValueOrDefault();
        nullable2 = new DateTime?(valueOrDefault.Date);
      }
      DateTime? nullable3 = nullable2;
      int num;
      if ((nullable3.HasValue ? (date1 < nullable3.GetValueOrDefault() ? 1 : 0) : 0) == 0)
      {
        DateTime date2 = dateTime1.Date;
        nullable1 = this.MaxDate;
        ref DateTime? local3 = ref nullable1;
        DateTime? nullable4;
        if (!local3.HasValue)
        {
          nullable4 = new DateTime?();
        }
        else
        {
          valueOrDefault = local3.GetValueOrDefault();
          nullable4 = new DateTime?(valueOrDefault.Date);
        }
        nullable3 = nullable4;
        num = nullable3.HasValue ? (date2 > nullable3.GetValueOrDefault() ? 1 : 0) : 0;
      }
      else
        num = 1;
      return num != 0;
    }

    private bool DisableCurrentMonthDate(int day)
    {
      DateTime dateTime = new DateTime(this._date.Year, this._date.Month, day);
      DateTime date1 = dateTime.Date;
      DateTime? nullable1 = this.MinDate;
      ref DateTime? local1 = ref nullable1;
      DateTime valueOrDefault;
      DateTime? nullable2;
      if (!local1.HasValue)
      {
        nullable2 = new DateTime?();
      }
      else
      {
        valueOrDefault = local1.GetValueOrDefault();
        nullable2 = new DateTime?(valueOrDefault.Date);
      }
      DateTime? nullable3 = nullable2;
      int num;
      if ((nullable3.HasValue ? (date1 < nullable3.GetValueOrDefault() ? 1 : 0) : 0) == 0)
      {
        DateTime date2 = dateTime.Date;
        nullable1 = this.MaxDate;
        ref DateTime? local2 = ref nullable1;
        DateTime? nullable4;
        if (!local2.HasValue)
        {
          nullable4 = new DateTime?();
        }
        else
        {
          valueOrDefault = local2.GetValueOrDefault();
          nullable4 = new DateTime?(valueOrDefault.Date);
        }
        nullable3 = nullable4;
        num = nullable3.HasValue ? (date2 > nullable3.GetValueOrDefault() ? 1 : 0) : 0;
      }
      else
        num = 1;
      return num != 0;
    }

    private bool DisableNextMonthDate(int day)
    {
      DateTime dateTime1=new DateTime();
      ref DateTime local1 = ref dateTime1;
      DateTime dateTime2 = this._date.AddMonths(1);
      int year = dateTime2.Year;
      dateTime2 = this._date.AddMonths(1);
      int month = dateTime2.Month;
      int day1 = day;
      local1 = new DateTime(year, month, day1);
      DateTime date1 = dateTime1.Date;
      DateTime? nullable1 = this.MinDate;
      ref DateTime? local2 = ref nullable1;
      DateTime valueOrDefault;
      DateTime? nullable2;
      if (!local2.HasValue)
      {
        nullable2 = new DateTime?();
      }
      else
      {
        valueOrDefault = local2.GetValueOrDefault();
        nullable2 = new DateTime?(valueOrDefault.Date);
      }
      DateTime? nullable3 = nullable2;
      int num;
      if ((nullable3.HasValue ? (date1 < nullable3.GetValueOrDefault() ? 1 : 0) : 0) == 0)
      {
        DateTime date2 = dateTime1.Date;
        nullable1 = this.MaxDate;
        ref DateTime? local3 = ref nullable1;
        DateTime? nullable4;
        if (!local3.HasValue)
        {
          nullable4 = new DateTime?();
        }
        else
        {
          valueOrDefault = local3.GetValueOrDefault();
          nullable4 = new DateTime?(valueOrDefault.Date);
        }
        nullable3 = nullable4;
        num = nullable3.HasValue ? (date2 > nullable3.GetValueOrDefault() ? 1 : 0) : 0;
      }
      else
        num = 1;
      return num != 0;
    }

    private DateTime? IsValidDate(int year, int month, int day)
    {
      try
      {
        return new DateTime?(new DateTime(year, month, day));
      }
      catch
      {
        return new DateTime?();
      }
    }

    [Inject]
    private BrowserExtensions be { get; set; } = (BrowserExtensions) null;

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
