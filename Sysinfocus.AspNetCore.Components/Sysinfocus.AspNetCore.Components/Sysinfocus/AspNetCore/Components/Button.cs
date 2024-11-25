// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Button
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Runtime.CompilerServices;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class Button : ComponentBase
  {
    private string? _class;
    private string? _style;

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "button");
      __builder.AddAttribute(1, "accesskey", this.AccessKey);
      __builder.AddAttribute(2, "type", this.Action.ToString().ToLower());
      __builder.AddAttribute(3, "id", this.Id);
      __builder.AddAttribute(4, "class", this._class);
      __builder.AddAttribute(5, "style", this._style);
      __builder.AddAttribute<MouseEventArgs>(6, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, this.OnClick));
      __builder.AddAttribute(7, "disabled", this.Disabled);
      __builder.AddAttribute(8, "title", this.Tooltip);
      __builder.AddAttribute(9, "b-dxlcnpbuql");
      if (this.ChildContent != null)
        __builder.AddContent(10, this.ChildContent);
      else if (this.Icon != null && this.ChildContent == null && this.IconPositionRight)
      {
        __builder.AddContent(11, this.Text);
        __builder.AddContent(12, " ");
        __builder.OpenElement(13, "span");
        __builder.AddAttribute(14, "class", "material-symbols-outlined");
        __builder.AddAttribute(15, "b-dxlcnpbuql");
        __builder.AddContent(16, this.Icon);
        __builder.CloseElement();
      }
      else if (this.Type == ButtonType.Icon || this.Icon != null)
      {
        __builder.OpenElement(17, "span");
        __builder.AddAttribute(18, "class", "material-symbols-outlined");
        __builder.AddAttribute(19, "b-dxlcnpbuql");
        __builder.AddContent(20, this.Icon);
        __builder.CloseElement();
      }
      else if (this.Type == ButtonType.Loading)
        __builder.AddMarkupContent(21, "<span class=\"rotate material-symbols-outlined\" b-dxlcnpbuql>progress_activity</span>");
      if (this.Type != ButtonType.Icon && this.ChildContent == null && !this.IconPositionRight)
        __builder.AddContent(22, this.Text);
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    string? Id { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public string? AccessKey { get; set; }

    [Parameter]
    public string? Tooltip { get; set; }

    [Parameter]
    public string? Text { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public string? Icon { get; set; }

    [Parameter]
    public string? Width { get; set; }

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Parameter]
    public ButtonAction Action { get; set; }

    [Parameter]
    public ButtonType Type { get; set; }

    [Parameter]
    public ButtonSize Size { get; set; }

    [Parameter]
    public EventCallback OnClick { get; set; }

    [Parameter]
    public bool IconPositionRight { get; set; }

    protected override void OnParametersSet()
    {
      if (this.Type == ButtonType.Icon)
        this.Width = "36px";
      else if (this.Type == ButtonType.Loading)
        this.Disabled = true;
      this._class = "sbc-button ".AppendTo(this.Type.ToString().ToLower()).AppendTo(this.Size.ToString().ToLower()).AppendTo(this.Class);
      this._style = "width:".AppendTo(this.Width, ';').AppendTo(this.Style);
    }

    [Inject]
    private StateManager sm { get; set; }

    public Button()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
      interpolatedStringHandler.AppendLiteral("btn-");
      interpolatedStringHandler.AppendFormatted<Guid>(Guid.NewGuid());
      // ISSUE: reference to a compiler-generated field
      this.Id = interpolatedStringHandler.ToStringAndClear();
      // ISSUE: reference to a compiler-generated field
      this.Width = "fit-content";
      // ISSUE: reference to a compiler-generated field
      this.Action = ButtonAction.Button;
      // ISSUE: reference to a compiler-generated field
      this.Type = ButtonType.Primary;
      // ISSUE: reference to a compiler-generated field
      this.Size = ButtonSize.Regular;
      // ISSUE: reference to a compiler-generated field
      this.sm = (StateManager) null;
      // ISSUE: explicit constructor call
      base.OnInitialized();
    }
  }
}
