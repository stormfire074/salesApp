// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.SpeechToText
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class SpeechToText : ComponentBase, IDisposable
  {
    private static StateManager? smx;

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
    }

    [Parameter]
    public 
    #nullable enable
    string Language { get; set; } = "en-US";

    [Parameter]
    public bool Continuous { get; set; }

    [Parameter]
    public bool InterimResults { get; set; } = true;

    [Parameter]
    public double MaxAlternatives { get; set; } = 2.0;

    [Parameter]
    public EventCallback OnSpeechStart { get; set; }

    [Parameter]
    public EventCallback OnSpeechEnd { get; set; }

    [Parameter]
    public EventCallback<string?> OnSpeechRecognized { get; set; }

    protected override async Task OnInitializedAsync()
    {
      if (SpeechToText.smx == null)
        SpeechToText.smx = new StateManager();
      SpeechToText.smx.StateChanged += new NotifyStateChanged(this.GetStateChanged);
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(715, 4);
      interpolatedStringHandler.AppendLiteral("const recognition = new webkitSpeechRecognition();\r\nrecognition.onstart = function() { DotNet.invokeMethodAsync('");
      interpolatedStringHandler.AppendFormatted(ComponentExtension.ASSEMBLY_NAME);
      interpolatedStringHandler.AppendLiteral("', 'getListening'); };\r\nrecognition.onresult = function(event) { let transcript = event.results[0][0].transcript; let confidence = event.results[0][0].confidence; DotNet.invokeMethodAsync('");
      interpolatedStringHandler.AppendFormatted(ComponentExtension.ASSEMBLY_NAME);
      interpolatedStringHandler.AppendLiteral("', 'getTranscipt', transcript, confidence); };\r\nfunction start(ctn, lang, ma, ir) { recognition.continuous = ctn; recognition.lang = lang; recognition.maxAlternatives = ma; recognition.interimResults = ir; recognition.start(); }\r\nfunction stop() { recognition.stop(); DotNet.invokeMethodAsync('");
      interpolatedStringHandler.AppendFormatted(ComponentExtension.ASSEMBLY_NAME);
      interpolatedStringHandler.AppendLiteral("', 'stoppedListening'); }\r\nrecognition.onspeechend = function() { DotNet.invokeMethodAsync('");
      interpolatedStringHandler.AppendFormatted(ComponentExtension.ASSEMBLY_NAME);
      interpolatedStringHandler.AppendLiteral("', 'stoppedListening'); }\r\n");
      string scp = interpolatedStringHandler.ToStringAndClear();
      await this.be.EvalVoid((object) scp);
      await Task.Delay(200);
      scp = (string) null;
    }

    public async Task StartListening()
    {
      await this.be.JSVoid("start", (object) this.Continuous, (object) this.Language, (object) this.MaxAlternatives, (object) this.InterimResults);
    }

    public async Task StopListening() => await this.be.JSVoid("stop");

    private async void GetStateChanged(object sender, object values)
    {
      if (sender.ToString() == "HandleTranscript")
        await this.OnSpeechRecognized.InvokeAsync(values.ToString());
      else if (sender.ToString() == "HandleListening")
      {
        await this.OnSpeechStart.InvokeAsync();
      }
      else
      {
        if (!(sender.ToString() == "HandleStopListening"))
          return;
        await this.OnSpeechEnd.InvokeAsync();
      }
    }

    [JSInvokable]
    public static void getTranscipt(string text, double confidence)
    {
      SpeechToText.smx?.Publish((object) "HandleTranscript", (object) text);
    }

    [JSInvokable]
    public static void getListening()
    {
      SpeechToText.smx?.Publish((object) "HandleListening", (object) true);
    }

    [JSInvokable]
    public static void stoppedListening()
    {
      SpeechToText.smx?.Publish((object) "HandleStopListening", (object) true);
    }

    void IDisposable.Dispose()
    {
      if (SpeechToText.smx == null)
        return;
      SpeechToText.smx.StateChanged -= new NotifyStateChanged(this.GetStateChanged);
    }

    [Inject]
    private BrowserExtensions be { get; set; } = (BrowserExtensions) null;

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
