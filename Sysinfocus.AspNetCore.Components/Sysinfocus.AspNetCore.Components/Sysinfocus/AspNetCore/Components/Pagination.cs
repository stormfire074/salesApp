// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Pagination
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.CompilerServices;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class Pagination : ComponentBase
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      if (this.State.TotalPages <= 1)
        return;
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-pagination");
      __builder.AddAttribute(2, "b-eeewzadjmu");
      if (this.ShowFirstLast && this.State.TotalPages > 3)
      {
        __builder.OpenComponent<Button>(3);
        __builder.AddComponentParameter(4, "AccessKey", (object) "[");
        __builder.AddComponentParameter(5, "Icon", (object) "first_page");
        __builder.AddComponentParameter(6, "Size", (object) RuntimeHelpers.TypeCheck<ButtonSize>(this.Size));
        __builder.AddComponentParameter(7, "Type", (object) RuntimeHelpers.TypeCheck<ButtonType>(this.Type));
        __builder.AddComponentParameter(8, "Disabled", (object) RuntimeHelpers.TypeCheck<bool>(this.HasPrevious()));
        __builder.AddComponentParameter(9, "OnClick", (object) RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, new Func<Task>(this.GotoFirstPage))));
        __builder.CloseComponent();
      }
      if (this.State.TotalPages > 1)
      {
        __builder.OpenComponent<Button>(10);
        __builder.AddComponentParameter(11, "AccessKey", (object) "<");
        __builder.AddComponentParameter(12, "Icon", (object) "chevron_left");
        __builder.AddComponentParameter(13, "Text", (object) RuntimeHelpers.TypeCheck<string>(this.PreviousText));
        __builder.AddComponentParameter(14, "Size", (object) RuntimeHelpers.TypeCheck<ButtonSize>(this.Size));
        __builder.AddComponentParameter(15, "Type", (object) RuntimeHelpers.TypeCheck<ButtonType>(this.Type));
        __builder.AddComponentParameter(16, "Disabled", (object) RuntimeHelpers.TypeCheck<bool>(this.HasPrevious()));
        __builder.AddComponentParameter(17, "OnClick", (object) RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, new Func<Task>(this.GotoPrevPage))));
        __builder.CloseComponent();
      }
      int num;
      if (this.State.CurrentPage == this.State.TotalPages && this.State.TotalPages > 2)
      {
        __builder.OpenComponent<Button>(18);
        RenderTreeBuilder renderTreeBuilder = __builder;
        num = this.State.CurrentPage - 2;
        string str = RuntimeHelpers.TypeCheck<string>(num.ToString());
        renderTreeBuilder.AddComponentParameter(19, "Text", (object) str);
        __builder.AddComponentParameter(20, "Size", (object) RuntimeHelpers.TypeCheck<ButtonSize>(this.Size));
        __builder.AddComponentParameter(21, "Type", (object) RuntimeHelpers.TypeCheck<ButtonType>(this.Type));
        __builder.AddComponentParameter(22, "OnClick", (object) RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (() => this.HandleSelect(this.State.CurrentPage - 2)))));
        __builder.CloseComponent();
      }
      if (this.State.CurrentPage > 1)
      {
        __builder.OpenComponent<Button>(23);
        RenderTreeBuilder renderTreeBuilder = __builder;
        num = this.State.CurrentPage - 1;
        string str = RuntimeHelpers.TypeCheck<string>(num.ToString());
        renderTreeBuilder.AddComponentParameter(24, "Text", (object) str);
        __builder.AddComponentParameter(25, "Size", (object) RuntimeHelpers.TypeCheck<ButtonSize>(this.Size));
        __builder.AddComponentParameter(26, "Type", (object) RuntimeHelpers.TypeCheck<ButtonType>(this.Type));
        __builder.AddComponentParameter(27, "OnClick", (object) RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (() => this.HandleSelect(this.State.CurrentPage - 1)))));
        __builder.CloseComponent();
      }
      __builder.OpenComponent<Button>(28);
      RenderTreeBuilder renderTreeBuilder1 = __builder;
      num = this.State.CurrentPage;
      string str1 = RuntimeHelpers.TypeCheck<string>(num.ToString());
      renderTreeBuilder1.AddComponentParameter(29, "Text", (object) str1);
      __builder.AddComponentParameter(30, "Size", (object) RuntimeHelpers.TypeCheck<ButtonSize>(this.Size));
      __builder.AddComponentParameter(31, "Type", (object) RuntimeHelpers.TypeCheck<ButtonType>(this.ActiveType));
      __builder.AddComponentParameter(32, "OnClick", (object) RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (() => this.HandleSelect(this.State.CurrentPage)))));
      __builder.CloseComponent();
      if (this.State.CurrentPage < this.State.TotalPages)
      {
        __builder.OpenComponent<Button>(33);
        RenderTreeBuilder renderTreeBuilder2 = __builder;
        num = this.State.CurrentPage + 1;
        string str2 = RuntimeHelpers.TypeCheck<string>(num.ToString());
        renderTreeBuilder2.AddComponentParameter(34, "Text", (object) str2);
        __builder.AddComponentParameter(35, "Size", (object) RuntimeHelpers.TypeCheck<ButtonSize>(this.Size));
        __builder.AddComponentParameter(36, "Type", (object) RuntimeHelpers.TypeCheck<ButtonType>(this.Type));
        __builder.AddComponentParameter(37, "OnClick", (object) RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (() => this.HandleSelect(this.State.CurrentPage + 1)))));
        __builder.CloseComponent();
      }
      if (this.State.CurrentPage == 1 && this.State.TotalPages > 2)
      {
        __builder.OpenComponent<Button>(38);
        RenderTreeBuilder renderTreeBuilder3 = __builder;
        num = this.State.CurrentPage + 2;
        string str3 = RuntimeHelpers.TypeCheck<string>(num.ToString());
        renderTreeBuilder3.AddComponentParameter(39, "Text", (object) str3);
        __builder.AddComponentParameter(40, "Size", (object) RuntimeHelpers.TypeCheck<ButtonSize>(this.Size));
        __builder.AddComponentParameter(41, "Type", (object) RuntimeHelpers.TypeCheck<ButtonType>(this.Type));
        __builder.AddComponentParameter(42, "OnClick", (object) RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (() => this.HandleSelect(this.State.CurrentPage + 2)))));
        __builder.CloseComponent();
      }
      if (this.State.TotalPages > 1)
      {
        __builder.OpenComponent<Button>(43);
        __builder.AddComponentParameter(44, "AccessKey", (object) ">");
        __builder.AddComponentParameter(45, "Icon", (object) "chevron_right");
        __builder.AddComponentParameter(46, "Text", (object) RuntimeHelpers.TypeCheck<string>(this.NextText));
        __builder.AddComponentParameter(47, "Size", (object) RuntimeHelpers.TypeCheck<ButtonSize>(this.Size));
        __builder.AddComponentParameter(48, "Type", (object) RuntimeHelpers.TypeCheck<ButtonType>(this.Type));
        __builder.AddComponentParameter(49, "IconPositionRight", (object) true);
        __builder.AddComponentParameter(50, "Disabled", (object) RuntimeHelpers.TypeCheck<bool>(this.HasNext()));
        __builder.AddComponentParameter(51, "OnClick", (object) RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, new Func<Task>(this.GotoNextPage))));
        __builder.CloseComponent();
      }
      if (this.ShowFirstLast && this.State.TotalPages > 3)
      {
        __builder.OpenComponent<Button>(52);
        __builder.AddComponentParameter(53, "AccessKey", (object) "]");
        __builder.AddComponentParameter(54, "Icon", (object) "last_page");
        __builder.AddComponentParameter(55, "Size", (object) RuntimeHelpers.TypeCheck<ButtonSize>(this.Size));
        __builder.AddComponentParameter(56, "Type", (object) RuntimeHelpers.TypeCheck<ButtonType>(this.Type));
        __builder.AddComponentParameter(57, "Disabled", (object) RuntimeHelpers.TypeCheck<bool>(this.HasNext()));
        __builder.AddComponentParameter(58, "OnClick", (object) RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, new Func<Task>(this.GotoLastPage))));
        __builder.CloseComponent();
      }
      __builder.CloseElement();
    }

    [Parameter]
    [EditorRequired]
    public 
    #nullable enable
    PaginationState State { get; set; } = (PaginationState) null;

    [Parameter]
    public EventCallback<int> OnPageChange { get; set; }

    [Parameter]
    public ButtonType Type { get; set; } = ButtonType.Ghost;

    [Parameter]
    public ButtonType ActiveType { get; set; } = ButtonType.Outline;

    [Parameter]
    public ButtonSize Size { get; set; } = ButtonSize.Regular;

    [Parameter]
    public bool ShowFirstLast { get; set; }

    [Parameter]
    public string? PreviousText { get; set; } = "Previous";

    [Parameter]
    public string? NextText { get; set; } = "Next";

    private bool HasPrevious() => this.State.CurrentPage <= 1;

    private bool HasNext() => this.State.CurrentPage >= this.State.TotalPages;

    private async Task GotoPrevPage()
    {
      if (this.State.CurrentPage > 1)
        --this.State.CurrentPage;
      this.HasNext();
      await this.HandleSelect(this.State.CurrentPage);
    }

    private async Task GotoNextPage()
    {
      if (this.State.CurrentPage < this.State.TotalPages)
        ++this.State.CurrentPage;
      this.HasPrevious();
      await this.HandleSelect(this.State.CurrentPage);
    }

    private async Task GotoFirstPage()
    {
      if (this.State.CurrentPage > 1)
        this.State.CurrentPage = 1;
      this.HasNext();
      await this.HandleSelect(this.State.CurrentPage);
    }

    private async Task GotoLastPage()
    {
      if (this.State.CurrentPage < this.State.TotalPages)
        this.State.CurrentPage = this.State.TotalPages;
      this.HasPrevious();
      await this.HandleSelect(this.State.CurrentPage);
    }

    private async Task HandleSelect(int page)
    {
      this.State.CurrentPage = page > this.State.TotalPages ? this.State.TotalPages : (page < 1 ? 1 : page);
      await this.OnPageChange.InvokeAsync(this.State.CurrentPage);
    }

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
