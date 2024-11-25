// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Icons
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;

#nullable disable
namespace Sysinfocus.AspNetCore.Components
{
  public static class Icons
  {
    public static MarkupString CHEVRON_DOWN = new MarkupString("<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\"><path d=\"m6 9 6 6 6-6\"></path></svg>");

    public static MarkupString CHEVRON_UP_DOWN
    {
      get
      {
        return new MarkupString("<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" fill=\"none\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\"><path d=\"m7 15 5 5 5-5\"></path><path d=\"m7 9 5-5 5 5\"></path></svg>");
      }
    }

    public static MarkupString SEARCH_ICON
    {
      get
      {
        return new MarkupString("<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"black\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\"><circle cx=\"11\" cy=\"11\" r=\"8\"></circle><path d=\"m21 21-4.3-4.3\"></path></svg>");
      }
    }

    public static MarkupString TICK_ICON
    {
      get
      {
        return new MarkupString("<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"black\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\"><path d=\"M20 6 9 17l-5-5\"></path></svg>");
      }
    }
  }
}
