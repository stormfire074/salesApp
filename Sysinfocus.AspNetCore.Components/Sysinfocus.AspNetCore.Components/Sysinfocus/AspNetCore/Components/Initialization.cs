// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Initialization
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class Initialization(StateManager stateManager, BrowserExtensions browserExtensions)
  {
    public bool ShowHeader;
    public string CurrentTheme = "light";
    public string? CurrentAccent;

    public void HandleMainLayoutClickEvent()
    {
      stateManager.Publish((object) this, (object) "mouseup");
    }

    public async Task PreloadJSAndCSSDependencies(params PreloadType[] preloads)
    {
      bool preloadAll = false;
      if (preloads.Length == 0)
        preloadAll = true;
      if (((IEnumerable<PreloadType>) preloads).Contains<PreloadType>(PreloadType.Barcode) | preloadAll)
      {
        stateManager.Publish((object) "BARCODE_JS", (object) true);
        await browserExtensions.AddScript(InitializeSysinfocus.BARCODE_JS);
      }
      if (((IEnumerable<PreloadType>) preloads).Contains<PreloadType>(PreloadType.Charts) | preloadAll)
      {
        stateManager.Publish((object) "ECHARTS_JS", (object) true);
        await browserExtensions.AddScript(InitializeSysinfocus.ECHARTS_JS);
      }
      if (((IEnumerable<PreloadType>) preloads).Contains<PreloadType>(PreloadType.Lottie) | preloadAll)
      {
        stateManager.Publish((object) "LOTTIE_JS", (object) true);
        await browserExtensions.AddScript(InitializeSysinfocus.LOTTIE_JS);
      }
      ValueTask valueTask;
      if (((IEnumerable<PreloadType>) preloads).Contains<PreloadType>(PreloadType.Maps) | preloadAll)
      {
        stateManager.Publish((object) "MAPS_JS", (object) true);
        await browserExtensions.AddStylesheet(InitializeSysinfocus.MAPS_CSS);
        valueTask = browserExtensions.AddScript(InitializeSysinfocus.MAPS_JS, false);
        await valueTask;
      }
      if (((IEnumerable<PreloadType>) preloads).Contains<PreloadType>(PreloadType.QRCode) | preloadAll)
      {
        stateManager.Publish((object) "QRCODE_JS", (object) true);
        valueTask = browserExtensions.AddScript(InitializeSysinfocus.QRCODE_JS);
        await valueTask;
      }
      if (((IEnumerable<PreloadType>) preloads).Contains<PreloadType>(PreloadType.Scanner) | preloadAll)
      {
        stateManager.Publish((object) "CODESCANNER_JS", (object) true);
        valueTask = browserExtensions.AddScript(InitializeSysinfocus.CODESCANNER_JS);
        await valueTask;
      }
      if (!(((IEnumerable<PreloadType>) preloads).Contains<PreloadType>(PreloadType.Sortable) | preloadAll))
        return;
      stateManager.Publish((object) "SORTABLE_JS", (object) true);
      valueTask = browserExtensions.AddScript(InitializeSysinfocus.SORTABLE_JS);
      await valueTask;
      string scp = "let dn = {}; dn.DotNetReference = null; function setRef(r) { dn.DotNetReference = r; } function notify(m,o,n,f,t) { dn.DotNetReference.invokeMethodAsync(m,o,n,f,t) }";
      valueTask = browserExtensions.EvalVoid((object) scp);
      await valueTask;
      scp = (string) null;
    }

    public async Task InitializeTheme()
    {
      ValueTask<string> fromLocalStorage = browserExtensions.GetFromLocalStorage("theme");
      string str1 = await fromLocalStorage;
      this.CurrentTheme = str1 ?? "light";
      str1 = (string) null;
      fromLocalStorage = browserExtensions.GetFromLocalStorage("accent");
      string str2 = await fromLocalStorage;
      this.CurrentAccent = str2;
      str2 = (string) null;
      await this.UpdateAndApplyTheme();
    }

    public async Task ToggleTheme()
    {
      this.CurrentTheme = this.CurrentTheme == "light" ? "dark" : "light";
      await this.UpdateAndApplyTheme();
    }

    public async Task SetAccent(string? accentName)
    {
      await this.RemoveThemeAccent(this.CurrentAccent);
      this.CurrentAccent = accentName;
      await this.UpdateAndApplyTheme();
    }

    private async Task RemoveThemeAccent(string? accent)
    {
      if (!string.IsNullOrWhiteSpace(accent))
        await browserExtensions.EvalVoid((object) ("document.querySelector('body').classList.remove('" + accent + "')"));
      await browserExtensions.EvalVoid((object) "document.querySelector('body').classList.remove('light'); document.querySelector('body').classList.remove('dark')");
    }

    private async Task UpdateThemeAccent(string theme, string? accent)
    {
      ValueTask valueTask = browserExtensions.EvalVoid((object) "document.querySelector('body').classList.remove('light'); document.querySelector('body').classList.remove('dark')");
      await valueTask;
      if (!string.IsNullOrWhiteSpace(theme))
      {
        valueTask = browserExtensions.EvalVoid((object) ("document.querySelector('body').classList.add('" + theme + "')"));
        await valueTask;
      }
      if (string.IsNullOrWhiteSpace(accent))
        return;
      valueTask = browserExtensions.EvalVoid((object) ("document.querySelector('body').classList.add('" + accent + "')"));
      await valueTask;
    }

    private async Task SaveThemeAccent(string theme, string? accent)
    {
      ValueTask valueTask;
      if (!string.IsNullOrWhiteSpace(theme))
      {
        valueTask = browserExtensions.SetToLocalStorage(nameof (theme), theme);
        await valueTask;
      }
      if (!string.IsNullOrWhiteSpace(accent))
      {
        valueTask = browserExtensions.SetToLocalStorage(nameof (accent), accent);
        await valueTask;
      }
      else
      {
        valueTask = browserExtensions.RemoveFromLocalStorage(nameof (accent));
        await valueTask;
      }
    }

    private async Task UpdateAndApplyTheme()
    {
      await this.UpdateThemeAccent(this.CurrentTheme, this.CurrentAccent);
      await this.SaveThemeAccent(this.CurrentTheme, this.CurrentAccent);
    }
  }
}
