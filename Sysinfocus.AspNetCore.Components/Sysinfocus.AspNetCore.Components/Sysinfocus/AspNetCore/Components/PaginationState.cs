// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.PaginationState
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using System;

#nullable disable
namespace Sysinfocus.AspNetCore.Components
{
  public class PaginationState
  {
    public int CurrentPage { get; set; }

    public int TotalRecords { get; set; }

    public int PageSize { get; set; } = 15;

    public int TotalPages
    {
      get
      {
        return this.TotalRecords <= 0 || this.PageSize <= 0 ? 0 : (int) Math.Ceiling((double) this.TotalRecords / (double) this.PageSize);
      }
    }
  }
}
