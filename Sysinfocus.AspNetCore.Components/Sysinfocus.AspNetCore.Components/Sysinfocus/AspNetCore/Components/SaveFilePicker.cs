// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.SaveFilePicker
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class SaveFilePicker : ComponentBase
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
    }

    [Parameter]
    public 
    #nullable enable
    string? Accept { get; set; } = "{ 'text/plain': ['.txt'] }";

    [Parameter]
    public string? Description { get; set; } = "Text file";

    [Parameter]
    public string? SuggestedName { get; set; } = "example.txt";

    [Parameter]
    public string? InitialLocation { get; set; } = "downloads";

    [Parameter]
    public bool ExcludeAcceptAllOption { get; set; }

    protected override async Task OnInitializedAsync()
    {
      string eao = this.ExcludeAcceptAllOption ? "true" : "false";
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(799, 7);
      interpolatedStringHandler.AppendLiteral("function regularDownload(blob, contentType, filename) { const blobURL = window.URL.createObjectURL(new Blob([blob], { type: contentType }));\r\nconst a = document.createElement('a'); a.href = blobURL; a.download = \"");
      interpolatedStringHandler.AppendFormatted(this.SuggestedName);
      interpolatedStringHandler.AppendLiteral("\"; a.style.display = 'none'; document.body.append(a); a.click();\r\nsetTimeout(() => { window.URL.revokeObjectURL(blobURL); a.remove(); }, 1000); }\r\nasync function getNewFileHandle(blob, ct) { if ('showSaveFilePicker' in window) { try {\r\nconst opts = { startIn: \"");
      interpolatedStringHandler.AppendFormatted(this.InitialLocation);
      interpolatedStringHandler.AppendLiteral("\", types: [ { description: \"");
      interpolatedStringHandler.AppendFormatted(this.Description);
      interpolatedStringHandler.AppendLiteral("\", accept: ");
      interpolatedStringHandler.AppendFormatted(this.Accept);
      interpolatedStringHandler.AppendLiteral(", suggestedName: \"");
      interpolatedStringHandler.AppendFormatted(this.SuggestedName);
      interpolatedStringHandler.AppendLiteral("\" }, ], excludeAcceptAllOption: ");
      interpolatedStringHandler.AppendFormatted(eao);
      interpolatedStringHandler.AppendLiteral(" };\r\nconst handle = await window.showSaveFilePicker(opts);\r\nif (!handle) return; const write = await handle.createWritable(); await write.write(blob); await write.close(); return;\r\n} catch { } } else { regularDownload(blob, ct, \"");
      interpolatedStringHandler.AppendFormatted(this.SuggestedName);
      interpolatedStringHandler.AppendLiteral("\"); } }");
      string scp = interpolatedStringHandler.ToStringAndClear();
      await this.be.EvalVoid((object) scp);
      eao = (string) null;
      scp = (string) null;
    }

    public async Task SaveFile(byte[] content, string optionalContentType = "text/plain")
    {
      await this.be.JSVoid("getNewFileHandle", (object) content, (object) optionalContentType);
    }

    public async Task DownloadFile(byte[] content, string contentType = "application/octet-stream", string filename = "download")
    {
      await this.be.JSVoid("regularDownload", (object) content, (object) contentType, (object) filename);
    }

    public async Task DownloadFile(object content, string contentType = "text/plain", string filename = "download.txt")
    {
      await this.be.JSVoid("regularDownload", content, (object) contentType, (object) filename);
    }

    [Inject]
    private BrowserExtensions be { get; set; } = (BrowserExtensions) null;

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
