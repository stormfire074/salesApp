// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.FileManager
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class FileManager : ComponentBase, IDisposable
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "id", this.Id);
      __builder.AddAttribute(2, "class", "sbc-file-manager " + this.Class);
      __builder.AddAttribute(3, "style", "width:" + this.Width + ";height:" + this.Height + ";" + this.Style);
      __builder.AddAttribute(4, "b-9x2eenk5wh");
      if (this.ShowAsList)
      {
        __builder.OpenComponent<Table>(5);
        __builder.AddComponentParameter(6, "StickyHeader", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<bool>(true));
        __builder.AddComponentParameter(7, "Style", (object) "height: 100%");
                __builder.AddAttribute(8, "TableHeader", (RenderFragment)(__builder2 =>
                {
                    __builder2.AddMarkupContent(9, "<tr b-9x2eenk5wh><th b-9x2eenk5wh></th>\r\n                    <th b-9x2eenk5wh>Filename</th>\r\n                    <th b-9x2eenk5wh>Date</th>\r\n                    <th b-9x2eenk5wh>Type</th>\r\n                    <th class=\"ta-right\" b-9x2eenk5wh>Size</th></tr>");
                }));

                __builder.AddAttribute(10, "TableBody", (RenderFragment)(__builder2 =>
                {
                    foreach (Files item in this.Items
                        .OrderBy(a => a.Size)
                        .ThenBy(a => a.Name))
                    {
                        __builder2.OpenElement(11, "tr");
                        __builder2.AddAttribute(12, "class", "sbc-file-item-list");
                        __builder2.AddAttribute(13, "tabindex", "0");
                        __builder2.AddAttribute<MouseEventArgs>(14, "onclick",
                            EventCallback.Factory.Create<MouseEventArgs>(this, () => this.HandleClicked(item)));
                        __builder2.AddAttribute<MouseEventArgs>(15, "ondblclick",
                            EventCallback.Factory.Create<MouseEventArgs>(this, () => this.HandleDoubleClicked(item)));
                        __builder2.AddAttribute<MouseEventArgs>(16, "oncontextmenu",
                            EventCallback.Factory.Create<MouseEventArgs>(this, e => this.HandleContextMenu(e, item)));
                        __builder2.AddEventPreventDefaultAttribute(17, "oncontextmenu", true);
                        __builder2.AddAttribute<KeyboardEventArgs>(18, "onkeydown",
                            EventCallback.Factory.Create<KeyboardEventArgs>(this, e => this.HandleKeyDown(e, item)));
                        __builder2.AddAttribute(19, "b-9x2eenk5wh");

                        // File icon
                        __builder2.OpenElement(20, "td");
                        __builder2.AddAttribute(21, "b-9x2eenk5wh");
                        __builder2.OpenElement(22, "img");
                        __builder2.AddAttribute(23, "class", "list-icon");
                        __builder2.AddAttribute(24, "src", item.Icon);
                        __builder2.AddAttribute(25, "b-9x2eenk5wh");
                        __builder2.CloseElement();
                        __builder2.CloseElement();

                        // Filename
                        __builder2.AddMarkupContent(26, "\r\n                        ");
                        __builder2.OpenElement(27, "td");
                        __builder2.AddAttribute(28, "b-9x2eenk5wh");
                        __builder2.AddContent(29, item.Name);
                        __builder2.CloseElement();

                        // Date
                        __builder2.AddMarkupContent(30, "\r\n                        ");
                        __builder2.OpenElement(31, "td");
                        __builder2.AddAttribute(32, "b-9x2eenk5wh");
                        __builder2.AddContent(33, item.Date);
                        __builder2.CloseElement();

                        // Type
                        __builder2.AddMarkupContent(34, "\r\n                        ");
                        __builder2.OpenElement(35, "td");
                        __builder2.AddAttribute(36, "b-9x2eenk5wh");
                        __builder2.AddContent(37, item.Type);
                        __builder2.CloseElement();

                        // Size
                        __builder2.AddMarkupContent(38, "\r\n                        ");
                        __builder2.OpenElement(39, "td");
                        __builder2.AddAttribute(40, "class", "ta-right");
                        __builder2.AddAttribute(41, "b-9x2eenk5wh");
                        __builder2.AddContent(42, item.Size == 0 ? "" : $"{item.Size} KB");
                        __builder2.CloseElement();

                        __builder2.CloseElement(); // Close "tr"
                    }
                }));

                __builder.CloseComponent();
      }
      else
      {
        __builder.OpenElement(43, "div");
        __builder.AddAttribute(44, "class", "sbc-file-items");
        __builder.AddAttribute(45, "b-9x2eenk5wh");
        foreach (Files files in (IEnumerable<Files>) this.Items.OrderBy<Files, int>((Func<Files, int>) (a => a.Size)).ThenBy<Files, string>((Func<Files, string>) (a => a.Name)))
        {
          Files item = files;
          __builder.OpenElement(46, "div");
          __builder.AddAttribute(47, "class", "sbc-file-item");
          __builder.AddAttribute(48, "tabindex", "0");
          __builder.AddAttribute<MouseEventArgs>(49, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, (Func<Task>) (() => this.HandleClicked(item))));
          __builder.AddAttribute<MouseEventArgs>(50, "ondblclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, (Func<Task>) (() => this.HandleDoubleClicked(item))));
          __builder.AddAttribute<MouseEventArgs>(51, "oncontextmenu", EventCallback.Factory.Create<MouseEventArgs>((object) this, (Func<MouseEventArgs, Task>) (e => this.HandleContextMenu(e, item))));
          __builder.AddEventPreventDefaultAttribute(52, "oncontextmenu", true);
          __builder.AddAttribute<KeyboardEventArgs>(53, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, (Func<KeyboardEventArgs, Task>) (e => this.HandleKeyDown(e, item))));
          __builder.AddAttribute(54, "b-9x2eenk5wh");
          __builder.OpenElement(55, "img");
          __builder.AddAttribute(56, "src", item.Icon);
          __builder.AddAttribute(57, "b-9x2eenk5wh");
          __builder.CloseElement();
          __builder.AddMarkupContent(58, "\r\n                            ");
          __builder.OpenElement(59, "p");
          __builder.AddAttribute(60, "b-9x2eenk5wh");
          __builder.AddContent(61, item.Name);
          __builder.CloseElement();
          __builder.CloseElement();
        }
        __builder.CloseElement();
      }
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    string Id { get; set; }

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Parameter]
    public string? Width { get; set; }

    [Parameter]
    public string? Height { get; set; }

    [Parameter]
    public bool ShowAsList { get; set; }

    [Parameter]
    [EditorRequired]
    public ICollection<Files> Items { get; set; }

    [Parameter]
    public EventCallback<Files> OnClicked { get; set; }

    [Parameter]
    public EventCallback<(KeyboardEventArgs, Files)> OnKeyDown { get; set; }

    [Parameter]
    public EventCallback<Files> OnDoubleClicked { get; set; }

    [Parameter]
    public EventCallback<(MouseEventArgs, Files)> OnContextMenu { get; set; }

    [Parameter]
    public EventCallback OnContextMenuCancelled { get; set; }

    protected override void OnInitialized()
    {
      this.sm.StateChanged += new NotifyStateChanged(this.GetStateChanged);
    }

    private async void GetStateChanged(object? sender, object? value)
    {
      if (!(value?.ToString() == "mouseup"))
        return;
      await this.OnContextMenuCancelled.InvokeAsync();
    }

    private async Task HandleClicked(Files file) => await this.OnClicked.InvokeAsync(file);

    private async Task HandleDoubleClicked(Files file)
    {
      await this.OnDoubleClicked.InvokeAsync(file);
    }

    private async Task HandleContextMenu(MouseEventArgs args, Files file)
    {
      await this.OnContextMenu.InvokeAsync((args, file));
    }

    private async Task HandleKeyDown(KeyboardEventArgs args, Files file)
    {
      await this.OnKeyDown.InvokeAsync((args, file));
    }

    void IDisposable.Dispose()
    {
      this.sm.StateChanged -= new NotifyStateChanged(this.GetStateChanged);
    }

    [Inject]
    private StateManager sm { get; set; }

    public FileManager()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
      interpolatedStringHandler.AppendLiteral("fm-");
      interpolatedStringHandler.AppendFormatted<Guid>(Guid.NewGuid());
      // ISSUE: reference to a compiler-generated field
      this.Id = interpolatedStringHandler.ToStringAndClear();
      // ISSUE: reference to a compiler-generated field
      this.Width = "100%";
      // ISSUE: reference to a compiler-generated field
      this.Height = "600px";
      // ISSUE: reference to a compiler-generated field
      this.ShowAsList = true;
      // ISSUE: reference to a compiler-generated field
      this.Items = (ICollection<Files>) new List<Files>();
      // ISSUE: reference to a compiler-generated field
      this.sm = (StateManager) null;
      // ISSUE: explicit constructor call
      base.OnInitialized();
    }
  }
}
