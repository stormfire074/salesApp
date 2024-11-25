// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Editor
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class Editor : ComponentBase
  {
    private string? fc;
    private string? bc;

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-editor " + this.Class);
      __builder.AddAttribute(2, "style", this.Style);
      __builder.AddAttribute(3, "id", this.Id);
      __builder.AddAttribute(4, "b-dn6bos3dew");
      if (!InitializeSysinfocus.IsLicensed)
        __builder.AddMarkupContent(5, "<small class=\"mtb1 ta-center\" b-dn6bos3dew>You are using a trial version.</small>");
      if (this.ShowUndoRedo || this.ShowCutCopyPaste || this.ShowAlignments || this.ShowTextFormatting || this.ShowListings || this.ShowColors || this.ShowHeadings || this.ShowExtras)
      {
        __builder.OpenElement(6, "div");
        __builder.AddAttribute(7, "class", "sbc-editor-toolbar " + (this.WrapOverflow ? "wrap" : (string) null));
        __builder.AddAttribute(8, "style", this.WrapOverflow ? (string) null : "overflow-x: auto");
        __builder.AddAttribute(9, "b-dn6bos3dew");
        if (this.ShowUndoRedo)
        {
          __builder.OpenComponent<Button>(10);
          __builder.AddComponentParameter(11, "Class", (object) "ghost");
          __builder.AddComponentParameter(12, "Style", (object) "padding: 8px");
          __builder.AddComponentParameter(13, "Tooltip", (object) "Undo");
          __builder.AddComponentParameter(14, "Icon", (object) "undo");
          __builder.AddComponentParameter(15, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (async () => await this.InvokeButton("undo")))));
          __builder.CloseComponent();
          __builder.AddMarkupContent(16, "\r\n        ");
          __builder.OpenComponent<Button>(17);
          __builder.AddComponentParameter(18, "Class", (object) "ghost");
          __builder.AddComponentParameter(19, "Style", (object) "padding: 8px");
          __builder.AddComponentParameter(20, "Tooltip", (object) "Redo");
          __builder.AddComponentParameter(21, "Icon", (object) "redo");
          __builder.AddComponentParameter(22, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (async () => await this.InvokeButton("redo")))));
          __builder.CloseComponent();
          __builder.AddMarkupContent(23, "\r\n        ");
          __builder.OpenComponent<Separator>(24);
          __builder.AddComponentParameter(25, "Vertical", (object) true);
          __builder.CloseComponent();
        }
        if (this.ShowCutCopyPaste)
        {
          __builder.OpenComponent<Button>(26);
          __builder.AddComponentParameter(27, "Class", (object) "ghost");
          __builder.AddComponentParameter(28, "Style", (object) "padding: 8px");
          __builder.AddComponentParameter(29, "Tooltip", (object) "Cut");
          __builder.AddComponentParameter(30, "Icon", (object) "content_cut");
          __builder.AddComponentParameter(31, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (async () => await this.InvokeButton("cut")))));
          __builder.CloseComponent();
          __builder.AddMarkupContent(32, "\r\n        ");
          __builder.OpenComponent<Button>(33);
          __builder.AddComponentParameter(34, "Class", (object) "ghost");
          __builder.AddComponentParameter(35, "Style", (object) "padding: 8px");
          __builder.AddComponentParameter(36, "Tooltip", (object) "Copy");
          __builder.AddComponentParameter(37, "Icon", (object) "content_copy");
          __builder.AddComponentParameter(38, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (async () => await this.InvokeButton("copy")))));
          __builder.CloseComponent();
          __builder.AddMarkupContent(39, "\r\n        ");
          __builder.OpenComponent<Button>(40);
          __builder.AddComponentParameter(41, "Class", (object) "ghost");
          __builder.AddComponentParameter(42, "Style", (object) "padding: 8px");
          __builder.AddComponentParameter(43, "Tooltip", (object) "Paste");
          __builder.AddComponentParameter(44, "Icon", (object) "content_paste");
          __builder.AddComponentParameter(45, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (async () => await this.InvokeButton("paste")))));
          __builder.CloseComponent();
          __builder.AddMarkupContent(46, "\r\n        ");
          __builder.OpenComponent<Separator>(47);
          __builder.AddComponentParameter(48, "Vertical", (object) true);
          __builder.CloseComponent();
        }
        if (this.ShowAlignments)
        {
          __builder.OpenComponent<Button>(49);
          __builder.AddComponentParameter(50, "Class", (object) "ghost");
          __builder.AddComponentParameter(51, "Style", (object) "padding: 8px");
          __builder.AddComponentParameter(52, "Tooltip", (object) "Align Left");
          __builder.AddComponentParameter(53, "Icon", (object) "format_align_left");
          __builder.AddComponentParameter(54, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (async () => await this.InvokeButton("justifyLeft")))));
          __builder.CloseComponent();
          __builder.AddMarkupContent(55, "\r\n        ");
          __builder.OpenComponent<Button>(56);
          __builder.AddComponentParameter(57, "Class", (object) "ghost");
          __builder.AddComponentParameter(58, "Style", (object) "padding: 8px");
          __builder.AddComponentParameter(59, "Tooltip", (object) "Align Center");
          __builder.AddComponentParameter(60, "Icon", (object) "format_align_center");
          __builder.AddComponentParameter(61, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (async () => await this.InvokeButton("justifyCenter")))));
          __builder.CloseComponent();
          __builder.AddMarkupContent(62, "\r\n        ");
          __builder.OpenComponent<Button>(63);
          __builder.AddComponentParameter(64, "Class", (object) "ghost");
          __builder.AddComponentParameter(65, "Style", (object) "padding: 8px");
          __builder.AddComponentParameter(66, "Tooltip", (object) "Align Right");
          __builder.AddComponentParameter(67, "Icon", (object) "format_align_right");
          __builder.AddComponentParameter(68, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (async () => await this.InvokeButton("justifyRight")))));
          __builder.CloseComponent();
          __builder.AddMarkupContent(69, "\r\n        ");
          __builder.OpenComponent<Button>(70);
          __builder.AddComponentParameter(71, "Class", (object) "ghost");
          __builder.AddComponentParameter(72, "Style", (object) "padding: 8px");
          __builder.AddComponentParameter(73, "Tooltip", (object) "Align Justify");
          __builder.AddComponentParameter(74, "Icon", (object) "format_align_justify");
          __builder.AddComponentParameter(75, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (async () => await this.InvokeButton("justifyFull")))));
          __builder.CloseComponent();
          __builder.AddMarkupContent(76, "\r\n        ");
          __builder.OpenComponent<Separator>(77);
          __builder.AddComponentParameter(78, "Vertical", (object) true);
          __builder.CloseComponent();
        }
        if (this.ShowTextFormatting)
        {
          __builder.OpenComponent<Button>(79);
          __builder.AddComponentParameter(80, "Class", (object) "ghost");
          __builder.AddComponentParameter(81, "Style", (object) "padding: 8px");
          __builder.AddComponentParameter(82, "Tooltip", (object) "Bold");
          __builder.AddComponentParameter(83, "Icon", (object) "format_bold");
          __builder.AddComponentParameter(84, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (async () => await this.InvokeButton("bold")))));
          __builder.CloseComponent();
          __builder.AddMarkupContent(85, "\r\n        ");
          __builder.OpenComponent<Button>(86);
          __builder.AddComponentParameter(87, "Class", (object) "ghost");
          __builder.AddComponentParameter(88, "Style", (object) "padding: 8px");
          __builder.AddComponentParameter(89, "Tooltip", (object) "Italic");
          __builder.AddComponentParameter(90, "Icon", (object) "format_italic");
          __builder.AddComponentParameter(91, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (async () => await this.InvokeButton("italic")))));
          __builder.CloseComponent();
          __builder.AddMarkupContent(92, "\r\n        ");
          __builder.OpenComponent<Button>(93);
          __builder.AddComponentParameter(94, "Class", (object) "ghost");
          __builder.AddComponentParameter(95, "Style", (object) "padding: 8px");
          __builder.AddComponentParameter(96, "Tooltip", (object) "Underline");
          __builder.AddComponentParameter(97, "Icon", (object) "format_underlined");
          __builder.AddComponentParameter(98, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (async () => await this.InvokeButton("underline")))));
          __builder.CloseComponent();
          __builder.AddMarkupContent(99, "\r\n        ");
          __builder.OpenComponent<Button>(100);
          __builder.AddComponentParameter(101, "Class", (object) "ghost");
          __builder.AddComponentParameter(102, "Style", (object) "padding: 8px");
          __builder.AddComponentParameter(103, "Tooltip", (object) "Strikethrough");
          __builder.AddComponentParameter(104, "Icon", (object) "format_strikethrough");
          __builder.AddComponentParameter(105, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (async () => await this.InvokeButton("strikeThrough")))));
          __builder.CloseComponent();
          __builder.AddMarkupContent(106, "\r\n        ");
          __builder.OpenComponent<Button>(107);
          __builder.AddComponentParameter(108, "Class", (object) "ghost");
          __builder.AddComponentParameter(109, "Style", (object) "padding: 8px");
          __builder.AddComponentParameter(110, "Tooltip", (object) "Subscript");
          __builder.AddComponentParameter(111, "Icon", (object) "subscript");
          __builder.AddComponentParameter(112, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (async () => await this.InvokeButton("subscript")))));
          __builder.CloseComponent();
          __builder.AddMarkupContent(113, "\r\n        ");
          __builder.OpenComponent<Button>(114);
          __builder.AddComponentParameter(115, "Class", (object) "ghost");
          __builder.AddComponentParameter(116, "Style", (object) "padding: 8px");
          __builder.AddComponentParameter(117, "Tooltip", (object) "Superscript");
          __builder.AddComponentParameter(118, "Icon", (object) "superscript");
          __builder.AddComponentParameter(119, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (async () => await this.InvokeButton("superscript")))));
          __builder.CloseComponent();
          __builder.AddMarkupContent(120, "\r\n        ");
          __builder.OpenComponent<Separator>(121);
          __builder.AddComponentParameter(122, "Vertical", (object) true);
          __builder.CloseComponent();
        }
        if (this.ShowListings)
        {
          __builder.OpenComponent<Button>(123);
          __builder.AddComponentParameter(124, "Class", (object) "ghost");
          __builder.AddComponentParameter(125, "Style", (object) "padding: 8px");
          __builder.AddComponentParameter(126, "Tooltip", (object) "Unordered List");
          __builder.AddComponentParameter((int) sbyte.MaxValue, "Icon", (object) "format_list_bulleted");
          __builder.AddComponentParameter(128, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (async () => await this.InvokeButton("insertUnorderedList")))));
          __builder.CloseComponent();
          __builder.AddMarkupContent(129, "\r\n        ");
          __builder.OpenComponent<Button>(130);
          __builder.AddComponentParameter(131, "Class", (object) "ghost");
          __builder.AddComponentParameter(132, "Style", (object) "padding: 8px");
          __builder.AddComponentParameter(133, "Tooltip", (object) "Ordered List");
          __builder.AddComponentParameter(134, "Icon", (object) "format_list_numbered");
          __builder.AddComponentParameter(135, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (async () => await this.InvokeButton("insertOrderedList")))));
          __builder.CloseComponent();
          __builder.AddMarkupContent(136, "\r\n        ");
          __builder.OpenComponent<Button>(137);
          __builder.AddComponentParameter(138, "Class", (object) "ghost");
          __builder.AddComponentParameter(139, "Style", (object) "padding: 8px");
          __builder.AddComponentParameter(140, "Tooltip", (object) "Add Indent");
          __builder.AddComponentParameter(141, "Icon", (object) "format_indent_increase");
          __builder.AddComponentParameter(142, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (async () => await this.InvokeButton("indent")))));
          __builder.CloseComponent();
          __builder.AddMarkupContent(143, "\r\n        ");
          __builder.OpenComponent<Button>(144);
          __builder.AddComponentParameter(145, "Class", (object) "ghost");
          __builder.AddComponentParameter(146, "Style", (object) "padding: 8px");
          __builder.AddComponentParameter(147, "Tooltip", (object) "Remove Indent");
          __builder.AddComponentParameter(148, "Icon", (object) "format_indent_decrease");
          __builder.AddComponentParameter(149, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (async () => await this.InvokeButton("outdent")))));
          __builder.CloseComponent();
          __builder.AddMarkupContent(150, "\r\n        ");
          __builder.OpenComponent<Separator>(151);
          __builder.AddComponentParameter(152, "Vertical", (object) true);
          __builder.CloseComponent();
        }
        if (this.ShowColors)
        {
          __builder.OpenElement(153, "div");
          __builder.AddAttribute(154, "style", "position: relative");
          __builder.AddAttribute(155, "b-dn6bos3dew");
          __builder.OpenComponent<Button>(156);
          __builder.AddComponentParameter(157, "Class", (object) "ghost");
          __builder.AddComponentParameter(158, "Style", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<string>("padding: 8px; color: " + this.fc));
          __builder.AddComponentParameter(159, "Tooltip", (object) "Text Color");
          __builder.AddComponentParameter(160, "Icon", (object) "format_color_text");
          __builder.AddComponentParameter(161, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (async () => await this.Colors("fc")))));
          __builder.CloseComponent();
          __builder.AddMarkupContent(162, "\r\n            ");
          __builder.OpenElement(163, "input");
          __builder.AddAttribute(164, "id", "fcInput");
          __builder.AddAttribute(165, "type", "color");
          __builder.AddAttribute(166, "value", this.fc);
          __builder.AddAttribute<ChangeEventArgs>(167, "onchange", EventCallback.Factory.Create<ChangeEventArgs>((object) this, (Func<ChangeEventArgs, Task>) (async c => await this.ChangeColors("fc", c.Value?.ToString()))));
          __builder.AddAttribute(168, "style", "position: absolute; visibility: hidden; top: 0");
          __builder.AddAttribute(169, "b-dn6bos3dew");
          __builder.CloseElement();
          __builder.CloseElement();
          __builder.AddMarkupContent(170, "\r\n        ");
          __builder.OpenElement(171, "div");
          __builder.AddAttribute(172, "style", "position: relative");
          __builder.AddAttribute(173, "b-dn6bos3dew");
          __builder.OpenComponent<Button>(174);
          __builder.AddComponentParameter(175, "Class", (object) "ghost");
          __builder.AddComponentParameter(176, "Style", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<string>("padding: 8px; background-color: " + this.bc));
          __builder.AddComponentParameter(177, "Tooltip", (object) "Fill Color");
          __builder.AddComponentParameter(178, "Icon", (object) "format_color_fill");
          __builder.AddComponentParameter(179, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (async () => await this.Colors("bc")))));
          __builder.CloseComponent();
          __builder.AddMarkupContent(180, "\r\n            ");
          __builder.OpenElement(181, "input");
          __builder.AddAttribute(182, "id", "bcInput");
          __builder.AddAttribute(183, "type", "color");
          __builder.AddAttribute(184, "value", this.bc);
          __builder.AddAttribute<ChangeEventArgs>(185, "onchange", EventCallback.Factory.Create<ChangeEventArgs>((object) this, (Func<ChangeEventArgs, Task>) (async c => await this.ChangeColors("bc", c.Value?.ToString()))));
          __builder.AddAttribute(186, "style", "position: absolute; visibility: hidden; top: 0");
          __builder.AddAttribute(187, "b-dn6bos3dew");
          __builder.CloseElement();
          __builder.CloseElement();
          __builder.AddMarkupContent(188, "\r\n        ");
          __builder.OpenComponent<Separator>(189);
          __builder.AddComponentParameter(190, "Vertical", (object) true);
          __builder.CloseComponent();
        }
        if (this.ShowHeadings)
        {
          __builder.OpenComponent<Button>(191);
          __builder.AddComponentParameter(192, "Class", (object) "ghost");
          __builder.AddComponentParameter(193, "Style", (object) "padding: 8px");
          __builder.AddComponentParameter(194, "Tooltip", (object) "Paragraph");
          __builder.AddComponentParameter(195, "Icon", (object) "format_paragraph");
          __builder.AddComponentParameter(196, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (async () => await this.InvokeButton("insertParagraph")))));
          __builder.CloseComponent();
          __builder.AddMarkupContent(197, "\r\n        ");
          __builder.OpenComponent<Button>(198);
          __builder.AddComponentParameter(199, "Class", (object) "ghost");
          __builder.AddComponentParameter(200, "Style", (object) "padding: 8px");
          __builder.AddComponentParameter(201, "Tooltip", (object) "Header 1");
          __builder.AddComponentParameter(202, "Icon", (object) "format_h1");
          __builder.AddComponentParameter(203, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (async () => await this.InvokeButton("h1")))));
          __builder.CloseComponent();
          __builder.AddMarkupContent(204, "\r\n        ");
          __builder.OpenComponent<Button>(205);
          __builder.AddComponentParameter(206, "Class", (object) "ghost");
          __builder.AddComponentParameter(207, "Style", (object) "padding: 8px");
          __builder.AddComponentParameter(208, "Tooltip", (object) "Header 2");
          __builder.AddComponentParameter(209, "Icon", (object) "format_h2");
          __builder.AddComponentParameter(210, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (async () => await this.InvokeButton("h2")))));
          __builder.CloseComponent();
          __builder.AddMarkupContent(211, "\r\n        ");
          __builder.OpenComponent<Button>(212);
          __builder.AddComponentParameter(213, "Class", (object) "ghost");
          __builder.AddComponentParameter(214, "Style", (object) "padding: 8px");
          __builder.AddComponentParameter(215, "Tooltip", (object) "Header 3");
          __builder.AddComponentParameter(216, "Icon", (object) "format_h3");
          __builder.AddComponentParameter(217, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (async () => await this.InvokeButton("h3")))));
          __builder.CloseComponent();
          __builder.AddMarkupContent(218, "\r\n        ");
          __builder.OpenComponent<Button>(219);
          __builder.AddComponentParameter(220, "Class", (object) "ghost");
          __builder.AddComponentParameter(221, "Style", (object) "padding: 8px");
          __builder.AddComponentParameter(222, "Tooltip", (object) "Header 4");
          __builder.AddComponentParameter(223, "Icon", (object) "format_h4");
          __builder.AddComponentParameter(224, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (async () => await this.InvokeButton("h4")))));
          __builder.CloseComponent();
          __builder.AddMarkupContent(225, "\r\n        ");
          __builder.OpenComponent<Button>(226);
          __builder.AddComponentParameter(227, "Class", (object) "ghost");
          __builder.AddComponentParameter(228, "Style", (object) "padding: 8px");
          __builder.AddComponentParameter(229, "Tooltip", (object) "Header 5");
          __builder.AddComponentParameter(230, "Icon", (object) "format_h5");
          __builder.AddComponentParameter(231, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (async () => await this.InvokeButton("h5")))));
          __builder.CloseComponent();
          __builder.AddMarkupContent(232, "\r\n        ");
          __builder.OpenComponent<Button>(233);
          __builder.AddComponentParameter(234, "Class", (object) "ghost");
          __builder.AddComponentParameter(235, "Style", (object) "padding: 8px");
          __builder.AddComponentParameter(236, "Tooltip", (object) "Header 6");
          __builder.AddComponentParameter(237, "Icon", (object) "format_h6");
          __builder.AddComponentParameter(238, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (async () => await this.InvokeButton("h6")))));
          __builder.CloseComponent();
          __builder.AddMarkupContent(239, "\r\n        ");
          __builder.OpenComponent<Separator>(240);
          __builder.AddComponentParameter(241, "Vertical", (object) true);
          __builder.CloseComponent();
        }
        if (this.ShowExtras)
        {
          __builder.OpenComponent<Button>(242);
          __builder.AddComponentParameter(243, "Class", (object) "ghost");
          __builder.AddComponentParameter(244, "Style", (object) "padding: 8px");
          __builder.AddComponentParameter(245, "Tooltip", (object) "Remove Format");
          __builder.AddComponentParameter(246, "Icon", (object) "format_clear");
          __builder.AddComponentParameter(247, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (async () => await this.InvokeButton("removeFormat")))));
          __builder.CloseComponent();
          __builder.AddMarkupContent(248, "\r\n        ");
          __builder.OpenComponent<Button>(249);
          __builder.AddComponentParameter(250, "Class", (object) "ghost");
          __builder.AddComponentParameter(251, "Style", (object) "padding: 8px");
          __builder.AddComponentParameter(252, "Tooltip", (object) "Insert Current Date/Time");
          __builder.AddComponentParameter(253, "Icon", (object) "calendar_month");
          __builder.AddComponentParameter(254, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback>(EventCallback.Factory.Create((object) this, (Func<Task>) (async () => await this.InvokeButton("datetime")))));
          __builder.CloseComponent();
          __builder.AddMarkupContent((int) byte.MaxValue, "\r\n        ");
          __builder.OpenComponent<Separator>(256);
          __builder.AddComponentParameter(257, "Vertical", (object) true);
          __builder.CloseComponent();
        }
        __builder.CloseElement();
      }
      __builder.OpenElement(258, "div");
      __builder.AddAttribute(259, "class", "sbc-editor-content");
      __builder.AddAttribute(260, "id", "content-" + this.Id);
      __builder.AddAttribute(261, "contenteditable", "true");
      __builder.AddAttribute<FocusEventArgs>(262, "onfocus", EventCallback.Factory.Create<FocusEventArgs>((object) this, this.OnFocus));
      __builder.AddAttribute<FocusEventArgs>(263, "onblur", EventCallback.Factory.Create<FocusEventArgs>((object) this, this.OnLostFocus));
      __builder.AddAttribute(264, "b-dn6bos3dew");
      __builder.CloseElement();
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    string? Id { get; set; }

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Parameter]
    public string? Content { get; set; }

    [Parameter]
    public bool WrapOverflow { get; set; }

    [Parameter]
    public bool ShowUndoRedo { get; set; }

    [Parameter]
    public bool ShowCutCopyPaste { get; set; }

    [Parameter]
    public bool ShowAlignments { get; set; }

    [Parameter]
    public bool ShowTextFormatting { get; set; }

    [Parameter]
    public bool ShowListings { get; set; }

    [Parameter]
    public bool ShowColors { get; set; }

    [Parameter]
    public bool ShowHeadings { get; set; }

    [Parameter]
    public bool ShowExtras { get; set; }

    [Parameter]
    public EventCallback OnFocus { get; set; }

    [Parameter]
    public EventCallback OnLostFocus { get; set; }

    protected override async Task OnInitializedAsync()
    {
      string scp = "async function getPaste() { return await navigator.clipboard.readText() } async function getPasteData() { return await getPaste(); }";
      await this.be.EvalVoid((object) scp);
      scp = (string) null;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
      if (this.Content == null)
        return;
      await this.SetContent(this.Content);
      await this.be.EvalVoid((object) "document.execCommand('enableInlineTableEditing', true)");
      await this.be.EvalVoid((object) "document.execCommand('enableObjectResizing', true)");
    }

    public async Task<string?> GetContent()
    {
      string content = await this.be.EvalGet<string>((object) ("document.querySelector('#content-" + this.Id + "').innerHTML"));
      return content;
    }

    public async Task SetContent(string? value)
    {
      BrowserExtensions be = this.be;
      object[] objArray = new object[1];
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(50, 2);
      interpolatedStringHandler.AppendLiteral("document.querySelector('#content-");
      interpolatedStringHandler.AppendFormatted(this.Id);
      interpolatedStringHandler.AppendLiteral("').innerHTML = `");
      interpolatedStringHandler.AppendFormatted(value?.Replace("\\", "\\\\"));
      interpolatedStringHandler.AppendLiteral("`");
      objArray[0] = (object) interpolatedStringHandler.ToStringAndClear();
      await be.EvalVoid(objArray);
    }

    public async Task SetFocus() => await this.be.SetFocus("#content-" + this.Id);

    private async Task InvokeButton(string code)
    {
      if (code == "datetime")
      {
        BrowserExtensions be = this.be;
        object[] objArray = new object[1];
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(45, 1);
        interpolatedStringHandler.AppendLiteral("document.execCommand('insertText', false, '");
        interpolatedStringHandler.AppendFormatted<DateTime>(DateTime.Now);
        interpolatedStringHandler.AppendLiteral("')");
        objArray[0] = (object) interpolatedStringHandler.ToStringAndClear();
        await be.EvalVoid(objArray);
      }
      else if ("h1,h2,h3,h4,h5,h6".Contains(code))
      {
        string str = code;
        int size = 7 - int.Parse(str.Substring(1, str.Length - 1));
        BrowserExtensions be = this.be;
        object[] objArray = new object[1];
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(43, 1);
        interpolatedStringHandler.AppendLiteral("document.execCommand('fontSize', false, '");
        interpolatedStringHandler.AppendFormatted<int>(size);
        interpolatedStringHandler.AppendLiteral("')");
        objArray[0] = (object) interpolatedStringHandler.ToStringAndClear();
        await be.EvalVoid(objArray);
      }
      else
      {
        switch (code)
        {
          case "copy":
            await this.HandleCopy();
            break;
          case "paste":
            await this.HandlePaste();
            break;
          default:
            await this.be.EvalVoid((object) ("document.execCommand('" + code + "')"));
            break;
        }
      }
    }

    private async Task HandleCopy()
    {
      string scp = "const rtd = document.querySelector('#content-" + this.Id + "'); const ci = new ClipboardItem({'text/plain': new Blob([rtd.innerText], {type: 'text/plain'}), 'text/html': new Blob([rtd.innerHTML], {type: 'text/html'})}); navigator.clipboard.write([ci]);";
      await this.be.EvalVoid((object) scp);
      scp = (string) null;
    }

    private async Task HandlePaste()
    {
      await this.be.EvalVoid((object) "getPasteData().then(a => a).then(b => document.execCommand('insertHTML', false, b))");
    }

    private async Task Colors(string type)
    {
      await this.be.EvalVoid((object) ("document.querySelector('#" + type + "Input')?.click()"));
    }

    private async Task ChangeColors(string type, string? value)
    {
      switch (type)
      {
        case "fc":
          this.fc = value;
          await this.be.EvalVoid((object) ("document.execCommand('foreColor', false, '" + this.fc + "')"));
          break;
        case "bc":
          this.bc = value;
          await this.be.EvalVoid((object) ("document.execCommand('backColor', false, '" + this.bc + "')"));
          break;
      }
    }

    [Inject]
    private BrowserExtensions be { get; set; }

    [Inject]
    private StateManager sm { get; set; }

    public Editor()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
      interpolatedStringHandler.AppendLiteral("editor-");
      interpolatedStringHandler.AppendFormatted<Guid>(Guid.NewGuid());
      // ISSUE: reference to a compiler-generated field
      this.Id = interpolatedStringHandler.ToStringAndClear();
      // ISSUE: reference to a compiler-generated field
      this.WrapOverflow = true;
      // ISSUE: reference to a compiler-generated field
      this.ShowUndoRedo = true;
      // ISSUE: reference to a compiler-generated field
      this.ShowCutCopyPaste = true;
      // ISSUE: reference to a compiler-generated field
      this.ShowAlignments = true;
      // ISSUE: reference to a compiler-generated field
      this.ShowTextFormatting = true;
      // ISSUE: reference to a compiler-generated field
      this.ShowListings = true;
      // ISSUE: reference to a compiler-generated field
      this.ShowColors = true;
      // ISSUE: reference to a compiler-generated field
      this.ShowHeadings = true;
      // ISSUE: reference to a compiler-generated field
      this.ShowExtras = true;
      // ISSUE: reference to a compiler-generated field
      this.be = (BrowserExtensions) null;
      // ISSUE: reference to a compiler-generated field
      this.sm = (StateManager) null;
      // ISSUE: explicit constructor call
      base.OnInitialized();
    }
  }
}
