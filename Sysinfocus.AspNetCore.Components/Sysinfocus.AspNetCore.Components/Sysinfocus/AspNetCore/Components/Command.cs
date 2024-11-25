// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Command
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.CompilerServices;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class Command : ComponentBase
  {
    private ElementReference input;
    private string? search;
    private string? altIcon = "⌘";
    private CommandOption[]? filtered;
    private bool pd;
    private int selectedIndex = -1;

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-command");
      __builder.AddAttribute(2, "style", "max-width: " + this.Width);
      __builder.AddAttribute(3, "b-ta3hx27b8r");
      __builder.OpenElement(4, "div");
      __builder.AddAttribute(5, "class", "sbc-command-search");
      __builder.AddAttribute(6, "b-ta3hx27b8r");
      __builder.AddMarkupContent(7, "<span class=\"material-symbols-outlined\" b-ta3hx27b8r>search</span>\r\n        ");
      __builder.OpenElement(8, "input");
      __builder.AddAttribute(9, "accesskey", this.AccessKey);
      __builder.AddAttribute(10, "autocomplete", "off");
      __builder.AddAttribute(11, "aria-autocomplete", "none");
      __builder.AddAttribute(12, "spellcheck", "false");
      __builder.AddAttribute(13, "type", "text");
      __builder.AddAttribute(14, "placeholder", this.Placeholder);
      __builder.AddAttribute(15, "value", this.search);
      __builder.AddAttribute<ChangeEventArgs>(16, "oninput", EventCallback.Factory.Create<ChangeEventArgs>((object) this, new Action<ChangeEventArgs>(this.HandleInput)));
      __builder.AddAttribute<FocusEventArgs>(17, "onfocusout", EventCallback.Factory.Create<FocusEventArgs>((object) this, new Func<Task>(this.HandleFocusOut)));
      __builder.AddAttribute<KeyboardEventArgs>(18, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, new Func<KeyboardEventArgs, Task>(this.HandleKeyDown)));
      __builder.AddEventPreventDefaultAttribute(19, "onkeydown", this.pd);
      __builder.AddAttribute(20, "b-ta3hx27b8r");
      __builder.AddElementReferenceCapture(21, (Action<ElementReference>) (__value => this.input = __value));
      __builder.CloseElement();
      __builder.CloseElement();
      if (this.Show)
      {
        IEnumerable<IGrouping<string, CommandOption>> source = ((IEnumerable<CommandOption>) this.filtered).GroupBy<CommandOption, string>((Func<CommandOption, string>) (a => a.Group));
        int num1 = 0;
        if (source.Any<IGrouping<string, CommandOption>>())
        {
          foreach (IGrouping<string, CommandOption> grouping in source)
          {
            IGrouping<string, CommandOption> group = grouping;
            __builder.OpenElement(22, "div");
            __builder.AddAttribute(23, "class", "sbc-command-group");
            __builder.AddAttribute(24, "b-ta3hx27b8r");
            __builder.OpenElement(25, "p");
            __builder.AddAttribute(26, "b-ta3hx27b8r");
            __builder.AddContent(27, group.Key);
            __builder.CloseElement();
            CommandOption[] filtered = this.filtered;
            foreach (CommandOption commandOption in (IEnumerable<CommandOption>) ((filtered != null ? (object) ((IEnumerable<CommandOption>) filtered).Where<CommandOption>((Func<CommandOption, bool>) (a => a.Group == group.Key)) : (object) null) ?? (object) Array.Empty<CommandOption>()))
            {
              int num2 = num1;
              __builder.OpenComponent<CommandItem>(28);
              __builder.AddComponentParameter(29, "Selected", (object) RuntimeHelpers.TypeCheck<bool>(this.selectedIndex == num2));
              __builder.AddComponentParameter(30, "Item", (object) RuntimeHelpers.TypeCheck<CommandOption>(commandOption));
              __builder.AddComponentParameter(31, "OnClick", (object) RuntimeHelpers.TypeCheck<EventCallback<CommandOption>>(EventCallback.Factory.Create<CommandOption>((object) this, new Func<CommandOption, Task>(this.HandleItemClick))));
              __builder.AddComponentParameter(32, "AltIcon", (object) RuntimeHelpers.TypeCheck<string>(this.altIcon));
              __builder.CloseComponent();
              ++num1;
            }
            __builder.CloseElement();
          }
        }
        else
          __builder.AddMarkupContent(33, "<div class=\"sbc-command-notfound\" b-ta3hx27b8r>\r\n                No results found.\r\n            </div>");
      }
      if (!InitializeSysinfocus.IsLicensed)
        __builder.AddMarkupContent(34, "<small class=\"mtb1\" b-ta3hx27b8r>You are using a trial version.</small>");
      __builder.CloseElement();
    }

    [Parameter]
    public bool Show { get; set; }

    [Parameter]
    [EditorRequired]
    public 
    #nullable enable
    ICollection<CommandOption>? Items { get; set; }

    [Parameter]
    public string? AccessKey { get; set; }

    [Parameter]
    public string? Placeholder { get; set; } = "Type a command or search...";

    [Parameter]
    public string Width { get; set; } = "450px";

    [Parameter]
    public string Height { get; set; } = "450px";

    [Parameter]
    public int Take { get; set; } = 10;

    [Parameter]
    public EventCallback<CommandOption> OnClick { get; set; }

    [Parameter]
    public EventCallback OnClose { get; set; }

    protected override async Task OnInitializedAsync()
    {
      CommandOption[] array;
      if (this.Take != -1)
      {
        ICollection<CommandOption> items = this.Items;
        array = items != null ? items.Take<CommandOption>(this.Take).ToArray<CommandOption>() : (CommandOption[]) null;
      }
      else
      {
        ICollection<CommandOption> items = this.Items;
        array = items != null ? items.ToArray<CommandOption>() : (CommandOption[]) null;
      }
      this.filtered = array;
      int os = await this.jsr.InvokeAsync<int>("eval", (object) "navigator.userAgent.indexOf('Mac OS')");
      if (os != -1)
        return;
      this.altIcon = "Alt +";
    }

    private async Task HandleItemClick(CommandOption? co)
    {
      if ((object) co == null)
      {
        await this.input.FocusAsync();
      }
      else
      {
        this.search = (string) null;
        await this.OnClick.InvokeAsync(co);
        this.Show = false;
      }
    }

    private async Task HandleKeyDown(KeyboardEventArgs args)
    {
      if (args.Key == "ArrowDown")
      {
        this.pd = true;
        if (!this.Show)
          this.Show = true;
        if (this.search == null)
        {
          CommandOption[] array;
          if (this.Take != -1)
          {
            ICollection<CommandOption> items = this.Items;
            array = items != null ? items.Take<CommandOption>(this.Take).ToArray<CommandOption>() : (CommandOption[]) null;
          }
          else
          {
            ICollection<CommandOption> items = this.Items;
            array = items != null ? items.ToArray<CommandOption>() : (CommandOption[]) null;
          }
          this.filtered = array;
        }
        int selectedIndex = this.selectedIndex;
        CommandOption[] filtered = this.filtered;
        int? nullable = filtered != null ? new int?(filtered.Length - 1) : new int?();
        int valueOrDefault = nullable.GetValueOrDefault();
        if (selectedIndex < valueOrDefault & nullable.HasValue)
          ++this.selectedIndex;
      }
      else if (args.Key == "ArrowUp")
      {
        this.pd = true;
        if (this.selectedIndex > 0)
          --this.selectedIndex;
      }
      else if (args.Key == "Enter")
      {
        this.pd = true;
        CommandOption[] filtered = this.filtered;
        if ((filtered != null ? (filtered.Length != 0 ? 1 : 0) : 0) != 0 && this.selectedIndex >= 0)
        {
          await this.OnClick.InvokeAsync(this.filtered[this.selectedIndex]);
          this.Show = false;
          this.search = (string) null;
        }
      }
      else if (args.Key == "Escape" || args.Key == "Tab")
      {
        this.pd = true;
        this.search = (string) null;
        this.Show = false;
        await this.OnClose.InvokeAsync();
      }
      this.pd = false;
    }

    private void HandleInput(ChangeEventArgs args)
    {
      this.search = args.Value?.ToString();
      if (!this.Show)
        this.Show = true;
      if (string.IsNullOrEmpty(this.search))
      {
        CommandOption[] array;
        if (this.Take != -1)
        {
          ICollection<CommandOption> items = this.Items;
          array = items != null ? items.Take<CommandOption>(this.Take).ToArray<CommandOption>() : (CommandOption[]) null;
        }
        else
        {
          ICollection<CommandOption> items = this.Items;
          array = items != null ? items.ToArray<CommandOption>() : (CommandOption[]) null;
        }
        this.filtered = array;
      }
      else
      {
        ICollection<CommandOption> items = this.Items;
        IEnumerable<CommandOption> source = items != null ? items.Where<CommandOption>((Func<CommandOption, bool>) (a => a.Group.Contains(this.search, StringComparison.OrdinalIgnoreCase) || a.Name.Contains(this.search, StringComparison.OrdinalIgnoreCase))) : (IEnumerable<CommandOption>) null;
        this.filtered = this.Take == -1 ? (source != null ? source.ToArray<CommandOption>() : (CommandOption[]) null) : (source != null ? source.Take<CommandOption>(this.Take).ToArray<CommandOption>() : (CommandOption[]) null);
      }
      this.selectedIndex = 0;
    }

    private async Task HandleFocusOut()
    {
      await Task.Delay(100);
      this.Show = false;
    }

    [Inject]
    private IJSRuntime jsr { get; set; } = (IJSRuntime) null;

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
