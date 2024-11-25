// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Combobox`1
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System.Runtime.CompilerServices;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
    public class Combobox<TItem> : ComponentBase
    {
        private string? errorMessage;
        private TItem[]? filterItems;
        private string? show = (string)null;
        private string? search = string.Empty;
        private int itemIndex = -1;
        private bool pku = false;
        private bool pkd = false;
        private bool bkd = false;

        protected override void BuildRenderTree(
#nullable disable
        RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "sbc-combobox");
            __builder.AddAttribute(2, "b-52fbtuz3y3");
            if (!string.IsNullOrEmpty(this.Label))
            {
                __builder.OpenElement(3, "label");
                __builder.AddAttribute(4, "for", this.Id);
                __builder.AddAttribute(5, "style", !string.IsNullOrEmpty(this.errorMessage) ? "color: var(--error);" : (string)null);
                __builder.AddAttribute(6, "b-52fbtuz3y3");
                __builder.AddContent(7, this.Label);
                __builder.CloseElement();
            }
            __builder.OpenElement(8, "button");
            __builder.AddAttribute(9, "accesskey", this.AccessKey);
            __builder.AddAttribute(10, "disabled", this.Disabled);
            __builder.AddAttribute(11, "style", "width: " + this.Width + ";");
            __builder.AddAttribute(12, "id", this.Id);
            __builder.AddAttribute<MouseEventArgs>(13, "onmousedown", EventCallback.Factory.Create<MouseEventArgs>((object)this, new Func<Task>(this.ToggleShow)));
            __builder.AddAttribute<KeyboardEventArgs>(14, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object)this, new Func<KeyboardEventArgs, Task>(this.HandleButtonKeyDown)));
            __builder.AddEventPreventDefaultAttribute(15, "onkeydown", this.bkd);
            __builder.AddAttribute(16, "b-52fbtuz3y3");
            __builder.OpenElement(17, "span");
            __builder.AddAttribute(18, "b-52fbtuz3y3");
            __builder.AddContent(19, this.text ?? this.Placeholder);
            __builder.CloseElement();
            __builder.AddContent(20, " ");
            __builder.AddContent(21, Icons.CHEVRON_UP_DOWN);
            __builder.CloseElement();
            if (!InitializeSysinfocus.IsLicensed)
                __builder.AddMarkupContent(22, "<span class=\"info\" b-52fbtuz3y3>You are using a trial version.</span>");
            else if (!string.IsNullOrEmpty(this.Info))
            {
                __builder.OpenElement(23, "span");
                __builder.AddAttribute(24, "class", "info");
                __builder.AddAttribute(25, "b-52fbtuz3y3");
                __builder.AddContent(26, this.Info);
                __builder.CloseElement();
            }
            if (!string.IsNullOrEmpty(this.errorMessage))
            {
                __builder.OpenElement(27, "p");
                __builder.AddAttribute(28, "style", "color: var(--error); font-size: 14px");
                __builder.AddAttribute(29, "b-52fbtuz3y3");
                __builder.AddContent(30, this.errorMessage);
                __builder.CloseElement();
            }
            __builder.CloseElement();
            if (this.show == null)
                return;
            __builder.OpenElement(31, "div");
            __builder.AddAttribute(32, "class", "sbc-ac-list " + this.show);
            __builder.AddAttribute(33, "style", "width: " + this.ListWidth + "; max-height: " + this.Height);
            __builder.AddAttribute(34, "b-52fbtuz3y3");
            __builder.OpenElement(35, "div");
            __builder.AddAttribute(36, "class", "search-box");
            __builder.AddAttribute(37, "style", !this.Searchable ? "opacity:0; height: 0 !important; margin-bottom: 0" : (string)null);
            __builder.AddAttribute(38, "b-52fbtuz3y3");
            __builder.AddContent(39, Icons.SEARCH_ICON);
            __builder.AddMarkupContent(40, "\r\n            ");
            __builder.OpenElement(41, "input");
            __builder.AddAttribute(42, "tabindex", "-1");
            __builder.AddAttribute(43, "style", "color: var(--fg);");
            __builder.AddAttribute(44, "aria-autocomplete", "none");
            __builder.AddAttribute(45, "spellcheck", "false");
            __builder.AddAttribute(46, "type", "text");
            __builder.AddAttribute(47, "placeholder", this.Placeholder);
            __builder.AddAttribute<ChangeEventArgs>(48, "oninput", EventCallback.Factory.Create<ChangeEventArgs>((object)this, new Action<ChangeEventArgs>(this.HandleSearch)));
            __builder.AddAttribute<KeyboardEventArgs>(49, "onkeyup", EventCallback.Factory.Create<KeyboardEventArgs>((object)this, new Func<KeyboardEventArgs, Task>(this.HandleKeyUp)));
            __builder.AddEventPreventDefaultAttribute(50, "onkeyup", this.pku);
            __builder.AddAttribute<KeyboardEventArgs>(51, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object)this, new Func<KeyboardEventArgs, Task>(this.HandleKeyDown)));
            __builder.AddAttribute(52, "autofocus", "false");
            __builder.AddEventPreventDefaultAttribute(53, "onkeydown", this.pkd);
            __builder.AddAttribute<FocusEventArgs>(54, "onblur", EventCallback.Factory.Create<FocusEventArgs>((object)this, new Action(this.HideListing)));
            __builder.AddAttribute(55, "value", BindConverter.FormatValue(this.search));
            __builder.AddAttribute<ChangeEventArgs>(56, "onchange", EventCallback.Factory.CreateBinder((object)this, (Action<string>)(__value => this.search = __value), this.search));
            __builder.SetUpdatesAttributeName("value");
            __builder.AddAttribute(57, "b-52fbtuz3y3");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(58, "\r\n        ");
            __builder.OpenElement(59, "div");
            __builder.AddAttribute(60, "class", "list-items");
            __builder.AddAttribute(61, "b-52fbtuz3y3");
            if (this.filterItems != null)
            {
                int num1 = 0;
                foreach (TItem filterItem in this.filterItems)
                {
                    TItem item = filterItem;
                    string textContent = this.Display(item);
                    if (textContent == "-")
                    {
                        __builder.AddMarkupContent(62, "<hr b-52fbtuz3y3>");
                    }
                    else
                    {
                        __builder.OpenElement(63, "div");
                        __builder.AddAttribute(64, "class", "item " + (this.itemIndex == num1 ? "selected" : (string)null));
                        __builder.AddAttribute<MouseEventArgs>(65, "onmousedown", EventCallback.Factory.Create<MouseEventArgs>((object)this, (Func<Task>)(() => this.SetItem(item))));
                        __builder.AddAttribute(66, "b-52fbtuz3y3");
                        __builder.AddContent(67, textContent);
                        int num2;
                        if (item != null)
                        {
                            TItem local = item;
                            TItem obj = default(TItem);

                            if (EqualityComparer<TItem>.Default.Equals(obj, default(TItem)))
                            {
                                obj = local;
                            }

                            TItem selectedItem = this.SelectedItem;

                            bool isEqual = EqualityComparer<TItem>.Default.Equals(local, selectedItem);
                            num2 = isEqual ? 1 : 0;
                        }

                        else
                            num2 = 0;
                        if (num2 != 0)
                        {
                            if (this.itemIndex == -1)
                                this.itemIndex = num1;
                            __builder.AddContent(68, Icons.TICK_ICON);
                        }
                        __builder.CloseElement();
                        ++num1;
                    }
                }
                TItem[] filterItems = this.filterItems;
                if ((filterItems != null ? (filterItems.Length == 0 ? 1 : 0) : 0) != 0 && !string.IsNullOrEmpty(this.search))
                {
                    __builder.AddMarkupContent(69, "<div style=\"text-align: center; padding: 2rem; font-size: 14px\" b-52fbtuz3y3>\r\n                        No match found.\r\n                    </div>");
                    this.itemIndex = -1;
                }
            }
            __builder.CloseElement();
            __builder.CloseElement();
        }

        [Parameter]
        public
