// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.RadioGroupItem
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
    public class RadioGroupItem : ComponentBase
    {
        private bool pd = false;

        protected override void BuildRenderTree(
#nullable disable
        RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "label");
            __builder.AddAttribute(1, "class", "sbc-radio-item");
            __builder.AddAttribute(2, "for", this.Parent.Name + this.Value);
            __builder.AddAttribute<KeyboardEventArgs>(3, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object)this, new Func<KeyboardEventArgs, Task>(this.HandleKeyDown)));
            __builder.AddEventPreventDefaultAttribute(4, "onkeydown", this.pd);
            __builder.OpenElement(5, "input");
            __builder.AddAttribute(6, "type", "radio");
            __builder.AddAttribute(7, "id", this.Parent.Name + this.Value);
            __builder.AddAttribute(8, "value", this.Value);
            __builder.AddAttribute(9, "name", this.Parent.Name);
            __builder.AddAttribute(10, "checked", this.Checked);
            __builder.CloseElement();
            __builder.AddMarkupContent(11, "\r\n    ");
            __builder.AddMarkupContent(12, "<span class=\"sbc-radio-check-mark\"><svg xmlns=\"http://www.w3.org/2000/svg\" width=\"14\" height=\"14\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"var(--primary-fg)\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\"><path d=\"M20 6 9 17l-5-5\"></path></svg></span>\r\n    ");
            __builder.AddContent(13, this.Label);
            __builder.CloseElement();
        }

        [CascadingParameter]
        private
#nullable enable
        RadioGroup Parent
        { get; set; } = (RadioGroup)null;

        [Parameter]
        public string For { get; set; } = string.Empty;

        [Parameter]
        [EditorRequired]
        public string Value { get; set; } = string.Empty;

        [Parameter]
        [EditorRequired]
        public string Label { get; set; } = string.Empty;

        [Parameter]
        public bool Checked { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        private async Task HandleKeyDown(KeyboardEventArgs args)
        {
            this.pd = true;

            if (args.Key == " ")
            {
                if (this.Disabled)
                    return;

                this.Checked = true;
                StateHasChanged(); // Directly invoke the method
            }
            else
            {
                if (args.Key != "Tab" && args.Key != "ArrowUp" && args.Key != "ArrowDown")
                    return;

                this.pd = false;
            }
        }


        [Inject]
        private StateManager sm { get; set; } = (StateManager)null;
    }
}
