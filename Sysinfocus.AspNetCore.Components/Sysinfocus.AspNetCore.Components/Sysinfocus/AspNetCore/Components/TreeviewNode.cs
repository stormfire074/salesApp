// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.TreeviewNode
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.CompilerServices;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class TreeviewNode : ComponentBase
  {
    private bool preventDefault;

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      foreach (TreeviewModel treeviewModel in (IEnumerable<TreeviewModel>) this.Nodes.Where<TreeviewModel>((Func<TreeviewModel, bool>) (x =>
      {
        int parentId = x.ParentId;
        int? id = this.Parent?.Id;
        int valueOrDefault = id.GetValueOrDefault();
        return parentId == valueOrDefault & id.HasValue;
      })).OrderByDescending<TreeviewModel, int>((Func<TreeviewModel, int>) (a => a.Sequence)))
      {
        TreeviewModel node = treeviewModel;
        string markupContent = (string) null;
        if (this.EnableIcons)
          markupContent = string.IsNullOrWhiteSpace(node.Icon) ? (string) null : "<span style='pointer-events:none' class='material-symbols-outlined'>" + (node.Collapsed ? node.AlternateIcon : node.Icon) + "</span>";
        if (this.UpdateLevel && node.Level == -1)
          node.Level = this.Parent.Level + 1;
        if (this.Nodes.Any<TreeviewModel>((Func<TreeviewModel, bool>) (a => a.ParentId == node.Id)))
        {
          node.IsParent = true;
          __builder.OpenElement(0, "li");
          __builder.AddAttribute(1, "tabindex", (object) (node.Disabled ? -1 : 0));
          __builder.AddAttribute(2, "class", "parent " + (node.Disabled ? " disabled" : (string) null) + " " + (node.Collapsed ? "collapse" : (string) null) + " " + node.Class);
          __builder.AddAttribute(3, "style", node.Style);
          __builder.AddAttribute<KeyboardEventArgs>(4, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, (Func<KeyboardEventArgs, Task>) (async x => await this.HandleKeyDown(x, node))));
          __builder.AddEventPreventDefaultAttribute(5, "onkeydown", this.preventDefault);
          __builder.AddAttribute<MouseEventArgs>(6, "oncontextmenu", EventCallback.Factory.Create<MouseEventArgs>((object) this, (Func<MouseEventArgs, Task>) (async x => await this.OnContextMenu.InvokeAsync((x, node)))));
          __builder.AddEventPreventDefaultAttribute(7, "oncontextmenu", true);
          __builder.AddAttribute<MouseEventArgs>(8, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, (Func<Task>) (async () => await this.HandleClick(node))));
          __builder.SetKey((object) node.Id);
          __builder.AddContent(9, (MarkupString) markupContent);
          __builder.AddContent(10, " ");
          __builder.AddContent(11, node.Text);
          __builder.CloseElement();
          if (!node.Collapsed)
          {
            __builder.OpenElement(12, "ul");
            __builder.OpenComponent<TreeviewNode>(13);
            __builder.AddComponentParameter(14, "Parent", (object) RuntimeHelpers.TypeCheck<TreeviewModel>(node));
            __builder.AddComponentParameter(15, "OnClick", (object) RuntimeHelpers.TypeCheck<EventCallback<TreeviewModel>>(EventCallback.Factory.Create<TreeviewModel>((object) this, this.OnClick)));
            __builder.AddComponentParameter(16, "OnCollapsed", (object) RuntimeHelpers.TypeCheck<EventCallback<TreeviewModel>>(EventCallback.Factory.Create<TreeviewModel>((object) this, this.OnCollapsed)));
            __builder.AddComponentParameter(17, "OnExpanded", (object) RuntimeHelpers.TypeCheck<EventCallback<TreeviewModel>>(EventCallback.Factory.Create<TreeviewModel>((object) this, this.OnExpanded)));
            __builder.AddComponentParameter(18, "OnContextMenu", (object) RuntimeHelpers.TypeCheck<EventCallback<(MouseEventArgs, TreeviewModel)>>(EventCallback.Factory.Create<(MouseEventArgs, TreeviewModel)>((object) this, this.OnContextMenu)));
            __builder.AddComponentParameter(19, "EnableIcons", (object) RuntimeHelpers.TypeCheck<bool>(this.EnableIcons));
            __builder.CloseComponent();
            __builder.CloseElement();
          }
        }
        else
        {
          __builder.OpenElement(20, "li");
          __builder.AddAttribute(21, "tabindex", (object) (node.Disabled ? -1 : 0));
          __builder.AddAttribute(22, "class", (node.Disabled ? "disabled" : (string) null) + " " + node.Class);
          __builder.AddAttribute(23, "style", node.Style);
          __builder.AddAttribute<KeyboardEventArgs>(24, "onkeydown", EventCallback.Factory.Create<KeyboardEventArgs>((object) this, (Func<KeyboardEventArgs, Task>) (async x => await this.HandleKeyDown(x, node))));
          __builder.AddEventPreventDefaultAttribute(25, "onkeydown", this.preventDefault);
          __builder.AddAttribute<MouseEventArgs>(26, "oncontextmenu", EventCallback.Factory.Create<MouseEventArgs>((object) this, (Func<MouseEventArgs, Task>) (async x => await this.OnContextMenu.InvokeAsync((x, node)))));
          __builder.AddEventPreventDefaultAttribute(27, "oncontextmenu", true);
          __builder.AddAttribute<MouseEventArgs>(28, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, (Func<Task>) (async () => await this.HandleClick(node))));
          __builder.SetKey((object) node.Id);
          __builder.AddContent(29, (MarkupString) markupContent);
          __builder.AddContent(30, " ");
          __builder.AddContent(31, node.Text);
          __builder.CloseElement();
        }
      }
    }

    [CascadingParameter]
    public 
    #nullable enable
    List<TreeviewModel> Nodes { get; set; } = new List<TreeviewModel>();

    [Parameter]
    public TreeviewModel? Parent { get; set; }

    [Parameter]
    public EventCallback<TreeviewModel> OnClick { get; set; }

    [Parameter]
    public EventCallback<TreeviewModel> OnCollapsed { get; set; }

    [Parameter]
    public EventCallback<TreeviewModel> OnExpanded { get; set; }

    [Parameter]
    public EventCallback<(MouseEventArgs, TreeviewModel)> OnContextMenu { get; set; }

    [Parameter]
    public bool EnableIcons { get; set; }

    [Parameter]
    public bool UpdateLevel { get; set; }

        private async Task HandleClick(TreeviewModel model)
        {
            if (model.Disabled)
                return;

            model.Collapsed = !model.Collapsed;

            // Call StateHasChanged directly without casting
            StateHasChanged();

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

                // Call StateHasChanged directly
                StateHasChanged();

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


        [Inject]
    private BrowserExtensions be { get; set; } = (BrowserExtensions) null;

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
