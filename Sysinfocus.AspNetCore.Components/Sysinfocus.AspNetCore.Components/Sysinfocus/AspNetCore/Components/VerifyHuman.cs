// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.VerifyHuman
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using __Blazor.Sysinfocus.AspNetCore.Components.VerifyHuman;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.CompilerServices;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class VerifyHuman : ComponentBase
  {
    private int verificationStage = 0;
    private List<string> items = Enumerable.Range(0, 10).Select<int, string>((Func<int, string>) (a => a.ToString())).ToList<string>();
    private List<string> newItems = new List<string>();
    private string toMatch = Sysinfocus.AspNetCore.Components.VerifyHuman.GetRandomNumbers();
    private bool shouldRegister;
    private int retries = 1;
    private bool shouldRender = true;

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.AddMarkupContent(0, "<style>\r\n    .item {\r\n        display: flex;\r\n        align-items: center;\r\n        justify-content: center;\r\n        border-radius: 9999px;\r\n        background-color: var(--btn-secondary-bg);\r\n        font-weight: bold;\r\n        font-size: 18px;\r\n        width: 40px;\r\n        height: 40px;\r\n        cursor: grab;\r\n        transition: 300ms ease-in-out;\r\n    }\r\n\r\n        .item:hover {\r\n            background-color: var(--primary-border);\r\n        }\r\n</style>\r\n\r\n");
      __builder.OpenElement(1, "div");
      __builder.AddAttribute(2, "class", "flex jcc aic");
      __builder.OpenComponent<Card>(3);
      __builder.AddComponentParameter(4, "Style", (object) "max-width: 320px");
      __builder.AddAttribute(5, "CardContent", (RenderFragment) (__builder2 =>
      {
        if (this.verificationStage == 0)
        {
          __builder2.OpenElement(6, "div");
          __builder2.AddAttribute(7, "class", "flex-col jcc aic");
          __builder2.AddAttribute(8, "style", "padding: 0.5rem");
          __builder2.AddMarkupContent(9, "<div class=\"flex-col g4 aic\"><h4>Verify if Human?</h4>\r\n                        <small class=\"muted ta-center\">Drag the number and drop at the matching destination</small></div>\r\n                    ");
          TypeInference.CreateSortable_0<string>(__builder2, 10, 11, this.items.OrderBy<string, string>((Func<string, string>) (a => a)).ToList<string>(), 12, "first", 13, "second", 14, "item-drag", 15, this.shouldRegister, 16, 0, 17, "flex g8 wrap jcse", 18, "270px", 19, "border: none", 20, EventCallback.Factory.Create<(int, int, string, string)>((object) this, new Action<(int, int, string, string)>(this.HandleInsert)), 21, (RenderFragment<string>) (context => (RenderFragment) (__builder3 =>
          {
            __builder3.OpenElement(22, "div");
            __builder3.AddAttribute(23, "class", "item");
            __builder3.AddContent(24, context);
            __builder3.CloseElement();
          })));
          __builder2.AddMarkupContent(25, "\r\n                    ");
          __builder2.AddMarkupContent(26, "<small class=\"muted\">Match numbers below</small>\r\n                    ");
          __builder2.OpenElement(27, "p");
          __builder2.AddAttribute(28, "style", "letter-spacing: 0.5rem; font-weight: bold; line-height: 1; color: crimson");
          __builder2.AddContent(29, this.toMatch);
          __builder2.CloseElement();
          __builder2.AddMarkupContent(30, "\r\n                    ");
          __builder2.OpenElement(31, "div");
          __builder2.AddAttribute(32, "class", "flex jcc aic");
          __builder2.AddAttribute(33, "style", "position:relative");
          if (this.newItems.Count == 0)
            __builder2.AddMarkupContent(34, "<small style=\"position:absolute; opacity: 0.35\">Drop matching numbers here ...</small>");
          TypeInference.CreateSortable_1<string>(__builder2, 35, 36, this.newItems, 37, "first", 38, "first", 39, "item-drag", 40, false, 41, "flex g8 jcc", 42, "360px", 43, "62px", 44, EventCallback.Factory.Create<(int, int, string, string)>((object) this, new Action<(int, int, string, string)>(this.HandleInsert)), 45, (RenderFragment<string>) (context => (RenderFragment) (__builder3 =>
          {
            __builder3.OpenElement(46, "div");
            __builder3.AddAttribute(47, "class", "item");
            __builder3.AddContent(48, context);
            __builder3.CloseElement();
          })));
          __builder2.CloseElement();
          __builder2.AddMarkupContent(49, "\r\n                    ");
          __builder2.OpenElement(50, "div");
          __builder2.AddAttribute(51, "class", "flex g8");
          __builder2.OpenComponent<Button>(52);
          __builder2.AddComponentParameter(53, "Icon", (object) "check");
          __builder2.AddComponentParameter(54, "Text", (object) "I'm human, verify");
          __builder2.AddComponentParameter(55, "Type", (object) RuntimeHelpers.TypeCheck<ButtonType>(this.newItems.Count != 6 ? ButtonType.Secondary : ButtonType.Primary));
          __builder2.AddComponentParameter(56, "OnClick", (object) RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, new Func<Task>(this.HandleVerification))));
          __builder2.AddComponentParameter(57, "Disabled", (object) RuntimeHelpers.TypeCheck<bool>(this.newItems.Count > 6));
          __builder2.CloseComponent();
          __builder2.AddMarkupContent(58, "\r\n                        ");
          __builder2.OpenComponent<Button>(59);
          __builder2.AddComponentParameter(60, "Icon", (object) "refresh");
          __builder2.AddComponentParameter(61, "Text", (object) "Reset");
          __builder2.AddComponentParameter(62, "Type", (object) RuntimeHelpers.TypeCheck<ButtonType>(ButtonType.Outline));
          __builder2.AddComponentParameter(63, "OnClick", (object) RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (async () => await this.HandleTryAgain(true)))));
          __builder2.CloseComponent();
          __builder2.CloseElement();
          __builder2.CloseElement();
        }
        else if (this.verificationStage == 1)
        {
          if (this.ProcessTemplate == null)
          {
            __builder2.OpenElement(64, "div");
            __builder2.AddAttribute(65, "class", "flex-col ptb1 aic jcc");
            __builder2.OpenComponent<Lottie>(66);
            __builder2.AddComponentParameter(67, "Source", (object) "https://lottie.host/ffb368d8-295e-4367-9423-f490ea84d70a/Ru73Iouiy6.json");
            __builder2.AddComponentParameter(68, "Width", (object) "200px");
            __builder2.AddComponentParameter(69, "Height", (object) "150px");
            __builder2.CloseComponent();
            __builder2.AddMarkupContent(70, "\r\n                        ");
            __builder2.AddMarkupContent(71, "<small>Verifying, please wait...</small>");
            __builder2.CloseElement();
          }
          else
            __builder2.AddContent(72, this.ProcessTemplate);
        }
        else if (this.verificationStage == 2)
        {
          if (this.FailureTemplate == null)
          {
            __builder2.OpenElement(73, "div");
            __builder2.AddAttribute(74, "class", "flex-col jcc aic ptb1");
            __builder2.OpenComponent<Lottie>(75);
            __builder2.AddComponentParameter(76, "Source", (object) "https://lottie.host/33bc9129-ff29-4ba9-bd58-11dd2957c215/amfGQe9CKk.json");
            __builder2.AddComponentParameter(77, "Width", (object) "150px");
            __builder2.AddComponentParameter(78, "Height", (object) "150px");
            __builder2.CloseComponent();
            __builder2.AddMarkupContent(79, "\r\n                        ");
            __builder2.AddMarkupContent(80, "<small>Verification failed.</small>");
            if (this.retries < this.RetryAllowed)
            {
              __builder2.OpenComponent<Button>(81);
              __builder2.AddComponentParameter(82, "Icon", (object) "check");
              __builder2.AddComponentParameter(83, "Text", (object) "Try again");
              __builder2.AddComponentParameter(84, "OnClick", (object) RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (async () => await this.HandleTryAgain()))));
              __builder2.CloseComponent();
            }
            else
            {
              __builder2.OpenElement(85, "p");
              __builder2.AddAttribute(86, "class", "ta-center");
              __builder2.AddContent(87, "Sorry, only ");
              __builder2.AddContent(88, (object) this.RetryAllowed);
              __builder2.AddContent(89, " retries allowed.");
              __builder2.CloseElement();
            }
            __builder2.CloseElement();
          }
          else
            __builder2.AddContent(90, this.FailureTemplate);
        }
        else if (this.SuccessTemplate == null)
          __builder2.AddMarkupContent(91, "<div class=\"flex jcc aic ptb1\"><h1>Verified \uD83D\uDC4D</h1></div>");
        else
          __builder2.AddContent(92, this.SuccessTemplate);
      }));
      __builder.CloseComponent();
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    RenderFragment? ProcessTemplate { get; set; }

    [Parameter]
    public RenderFragment? SuccessTemplate { get; set; }

    [Parameter]
    public RenderFragment? FailureTemplate { get; set; }

    [Parameter]
    public EventCallback OnSuccess { get; set; }

    [Parameter]
    public EventCallback OnFailure { get; set; }

    [Parameter]
    public int RetryAllowed { get; set; } = 3;

    [Parameter]
    public bool Register { get; set; } = true;

    protected override void OnParametersSet() => this.shouldRegister = this.Register;

    private async Task HandleVerification()
    {
      if (this.verificationStage != 0)
        return;
      this.verificationStage = 1;
      await Task.Delay(1000);
      if (this.toMatch == string.Join(string.Empty, (IEnumerable<string>) this.newItems))
      {
        this.verificationStage = 3;
        await this.OnSuccess.InvokeAsync();
      }
      else
      {
        this.verificationStage = 2;
        await this.OnFailure.InvokeAsync();
      }
    }

    private async Task HandleTryAgain(bool isReset = false)
    {
      await this.InvokeAsync((Action) (() =>
      {
        this.verificationStage = 0;
        this.toMatch = Sysinfocus.AspNetCore.Components.VerifyHuman.GetRandomNumbers();
        this.newItems = new List<string>();
        this.shouldRender = false;
        this.StateHasChanged();
        if (isReset)
          return;
        ++this.retries;
      }));
    }

    private void HandleInsert((int o, int n, string f, string t) index)
    {
      if (this.newItems.Count == 6 || !(index.f == "second"))
        return;
      this.newItems.Add(this.items[index.o]);
    }

    private static string GetRandomNumbers()
    {
      long num = DateTime.Now.Ticks + (long) Random.Shared.Next();
      return num.ToString().Substring(num.ToString().Length - 6);
    }

    protected override void OnAfterRender(bool firstRender) => this.shouldRegister = false;

    protected override bool ShouldRender()
    {
      if (this.shouldRender)
        return base.ShouldRender();
      this.shouldRender = true;
      return base.ShouldRender();
    }

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
