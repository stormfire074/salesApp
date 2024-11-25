// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Sortable`1
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class Sortable<TItem> : ComponentBase
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-sortable list-group " + this.Class);
      __builder.AddAttribute(2, "style", "width:" + this.Width + ";height:" + this.Height + ";" + this.Style);
      __builder.AddAttribute(3, "id", this.Id);
      __builder.AddAttribute(4, "b-a1phddmn3a");
      if (!InitializeSysinfocus.IsLicensed)
        __builder.AddMarkupContent(5, "<small class=\"mtb05 ta-center\" b-a1phddmn3a>You are using a trial version.</small>");
      if (this.SortableItemTemplate != null)
      {
        foreach (TItem obj in this.Items ?? new List<TItem>())
          __builder.AddContent(6, this.SortableItemTemplate(obj));
      }
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    string Id { get; set; } = "sort-" + Guid.NewGuid().ToString().Replace("-", "");

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public string? Width { get; set; } = "100%";

    [Parameter]
    public string? Height { get; set; } = "100%";

    [Parameter]
    public string? Group { get; set; } = "name";

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Parameter]
    public string? Easing { get; set; } = "linear";

    [Parameter]
    public string? Draggable { get; set; } = ".item";

    [Parameter]
    public string? Handle { get; set; }

    [Parameter]
    public string? GhostClass { get; set; } = "item-ghost";

    [Parameter]
    public string? ChosenClass { get; set; } = "item-chosen";

    [Parameter]
    public string? DragClass { get; set; } = "item-drag";

    [Parameter]
    public int SortDelay { get; set; } = 0;

    [Parameter]
    public int AnimationSpeed { get; set; } = 150;

    [Parameter]
    public bool Sort { get; set; } = false;

    [Parameter]
    public bool ForceFallback { get; set; }

    [Parameter]
    public bool Register { get; set; }

    [Parameter]
    public RenderFragment<TItem>? SortableItemTemplate { get; set; }

    [Parameter]
    public List<TItem>? Items { get; set; }

    [Parameter]
    public EventCallback<(int oldIndex, int newIndex, string from, string to)> OnInsert { get; set; }

    [Parameter]
    public EventCallback<(int oldIndex, int newIndex, string from, string to)> OnChange { get; set; }

    [Parameter]
    public EventCallback<(int oldIndex, int newIndex, string from, string to)> OnDelete { get; set; }

    protected override async Task OnInitializedAsync()
    {
      if (this.sm.GetFromState((object) "SORTABLE_JS") is bool)
        return;
      this.sm.Publish((object) "SORTABLE_JS", (object) true);
      await this.be.AddScript(InitializeSysinfocus.SORTABLE_JS);
      string scp = "let dn = {}; dn.DotNetReference = null; function setRef(r) { dn.DotNetReference = r; } function notify(m,o,n,f,t) { dn.DotNetReference.invokeMethodAsync(m,o,n,f,t) }";
      await this.be.EvalVoid((object) scp);
      scp = (string) null;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
      if (!firstRender)
        return;
      await Task.Delay(500);
      StringBuilder fn = new StringBuilder();
      fn.AppendLine(", onAdd: evt => { notify('HandleInsert', evt.oldDraggableIndex, evt.newDraggableIndex, evt.from.id, evt.to.id) }");
      fn.AppendLine(", onUpdate: evt => { evt.item.remove(); evt.to.insertBefore(evt.item, evt.to.childNodes[evt.oldIndex]); notify('HandleChange', evt.oldDraggableIndex, evt.newDraggableIndex, evt.from.id, evt.to.id) }");
      fn.AppendLine(", onRemove: evt => { if (evt.pullMode === 'clone') { evt.clone.remove(); } evt.item.remove(); evt.from.insertBefore(evt.item, evt.from.childNodes[evt.oldIndex]); notify('HandleDelete', evt.oldDraggableIndex, evt.newDraggableIndex, evt.from.id, evt.to.id) }");
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(190, 14);
      interpolatedStringHandler.AppendLiteral("new Sortable(document.getElementById(\"");
      interpolatedStringHandler.AppendFormatted(this.Id);
      interpolatedStringHandler.AppendLiteral("\"), { group: \"");
      interpolatedStringHandler.AppendFormatted(this.Group);
      interpolatedStringHandler.AppendLiteral("\", easing: \"");
      interpolatedStringHandler.AppendFormatted(this.Easing);
      interpolatedStringHandler.AppendLiteral("\", ");
      interpolatedStringHandler.AppendFormatted(this.Handle != null ? "handle: " + this.Handle + ", " : "");
      interpolatedStringHandler.AppendLiteral("sort: ");
      interpolatedStringHandler.AppendFormatted(this.Sort ? "true" : "false");
      interpolatedStringHandler.AppendLiteral(", disabled: ");
      interpolatedStringHandler.AppendFormatted(this.Disabled ? "true" : "false");
      interpolatedStringHandler.AppendLiteral(", delay: ");
      interpolatedStringHandler.AppendFormatted<int>(this.SortDelay);
      interpolatedStringHandler.AppendLiteral(", animation: ");
      interpolatedStringHandler.AppendFormatted<int>(this.AnimationSpeed);
      interpolatedStringHandler.AppendLiteral(", draggable: \"");
      interpolatedStringHandler.AppendFormatted(this.Draggable);
      interpolatedStringHandler.AppendLiteral("\", ghostClass: \"");
      interpolatedStringHandler.AppendFormatted(this.GhostClass);
      interpolatedStringHandler.AppendLiteral("\", chosenClass: \"");
      interpolatedStringHandler.AppendFormatted(this.ChosenClass);
      interpolatedStringHandler.AppendLiteral("\", dragClass: \"");
      interpolatedStringHandler.AppendFormatted(this.DragClass);
      interpolatedStringHandler.AppendLiteral("\", forceFallback: ");
      interpolatedStringHandler.AppendFormatted(this.ForceFallback ? "true" : "false");
      interpolatedStringHandler.AppendFormatted<StringBuilder>(fn);
      interpolatedStringHandler.AppendLiteral("});");
      string scp = interpolatedStringHandler.ToStringAndClear();
      await this.be.EvalVoid((object) scp);
      if (this.Register)
      {
        DotNetObjectReference<Sortable<TItem>> self = DotNetObjectReference.Create<Sortable<TItem>>(this);
        await this.be.JSVoid("setRef", (object) self);
        self = (DotNetObjectReference<Sortable<TItem>>) null;
      }
      fn = (StringBuilder) null;
      scp = (string) null;
    }

    [JSInvokable]
    public async Task HandleInsert(int oldIndex, int newIndex, string from, string to)
    {
      await this.OnInsert.InvokeAsync((oldIndex, newIndex, from, to));
    }

    [JSInvokable]
    public async Task HandleChange(int oldIndex, int newIndex, string from, string to)
    {
      await this.OnChange.InvokeAsync((oldIndex, newIndex, from, to));
    }

    [JSInvokable]
    public async Task HandleDelete(int oldIndex, int newIndex, string from, string to)
    {
      await this.OnDelete.InvokeAsync((oldIndex, newIndex, from, to));
    }

    [Inject]
    private BrowserExtensions be { get; set; } = (BrowserExtensions) null;

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
