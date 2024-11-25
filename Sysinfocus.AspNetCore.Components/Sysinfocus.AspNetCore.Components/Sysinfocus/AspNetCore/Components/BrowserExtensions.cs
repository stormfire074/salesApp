// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.BrowserExtensions
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class BrowserExtensions(IJSRuntime jsr, NavigationManager navigationManager)
  {
    private ConcurrentDictionary<string, object> _navigationData = new ConcurrentDictionary<string, object>();

    public void Goto(string url, bool forceLoad = false, bool replace = false)
    {
      navigationManager.NavigateTo(url, forceLoad, replace);
    }

    public void Goto<T>(string url, T value)
    {
      navigationManager.NavigateTo(url);
      if (this._navigationData.ContainsKey(url))
        this._navigationData[url] = (object) value;
      else
        this._navigationData.TryAdd(url, (object) value);
    }

    public T? GetModelData<T>(string url)
    {
      if (this._navigationData.IsEmpty)
      {
        this.Goto("");
        return default (T);
      }
      T modelData = (T) this._navigationData[url];
      if ((object) modelData != null)
        return modelData;
      this.Goto("");
      return default (T);
    }

    public async ValueTask Open(string url)
    {
      await jsr.InvokeVoidAsync("window.open", (object) url, (object) "_blank");
    }

    public async ValueTask SetToLocalStorage(string key, string value)
    {
      await jsr.InvokeVoidAsync("localStorage.setItem", (object) key, (object) value);
    }

    public async ValueTask<string?> GetFromLocalStorage(string key, string? defaultValue = null)
    {
      string str = await jsr.InvokeAsync<string>("localStorage.getItem", (object) key);
      return str ?? defaultValue;
    }

    public async ValueTask RemoveFromLocalStorage(string key)
    {
      await jsr.InvokeVoidAsync("localStorage.removeItem", (object) key);
    }

    public async ValueTask SetToSessionStorage(string key, string value)
    {
      await jsr.InvokeVoidAsync("sessionStorage.setItem", (object) key, (object) value);
    }

    public async ValueTask<string?> GetFromSessionStorage(string key, string? defaultValue = null)
    {
      string str = await jsr.InvokeAsync<string>("sessionStorage.getItem", (object) key);
      return str ?? defaultValue;
    }

    public async ValueTask RemoveFromSessionStorage(string key)
    {
      await jsr.InvokeVoidAsync("sessionStorage.removeItem", (object) key);
    }

    public async ValueTask SetFocus(string element)
    {
      await Task.Delay(100);
      await this.EvalVoid((object) ("document.querySelector('" + element + "')?.focus()"));
    }

    public async ValueTask EvalVoid(params object[] value)
    {
      await jsr.InvokeVoidAsync("eval", value);
    }

    public async ValueTask<T> EvalGet<T>(params object[] value)
    {
      T obj = await jsr.InvokeAsync<T>("eval", value);
      return obj;
    }

    public async ValueTask JSVoid(string identifier, params object[] value)
    {
      await jsr.InvokeVoidAsync(identifier, value);
    }

    public async ValueTask<T> JSGet<T>(string identifier, params object[] value)
    {
      T obj = await jsr.InvokeAsync<T>(identifier, value);
      return obj;
    }

    public async ValueTask<bool> IsDesktop()
    {
      bool flag = await jsr.InvokeAsync<bool>("eval", (object) "window.innerWidth >= 800");
      return flag;
    }

    public string GetBaseUrl() => navigationManager.BaseUri.ToString();

    public string GetUrl() => navigationManager.Uri.ToString();

    public async ValueTask AddStylesheet(string source, string? integrity = null, string? crossorigin = null)
    {
      string place = "document.head.appendChild(link);";
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(263, 5);
      interpolatedStringHandler.AppendLiteral("let bFound = false; Object.values(document.styleSheets).forEach(s => { if (s.src == '");
      interpolatedStringHandler.AppendFormatted(source);
      interpolatedStringHandler.AppendLiteral("') bFound = true; }); if (bFound === false) { const link = document.createElement('link'); link.rel = 'stylesheet'; link.integrity = '");
      interpolatedStringHandler.AppendFormatted(integrity);
      interpolatedStringHandler.AppendLiteral("'; link.crossorigin = '");
      interpolatedStringHandler.AppendFormatted(crossorigin);
      interpolatedStringHandler.AppendLiteral("'; link.href = '");
      interpolatedStringHandler.AppendFormatted(source);
      interpolatedStringHandler.AppendLiteral("'; ");
      interpolatedStringHandler.AppendFormatted(place);
      interpolatedStringHandler.AppendLiteral(" }");
      string scp = interpolatedStringHandler.ToStringAndClear();
      await Task.Delay(50);
      await this.EvalVoid((object) scp);
      place = (string) null;
      scp = (string) null;
    }

    public async ValueTask AddScript(
      string source,
      bool isAsync = true,
      string? integrity = null,
      string? crossorigin = null,
      bool beforeBody = false)
    {
      string place = "document.body.appendChild(script);";
      if (beforeBody)
        place = "document.head.appendChild(script);";
      string sb = "const script = document.createElement('script'); script.type = 'text/javascript'; ";
      if (isAsync)
        sb += "script.async = true;";
      if (integrity != null)
        sb = sb + "script.integrity = '" + integrity + "';";
      if (crossorigin != null)
        sb = sb + "script.crossorigin = '" + crossorigin + "';";
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(148, 4);
      interpolatedStringHandler.AppendLiteral("let bFound = false; Object.values(document.scripts).forEach(s => { if (s.src == '");
      interpolatedStringHandler.AppendFormatted(source);
      interpolatedStringHandler.AppendLiteral("') bFound = true; }); if (bFound === false) { ");
      interpolatedStringHandler.AppendFormatted(sb);
      interpolatedStringHandler.AppendLiteral("; script.src = '");
      interpolatedStringHandler.AppendFormatted(source);
      interpolatedStringHandler.AppendLiteral("'; ");
      interpolatedStringHandler.AppendFormatted(place);
      interpolatedStringHandler.AppendLiteral(" }");
      string scp = interpolatedStringHandler.ToStringAndClear();
      await Task.Delay(50);
      await this.EvalVoid((object) scp);
      place = (string) null;
      sb = (string) null;
      scp = (string) null;
    }

    public async ValueTask RemoveScript(string source)
    {
      string scp = "let found = null; Object.values(document.scripts).forEach(s => { if (s.src == '" + source + "') found = s; }); if (found !== null) found.remove();";
      await Task.Delay(50);
      await this.EvalVoid((object) scp);
      scp = (string) null;
    }

    public async ValueTask SetPosition(
      string elementToPosition,
      string? sourceElement = null,
      double? x = 0.0,
      double? y = 0.0)
    {
      await Task.Delay(10);
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(606, 7);
      interpolatedStringHandler.AppendLiteral("const sourceElement = '");
      interpolatedStringHandler.AppendFormatted(sourceElement);
      interpolatedStringHandler.AppendLiteral("' == null ? document.querySelector('");
      interpolatedStringHandler.AppendFormatted(sourceElement);
      interpolatedStringHandler.AppendLiteral("') : document.elementFromPoint(");
      interpolatedStringHandler.AppendFormatted<double?>(x);
      interpolatedStringHandler.AppendLiteral(",");
      interpolatedStringHandler.AppendFormatted<double?>(y);
      interpolatedStringHandler.AppendLiteral(");\r\nconst e2p = document.querySelector('");
      interpolatedStringHandler.AppendFormatted(elementToPosition);
      interpolatedStringHandler.AppendLiteral("');const seRect = sourceElement.getBoundingClientRect();const ww = window.innerWidth;\r\nconst wh = window.innerHeight;const pw = e2p.clientWidth;const ph = e2p.clientHeight;const sx = (seRect.x + seRect.width + pw);\r\nconst sy = (seRect.y + seRect.height + ph);const positionLeft = ww > sx ? (");
      interpolatedStringHandler.AppendFormatted<double?>(x);
      interpolatedStringHandler.AppendLiteral(" || seRect.x)+8 : (ww - pw);const positionTop = wh > sy ? (");
      interpolatedStringHandler.AppendFormatted<double?>(y);
      interpolatedStringHandler.AppendLiteral(" || seRect.y)+8 : (wh - ph)\r\ne2p.style.left = positionLeft + 'px';e2p.style.top = positionTop + 'px';e2p.style.opacity = 1;\r\n");
      string scp = interpolatedStringHandler.ToStringAndClear();
      await this.EvalVoid((object) scp);
      scp = (string) null;
    }
  }
}
