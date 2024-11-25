// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Toast
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
  public class Toast : ComponentBase
  {
    private string show = nameof (show);

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      if (!this.Show)
        return;
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-toast " + this.show);
      __builder.AddAttribute(2, "style", this.Style);
      __builder.AddAttribute(3, "b-zz5e4w4zxv");
      __builder.AddContent(4, this.ChildContent);
      __builder.AddMarkupContent(5, "\r\n    ");
      __builder.OpenComponent<Button>(6);
      __builder.AddComponentParameter(7, "Icon", (object) "close");
      __builder.AddComponentParameter(8, "Type", (object) RuntimeHelpers.TypeCheck<ButtonType>(ButtonType.Ghost));
      __builder.AddComponentParameter(9, "Class", (object) "small toast-close");
      __builder.AddComponentParameter(10, "OnClick", (object) RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, new Func<Task>(this.HandleClose))));
      __builder.CloseComponent();
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    RenderFragment? ChildContent { get; set; }

    [Parameter]
    public bool Show { get; set; }

    [Parameter]
    public string? Style { get; set; }

    private async Task HandleClose()
    {
      this.show = "hide";
      await Task.Delay(300);
      this.Show = false;
      this.show = "show";
    }

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
