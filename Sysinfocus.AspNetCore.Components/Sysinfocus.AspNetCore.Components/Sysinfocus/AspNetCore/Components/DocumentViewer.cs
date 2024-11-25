// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.DocumentViewer
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class DocumentViewer : ComponentBase
  {
    private const string forPDF = "https://docs.google.com/viewer?url={document_url}&embedded=true";
    private const string forOffice = "https://view.officeapps.live.com/op/embed.aspx?src={document_url}";
    private const string forImage = "<html><head></head><body><img src='{document_url}' style='width: 100%' /></body></html>";
    private string? source;

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-doc-viewer " + this.Class);
      __builder.AddAttribute(2, "style", "display:flex;flex-direction:column;width:" + this.Width + ";height:" + this.Height + ";" + this.Style);
      __builder.AddAttribute(3, "id", this.Id);
      __builder.AddAttribute(4, "b-yiy5vs5u8w");
      if (!InitializeSysinfocus.IsLicensed)
        __builder.AddMarkupContent(5, "<small class=\"mtb1\" b-yiy5vs5u8w>You are using a trial version.</small>");
      if (this.Type == DocumentType.Image)
      {
        __builder.OpenElement(6, "iframe");
        __builder.AddAttribute(7, "id", "iframe");
        __builder.AddAttribute(8, "name", "docViewer");
        __builder.AddAttribute(9, "title", "Document Viewer");
        __builder.AddAttribute(10, "srcdoc", this.source);
        __builder.AddAttribute(11, "sandbox", "allow-same-origin allow-scripts allow-forms");
        __builder.AddAttribute(12, "b-yiy5vs5u8w");
        __builder.CloseElement();
      }
      else
      {
        __builder.OpenElement(13, "iframe");
        __builder.AddAttribute(14, "id", "iframe");
        __builder.AddAttribute(15, "name", "docViewer");
        __builder.AddAttribute(16, "title", "Document Viewer");
        __builder.AddAttribute(17, "src", this.source);
        __builder.AddAttribute(18, "sandbox", "allow-same-origin allow-scripts allow-forms");
        __builder.AddAttribute(19, "b-yiy5vs5u8w");
        __builder.CloseElement();
      }
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
    public string? Width { get; set; }

    [Parameter]
    public string? Height { get; set; }

    [Parameter]
    public string Source { get; set; }

    [Parameter]
    public DocumentType Type { get; set; }

    protected override Task OnParametersSetAsync()
    {
      string str;
      switch (this.Type)
      {
        case DocumentType.Image:
          str = "<html><head></head><body><img src='{document_url}' style='width: 100%' /></body></html>".Replace("{document_url}", this.Source);
          break;
        case DocumentType.Excel:
        case DocumentType.Powerpoint:
        case DocumentType.Word:
          str = "https://view.officeapps.live.com/op/embed.aspx?src={document_url}".Replace("{document_url}", this.Source);
          break;
        case DocumentType.PDF:
          str = "https://docs.google.com/viewer?url={document_url}&embedded=true".Replace("{document_url}", this.Source);
          break;
        default:
          str = this.Source;
          break;
      }
      this.source = str;
      return Task.CompletedTask;
    }

    [Inject]
    private StateManager sm { get; set; }

    public DocumentViewer()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
      interpolatedStringHandler.AppendLiteral("dv-");
      interpolatedStringHandler.AppendFormatted<Guid>(Guid.NewGuid());
      // ISSUE: reference to a compiler-generated field
      this.Id = interpolatedStringHandler.ToStringAndClear();
      // ISSUE: reference to a compiler-generated field
      this.Width = "100%";
      // ISSUE: reference to a compiler-generated field
      this.Height = "100vh";
      // ISSUE: reference to a compiler-generated field
      this.Source = (string) null;
      // ISSUE: reference to a compiler-generated field
      this.Type = DocumentType.Image;
      // ISSUE: reference to a compiler-generated field
      this.sm = (StateManager) null;
      // ISSUE: explicit constructor call
      base.OnInitialized();
    }
  }
}
