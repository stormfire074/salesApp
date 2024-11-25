// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.ComponentExtension
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using System;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  internal static class ComponentExtension
  {
    public static string ASSEMBLY_NAME = "Sysinfocus.AspNetCore.Components";
    public static string MATCH = "9599465319";

    public static bool Matches(this string commaSeparatedString, string toMatch)
    {
      foreach (string str in commaSeparatedString.Split(','))
      {
        if (str.Trim().Equals(toMatch, StringComparison.OrdinalIgnoreCase))
          return true;
      }
      return false;
    }
  }
}
