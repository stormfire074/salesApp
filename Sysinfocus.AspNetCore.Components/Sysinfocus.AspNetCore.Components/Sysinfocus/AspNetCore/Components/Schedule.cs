// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Schedule
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using System;

#nullable disable
namespace Sysinfocus.AspNetCore.Components
{
  public class Schedule
  {
    public Guid Id { get; set; }

    public DateTime On { get; set; }

    public bool IsMarked { get; set; }

    public bool IsPast => this.On < DateTime.Now;
  }
}
