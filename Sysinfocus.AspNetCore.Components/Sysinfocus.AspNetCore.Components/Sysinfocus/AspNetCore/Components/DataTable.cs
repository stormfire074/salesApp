// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.DataTable`1
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using __Blazor.Sysinfocus.AspNetCore.Components.DataTable;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System.Runtime.CompilerServices;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
    [CascadingTypeParameter("TItem")]
    public class DataTable<TItem> : ComponentBase
    {
        private bool IsChecked;
        private bool pkd;
        private int activeIndex = -1;

        protected override void BuildRenderTree(
#nullable disable
        RenderTreeBuilder __builder)
        {
            if (!InitializeSysinfocus.IsLicensed)
                __builder.AddMarkupContent(0, "<small class=\"mtb05\" b-7xhksee9mk>You are using a trial version.</small>");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "sbc-data-table-container");
            __builder.AddAttribute(3, "b-7xhksee9mk");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "sbc-data-table");
            __builder.AddAttribute(6, "style", "--spacing: " + this.Spacing + "; --height: " + this.Height + "; z-index: 0;");
            __builder.AddAttribute(7, "b-7xhksee9mk");
            __builder.OpenElement(8, "table");
            __builder.AddAttribute(9, "class", (this.ShowVerticalBorder ? "verticalBorder" : (string)null) + " " + (!this.OverflowWrap ? "nowrap" : (string)null));
            __builder.AddAttribute(10, "accesskey", this.AccessKey);
            __builder.AddAttribute(11, "cellpadding", "0");
            __builder.AddAttribute(12, "cellspacing", "0");
            __builder.AddAttribute(13, "b-7xhksee9mk");
            __builder.OpenElement(14, "thead");
            __builder.AddAttribute(15, "b-7xhksee9mk");
            __builder.OpenElement(16, "tr");
            __builder.AddAttribute(17, "b-7xhksee9mk");
            if (this.ShowSelectAll)
            {
                __builder.OpenElement(18, "th");
                __builder.AddAttribute(19, "class", "freeze");
                __builder.AddAttribute(20, "style", "width: fit-content;");
                __builder.AddAttribute(21, "b-7xhksee9mk");
                __builder.OpenComponent<Checkbox>(22);
                __builder.AddComponentParameter(23, "AccessKey", (object)"a");
                __builder.AddComponentParameter(24, "Tooltip", (object)"Toggle Check All");
                __builder.AddComponentParameter(25, "Checked", (object)Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<bool>(this.IsChecked));
                __builder.AddComponentParameter(26, "OnClick", (object)Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback<bool>>(EventCallback.Factory.Create<bool>((object)this, new Func<Task>(this.HandleSelectAll))));
                __builder.CloseComponent();
                __builder.CloseElement();
            }
            __builder.AddContent(27, this.DataColumns(default(TItem)));
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(28, "\r\n            ");
            __builder.OpenElement(29, "tbody");
            __builder.AddAttribute(30, "b-7xhksee9mk");
            int i = 0;
            if (this.Virtualized)
            {
                TypeInference.CreateVirtualize_0<TItem>(__builder, 31, 32, (ICollection<TItem>)this.Items.ToArray<TItem>(), 33, 50f, 34, (RenderFragment<TItem>)(context => (RenderFragment)(__builder2 =>
                {
                    int index = i;
                    __builder2.OpenElement(35, "tr");
                    __builder2.AddAttribute(36, "tabindex", "0");
                    __builder2.AddAttribute(37, "class", this.activeIndex == index ? "selected" : (string)null);
                    __builder2.AddAttribute(38, "style", this.RowStyle);
                    __builder2.AddAttribute<MouseEventArgs>(39, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object)this, (Func<Task>)(async () => await this.HandleClick(index))));
                    __builder2.AddAttribute<MouseEventArgs>(40, "ondblclick", EventCallback.Factory.Create<MouseEventArgs>((object)this, (Func<Task>)(async () => await this.HandleDoubleClick(index))));
                    __builder2.AddAttribute<KeyboardEventArgs>(41, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object)this, new Func<KeyboardEventArgs, Task>(this.HandleKeyDown)));
                    __builder2.AddEventPreventDefaultAttribute(42, "onkeydown", this.pkd);
                    __builder2.AddAttribute(43, "b-7xhksee9mk");
                    __builder2.SetKey((object)index);
                    TypeInference.CreateCascadingValue_1<TItem>(__builder2, 44, 45, context, 46, true, 47, (RenderFragment)(__builder3 => __builder3.AddContent(48, this.DataColumns(context))));
                    __builder2.CloseElement();
                    ++i;
                })));
            }
            else
            {
                foreach (TItem obj in this.Items)
                {
                    TItem row = obj;
                    int index = i;
                    __builder.OpenElement(49, "tr");
                    __builder.AddAttribute(50, "data-rowid", (object)index);
                    __builder.AddAttribute(51, "tabindex", "0");
                    __builder.AddAttribute(52, "class", this.activeIndex == index ? "selected" : (string)null);
                    __builder.AddAttribute(53, "style", this.RowStyle);
                    __builder.AddAttribute<MouseEventArgs>(54, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object)this, (Func<Task>)(async () => await this.HandleClick(index))));
                    __builder.AddAttribute<MouseEventArgs>(55, "ondblclick", EventCallback.Factory.Create<MouseEventArgs>((object)this, (Func<Task>)(async () => await this.HandleDoubleClick(index))));
                    __builder.AddAttribute<KeyboardEventArgs>(56, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object)this, new Func<KeyboardEventArgs, Task>(this.HandleKeyDown)));
                    __builder.AddEventPreventDefaultAttribute(57, "onkeydown", this.pkd);
                    __builder.AddAttribute(58, "b-7xhksee9mk");
                    __builder.SetKey((object)index);
                    TypeInference.CreateCascadingValue_2<TItem>(__builder, 59, 60, row, 61, true, 62, (RenderFragment)(__builder2 => __builder2.AddContent(63, this.DataColumns(row))));
                    __builder.CloseElement();
                    i++;
                }
            }
            __builder.CloseElement();
            __builder.AddMarkupContent(64, "\r\n            <tfoot b-7xhksee9mk></tfoot>");
            __builder.CloseElement();
            if (!this.Items.Any<TItem>() && this.EmptyTemplate == null)
                __builder.AddMarkupContent(65, "<div class=\"flex-col g4 mtb1 jcc aic\" b-7xhksee9mk><span class=\"large mt1\" b-7xhksee9mk>No Content</span>\r\n                <span class=\"mb1 muted\" b-7xhksee9mk>Try with different search and/or filter.</span></div>");
            else
                __builder.AddContent(66, this.EmptyTemplate);
            __builder.CloseElement();
            __builder.CloseElement();
        }

        [Parameter]
        public
