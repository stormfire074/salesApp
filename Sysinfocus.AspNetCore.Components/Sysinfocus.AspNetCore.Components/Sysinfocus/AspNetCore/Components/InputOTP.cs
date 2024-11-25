// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.InputOTP
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class InputOTP : ComponentBase
  {
    private string? i1;
    private string? i2;
    private string? i3;
    private string? i4;
    private string? i5;
    private string? i6;
    private bool pkd;
    private bool pd;
    private string? copiedNumber;
    private string? enteredNumber;
    private string _id;

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-input-otp");
      __builder.AddAttribute(2, "id", this._id);
      __builder.AddAttribute(3, "oncontextmenu", "return false");
      __builder.AddAttribute(4, "b-xrw4bh561a");
      if (this.GroupBy == 2)
      {
        __builder.OpenElement(5, "input");
        __builder.AddAttribute(6, "autofocus");
        __builder.AddAttribute(7, "type", "number");
        __builder.AddAttribute(8, "placeholder", this.Placeholder);
        __builder.AddAttribute<KeyboardEventArgs>(9, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Action<KeyboardEventArgs>(this.HandleKeyDown)));
        __builder.AddEventPreventDefaultAttribute(10, "onkeydown", this.pkd);
        __builder.AddAttribute<KeyboardEventArgs>(11, "onkeyup", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Func<KeyboardEventArgs, Task>(this.HandleInput)));
        __builder.AddEventPreventDefaultAttribute(12, "onkeyup", this.pd);
        __builder.AddAttribute(13, "value", BindConverter.FormatValue(this.i1, CultureInfo.InvariantCulture));
        __builder.AddAttribute<ChangeEventArgs>(14, "oninput", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => this.i1 = __value), this.i1, CultureInfo.InvariantCulture));
        __builder.SetUpdatesAttributeName("value");
        __builder.AddAttribute(15, "b-xrw4bh561a");
        __builder.CloseElement();
        __builder.AddMarkupContent(16, "\r\n        ");
        __builder.OpenElement(17, "input");
        __builder.AddAttribute(18, "type", "number");
        __builder.AddAttribute(19, "placeholder", this.Placeholder);
        __builder.AddAttribute<KeyboardEventArgs>(20, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Action<KeyboardEventArgs>(this.HandleKeyDown)));
        __builder.AddEventPreventDefaultAttribute(21, "onkeydown", this.pkd);
        __builder.AddAttribute<KeyboardEventArgs>(22, "onkeyup", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Func<KeyboardEventArgs, Task>(this.HandleInput)));
        __builder.AddEventPreventDefaultAttribute(23, "onkeyup", this.pd);
        __builder.AddAttribute(24, "value", BindConverter.FormatValue(this.i2, CultureInfo.InvariantCulture));
        __builder.AddAttribute<ChangeEventArgs>(25, "oninput", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => this.i2 = __value), this.i2, CultureInfo.InvariantCulture));
        __builder.SetUpdatesAttributeName("value");
        __builder.AddAttribute(26, "b-xrw4bh561a");
        __builder.CloseElement();
        __builder.AddMarkupContent(27, "\r\n        ");
        __builder.AddMarkupContent(28, "<span b-xrw4bh561a>-</span>\r\n        ");
        __builder.OpenElement(29, "input");
        __builder.AddAttribute(30, "type", "number");
        __builder.AddAttribute(31, "placeholder", this.Placeholder);
        __builder.AddAttribute<KeyboardEventArgs>(32, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Action<KeyboardEventArgs>(this.HandleKeyDown)));
        __builder.AddEventPreventDefaultAttribute(33, "onkeydown", this.pkd);
        __builder.AddAttribute<KeyboardEventArgs>(34, "onkeyup", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Func<KeyboardEventArgs, Task>(this.HandleInput)));
        __builder.AddEventPreventDefaultAttribute(35, "onkeyup", this.pd);
        __builder.AddAttribute(36, "value", BindConverter.FormatValue(this.i3, CultureInfo.InvariantCulture));
        __builder.AddAttribute<ChangeEventArgs>(37, "oninput", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => this.i3 = __value), this.i3, CultureInfo.InvariantCulture));
        __builder.SetUpdatesAttributeName("value");
        __builder.AddAttribute(38, "b-xrw4bh561a");
        __builder.CloseElement();
        __builder.AddMarkupContent(39, "\r\n        ");
        __builder.OpenElement(40, "input");
        __builder.AddAttribute(41, "type", "number");
        __builder.AddAttribute(42, "placeholder", this.Placeholder);
        __builder.AddAttribute<KeyboardEventArgs>(43, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Action<KeyboardEventArgs>(this.HandleKeyDown)));
        __builder.AddEventPreventDefaultAttribute(44, "onkeydown", this.pkd);
        __builder.AddAttribute<KeyboardEventArgs>(45, "onkeyup", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Func<KeyboardEventArgs, Task>(this.HandleInput)));
        __builder.AddEventPreventDefaultAttribute(46, "onkeyup", this.pd);
        __builder.AddAttribute(47, "value", BindConverter.FormatValue(this.i4, CultureInfo.InvariantCulture));
        __builder.AddAttribute<ChangeEventArgs>(48, "oninput", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => this.i4 = __value), this.i4, CultureInfo.InvariantCulture));
        __builder.SetUpdatesAttributeName("value");
        __builder.AddAttribute(49, "b-xrw4bh561a");
        __builder.CloseElement();
        __builder.AddMarkupContent(50, "\r\n        ");
        __builder.AddMarkupContent(51, "<span b-xrw4bh561a>-</span>\r\n        ");
        __builder.OpenElement(52, "input");
        __builder.AddAttribute(53, "type", "number");
        __builder.AddAttribute(54, "placeholder", this.Placeholder);
        __builder.AddAttribute<KeyboardEventArgs>(55, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Action<KeyboardEventArgs>(this.HandleKeyDown)));
        __builder.AddEventPreventDefaultAttribute(56, "onkeydown", this.pkd);
        __builder.AddAttribute<KeyboardEventArgs>(57, "onkeyup", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Func<KeyboardEventArgs, Task>(this.HandleInput)));
        __builder.AddEventPreventDefaultAttribute(58, "onkeyup", this.pd);
        __builder.AddAttribute(59, "value", BindConverter.FormatValue(this.i5, CultureInfo.InvariantCulture));
        __builder.AddAttribute<ChangeEventArgs>(60, "oninput", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => this.i5 = __value), this.i5, CultureInfo.InvariantCulture));
        __builder.SetUpdatesAttributeName("value");
        __builder.AddAttribute(61, "b-xrw4bh561a");
        __builder.CloseElement();
        __builder.AddMarkupContent(62, "\r\n        ");
        __builder.OpenElement(63, "input");
        __builder.AddAttribute(64, "type", "number");
        __builder.AddAttribute(65, "placeholder", this.Placeholder);
        __builder.AddAttribute<KeyboardEventArgs>(66, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Action<KeyboardEventArgs>(this.HandleKeyDown)));
        __builder.AddEventPreventDefaultAttribute(67, "onkeydown", this.pkd);
        __builder.AddAttribute<KeyboardEventArgs>(68, "onkeyup", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Func<KeyboardEventArgs, Task>(this.HandleInput)));
        __builder.AddEventPreventDefaultAttribute(69, "onkeyup", this.pd);
        __builder.AddAttribute(70, "value", BindConverter.FormatValue(this.i6, CultureInfo.InvariantCulture));
        __builder.AddAttribute<ChangeEventArgs>(71, "oninput", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => this.i6 = __value), this.i6, CultureInfo.InvariantCulture));
        __builder.SetUpdatesAttributeName("value");
        __builder.AddAttribute(72, "b-xrw4bh561a");
        __builder.CloseElement();
      }
      else if (this.GroupBy == 3)
      {
        __builder.OpenElement(73, "input");
        __builder.AddAttribute(74, "autofocus");
        __builder.AddAttribute(75, "type", "number");
        __builder.AddAttribute(76, "placeholder", this.Placeholder);
        __builder.AddAttribute<KeyboardEventArgs>(77, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Action<KeyboardEventArgs>(this.HandleKeyDown)));
        __builder.AddEventPreventDefaultAttribute(78, "onkeydown", this.pkd);
        __builder.AddAttribute<KeyboardEventArgs>(79, "onkeyup", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Func<KeyboardEventArgs, Task>(this.HandleInput)));
        __builder.AddEventPreventDefaultAttribute(80, "onkeyup", this.pd);
        __builder.AddAttribute(81, "value", BindConverter.FormatValue(this.i1, CultureInfo.InvariantCulture));
        __builder.AddAttribute<ChangeEventArgs>(82, "oninput", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => this.i1 = __value), this.i1, CultureInfo.InvariantCulture));
        __builder.SetUpdatesAttributeName("value");
        __builder.AddAttribute(83, "b-xrw4bh561a");
        __builder.CloseElement();
        __builder.AddMarkupContent(84, "\r\n        ");
        __builder.OpenElement(85, "input");
        __builder.AddAttribute(86, "type", "number");
        __builder.AddAttribute(87, "placeholder", this.Placeholder);
        __builder.AddAttribute<KeyboardEventArgs>(88, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Action<KeyboardEventArgs>(this.HandleKeyDown)));
        __builder.AddEventPreventDefaultAttribute(89, "onkeydown", this.pkd);
        __builder.AddAttribute<KeyboardEventArgs>(90, "onkeyup", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Func<KeyboardEventArgs, Task>(this.HandleInput)));
        __builder.AddEventPreventDefaultAttribute(91, "onkeyup", this.pd);
        __builder.AddAttribute(92, "value", BindConverter.FormatValue(this.i2, CultureInfo.InvariantCulture));
        __builder.AddAttribute<ChangeEventArgs>(93, "oninput", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => this.i2 = __value), this.i2, CultureInfo.InvariantCulture));
        __builder.SetUpdatesAttributeName("value");
        __builder.AddAttribute(94, "b-xrw4bh561a");
        __builder.CloseElement();
        __builder.AddMarkupContent(95, "\r\n        ");
        __builder.OpenElement(96, "input");
        __builder.AddAttribute(97, "type", "number");
        __builder.AddAttribute(98, "placeholder", this.Placeholder);
        __builder.AddAttribute<KeyboardEventArgs>(99, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Action<KeyboardEventArgs>(this.HandleKeyDown)));
        __builder.AddEventPreventDefaultAttribute(100, "onkeydown", this.pkd);
        __builder.AddAttribute<KeyboardEventArgs>(101, "onkeyup", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Func<KeyboardEventArgs, Task>(this.HandleInput)));
        __builder.AddEventPreventDefaultAttribute(102, "onkeyup", this.pd);
        __builder.AddAttribute(103, "value", BindConverter.FormatValue(this.i3, CultureInfo.InvariantCulture));
        __builder.AddAttribute<ChangeEventArgs>(104, "oninput", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => this.i3 = __value), this.i3, CultureInfo.InvariantCulture));
        __builder.SetUpdatesAttributeName("value");
        __builder.AddAttribute(105, "b-xrw4bh561a");
        __builder.CloseElement();
        __builder.AddMarkupContent(106, "\r\n        ");
        __builder.AddMarkupContent(107, "<span b-xrw4bh561a>-</span>\r\n        ");
        __builder.OpenElement(108, "input");
        __builder.AddAttribute(109, "type", "number");
        __builder.AddAttribute(110, "placeholder", this.Placeholder);
        __builder.AddAttribute<KeyboardEventArgs>(111, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Action<KeyboardEventArgs>(this.HandleKeyDown)));
        __builder.AddEventPreventDefaultAttribute(112, "onkeydown", this.pkd);
        __builder.AddAttribute<KeyboardEventArgs>(113, "onkeyup", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Func<KeyboardEventArgs, Task>(this.HandleInput)));
        __builder.AddEventPreventDefaultAttribute(114, "onkeyup", this.pd);
        __builder.AddAttribute(115, "value", BindConverter.FormatValue(this.i4, CultureInfo.InvariantCulture));
        __builder.AddAttribute<ChangeEventArgs>(116, "oninput", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => this.i4 = __value), this.i4, CultureInfo.InvariantCulture));
        __builder.SetUpdatesAttributeName("value");
        __builder.AddAttribute(117, "b-xrw4bh561a");
        __builder.CloseElement();
        __builder.AddMarkupContent(118, "\r\n        ");
        __builder.OpenElement(119, "input");
        __builder.AddAttribute(120, "type", "number");
        __builder.AddAttribute(121, "placeholder", this.Placeholder);
        __builder.AddAttribute<KeyboardEventArgs>(122, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Action<KeyboardEventArgs>(this.HandleKeyDown)));
        __builder.AddEventPreventDefaultAttribute(123, "onkeydown", this.pkd);
        __builder.AddAttribute<KeyboardEventArgs>(124, "onkeyup", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Func<KeyboardEventArgs, Task>(this.HandleInput)));
        __builder.AddEventPreventDefaultAttribute(125, "onkeyup", this.pd);
        __builder.AddAttribute(126, "value", BindConverter.FormatValue(this.i5, CultureInfo.InvariantCulture));
        __builder.AddAttribute<ChangeEventArgs>((int) sbyte.MaxValue, "oninput", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => this.i5 = __value), this.i5, CultureInfo.InvariantCulture));
        __builder.SetUpdatesAttributeName("value");
        __builder.AddAttribute(128, "b-xrw4bh561a");
        __builder.CloseElement();
        __builder.AddMarkupContent(129, "\r\n        ");
        __builder.OpenElement(130, "input");
        __builder.AddAttribute(131, "type", "number");
        __builder.AddAttribute(132, "placeholder", this.Placeholder);
        __builder.AddAttribute<KeyboardEventArgs>(133, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Action<KeyboardEventArgs>(this.HandleKeyDown)));
        __builder.AddEventPreventDefaultAttribute(134, "onkeydown", this.pkd);
        __builder.AddAttribute<KeyboardEventArgs>(135, "onkeyup", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Func<KeyboardEventArgs, Task>(this.HandleInput)));
        __builder.AddEventPreventDefaultAttribute(136, "onkeyup", this.pd);
        __builder.AddAttribute(137, "value", BindConverter.FormatValue(this.i6, CultureInfo.InvariantCulture));
        __builder.AddAttribute<ChangeEventArgs>(138, "oninput", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => this.i6 = __value), this.i6, CultureInfo.InvariantCulture));
        __builder.SetUpdatesAttributeName("value");
        __builder.AddAttribute(139, "b-xrw4bh561a");
        __builder.CloseElement();
      }
      else
      {
        __builder.OpenElement(140, "input");
        __builder.AddAttribute(141, "autofocus");
        __builder.AddAttribute(142, "type", "number");
        __builder.AddAttribute(143, "placeholder", this.Placeholder);
        __builder.AddAttribute<KeyboardEventArgs>(144, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Action<KeyboardEventArgs>(this.HandleKeyDown)));
        __builder.AddEventPreventDefaultAttribute(145, "onkeydown", this.pkd);
        __builder.AddAttribute<KeyboardEventArgs>(146, "onkeyup", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Func<KeyboardEventArgs, Task>(this.HandleInput)));
        __builder.AddEventPreventDefaultAttribute(147, "onkeyup", this.pd);
        __builder.AddAttribute(148, "value", BindConverter.FormatValue(this.i1, CultureInfo.InvariantCulture));
        __builder.AddAttribute<ChangeEventArgs>(149, "oninput", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => this.i1 = __value), this.i1, CultureInfo.InvariantCulture));
        __builder.SetUpdatesAttributeName("value");
        __builder.AddAttribute(150, "b-xrw4bh561a");
        __builder.CloseElement();
        __builder.AddMarkupContent(151, "\r\n        ");
        __builder.OpenElement(152, "input");
        __builder.AddAttribute(153, "type", "number");
        __builder.AddAttribute(154, "placeholder", this.Placeholder);
        __builder.AddAttribute<KeyboardEventArgs>(155, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Action<KeyboardEventArgs>(this.HandleKeyDown)));
        __builder.AddEventPreventDefaultAttribute(156, "onkeydown", this.pkd);
        __builder.AddAttribute<KeyboardEventArgs>(157, "onkeyup", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Func<KeyboardEventArgs, Task>(this.HandleInput)));
        __builder.AddEventPreventDefaultAttribute(158, "onkeyup", this.pd);
        __builder.AddAttribute(159, "value", BindConverter.FormatValue(this.i2, CultureInfo.InvariantCulture));
        __builder.AddAttribute<ChangeEventArgs>(160, "oninput", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => this.i2 = __value), this.i2, CultureInfo.InvariantCulture));
        __builder.SetUpdatesAttributeName("value");
        __builder.AddAttribute(161, "b-xrw4bh561a");
        __builder.CloseElement();
        __builder.AddMarkupContent(162, "\r\n        ");
        __builder.OpenElement(163, "input");
        __builder.AddAttribute(164, "type", "number");
        __builder.AddAttribute(165, "placeholder", this.Placeholder);
        __builder.AddAttribute<KeyboardEventArgs>(166, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Action<KeyboardEventArgs>(this.HandleKeyDown)));
        __builder.AddEventPreventDefaultAttribute(167, "onkeydown", this.pkd);
        __builder.AddAttribute<KeyboardEventArgs>(168, "onkeyup", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Func<KeyboardEventArgs, Task>(this.HandleInput)));
        __builder.AddEventPreventDefaultAttribute(169, "onkeyup", this.pd);
        __builder.AddAttribute(170, "value", BindConverter.FormatValue(this.i3, CultureInfo.InvariantCulture));
        __builder.AddAttribute<ChangeEventArgs>(171, "oninput", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => this.i3 = __value), this.i3, CultureInfo.InvariantCulture));
        __builder.SetUpdatesAttributeName("value");
        __builder.AddAttribute(172, "b-xrw4bh561a");
        __builder.CloseElement();
        __builder.AddMarkupContent(173, "\r\n        ");
        __builder.OpenElement(174, "input");
        __builder.AddAttribute(175, "type", "number");
        __builder.AddAttribute(176, "placeholder", this.Placeholder);
        __builder.AddAttribute<KeyboardEventArgs>(177, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Action<KeyboardEventArgs>(this.HandleKeyDown)));
        __builder.AddEventPreventDefaultAttribute(178, "onkeydown", this.pkd);
        __builder.AddAttribute<KeyboardEventArgs>(179, "onkeyup", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Func<KeyboardEventArgs, Task>(this.HandleInput)));
        __builder.AddEventPreventDefaultAttribute(180, "onkeyup", this.pd);
        __builder.AddAttribute(181, "value", BindConverter.FormatValue(this.i4, CultureInfo.InvariantCulture));
        __builder.AddAttribute<ChangeEventArgs>(182, "oninput", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => this.i4 = __value), this.i4, CultureInfo.InvariantCulture));
        __builder.SetUpdatesAttributeName("value");
        __builder.AddAttribute(183, "b-xrw4bh561a");
        __builder.CloseElement();
        __builder.AddMarkupContent(184, "\r\n        ");
        __builder.OpenElement(185, "input");
        __builder.AddAttribute(186, "type", "number");
        __builder.AddAttribute(187, "placeholder", this.Placeholder);
        __builder.AddAttribute<KeyboardEventArgs>(188, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Action<KeyboardEventArgs>(this.HandleKeyDown)));
        __builder.AddEventPreventDefaultAttribute(189, "onkeydown", this.pkd);
        __builder.AddAttribute<KeyboardEventArgs>(190, "onkeyup", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Func<KeyboardEventArgs, Task>(this.HandleInput)));
        __builder.AddEventPreventDefaultAttribute(191, "onkeyup", this.pd);
        __builder.AddAttribute(192, "value", BindConverter.FormatValue(this.i5, CultureInfo.InvariantCulture));
        __builder.AddAttribute<ChangeEventArgs>(193, "oninput", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => this.i5 = __value), this.i5, CultureInfo.InvariantCulture));
        __builder.SetUpdatesAttributeName("value");
        __builder.AddAttribute(194, "b-xrw4bh561a");
        __builder.CloseElement();
        __builder.AddMarkupContent(195, "\r\n        ");
        __builder.OpenElement(196, "input");
        __builder.AddAttribute(197, "type", "number");
        __builder.AddAttribute(198, "placeholder", this.Placeholder);
        __builder.AddAttribute<KeyboardEventArgs>(199, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Action<KeyboardEventArgs>(this.HandleKeyDown)));
        __builder.AddEventPreventDefaultAttribute(200, "onkeydown", this.pkd);
        __builder.AddAttribute<KeyboardEventArgs>(201, "onkeyup", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Func<KeyboardEventArgs, Task>(this.HandleInput)));
        __builder.AddEventPreventDefaultAttribute(202, "onkeyup", this.pd);
        __builder.AddAttribute(203, "value", BindConverter.FormatValue(this.i6, CultureInfo.InvariantCulture));
        __builder.AddAttribute<ChangeEventArgs>(204, "oninput", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => this.i6 = __value), this.i6, CultureInfo.InvariantCulture));
        __builder.SetUpdatesAttributeName("value");
        __builder.AddAttribute(205, "b-xrw4bh561a");
        __builder.CloseElement();
      }
      __builder.CloseElement();
    }

    [Parameter]
    public int GroupBy { get; set; }

    [Parameter]
    public EventCallback<
    #nullable enable
    string> OnComplete { get; set; }

    [Parameter]
    public string? Placeholder { get; set; }

    private void HandleKeyDown(KeyboardEventArgs args)
    {
      this.pkd = true;
      if (!(args.Key == "Tab") && !(args.Key == "Backspace") && !"1234567890".Contains(args.Key))
        return;
      this.pkd = false;
    }

    private async Task HandleInput(KeyboardEventArgs args)
    {
      this.pd = false;
      string numbers = "1234567890";
      if (args.CtrlKey)
      {
        if (!(args.Key.ToUpper() == "V"))
        {
          numbers = (string) null;
        }
        else
        {
          this.pd = true;
          string str = await this.jsr.InvokeAsync<string>("navigator.clipboard.readText");
          this.copiedNumber = str;
          str = (string) null;
          if (!this.isValidOTP(this.copiedNumber))
          {
            numbers = (string) null;
          }
          else
          {
            await this.OnComplete.InvokeAsync(this.copiedNumber);
            numbers = (string) null;
          }
        }
      }
      else if (args.Key == "Tab")
        numbers = (string) null;
      else if (numbers.Contains(args.Key))
      {
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 6);
        interpolatedStringHandler.AppendFormatted(this.i1);
        interpolatedStringHandler.AppendFormatted(this.i2);
        interpolatedStringHandler.AppendFormatted(this.i3);
        interpolatedStringHandler.AppendFormatted(this.i4);
        interpolatedStringHandler.AppendFormatted(this.i5);
        interpolatedStringHandler.AppendFormatted(this.i6);
        this.enteredNumber = interpolatedStringHandler.ToStringAndClear();
        if (this.enteredNumber.Length > 6)
          this.enteredNumber = this.enteredNumber.Substring(0, 6);
        if (this.isValidOTP(this.enteredNumber))
        {
          await this.OnComplete.InvokeAsync(this.enteredNumber);
          numbers = (string) null;
        }
        else
        {
          IJSRuntime jsr = this.jsr;
          object[] objArray = new object[1];
          interpolatedStringHandler = new DefaultInterpolatedStringHandler(47, 2);
          interpolatedStringHandler.AppendLiteral("document.querySelectorAll('#");
          interpolatedStringHandler.AppendFormatted(this._id);
          interpolatedStringHandler.AppendLiteral(" input')[");
          interpolatedStringHandler.AppendFormatted<int>(this.enteredNumber.Length);
          interpolatedStringHandler.AppendLiteral("]?.focus()");
          objArray[0] = (object) interpolatedStringHandler.ToStringAndClear();
          await jsr.InvokeVoidAsync("eval", objArray);
          numbers = (string) null;
        }
      }
      else if (args.Key == "Backspace")
      {
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 6);
        interpolatedStringHandler.AppendFormatted(this.i1);
        interpolatedStringHandler.AppendFormatted(this.i2);
        interpolatedStringHandler.AppendFormatted(this.i3);
        interpolatedStringHandler.AppendFormatted(this.i4);
        interpolatedStringHandler.AppendFormatted(this.i5);
        interpolatedStringHandler.AppendFormatted(this.i6);
        this.enteredNumber = interpolatedStringHandler.ToStringAndClear();
        IJSRuntime jsr = this.jsr;
        object[] objArray = new object[1];
        interpolatedStringHandler = new DefaultInterpolatedStringHandler(47, 2);
        interpolatedStringHandler.AppendLiteral("document.querySelectorAll('#");
        interpolatedStringHandler.AppendFormatted(this._id);
        interpolatedStringHandler.AppendLiteral(" input')[");
        interpolatedStringHandler.AppendFormatted<int>(this.enteredNumber.Length - 1);
        interpolatedStringHandler.AppendLiteral("]?.focus()");
        objArray[0] = (object) interpolatedStringHandler.ToStringAndClear();
        await jsr.InvokeVoidAsync("eval", objArray);
        numbers = (string) null;
      }
      else
      {
        this.pd = true;
        numbers = (string) null;
      }
    }

    private bool isValidOTP(string otp)
    {
      if (otp.Length != 6)
        return false;
      foreach (char ch in otp)
      {
        if (!"0123456789".Contains(ch))
          return false;
      }
      this.i1 = otp[0].ToString();
      char ch1 = otp[1];
      this.i2 = ch1.ToString();
      ch1 = otp[2];
      this.i3 = ch1.ToString();
      ch1 = otp[3];
      this.i4 = ch1.ToString();
      ch1 = otp[4];
      this.i5 = ch1.ToString();
      ch1 = otp[5];
      this.i6 = ch1.ToString();
      return true;
    }

    [Inject]
    private IJSRuntime jsr { get; set; }

    [Inject]
    private StateManager sm { get; set; }

    public InputOTP()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
      interpolatedStringHandler.AppendLiteral("otp-");
      interpolatedStringHandler.AppendFormatted<Guid>(Guid.NewGuid());
      this._id = interpolatedStringHandler.ToStringAndClear();
      // ISSUE: reference to a compiler-generated field
      this.jsr = (IJSRuntime) null;
      // ISSUE: reference to a compiler-generated field
      this.sm = (StateManager) null;
      // ISSUE: explicit constructor call
      base.OnInitialized();
    }
  }
}
