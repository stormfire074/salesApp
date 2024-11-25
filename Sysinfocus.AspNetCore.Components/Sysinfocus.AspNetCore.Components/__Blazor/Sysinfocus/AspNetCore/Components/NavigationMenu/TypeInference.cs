// Decompiled with JetBrains decompiler
// Type: __Blazor.Sysinfocus.AspNetCore.Components.NavigationMenu.TypeInference
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

#nullable disable
namespace __Blazor.Sysinfocus.AspNetCore.Components.NavigationMenu
{
  internal static class TypeInference
  {
    public static void CreateCascadingValue_0<TValue>(
      RenderTreeBuilder __builder,
      int seq,
      int __seq0,
      TValue __arg0,
      int __seq1,
      bool __arg1,
      int __seq2,
      RenderFragment __arg2)
    {
      __builder.OpenComponent<CascadingValue<TValue>>(seq);
      __builder.AddComponentParameter(__seq0, "Value", (object) __arg0);
      __builder.AddComponentParameter(__seq1, "IsFixed", (object) __arg1);
      __builder.AddComponentParameter(__seq2, "ChildContent", (object) __arg2);
      __builder.CloseComponent();
    }
  }
}
