// Decompiled with JetBrains decompiler
// Type: __Blazor.Sysinfocus.AspNetCore.Components.DataTable.TypeInference
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using System.Collections.Generic;

#nullable disable
namespace __Blazor.Sysinfocus.AspNetCore.Components.DataTable
{
  internal static class TypeInference
  {
    public static void CreateVirtualize_0<TItem>(
      RenderTreeBuilder __builder,
      int seq,
      int __seq0,
      ICollection<TItem> __arg0,
      int __seq1,
      float __arg1,
      int __seq2,
      RenderFragment<TItem> __arg2)
    {
      __builder.OpenComponent<Virtualize<TItem>>(seq);
      __builder.AddComponentParameter(__seq0, "Items", (object) __arg0);
      __builder.AddComponentParameter(__seq1, "ItemSize", (object) __arg1);
      __builder.AddComponentParameter(__seq2, "ChildContent", (object) __arg2);
      __builder.CloseComponent();
    }

    public static void CreateCascadingValue_1<TValue>(
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

    public static void CreateCascadingValue_2<TValue>(
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