#nullable enable
        TItem? SelectedItem
        { get; set; }

        [Parameter]
        [EditorRequired]
        public Func<TItem, string>? Display { get; set; }

        [Parameter]
        public ICollection<TItem>? Items { get; set; }

        [Parameter]
        public string? Id { get; set; } = "cb" + Guid.NewGuid().ToString().Replace("-", "");

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public string? AccessKey { get; set; }

        [Parameter]
        public string? Placeholder { get; set; }

        [Parameter]
        public string? Width { get; set; } = "100%";

        [Parameter]
        public string? Height { get; set; }

        [Parameter]
        public bool Searchable { get; set; } = true;

        [Parameter]
        public string? ListWidth { get; set; }

        [Parameter]
        public string? Label { get; set; }

        [Parameter]
        public string? Info { get; set; }

        [Parameter]
        public EventCallback<TItem?> OnItemSelect { get; set; }

        [Parameter]
        public string? Error { get; set; }

        [CascadingParameter]
        private Dictionary<string, string>? FormErrors { get; set; }

        private string? text { get; set; }

        protected override void OnParametersSet()
        {
            this.errorMessage = (string)null;
            if (this.FormErrors != null && this.Error != null && this.FormErrors.ContainsKey(this.Error))
                this.errorMessage = this.FormErrors[this.Error];
            if (this.Display != null && (object)this.SelectedItem != null)
                this.text = this.Display(this.SelectedItem);
            if (this.ListWidth == null)
            {
                string str;
                this.ListWidth = str = this.Width != "100%" ? this.Width : "fit-content";
            }
            ICollection<TItem> items = this.Items;
            this.filterItems = items != null ? items.ToArray<TItem>() : (TItem[])null;
        }

        private void HideListing() => this.show = (string)null;

        private async Task ToggleShow()
        {
            this.show = this.show == null ? "show" : (string)null;
            if (this.show == null)
                return;
            await Task.Delay(10);
            string scp = "if( /Android|webOS|iPhone|iPad|iPod|BlackBerry/i.test(navigator.userAgent) ) {} else { document.querySelector('.search-box > input')?.focus(); }";
            await this.jsr.InvokeVoidAsync("eval", (object)scp);
            await this.UpdatePosition();
            await this.SetView();
            scp = (string)null;
        }

        private async Task SetView()
        {
            await Task.Delay(10);
            await this.jsr.InvokeVoidAsync("eval", (object)"document.querySelector('.item.selected')?.scrollIntoView(false)");
        }

        private async Task UpdatePosition()
        {
            ValueTask<RectBounds> valueTask = this.jsr.InvokeAsync<RectBounds>("eval", (object)"document.querySelector('body').getBoundingClientRect()");
            RectBounds window = await valueTask;
            valueTask = this.jsr.InvokeAsync<RectBounds>("eval", (object)("document.querySelector('#" + this.Id + "').getBoundingClientRect()"));
            RectBounds parent = await valueTask;
            double width = await this.jsr.InvokeAsync<double>("eval", (object)"document.querySelector('.sbc-ac-list')?.clientWidth");
            double height = await this.jsr.InvokeAsync<double>("eval", (object)"document.querySelector('.sbc-ac-list')?.clientHeight");
            double windowHeight = await this.jsr.InvokeAsync<double>("eval", (object)"window.innerHeight");
            double windowWidth = await this.jsr.InvokeAsync<double>("eval", (object)"document.body.scrollWidth");
            double right = parent.Left - (width - parent.Width);
            if (this.Height == null)
                height = parent.Top <= windowHeight / 2.0 ? windowHeight - parent.Bottom - 8.0 : parent.Top - 8.0;
            double top = windowHeight - height > parent.Bottom ? parent.Bottom + 4.0 : parent.Top - height - 6.0;
            double left = parent.Left + width > windowWidth ? right : parent.Left;
            string scp = "";
            if (height < windowHeight - parent.Top)
            {
                DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(218, 3);
                interpolatedStringHandler.AppendLiteral("document.querySelector('.sbc-ac-list').style.top = '");
                interpolatedStringHandler.AppendFormatted<double>(top);
                interpolatedStringHandler.AppendLiteral("px';\r\n                    document.querySelector('.sbc-ac-list').style.maxHeight = '");
                interpolatedStringHandler.AppendFormatted<double>(height);
                interpolatedStringHandler.AppendLiteral("px';\r\n                    document.querySelector('.sbc-ac-list').style.left = '");
                interpolatedStringHandler.AppendFormatted<double>(left);
                interpolatedStringHandler.AppendLiteral("px'");
                scp = interpolatedStringHandler.ToStringAndClear();
            }
            else
            {
                DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(221, 3);
                interpolatedStringHandler.AppendLiteral("document.querySelector('.sbc-ac-list').style.bottom = '");
                interpolatedStringHandler.AppendFormatted<double>(windowHeight - parent.Top + 4.0);
                interpolatedStringHandler.AppendLiteral("px';\r\n                    document.querySelector('.sbc-ac-list').style.maxHeight = '");
                interpolatedStringHandler.AppendFormatted<double>(height);
                interpolatedStringHandler.AppendLiteral("px';\r\n                    document.querySelector('.sbc-ac-list').style.left = '");
                interpolatedStringHandler.AppendFormatted<double>(left);
                interpolatedStringHandler.AppendLiteral("px'");
                scp = interpolatedStringHandler.ToStringAndClear();
            }
            await this.jsr.InvokeVoidAsync("eval", (object)scp);
            scp = (string)null;
        }

        private async Task SetItem(TItem? item)
        {
            this.pkd = true;
            this.pku = true;
            this.SelectedItem = item;
            Func<TItem, string> display = this.Display;
            this.text = display != null ? display(item) : (string)null;
            this.show = (string)null;
            this.itemIndex = -1;
            await this.OnItemSelect.InvokeAsync(this.SelectedItem);
        }

        private async Task HandleKeyUp(KeyboardEventArgs args)
        {
            this.pku = false;
            if (!"ArrowUp,ArrowDown,PageUp,PageDown,Home,End".Matches(args.Key))
                return;
            await this.SetView();
        }

        private async Task HandleKeyDown(KeyboardEventArgs args)
        {
            if (this.filterItems == null || this.filterItems.Length == 0)
                return;
            int maxItems = ((IEnumerable<TItem>)this.filterItems).Count<TItem>((Func<TItem, bool>)(a => this.Display(a) != "-"));
            this.pkd = false;
            if (args.Key == "Enter" || args.Key == "Tab")
            {
                this.pkd = true;
                await this.SetItem(this.filterItems[this.itemIndex]);
            }
            else if (args.Key == "Escape")
            {
                this.pkd = true;
                ICollection<TItem> items = this.Items;
                this.filterItems = items != null ? items.ToArray<TItem>() : (TItem[])null;
                this.search = (string)null;
                this.show = (string)null;
                this.itemIndex = -1;
            }
            else if (args.Key == "End")
            {
                this.pkd = true;
                this.itemIndex = maxItems - 1;
                await this.SetView();
            }
            else if (args.Key == "Home")
            {
                this.pkd = true;
                this.itemIndex = 0;
                await this.SetView();
            }
            else if (args.Key == "ArrowDown")
            {
                this.pkd = true;
                if (this.itemIndex < maxItems - 1)
                    ++this.itemIndex;
                await this.SetView();
            }
            else if (args.Key == "ArrowUp")
            {
                this.pkd = true;
                if (this.itemIndex > 0)
                    --this.itemIndex;
                await this.SetView();
            }
            else if (args.Key == "PageDown")
            {
                this.pkd = true;
                if (this.itemIndex + 10 < maxItems - 1)
                    this.itemIndex += 10;
                else
                    this.itemIndex = maxItems - 1;
                await this.SetView();
            }
            else if (args.Key == "PageUp")
            {
                this.pkd = true;
                if (this.itemIndex > 10)
                    this.itemIndex -= 10;
                else
                    this.itemIndex = 0;
                await this.SetView();
            }
            else
            {
                if (!(args.Key == "ArrowLeft") && !(args.Key == "ArrowRight"))
                    return;
                this.pkd = true;
            }
        }

        private async Task HandleButtonKeyDown(KeyboardEventArgs args)
        {
            this.bkd = false;
            TItem[] filterItems = this.filterItems;
            int? maxItems = filterItems != null ? new int?(((IEnumerable<TItem>)filterItems).Count<TItem>((Func<TItem, bool>)(a => this.Display(a) != "-"))) : new int?();
            if (!(args.Key == "ArrowDown") || this.show != null)
                return;
            this.bkd = true;
            await this.ToggleShow();
            int num1;
            if (this.filterItems != null)
            {
                int? nullable = maxItems;
                int num2 = 0;
                if (nullable.GetValueOrDefault() > num2 & nullable.HasValue)
                {
                    num1 = this.itemIndex == -1 ? 1 : 0;
                    goto label_6;
                }
            }
            num1 = 0;
        label_6:
            if (num1 != 0)
                this.itemIndex = 0;
            await Task.Delay(10);
            await this.jsr.InvokeVoidAsync("eval", (object)"document.querySelector('.item.selected')?.scrollIntoView(false)");
        }

        private void HandleSearch(ChangeEventArgs args)
        {
            if (this.show != null)
            {
                this.search = args.Value?.ToString();
                TItem[] array;
                if (!string.IsNullOrEmpty(this.search))
                {
                    ICollection<TItem> items = this.Items;
                    array = items != null ? items.Where<TItem>((Func<TItem, bool>)(a => this.Display(a).Contains(this.search, StringComparison.OrdinalIgnoreCase))).ToArray<TItem>() : (TItem[])null;
                }
                else
                {
                    ICollection<TItem> items = this.Items;
                    array = items != null ? items.ToArray<TItem>() : (TItem[])null;
                }
                this.filterItems = array;
                this.itemIndex = 0;
            }
            else
                this.search = (string)null;
        }

        [Inject]
        private IJSRuntime jsr { get; set; } = (IJSRuntime)null;

        [Inject]
        private StateManager sm { get; set; } = (StateManager)null;
    }
}
