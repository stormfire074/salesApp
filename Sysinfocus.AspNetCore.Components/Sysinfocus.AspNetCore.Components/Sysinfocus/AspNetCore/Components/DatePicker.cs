// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.DatePicker
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
    public class DatePicker : ComponentBase
    {
        private bool show;

        protected override void BuildRenderTree(
#nullable disable
        RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "id", this.Id);
            __builder.AddAttribute(2, "class", "sbc-datepicker " + this.Class);
            __builder.AddAttribute(3, "style", this.Style);
            __builder.AddAttribute(4, "b-seqom3cw9y");
            __builder.OpenComponent<Button>(5);
            __builder.AddComponentParameter(6, "Width", (object)"100%");
            __builder.AddComponentParameter(7, "Icon", (object)"calendar_month");
            RenderTreeBuilder renderTreeBuilder = __builder;
            string placeholder;
            if (this.Date.HasValue)
            {
                DateTime? date = this.Date;
                ref DateTime? local = ref date;
                placeholder = local.HasValue ? local.GetValueOrDefault().ToString(this.Format) : (string)null;
            }
            else
                placeholder = this.Placeholder;
            string str = Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<string>(placeholder);
            renderTreeBuilder.AddComponentParameter(8, "Text", (object)str);
            __builder.AddComponentParameter(9, "Type", (object)Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<ButtonType>(ButtonType.Outline));
            __builder.AddComponentParameter(10, "Id", (object)"btnDate");
            __builder.AddComponentParameter(11, "OnClick", (object)Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object)this, (Action)(() => this.show = !this.show))));
            __builder.CloseComponent();
            if (this.AllowClear && this.Date.HasValue)
            {
                __builder.OpenElement(12, "span");
                __builder.AddAttribute(13, "tabindex", "0");
                __builder.AddAttribute(14, "class", "material-symbols-outlined clear-btn");
                __builder.AddAttribute(15, "style", "font-size: 14px; margin-right: -8px");
                __builder.AddAttribute<MouseEventArgs>(16, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object)this, (Func<Task>)(() => this.HandleClearDate())));
                __builder.AddAttribute<KeyboardEventArgs>(17, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object)this, new Func<KeyboardEventArgs, Task>(this.HandleClearDate)));
                __builder.AddAttribute(18, "b-seqom3cw9y");
                __builder.AddContent(19, "close");
                __builder.CloseElement();
            }
            __builder.OpenComponent<Popover>(20);
            __builder.AddComponentParameter(21, "ParentId", (object)Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<string>(this.Id));
            __builder.AddComponentParameter(22, "Show", (object)Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<bool>(this.show));
            __builder.AddComponentParameter(23, "OnClose", (object)Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback<bool>>(EventCallback.Factory.Create<bool>((object)this, (Action<bool>)(x => this.show = x))));
            __builder.AddAttribute(24, "ChildContent", (RenderFragment)(__builder2 =>
            {
                __builder2.OpenComponent<Calendar>(25);
                __builder2.AddComponentParameter(26, "Date", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<DateTime?>(this.Date));
                __builder2.AddComponentParameter(27, "DateChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback<DateTime?>>(
                    EventCallback.Factory.Create<DateTime?>(this, (Func<DateTime?, Task>)(x => this.Update(x)))
                ));
                __builder2.AddComponentParameter(28, "MinDate", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<DateTime?>(this.MinDate));
                __builder2.AddComponentParameter(29, "MaxDate", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<DateTime?>(this.MaxDate));
                __builder2.CloseComponent();
            }));

            __builder.CloseComponent();
            __builder.CloseElement();
        }

        [Parameter]
        public
#nullable enable
        string? Id
        { get; set; }

        [Parameter]
        public bool AllowClear { get; set; }

        [Parameter]
        public string? Class { get; set; }

        [Parameter]
        public string? Style { get; set; }

        [Parameter]
        public string? Placeholder { get; set; }

        [Parameter]
        public string Format { get; set; }

        [Parameter]
        public bool HideOnDateSelect { get; set; }

        [Parameter]
        public DateTime? Date { get; set; }

        [Parameter]
        public DateTime? MinDate { get; set; }

        [Parameter]
        public DateTime? MaxDate { get; set; }

        [Parameter]
        public EventCallback<DateTime?> DateChanged { get; set; }

        private async Task Update(DateTime? d)
        {
            this.Date = d;
            await this.DateChanged.InvokeAsync(this.Date);
            if (!this.HideOnDateSelect)
                return;
            this.show = false;
        }

        private async Task HandleClearDate(KeyboardEventArgs? args = null)
        {
            if (args != null && !(args.Key == "Enter") && !(args.Key == " "))
                return;
            this.Date = new DateTime?();
            await this.DateChanged.InvokeAsync(this.Date);
            this.show = false;
        }

        [Inject]
        private IJSRuntime jsr { get; set; }

        [Inject]
        private StateManager sm { get; set; }

        public DatePicker()
        {
            DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
            interpolatedStringHandler.AppendLiteral("dp-");
            interpolatedStringHandler.AppendFormatted<Guid>(Guid.NewGuid());
            // ISSUE: reference to a compiler-generated field
            this.Id = interpolatedStringHandler.ToStringAndClear();
            // ISSUE: reference to a compiler-generated field
            this.AllowClear = true;
            // ISSUE: reference to a compiler-generated field
            this.Placeholder = "Pick a date";
            // ISSUE: reference to a compiler-generated field
            this.Format = "MMMM d, yyyy";
            // ISSUE: reference to a compiler-generated field
            this.HideOnDateSelect = true;
            // ISSUE: reference to a compiler-generated field
            this.jsr = (IJSRuntime)null;
            // ISSUE: reference to a compiler-generated field
            this.sm = (StateManager)null;
            // ISSUE: explicit constructor call
            base.OnInitialized();
        }
    }
}
