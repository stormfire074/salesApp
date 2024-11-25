// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Sonner
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
  public class Sonner : ComponentBase
  {
    private string cls = "show";

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      if (!this.Show)
        return;
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-sonner " + this.cls);
      __builder.AddAttribute(2, "b-1muo9l3izn");
      __builder.OpenElement(3, "div");
      __builder.AddAttribute(4, "class", "sbc-sonner-content");
      __builder.AddAttribute(5, "b-1muo9l3izn");
      __builder.OpenElement(6, "b");
      __builder.AddAttribute(7, "b-1muo9l3izn");
      __builder.AddContent(8, this.Title);
      __builder.CloseElement();
      __builder.AddMarkupContent(9, "\r\n        ");
      __builder.OpenElement(10, "p");
      __builder.AddAttribute(11, "b-1muo9l3izn");
      __builder.AddContent(12, this.Description);
      __builder.CloseElement();
      __builder.CloseElement();
      __builder.AddMarkupContent(13, "\r\n    ");
      __builder.OpenComponent<Button>(14);
      __builder.AddComponentParameter(15, "Text", (object) RuntimeHelpers.TypeCheck<string>(this.ActionName));
      __builder.AddComponentParameter(16, "Size", (object) RuntimeHelpers.TypeCheck<ButtonSize>(ButtonSize.Small));
      __builder.AddComponentParameter(17, "OnClick", (object) RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, new Func<Task>(this.HandleClick))));
      __builder.CloseComponent();
      __builder.CloseElement();
    }

    [Parameter]
    public bool Show { get; set; }

    [Parameter]
    public 
    #nullable enable
    string Title { get; set; } = "Your Title";

    [Parameter]
    public string Description { get; set; } = "Here goes your description...";

    [Parameter]
    public string ActionName { get; set; } = "OK";

    [Parameter]
    public EventCallback OnActionClick { get; set; }

    protected override async Task OnParametersSetAsync()
    {
      if (this.Show && this.cls != "show")
        this.cls = "show";
      await Task.Delay(5000);
      this.cls = "hide";
    }

    private async Task HandleClick()
    {
      this.cls = "hide";
      await Task.Delay(300);
      this.Show = false;
      this.cls = "show";
      await this.OnActionClick.InvokeAsync();
    }

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
