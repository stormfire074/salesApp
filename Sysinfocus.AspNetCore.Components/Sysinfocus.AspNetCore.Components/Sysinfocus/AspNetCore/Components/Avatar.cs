// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Avatar
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
  public class Avatar : ComponentBase
  {
    private string? initials;

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      if (!this.Show)
        return;
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-avatar " + this.Size.ToString().ToLower() + " " + (this.Disabled ? "disabled" : (string) null));
      __builder.AddAttribute(2, "style", "background-color: " + this.Background + "; color: " + this.Foreground);
      __builder.AddAttribute<MouseEventArgs>(3, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, this.OnClick));
      __builder.AddAttribute(4, "title", this.Name);
      __builder.AddAttribute(5, "b-0d20zdvh5e");
      if (this.ImageUrl != null)
      {
        __builder.OpenElement(6, "img");
        __builder.AddAttribute(7, "loading", "lazy");
        __builder.AddAttribute(8, "src", this.ImageUrl);
        __builder.AddAttribute(9, "b-0d20zdvh5e");
        __builder.CloseElement();
      }
      else
        __builder.AddContent(10, this.initials);
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    string? Id { get; set; }

    [Parameter]
    public string? Background { get; set; }

    [Parameter]
    public string? Foreground { get; set; }

    [Parameter]
    public string? Name { get; set; }

    [Parameter]
    public string? ImageUrl { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public bool Show { get; set; }

    [Parameter]
    public AvatarSize Size { get; set; }

    [Parameter]
    public EventCallback OnClick { get; set; }

    protected override void OnParametersSet()
    {
      if (this.ImageUrl != null)
        return;
      if (this.Name == null)
      {
        this.initials = ":(";
      }
      else
      {
        string[] strArray1 = this.Name?.ToUpper().Split(' ');
        string stringAndClear;
        if (strArray1.Length <= 1)
        {
          stringAndClear = strArray1[0][0].ToString();
        }
        else
        {
          DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
          interpolatedStringHandler.AppendFormatted<char>(strArray1[0][0]);
          ref DefaultInterpolatedStringHandler local = ref interpolatedStringHandler;
          string[] strArray2 = strArray1;
          int num = (int) strArray2[strArray2.Length - 1][0];
          local.AppendFormatted<char>((char) num);
          stringAndClear = interpolatedStringHandler.ToStringAndClear();
        }
        this.initials = stringAndClear;
      }
    }

    [Inject]
    private StateManager sm { get; set; }

    public Avatar()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
      interpolatedStringHandler.AppendLiteral("avt-");
      interpolatedStringHandler.AppendFormatted<Guid>(Guid.NewGuid());
      // ISSUE: reference to a compiler-generated field
      this.Id = interpolatedStringHandler.ToStringAndClear();
      // ISSUE: reference to a compiler-generated field
      this.Background = "var(--primary-fg)";
      // ISSUE: reference to a compiler-generated field
      this.Foreground = "var(--primary-bg)";
      // ISSUE: reference to a compiler-generated field
      this.Show = true;
      // ISSUE: reference to a compiler-generated field
      this.Size = AvatarSize.Regular;
      this.initials = (string) null;
      // ISSUE: reference to a compiler-generated field
      this.sm = (StateManager) null;
      // ISSUE: explicit constructor call
      base.OnInitialized();
    }
  }
}
