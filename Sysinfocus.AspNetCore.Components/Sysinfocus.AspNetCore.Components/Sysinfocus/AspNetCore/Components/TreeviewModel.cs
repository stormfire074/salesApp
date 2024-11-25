// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.TreeviewModel
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using System.Runtime.CompilerServices;
using System.Text;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public record TreeviewModel(int Id, int ParentId, string Text, string Icon)
  {
    public int Id { get; init; } = Id;

    public int ParentId { get; init; } = ParentId;

    public string Text { get; init; } = Text;

    public string Icon { get; init; } = Icon;

    public int Sequence { get; set; } = 0;

    public bool Disabled { get; set; }

    public bool Collapsed { get; set; }

    public string AlternateIcon { get; set; } = Icon;

    public string? Class { get; set; }

    public string? Style { get; set; }

    public int Level { get; set; } = -1;

    public bool IsParent { get; set; }

    [CompilerGenerated]
    protected virtual bool PrintMembers(StringBuilder builder)
    {
      RuntimeHelpers.EnsureSufficientExecutionStack();
      builder.Append("Id = ");
      builder.Append(this.Id.ToString());
      builder.Append(", ParentId = ");
      builder.Append(this.ParentId.ToString());
      builder.Append(", Text = ");
      builder.Append((object) this.Text);
      builder.Append(", Icon = ");
      builder.Append((object) this.Icon);
      builder.Append(", Sequence = ");
      builder.Append(this.Sequence.ToString());
      builder.Append(", Disabled = ");
      builder.Append(this.Disabled.ToString());
      builder.Append(", Collapsed = ");
      builder.Append(this.Collapsed.ToString());
      builder.Append(", AlternateIcon = ");
      builder.Append((object) this.AlternateIcon);
      builder.Append(", Class = ");
      builder.Append((object) this.Class);
      builder.Append(", Style = ");
      builder.Append((object) this.Style);
      builder.Append(", Level = ");
      builder.Append(this.Level.ToString());
      builder.Append(", IsParent = ");
      builder.Append(this.IsParent.ToString());
      return true;
    }
  }
}
