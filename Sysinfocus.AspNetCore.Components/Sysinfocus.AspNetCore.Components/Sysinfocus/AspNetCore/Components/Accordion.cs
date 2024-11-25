using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Runtime.CompilerServices;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
    public class Accordion : ComponentBase
    {
        protected override void BuildRenderTree(RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "id", this.Id);
            __builder.AddAttribute(2, "class", "sbc-accordion " + this.Class);
            __builder.AddAttribute(3, "style", this.Style);
            __builder.AddAttribute(4, "b-r2j58ysol1");
            __builder.AddContent(5, this.ChildContent);
            __builder.CloseElement();
        }

        [Parameter]
        public string? Class { get; set; }

        [Parameter]
        public string? Style { get; set; }

        [Parameter]
        public string? Id { get; set; }

        [Parameter]
        [EditorRequired]
        public RenderFragment? ChildContent { get; set; }

        protected override void OnInitialized()
        {
            if (this.ChildContent == null)
                throw new ArgumentNullException("At least one AccordionItem is required.");
        }

        [Inject]
        private BrowserExtensions? Be { get; set; }

        [Inject]
        private StateManager? Sm { get; set; }

        public Accordion()
        {
            DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
            interpolatedStringHandler.AppendLiteral("ac-");
            interpolatedStringHandler.AppendFormatted<Guid>(Guid.NewGuid());
            Id = interpolatedStringHandler.ToStringAndClear();

            Be = null;
            Sm = null;

            // Explicit constructor call
            base.OnInitialized();
        }
    }
}
