// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Treeview
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using __Blazor.Sysinfocus.AspNetCore.Components.Treeview;
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
  public class Treeview : ComponentBase, IDisposable
  {
    private bool preventDefault;

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-treeview " + this.Class);
      __builder.AddAttribute(2, "style", this.Style);
      __builder.AddAttribute(3, "id", this.Id);
      __builder.AddAttribute(4, "b-b2wsj9tslx");
      __builder.OpenElement(5, "ul");
      __builder.AddAttribute(6, "style", "width: 100%");
      __builder.AddAttribute(7, "b-b2wsj9tslx");
      if (!InitializeSysinfocus.IsLicensed)
        __builder.AddMarkupContent(8, "<small class=\"mtb05\" b-b2wsj9tslx>You are using a trial version.</small>");
      TypeInference.CreateCascadingValue_0<List<TreeviewModel>>(__builder, 9, 10, this.Items, 11, (RenderFragment) (__builder2 =>
      {
        foreach (TreeviewModel treeviewModel in (IEnumerable<TreeviewModel>) this.Items.Where<TreeviewModel>((Func<TreeviewModel, bool>) (p => p.ParentId == 0)).OrderByDescending<TreeviewModel, int>((Func<TreeviewModel, int>) (a => a.Sequence)))
        {
          TreeviewModel node = treeviewModel;
          string markupContent = (string) null;
          if (this.EnableIcons)
            markupContent = string.IsNullOrWhiteSpace(node.Icon) ? (string) null : "<span style='pointer-events:none' class='material-symbols-outlined'>" + (node.Collapsed ? node.AlternateIcon : node.Icon) + "</span>";
          if (this.UpdateLevel && node.Level == -1)
            ++node.Level;
          if (this.Items.Any<TreeviewModel>((Func<TreeviewModel, bool>) (a => a.ParentId == node.Id)))
          {
            node.IsParent = true;
            __builder2.OpenElement(12, "li");
            __builder2.AddAttribute(13, "tabindex", (object) (node.Disabled ? -1 : 0));
            __builder2.AddAttribute(14, "class", "parent " + (node.Disabled ? " disabled" : (string) null) + " " + (node.Collapsed ? "collapse" : (string) null) + " " + node.Class);
            __builder2.AddAttribute(15, "style", node.Style);
            __builder2.AddAttribute<KeyboardEventArgs>(16, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, (Func<KeyboardEventArgs, Task>) (async x => await this.HandleKeyDown(x, node))));
            __builder2.AddEventPreventDefaultAttribute(17, "onkeydown", this.preventDefault);
            __builder2.AddAttribute<MouseEventArgs>(18, "oncontextmenu", EventCallback.Factory.Create<MouseEventArgs>((object) this, (Func<MouseEventArgs, Task>) (async x => await this.OnContextMenu.InvokeAsync((x, node)))));
            __builder2.AddEventPreventDefaultAttribute(19, "oncontextmenu", true);
            __builder2.AddAttribute<MouseEventArgs>(20, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, (Func<Task>) (async () => await this.HandleClick(node))));
            __builder2.AddAttribute(21, "b-b2wsj9tslx");
            __builder2.SetKey((object) node.Id);
            __builder2.AddContent(22, (MarkupString) markupContent);
            __builder2.AddContent(23, " ");
            __builder2.AddContent(24, node.Text);
            __builder2.CloseElement();
            if (!node.Collapsed)
            {
              __builder2.OpenElement(25, "ul");
              __builder2.AddAttribute(26, "b-b2wsj9tslx");
              __builder2.OpenComponent<TreeviewNode>(27);
              __builder2.AddComponentParameter(28, "Parent", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<TreeviewModel>(node));
              __builder2.AddComponentParameter(29, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback<TreeviewModel>>(EventCallback.Factory.Create<TreeviewModel>((object) this, this.OnClick)));
              __builder2.AddComponentParameter(30, "OnCollapsed", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback<TreeviewModel>>(EventCallback.Factory.Create<TreeviewModel>((object) this, this.OnCollapsed)));
              __builder2.AddComponentParameter(31, "OnExpanded", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback<TreeviewModel>>(EventCallback.Factory.Create<TreeviewModel>((object) this, this.OnExpanded)));
              __builder2.AddComponentParameter(32, "OnContextMenu", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback<(MouseEventArgs, TreeviewModel)>>(EventCallback.Factory.Create<(MouseEventArgs, TreeviewModel)>((object) this, this.OnContextMenu)));
              __builder2.AddComponentParameter(33, "EnableIcons", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<bool>(this.EnableIcons));
              __builder2.CloseComponent();
              __builder2.CloseElement();
            }
          }
          else
          {
            __builder2.OpenElement(34, "li");
            __builder2.AddAttribute(35, "tabindex", (object) (node.Disabled ? -1 : 0));
            __builder2.AddAttribute(36, "class", (node.Disabled ? " disabled" : (string) null) + " " + node.Class);
            __builder2.AddAttribute(37, "style", node.Style);
            __builder2.AddAttribute<KeyboardEventArgs>(38, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, (Func<KeyboardEventArgs, Task>) (async x => await this.HandleKeyDown(x, node))));
            __builder2.AddEventPreventDefaultAttribute(39, "onkeydown", this.preventDefault);
            __builder2.AddAttribute<MouseEventArgs>(40, "oncontextmenu", EventCallback.Factory.Create<MouseEventArgs>((object) this, (Func<MouseEventArgs, Task>) (async x => await this.OnContextMenu.InvokeAsync((x, node)))));
            __builder2.AddEventPreventDefaultAttribute(41, "oncontextmenu", true);
            __builder2.AddAttribute<MouseEventArgs>(42, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, (Func<Task>) (async () => await this.HandleClick(node))));
            __builder2.AddAttribute(43, "b-b2wsj9tslx");
            __builder2.SetKey((object) node.Id);
            __builder2.AddContent(44, (MarkupString) markupContent);
            __builder2.AddContent(45, " ");
            __builder2.AddContent(46, node.Text);
            __builder2.CloseElement();
          }
        }
      }));
      __builder.CloseElement();
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    List<TreeviewModel> Items { get; set; }

    [Parameter]
    public EventCallback<TreeviewModel> OnClick { get; set; }

    [Parameter]
    public EventCallback<TreeviewModel> OnCollapsed { get; set; }

    [Parameter]
    public EventCallback<TreeviewModel> OnExpanded { get; set; }

    [Parameter]
    public EventCallback<(MouseEventArgs, TreeviewModel)> OnContextMenu { get; set; }

    [Parameter]
    public EventCallback OnContextMenuCancelled { get; set; }

    [Parameter]
    public bool EnableIcons { get; set; }

    [Parameter]
    public string? Id { get; set; }

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Parameter]
    public bool UpdateLevel { get; set; }

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

        private async Task HandleClick(TreeviewModel model)
        {
            if (model.Disabled)
                return;

            model.Collapsed = !model.Collapsed;
            StateHasChanged(); // Directly invoke the method
            await this.OnClick.InvokeAsync(model);
        }

        private async Task HandleKeyDown(KeyboardEventArgs args, TreeviewModel model)
        {
            this.preventDefault = false;

            if (args.Key == " " || args.Key == "Enter")
            {
                if (model.Disabled)
                    return;

                this.preventDefault = true;
                model.Collapsed = !model.Collapsed;
                StateHasChanged(); // Directly invoke the method
                await this.OnClick.InvokeAsync(model);
            }
            else if (args.Key == "End" || args.Key == "PageDown")
            {
                this.preventDefault = true;
                await this.be.EvalVoid("document.activeElement.parentElement.children[document.activeElement.parentElement.children.length - 1]?.focus()");
            }
            else if (args.Key == "Home" || args.Key == "PageUp")
            {
                this.preventDefault = true;
                await this.be.EvalVoid("document.activeElement.parentElement.children[0]?.focus()");
            }
            else if (args.Key == "ArrowDown")
            {
                this.preventDefault = true;
                string scp = @"
            if (document.activeElement.nextElementSibling?.tagName == 'LI') 
                document.activeElement.nextElementSibling?.focus();
            else if (document.activeElement.parentElement.children[document.activeElement.parentElement.children.length - 1] == document.activeElement) 
                document.activeElement.parentElement.nextElementSibling?.focus();
            else if (document.activeElement.nextElementSibling?.tagName == 'UL') 
                document.activeElement.closest('ul li')?.nextElementSibling?.firstElementChild?.focus();
            else 
                document.activeElement.nextElementSibling?.firstElementChild?.focus();
        ";
                await this.be.EvalVoid(scp);
            }
            else if (args.Key == "ArrowUp")
            {
                this.preventDefault = true;
                string scp = @"
            if (document.activeElement.previousElementSibling?.tagName == 'LI') 
                document.activeElement.previousElementSibling?.focus();
            else if (document.activeElement.previousElementSibling?.tagName == 'UL') 
                document.activeElement.previousElementSibling?.lastElementChild?.focus();
            else 
                document.activeElement.closest('ul')?.previousElementSibling?.focus();
        ";
                await this.be.EvalVoid(scp);
            }
            else if (args.Key == "ArrowLeft")
            {
                this.preventDefault = true;
                if (!model.Collapsed && model.IsParent && !model.Disabled)
                    await this.OnCollapsed.InvokeAsync(model);

                model.Collapsed = true;
                await this.be.EvalVoid("document.activeElement.closest('ul')?.previousElementSibling?.focus()");
            }
            else if (args.Key == "ArrowRight")
            {
                this.preventDefault = true;
                if (model.Collapsed && model.IsParent && !model.Disabled)
                    await this.OnExpanded.InvokeAsync(model);

                model.Collapsed = false;
                await this.be.EvalVoid("document.activeElement.closest('ul')?.nextElementSibling?.focus()");
            }
        }


        void IDisposable.Dispose()
    {
      this.sm.StateChanged -= new NotifyStateChanged(this.GetStateChanged);
    }

    [Inject]
    private BrowserExtensions be { get; set; }

    [Inject]
    private StateManager sm { get; set; }

    public Treeview()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
      interpolatedStringHandler.AppendLiteral("tv-");
      interpolatedStringHandler.AppendFormatted<Guid>(Guid.NewGuid());
      // ISSUE: reference to a compiler-generated field
      this.Id = interpolatedStringHandler.ToStringAndClear();
      // ISSUE: reference to a compiler-generated field
      this.be = (BrowserExtensions) null;
      // ISSUE: reference to a compiler-generated field
      this.sm = (StateManager) null;
      // ISSUE: explicit constructor call
      base.OnInitialized();
    }
  }
}
