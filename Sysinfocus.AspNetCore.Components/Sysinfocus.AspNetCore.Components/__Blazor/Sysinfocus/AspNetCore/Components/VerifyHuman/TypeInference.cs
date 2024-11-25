// Decompiled with JetBrains decompiler
// Type: __Blazor.Sysinfocus.AspNetCore.Components.VerifyHuman.TypeInference
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Sysinfocus.AspNetCore.Components;
using System.Collections.Generic;

#nullable disable
namespace __Blazor.Sysinfocus.AspNetCore.Components.VerifyHuman
{
  internal static class TypeInference
  {
    public static void CreateSortable_0<TItem>(
      RenderTreeBuilder __builder,
      int seq,
      int __seq0,
      List<TItem> __arg0,
      int __seq1,
      string __arg1,
      int __seq2,
      string __arg2,
      int __seq3,
      string __arg3,
      int __seq4,
      bool __arg4,
      int __seq5,
      int __arg5,
      int __seq6,
      string __arg6,
      int __seq7,
      string __arg7,
      int __seq8,
      string __arg8,
      int __seq9,
      EventCallback<(int oldIndex, int newIndex, string from, string to)> __arg9,
      int __seq10,
      RenderFragment<TItem> __arg10)
    {
      __builder.OpenComponent<Sortable<TItem>>(seq);
      __builder.AddComponentParameter(__seq0, "Items", (object) __arg0);
      __builder.AddComponentParameter(__seq1, "Group", (object) __arg1);
      __builder.AddComponentParameter(__seq2, "Id", (object) __arg2);
      __builder.AddComponentParameter(__seq3, "DragClass", (object) __arg3);
      __builder.AddComponentParameter(__seq4, "Register", (object) __arg4);
      __builder.AddComponentParameter(__seq5, "SortDelay", (object) __arg5);
      __builder.AddComponentParameter(__seq6, "Class", (object) __arg6);
      __builder.AddComponentParameter(__seq7, "Width", (object) __arg7);
      __builder.AddComponentParameter(__seq8, "Style", (object) __arg8);
      __builder.AddComponentParameter(__seq9, "OnInsert", (object) __arg9);
      __builder.AddComponentParameter(__seq10, "SortableItemTemplate", (object) __arg10);
      __builder.CloseComponent();
    }

    public static void CreateSortable_1<TItem>(
      RenderTreeBuilder __builder,
      int seq,
      int __seq0,
      List<TItem> __arg0,
      int __seq1,
      string __arg1,
      int __seq2,
      string __arg2,
      int __seq3,
      string __arg3,
      int __seq4,
      bool __arg4,
      int __seq5,
      string __arg5,
      int __seq6,
      string __arg6,
      int __seq7,
      string __arg7,
      int __seq8,
      EventCallback<(int oldIndex, int newIndex, string from, string to)> __arg8,
      int __seq9,
      RenderFragment<TItem> __arg9)
    {
      __builder.OpenComponent<Sortable<TItem>>(seq);
      __builder.AddComponentParameter(__seq0, "Items", (object) __arg0);
      __builder.AddComponentParameter(__seq1, "Group", (object) __arg1);
      __builder.AddComponentParameter(__seq2, "Id", (object) __arg2);
      __builder.AddComponentParameter(__seq3, "DragClass", (object) __arg3);
      __builder.AddComponentParameter(__seq4, "Sort", (object) __arg4);
      __builder.AddComponentParameter(__seq5, "Class", (object) __arg5);
      __builder.AddComponentParameter(__seq6, "Width", (object) __arg6);
      __builder.AddComponentParameter(__seq7, "Height", (object) __arg7);
      __builder.AddComponentParameter(__seq8, "OnInsert", (object) __arg8);
      __builder.AddComponentParameter(__seq9, "SortableItemTemplate", (object) __arg9);
      __builder.CloseComponent();
    }
  }
}
