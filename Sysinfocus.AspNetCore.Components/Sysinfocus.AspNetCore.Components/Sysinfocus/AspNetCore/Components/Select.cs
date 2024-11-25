// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Select`1
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
    public class Select<TItem> : ComponentBase
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
            __builder.AddAttribute(1, "class", "sbc-select");
            __builder.AddAttribute(2, "data-for", this.Id);
            __builder.AddAttribute(3, "b-oioz0f36uz");
            if (!string.IsNullOrEmpty(this.Label))
            {
                __builder.OpenElement(4, "label");
                __builder.AddAttribute(5, "for", this.Id);
                __builder.AddAttribute(6, "style", !string.IsNullOrEmpty(this.errorMessage) ? "color: var(--error);" : (string)null);
                __builder.AddAttribute(7, "b-oioz0f36uz");
                __builder.AddContent(8, this.Label);
                __builder.CloseElement();
            }
            __builder.OpenElement(9, "button");
            __builder.AddAttribute(10, "accesskey", this.AccessKey);
            __builder.AddAttribute(11, "disabled", this.Disabled);
            __builder.AddAttribute(12, "style", "width: " + this.Width + ";");
            __builder.AddAttribute(13, "id", this.Id);
            __builder.AddAttribute<MouseEventArgs>(14, "onmousedown", EventCallback.Factory.Create<MouseEventArgs>((object)this, new Func<Task>(this.ToggleShow)));
            __builder.AddAttribute<KeyboardEventArgs>(15, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object)this, new Func<KeyboardEventArgs, Task>(this.HandleButtonKeyDown)));
            __builder.AddEventPreventDefaultAttribute(16, "onkeydown", this.bkd);
            __builder.AddAttribute<FocusEventArgs>(17, "onfocus", EventCallback.Factory.Create<FocusEventArgs>((object)this, new Func<Task>(this.HandleOnFocus)));
            __builder.AddAttribute(18, "b-oioz0f36uz");
            __builder.OpenElement(19, "span");
            __builder.AddAttribute(20, "style", this.HideIcon ? "max-width: 100%" : (string)null);
            __builder.AddAttribute(21, "b-oioz0f36uz");
            __builder.AddContent(22, this.text ?? this.Placeholder);
            __builder.CloseElement();
            if (!this.HideIcon)
                __builder.AddContent(23, Icons.CHEVRON_UP_DOWN);
            __builder.CloseElement();
            if (!string.IsNullOrEmpty(this.Info))
            {
                __builder.OpenElement(24, "span");
                __builder.AddAttribute(25, "class", "info");
                __builder.AddAttribute(26, "b-oioz0f36uz");
                __builder.AddContent(27, this.Info);
                __builder.CloseElement();
            }
            if (!string.IsNullOrEmpty(this.errorMessage))
            {
                __builder.OpenElement(28, "p");
                __builder.AddAttribute(29, "style", "color: var(--error); font-size: 14px");
                __builder.AddAttribute(30, "b-oioz0f36uz");
                __builder.AddContent(31, this.errorMessage);
                __builder.CloseElement();
            }
            __builder.CloseElement();
            if (this.show == null)
                return;
            __builder.OpenElement(32, "div");
            __builder.AddAttribute(33, "class", "sbc-ac-list " + this.show);
            __builder.AddAttribute(34, "data-for", this.Id);
            __builder.AddAttribute(35, "style", "position:fixed; width: " + this.ListWidth);
            __builder.AddAttribute(36, "b-oioz0f36uz");
            __builder.OpenElement(37, "div");
            __builder.AddAttribute(38, "class", "search-box");
            __builder.AddAttribute(39, "style", !this.searchable ? "opacity:0; height: 0 !important; margin-bottom: 0" : (string)null);
            __builder.AddAttribute(40, "b-oioz0f36uz");
            __builder.AddContent(41, Icons.SEARCH_ICON);
            __builder.AddMarkupContent(42, "\r\n            ");
            __builder.OpenElement(43, "input");
            __builder.AddAttribute(44, "tabindex", "-1");
            __builder.AddAttribute(45, "aria-autocomplete", "none");
            __builder.AddAttribute(46, "spellcheck", "false");
            __builder.AddAttribute(47, "type", "text");
            __builder.AddAttribute(48, "placeholder", this.Placeholder);
            __builder.AddAttribute(49, "autofocus", "false");
            __builder.AddAttribute<ChangeEventArgs>(50, "oninput", EventCallback.Factory.Create<ChangeEventArgs>((object)this, new Action<ChangeEventArgs>(this.HandleSearch)));
            __builder.AddAttribute<KeyboardEventArgs>(51, "onkeyup", EventCallback.Factory.Create<KeyboardEventArgs>((object)this, new Action<KeyboardEventArgs>(this.HandleKeyUp)));
            __builder.AddEventPreventDefaultAttribute(52, "onkeyup", this.pku);
            __builder.AddAttribute<KeyboardEventArgs>(53, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object)this, new Func<KeyboardEventArgs, Task>(this.HandleKeyDown)));
            __builder.AddEventPreventDefaultAttribute(54, "onkeydown", this.pkd);
            __builder.AddAttribute<FocusEventArgs>(55, "onblur", EventCallback.Factory.Create<FocusEventArgs>((object)this, new Action(this.HideListing)));
            __builder.AddAttribute(56, "value", BindConverter.FormatValue(this.search));
            __builder.AddAttribute<ChangeEventArgs>(57, "onchange", EventCallback.Factory.CreateBinder((object)this, (Action<string>)(__value => this.search = __value), this.search));
            __builder.SetUpdatesAttributeName("value");
            __builder.AddAttribute(58, "b-oioz0f36uz");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(59, "\r\n        \r\n        ");
            __builder.OpenElement(60, "div");
            __builder.AddAttribute(61, "class", "list-items");
            __builder.AddAttribute(62, "b-oioz0f36uz");
            if (this.filterItems != null)
            {
                int num1 = 0;
                foreach (TItem filterItem in this.filterItems)
                {
                    TItem item = filterItem;
                    string textContent1 = this.Display(item);
                    if (textContent1.StartsWith("**") && textContent1.EndsWith("**"))
                    {
                        __builder.OpenElement(63, "b");
                        __builder.AddAttribute(64, "b-oioz0f36uz");
                        RenderTreeBuilder renderTreeBuilder = __builder;
                        string str = textContent1;
                        string textContent2 = str.Substring(2, str.Length - 2 - 2);
                        renderTreeBuilder.AddContent(65, textContent2);
                        __builder.CloseElement();
                    }
                    else if (textContent1 == "-")
                    {
                        __builder.AddMarkupContent(66, "<hr b-oioz0f36uz>");
                    }
                    else
                    {
                        __builder.OpenElement(67, "div");
                        __builder.AddAttribute(68, "class", "item " + (this.itemIndex == num1 ? "selected" : (string)null));
                        __builder.AddAttribute<MouseEventArgs>(69, "onmousedown", EventCallback.Factory.Create<MouseEventArgs>((object)this, (Func<Task>)(() => this.SetItem(item))));
                        __builder.AddAttribute(70, "b-oioz0f36uz");
                        __builder.AddContent(71, textContent1);
                        int num2;
                        if (item != null)
                        {
                            TItem local = item;
                            TItem obj = default;

                            if (obj == null)
                            {
                                obj = local;
                            }

                            // Compare with SelectedItem directly without boxing
                            bool isSelected = EqualityComparer<TItem>.Default.Equals(local, this.SelectedItem);

                            num2 = isSelected ? 1 : 0;
                        }

                        else
                            num2 = 0;
                        if (num2 != 0)
                        {
                            if (this.itemIndex == -1)
                                this.itemIndex = num1;
                            __builder.AddContent(72, Icons.TICK_ICON);
                        }
                        __builder.CloseElement();
                        ++num1;
                    }
                }
                TItem[] filterItems = this.filterItems;
                if ((filterItems != null ? (filterItems.Length == 0 ? 1 : 0) : 0) != 0 && !string.IsNullOrEmpty(this.search) && !this.HideIcon)
                {
                    this.itemIndex = -1;
                    __builder.AddMarkupContent(73, "<div style=\"text-align: center; padding: 2rem; font-size: 14px\" b-oioz0f36uz>\r\n                        No match found.\r\n                    </div>");
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
        public string? Id { get; set; } = "cb" + Guid.NewGuid().ToString();

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public bool HideIcon { get; set; } = false;

        [Parameter]
        public string? AccessKey { get; set; }

        [Parameter]
        public string? Placeholder { get; set; }

        [Parameter]
        public string? Width { get; set; } = "100%";

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

        private bool searchable { get; set; }

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
            scp = (string)null;
        }

        private async Task SetView()
        {
            await Task.Delay(10);
            await this.jsr.InvokeVoidAsync("eval", (object)"document.querySelector('.item.selected')?.scrollIntoView(false)");
        }

        private async Task UpdatePosition()
        {
            string list = ".sbc-ac-list[data-for=\"" + this.Id + "\"]";
            ValueTask<RectBounds> valueTask1 = this.jsr.InvokeAsync<RectBounds>("eval", (object)"document.querySelector('body').getBoundingClientRect()");
            RectBounds window = await valueTask1;
            valueTask1 = this.jsr.InvokeAsync<RectBounds>("eval", (object)("document.querySelector('#" + this.Id + "').getBoundingClientRect()"));
            RectBounds parent = await valueTask1;
            ValueTask<double> valueTask2 = this.jsr.InvokeAsync<double>("eval", (object)("document.querySelector('" + list + "')?.clientWidth"));
            double width = await valueTask2;
            valueTask2 = this.jsr.InvokeAsync<double>("eval", (object)("document.querySelector('" + list + "')?.clientHeight"));
            double height = await valueTask2;
            valueTask2 = this.jsr.InvokeAsync<double>("eval", (object)"window.innerHeight");
            double windowHeight = await valueTask2;
            valueTask2 = this.jsr.InvokeAsync<double>("eval", (object)"document.body.scrollWidth");
            double windowWidth = await valueTask2;
            double right = parent.Left - (width - parent.Width);
            double top = windowHeight - height > parent.Bottom ? parent.Bottom + 4.0 : parent.Top - height - 6.0;
            double left = parent.Left + width > windowWidth ? right : parent.Left;
            string scp = "";
            if (height < windowHeight - parent.Top)
            {
                DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(143, 5);
                interpolatedStringHandler.AppendLiteral("document.querySelector('");
                interpolatedStringHandler.AppendFormatted(list);
                interpolatedStringHandler.AppendLiteral("').style.position = 'fixed'; document.querySelector('");
                interpolatedStringHandler.AppendFormatted(list);
                interpolatedStringHandler.AppendLiteral("').style.top = '");
                interpolatedStringHandler.AppendFormatted<double>(top);
                interpolatedStringHandler.AppendLiteral("px'; document.querySelector('");
                interpolatedStringHandler.AppendFormatted(list);
                interpolatedStringHandler.AppendLiteral("').style.left = '");
                interpolatedStringHandler.AppendFormatted<double>(left);
                interpolatedStringHandler.AppendLiteral("px';");
                scp = interpolatedStringHandler.ToStringAndClear();
            }
            else
            {
                DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(146, 5);
                interpolatedStringHandler.AppendLiteral("document.querySelector('");
                interpolatedStringHandler.AppendFormatted(list);
                interpolatedStringHandler.AppendLiteral("').style.position = 'fixed'; document.querySelector('");
                interpolatedStringHandler.AppendFormatted(list);
                interpolatedStringHandler.AppendLiteral("').style.bottom = '");
                interpolatedStringHandler.AppendFormatted<double>(windowHeight - parent.Top + 4.0);
                interpolatedStringHandler.AppendLiteral("px'; document.querySelector('");
                interpolatedStringHandler.AppendFormatted(list);
                interpolatedStringHandler.AppendLiteral("').style.left = '");
                interpolatedStringHandler.AppendFormatted<double>(left);
                interpolatedStringHandler.AppendLiteral("px';");
                scp = interpolatedStringHandler.ToStringAndClear();
            }
            await this.jsr.InvokeVoidAsync("eval", (object)scp);
            list = (string)null;
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

        private void HandleKeyUp(KeyboardEventArgs args)
        {
            this.pku = false;
            if (!"ArrowUp,ArrowDown,PageUp,PageDown,Home,End".Contains(args.Key))
                ;
        }

        private int GetMaxItems()
        {
            return this.filterItems == null || this.filterItems.Length == 0 ? 0 : ((IEnumerable<TItem>)this.filterItems).Count<TItem>((Func<TItem, bool>)(a => this.Display(a) != "-" && !this.Display(a).StartsWith("**") && !this.Display(a).EndsWith("**")));
        }

        private TItem GetFilteredItem()
        {
            TItem[] filterItems = this.filterItems;
            TItem[] array = filterItems != null ? ((IEnumerable<TItem>)filterItems).Where<TItem>((Func<TItem, bool>)(a => this.Display(a) != "-" && !this.Display(a).StartsWith("**") && !this.Display(a).EndsWith("**"))).ToArray<TItem>() : (TItem[])null;
            return array == null ? default(TItem) : array[this.itemIndex];
        }

        private async Task HandleKeyDown(KeyboardEventArgs args)
        {
            if (this.filterItems == null || this.filterItems.Length == 0)
                return;
            int maxItems = this.GetMaxItems();
            this.pkd = false;
            if (args.Key == "Enter" || args.Key == "Tab")
            {
                this.pkd = true;
                await this.SetItem(this.GetFilteredItem());
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
            int maxItems = this.GetMaxItems();
            if (!(args.Key == "ArrowDown") || this.show != null)
                return;
            this.bkd = true;
            await this.ToggleShow();
            if (this.filterItems != null && maxItems > 0 && this.itemIndex == -1)
                this.itemIndex = 0;
            await this.HandleOnFocus();
        }

        private void HandleSearch(ChangeEventArgs args)
        {
            if (this.show == null)
                return;
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
            if (this.itemIndex == -1)
                this.itemIndex = 0;
        }

        private async Task HandleOnFocus()
        {
            this.search = (string)null;
            this.HandleSearch(new ChangeEventArgs());
            await this.SetView();
        }

        [Inject]
        private IJSRuntime jsr { get; set; } = (IJSRuntime)null;

        [Inject]
        private StateManager sm { get; set; } = (StateManager)null;
    }
}
