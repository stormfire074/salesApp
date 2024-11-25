// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.TextToSpeech
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class TextToSpeech : ComponentBase, IDisposable
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
    string Text { get; set; } = string.Empty;

    [Parameter]
    public string Language { get; set; } = "en-US";

    [Parameter]
    public bool Continuous { get; set; }

    [Parameter]
    public bool InterimResults { get; set; }

    [Parameter]
    public int MaxAlternatives { get; set; } = 1;

    [Parameter]
    public int VoiceID { get; set; } = 0;

    [Parameter]
    public double Pitch { get; set; } = 0.9;

    [Parameter]
    public double Rate { get; set; } = 0.9;

    [Parameter]
    public double Volume { get; set; } = 1.0;

    [Parameter]
    public EventCallback OnSpeechEnd { get; set; }

    protected override async Task OnInitializedAsync()
    {
      if (TextToSpeech.smx == null)
        TextToSpeech.smx = new StateManager();
      TextToSpeech.smx.StateChanged += new NotifyStateChanged(this.GetStateChanged);
      string scp = "const voices = window.speechSynthesis.getVoices();\r\nfunction getVoices() { const vo = []; window.speechSynthesis.getVoices().forEach(v => { vo.push(v.name); }); return vo; }\r\nfunction speak(txt, lang, voice, pitch, rate, volume) { const utterThis = new SpeechSynthesisUtterance(txt); utterThis.voice = speechSynthesis.getVoices()[voice]; utterThis.pitch = pitch; utterThis.rate = rate; utterThis.volume = volume; utterThis.lang = lang; speechSynthesis.speak(utterThis, speechSynthesis.QUEUE_FLUSH, null); utterThis.addEventListener('end', e => DotNet.invokeMethodAsync('" + ComponentExtension.ASSEMBLY_NAME + "','speechEnded')); }\r\nfunction pause() { speechSynthesis.pause() }\r\nfunction resume() { speechSynthesis.resume() }\r\nfunction stop() { speechSynthesis.cancel() }";
      await this.be.EvalVoid((object) scp);
      await Task.Delay(200);
      scp = (string) null;
    }

    public async Task<bool> IsSpeaking()
    {
      bool flag = await this.be.JSGet<bool>("speechSynthesis.speaking");
      return flag;
    }

    public async Task Speak()
    {
      await Task.Delay(50);
      await this.be.JSVoid("speak", (object) this.Text, (object) this.Language, (object) this.VoiceID, (object) this.Pitch, (object) this.Rate, (object) this.Volume);
    }

    public async Task Pause() => await this.be.JSVoid("pause");

    public async Task Resume() => await this.be.JSVoid("resume");

    public async Task Stop() => await this.be.JSVoid("stop");

    public async Task<string[]> GetVoices()
    {
      await Task.Delay(50);
      string[] voices = await this.be.JSGet<string[]>("getVoices");
      return voices;
    }

    private async void GetStateChanged(object sender, object values)
    {
      if (!(sender.ToString() == "HandleSpeechEnd") || !(values is bool))
        return;
      await this.OnSpeechEnd.InvokeAsync();
    }

    [JSInvokable]
    public static void speechEnded()
    {
      TextToSpeech.smx?.Publish((object) "HandleSpeechEnd", (object) true);
    }

    void IDisposable.Dispose()
    {
      if (TextToSpeech.smx == null)
        return;
      TextToSpeech.smx.StateChanged -= new NotifyStateChanged(this.GetStateChanged);
    }

    [Inject]
    private BrowserExtensions be { get; set; } = (BrowserExtensions) null;

    [Inject]
    private StateManager sm { get; set; } = (StateManager) null;
  }
}