#nullable enable
        IEnumerable<TItem> Items
        { get; set; } = (IEnumerable<TItem>)null;

        [Parameter]
        public RenderFragment? EmptyTemplate { get; set; }

        [Parameter]
        public RenderFragment<TItem>? DataColumns { get; set; }

        [Parameter]
        public string? AccessKey { get; set; }

        [Parameter]
        public string? Height { get; set; } = "fit-content";

        [Parameter]
        public string? Spacing { get; set; } = "12px";

        [Parameter]
        public string? RowStyle { get; set; }

        [Parameter]
        public bool ShowSelectAll { get; set; }

        [Parameter]
        public bool OverflowWrap { get; set; }

        [Parameter]
        public bool ShowVerticalBorder { get; set; }

        [Parameter]
        public bool Virtualized { get; set; }

        [Parameter]
        public EventCallback<bool> OnSelectAll { get; set; }

        [Parameter]
        public EventCallback<TItem> OnEnterKey { get; set; }

        [Parameter]
        public EventCallback<TItem> OnDeleteKey { get; set; }

        [Parameter]
        public EventCallback<TItem> OnClick { get; set; }

        [Parameter]
        public EventCallback<TItem> OnDoubleClick { get; set; }

        protected override void OnInitialized()
        {
        }

        private async Task HandleSelectAll()
        {
            this.IsChecked = !this.IsChecked;
            StateHasChanged(); // Directly invoke the method without casting
            await this.OnSelectAll.InvokeAsync(this.IsChecked);
        }
        private async Task HandleKeyDown(KeyboardEventArgs args)
        {
            this.pkd = false;
            if (args.Key == "Tab")
                return;
            int itemCount = this.Items.Count<TItem>();
            if (args.Key == "ArrowDown")
            {
                this.pkd = true;
                if (this.activeIndex < itemCount - 1)
                    ++this.activeIndex;
            }
            else if (args.Key == "ArrowUp")
            {
                this.pkd = true;
                if (this.activeIndex > 0)
                    --this.activeIndex;
            }
            else if (args.Key == "PageDown")
            {
                this.pkd = true;
                if (this.activeIndex + 10 < itemCount)
                    this.activeIndex += 10;
                else
                    this.activeIndex = itemCount - 1;
            }
            else if (args.Key == "PageUp")
            {
                this.pkd = true;
                if (this.activeIndex - 10 > 0)
                    this.activeIndex -= 10;
                else
                    this.activeIndex = 0;
            }
            else if (args.Key == "Home")
            {
                this.pkd = !this.Virtualized;
                this.activeIndex = 0;
            }
            else if (args.Key == "End")
            {
                this.pkd = !this.Virtualized;
                this.activeIndex = itemCount - 1;
            }
            else if (args.Key == "Enter")
            {
                if (this.activeIndex < 0)
                    return;
                this.pkd = true;
                await this.OnEnterKey.InvokeAsync(this.Items.ToArray<TItem>()[this.activeIndex]);
            }
            else if (args.Key == "Delete")
            {
                if (this.activeIndex < 0)
                    return;
                this.pkd = true;
                await this.OnDeleteKey.InvokeAsync(this.Items.ToArray<TItem>()[this.activeIndex]);
            }
            else if (args.Key == "Escape")
            {
                this.pkd = true;
                this.activeIndex = -1;
            }
            await this.jsr.InvokeVoidAsync("eval", (object)"document.querySelector('tr.selected')?.focus()");
            await this.jsr.InvokeVoidAsync("eval", (object)"document.querySelector('tr.selected')?.scrollIntoView(false)");
        }

        private async Task HandleClick(int index)
        {
            this.activeIndex = index;
            await this.OnClick.InvokeAsync(this.Items.ToArray<TItem>()[this.activeIndex]);
        }

        private async Task HandleDoubleClick(int index)
        {
            this.activeIndex = index;
            await this.OnDoubleClick.InvokeAsync(this.Items.ToArray<TItem>()[this.activeIndex]);
        }

        public async Task SetFocus(int rowId = 0)
        {
            if (!this.Items.Any<TItem>())
                return;
            await Task.Delay(100);
            IJSRuntime jsr = this.jsr;
            object[] objArray = new object[1];
            DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(50, 1);
            interpolatedStringHandler.AppendLiteral("document.querySelector('[data-rowid=\"");
            interpolatedStringHandler.AppendFormatted<int>(rowId);
            interpolatedStringHandler.AppendLiteral("\"]')?.focus()");
            objArray[0] = (object)interpolatedStringHandler.ToStringAndClear();
            await jsr.InvokeVoidAsync("eval", objArray);
        }

        [Inject]
        private IJSRuntime jsr { get; set; } = (IJSRuntime)null;

        [Inject]
        private StateManager sm { get; set; } = (StateManager)null;
    }
}
