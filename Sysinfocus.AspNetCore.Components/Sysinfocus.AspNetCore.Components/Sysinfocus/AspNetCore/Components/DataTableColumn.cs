// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.DataTableColumn`1
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.CompilerServices;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using System.Linq.Expressions;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
    public class DataTableColumn<TItem> : ComponentBase
    {
        private string? headerStyle;

        protected override void BuildRenderTree(
#nullable disable
        RenderTreeBuilder __builder)
        {
            if (this.Property != null && (object)this.Item == null)
            {
                __builder.OpenElement(0, "th");
                __builder.AddAttribute(1, "class", (this.Freeze != null ? "freeze" : (string)null) + " " + this.Align.ToString()?.ToLower() + " " + this.HeaderClass + " " + (this.SortOn?.Header == this.GetHeader() ? "sorted" : (string)null));
                __builder.AddAttribute(2, "style", "--freezeWidth:" + this.Freeze + ";" + this.headerStyle + ";" + this.HeaderStyle);
                __builder.AddContent(3, this.GetHeader());
                if (this.SortOn != null)
                {
                    __builder.OpenComponent<Icon>(4);
                    __builder.AddComponentParameter(5, "Tooltip", (object)"Toggle Sort");
                    __builder.AddComponentParameter(6, "Name", (object)"swap_vert");
                    __builder.AddComponentParameter(7, "Size", (object)"14px");
                    __builder.AddComponentParameter(8, "Color", (object)RuntimeHelpers.TypeCheck<string>(this.SortOn?.Header == this.GetHeader() ? "sorted" : (string)null));
                    __builder.AddComponentParameter(9, "Style", (object)"margin-left: 8px; margin-top: 2px;");
                    __builder.AddComponentParameter(10, "OnClick", (object)RuntimeHelpers.TypeCheck<EventCallback<MouseEventArgs>>(EventCallback.Factory.Create<MouseEventArgs>((object)this, (Func<Task>)(() => this.HandleSorting(this.GetHeader())))));
                    __builder.CloseComponent();
                }
                __builder.CloseElement();
            }
            else
            {
                if ((object)this.Item == null)
                    return;
                if (this.Template != null)
                {
                    __builder.OpenElement(11, "td");
                    __builder.AddAttribute(12, "class", (this.Freeze != null ? "freeze" : (string)null) + " " + this.Align.ToString()?.ToLower() + " " + this.Class);
                    __builder.AddAttribute(13, "style", "--freezeWidth:" + this.Freeze + ";" + this.Style);
                    __builder.AddContent(14, this.Template);
                    __builder.CloseElement();
                }
                else if (this.Property != null && (object)this.Item != null)
                {
                    __builder.OpenElement(15, "td");
                    __builder.AddAttribute(16, "class", (this.Freeze != null ? "freeze" : (string)null) + " " + this.Align.ToString()?.ToLower() + " " + this.Class);
                    __builder.AddAttribute(17, "style", "--freezeWidth:" + this.Freeze + ";" + this.Style);
                    __builder.AddContent(18, this.GetValue(this.Item));
                    __builder.CloseElement();
                }
            }
        }

        [CascadingParameter]
        private
#nullable enable
        TItem? Item
        { get; set; }

        [Parameter]
        public string? Freeze { get; set; }

        [Parameter]
        public string? HeaderClass { get; set; }

        [Parameter]
        public string? HeaderStyle { get; set; }

        [Parameter]
        public string? Class { get; set; }

        [Parameter]
        public string? Style { get; set; }

        [Parameter]
        public string Header { get; set; } = (string)null;

        [Parameter]
        public string? Format { get; set; }

        [Parameter]
        public string? Width { get; set; }

        [Parameter]
        public string? Padding { get; set; } = "12px";

        [Parameter]
        public Expression<Func<TItem, object>>? Property { get; set; }

        [Parameter]
        public Alignment? Align { get; set; } = new Alignment?(Alignment.Left);

        [Parameter]
        public RenderFragment<TItem>? ChildContent { get; set; }

        [Parameter]
        public RenderFragment? Template { get; set; }

        [Parameter]
        public SortModel? SortOn { get; set; }

        [Parameter]
        public EventCallback<SortModel> OnSort { get; set; }

        protected override void OnInitialized()
        {
            if (this.Width != null)
                this.headerStyle = "width: " + this.Width;
            if (this.Padding == null)
                return;
            this.Style = this.Style + ";padding: " + this.Padding + ";";
        }

        private string GetHeader()
        {
            if (this.Header == null && this.Property != null)
            {
                MemberExpression operand = null;

                if (this.Property.Body is UnaryExpression body1 && body1.Operand is MemberExpression unaryOperand)
                {
                    operand = unaryOperand;
                }
                else if (this.Property.Body is MemberExpression body2)
                {
                    operand = body2;
                }

                if (operand != null)
                {
                    return operand.Member.Name;
                }
            }
            else if (this.Header != null)
            {
                return this.Header;
            }

            return string.Empty;
        }


        private string GetValue(TItem item)
        {
            if (this.Property == null || (object)item == null)
                return string.Empty;
            if (this.Format != null)
                return ((IFormattable)this.Property.Compile()(item)).ToString(this.Format, (IFormatProvider)null);
            return (object)this.Item != null ? this.Property.Compile()(this.Item).ToString() : string.Empty;
        }

        private async Task HandleSorting(string sortProperty)
        {
            if (this.SortOn == null)
                return;

            this.SortOn.Header = sortProperty;
            this.SortOn.IsAscending = !this.SortOn.IsAscending;

            await this.OnSort.InvokeAsync(this.SortOn);

            // Call StateHasChanged directly without casting
            StateHasChanged();
        }


        [Inject]
        private StateManager sm { get; set; } = (StateManager)null;
    }
}
