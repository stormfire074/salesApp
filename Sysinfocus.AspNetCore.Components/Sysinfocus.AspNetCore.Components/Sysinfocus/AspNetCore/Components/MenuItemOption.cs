// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.MenuItemOption
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using System.Runtime.CompilerServices;
using System.Text;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public record MenuItemOption(
    string Text,
    string? Shortcut = null,
    string? Icon = null,
    string? RadioGroup = null,
    MenuType MenuType = MenuType.Normal)
  {
    public string Text { get; init; } = Text;

    public string? Shortcut { get; init; } = Shortcut;

    public string? Icon { get; init; } = Icon;

    public string? RadioGroup { get; init; } = RadioGroup;

    public MenuType MenuType { get; init; } = MenuType;

    public bool Checked { get; set; }

    public bool Disabled { get; set; }

    public bool ShowCheckmark { get; set; } = true;

    public bool IsHeader { get; set; }

    public string? Value { get; set; }

    [CompilerGenerated]
    protected virtual bool PrintMembers(StringBuilder builder)
    {
      RuntimeHelpers.EnsureSufficientExecutionStack();
      builder.Append("Text = ");
      builder.Append((object) this.Text);
      builder.Append(", Shortcut = ");
      builder.Append((object) this.Shortcut);
      builder.Append(", Icon = ");
      builder.Append((object) this.Icon);
      builder.Append(", RadioGroup = ");
      builder.Append((object) this.RadioGroup);
      builder.Append(", MenuType = ");
      builder.Append(this.MenuType.ToString());
      builder.Append(", Checked = ");
      builder.Append(this.Checked.ToString());
      builder.Append(", Disabled = ");
      builder.Append(this.Disabled.ToString());
      builder.Append(", ShowCheckmark = ");
      builder.Append(this.ShowCheckmark.ToString());
      builder.Append(", IsHeader = ");
      builder.Append(this.IsHeader.ToString());
      builder.Append(", Value = ");
      builder.Append((object) this.Value);
      return true;
    }
  }
}
