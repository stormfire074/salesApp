// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.HoverCard
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using System.Runtime.CompilerServices;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
    public class HoverCard : ComponentBase
    {
        private bool show;

        protected override void BuildRenderTree(
#nullable disable
        RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", this.Class);
            __builder.AddAttribute(2, "style", this.Style);
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "id", this.Id);
            __builder.AddAttribute<MouseEventArgs>(5, "onmouseenter", EventCallback.Factory.Create<MouseEventArgs>((object)this, new Func<Task>(this.HandleMouseOver)));
            __builder.AddAttribute<MouseEventArgs>(6, "onmouseout", EventCallback.Factory.Create<MouseEventArgs>((object)this, new Action(this.HandleMouseOut)));
            __builder.AddContent(7, this.HoverCardElement);
            __builder.CloseElement();
            __builder.AddMarkupContent(8, "\r\n    ");
            __builder.OpenComponent<Popover>(9);
            __builder.AddComponentParameter(10, "Show", (object)Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<bool>(this.show));
            __builder.AddComponentParameter(11, "ParentId", (object)Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<string>(this.Id));
            __builder.AddAttribute(12, "ChildContent", (RenderFragment)(__builder2 => __builder2.AddContent(13, this.HoverCardToggle)));
            __builder.CloseComponent();
            __builder.CloseElement();
        }

        [Parameter]
        public
#nullable enable
        RenderFragment? HoverCardElement
        { get; set; }

        [Parameter]
        public RenderFragment? HoverCardToggle { get; set; }

        [Parameter]
        public string? Id { get; set; }

        [Parameter]
        public string? Class { get; set; }

        [Parameter]
        public string? Style { get; set; }

        private async Task HandleMouseOver()
        {
            await Task.Delay(500);
            this.show = true;
        }

        private void HandleMouseOut() => this.show = false;

        [Inject]
        private StateManager sm { get; set; }

        public HoverCard()
        {
            DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
            interpolatedStringHandler.AppendLiteral("hc-");
            interpolatedStringHandler.AppendFormatted<Guid>(Guid.NewGuid());
            // ISSUE: reference to a compiler-generated field
            this.Id = interpolatedStringHandler.ToStringAndClear();
            // ISSUE: reference to a compiler-generated field
            this.sm = (StateManager)null;
            // ISSUE: explicit constructor call
            base.OnInitialized();
        }
    }
}
