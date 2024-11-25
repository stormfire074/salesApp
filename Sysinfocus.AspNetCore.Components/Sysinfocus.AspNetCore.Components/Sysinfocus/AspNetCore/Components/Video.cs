// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.Video
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Runtime.CompilerServices;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class Video : ComponentBase
  {
    private bool isPlaying;

    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "sbc-video " + this.Class);
      __builder.AddAttribute(2, "style", "width: " + this.Width + "; height: " + this.Height + "; " + this.Style);
      __builder.AddAttribute(3, "id", this.Id);
      __builder.AddAttribute(4, "b-owfw8plxlk");
      __builder.OpenElement(5, "img");
      __builder.AddAttribute(6, "src", "https://i.ytimg.com/vi/" + this.Source + "/hqdefault.jpg");
      __builder.AddAttribute(7, "b-owfw8plxlk");
      __builder.CloseElement();
      __builder.AddMarkupContent(8, "\r\n    ");
      __builder.OpenComponent<Icon>(9);
      __builder.AddComponentParameter(10, "Name", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<string>(!this.isPlaying ? "play_circle" : "pause_circle"));
      __builder.AddComponentParameter(11, "Class", (object) "sbc-video-play");
      __builder.AddComponentParameter(12, "Size", (object) "48px");
      __builder.AddComponentParameter(13, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback<MouseEventArgs>>(EventCallback.Factory.Create<MouseEventArgs>((object) this, new Action(this.HandlePlay))));
      __builder.CloseComponent();
      if (this.isPlaying)
      {
        __builder.OpenElement(14, "div");
        __builder.AddAttribute(15, "class", "sbc-video-source");
        __builder.AddAttribute(16, "style", !this.FullScreen ? "width: 100%; height: 100%; position: absolute; left: 0; top: 0;" : (string) null);
        __builder.AddAttribute(17, "b-owfw8plxlk");
        __builder.OpenElement(18, "iframe");
        __builder.AddAttribute(19, "style", "width: 100%; height: 100%");
        __builder.AddAttribute(20, "src", "https://www.youtube.com/embed/" + this.Source + "?si=ygmluXFI3uhW8MS_&rel=0&autoplay=1" + (this.ShowControls ? (string) null : "&controls=0"));
        __builder.AddAttribute(21, "title", "YouTube video player");
        __builder.AddAttribute(22, "frameborder", "0");
        __builder.AddAttribute(23, "allow", "accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share");
        __builder.AddAttribute(24, "referrerpolicy", "strict-origin-when-cross-origin");
        __builder.AddAttribute(25, "allowfullscreen");
        __builder.AddAttribute(26, "b-owfw8plxlk");
        __builder.CloseElement();
        __builder.AddMarkupContent(27, "\r\n            ");
        __builder.OpenComponent<Icon>(28);
        __builder.AddComponentParameter(29, "Name", (object) "close");
        __builder.AddComponentParameter(30, "Class", (object) "sbc-video-close");
        __builder.AddComponentParameter(31, "Style", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<string>(this.FullScreen ? (string) null : "position: absolute; padding: 0.5rem"));
        __builder.AddComponentParameter(32, "Color", (object) "white");
        __builder.AddComponentParameter(33, "Size", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<string>(this.FullScreen ? "48px" : "24px"));
        __builder.AddComponentParameter(34, "OnClick", (object) Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<EventCallback<MouseEventArgs>>(EventCallback.Factory.Create<MouseEventArgs>((object) this, new Action(this.HandlePlay))));
        __builder.CloseComponent();
        __builder.CloseElement();
      }
      __builder.CloseElement();
    }

    [Parameter]
    public 
    #nullable enable
    string? Source { get; set; }

    [Parameter]
    public string? Id { get; set; }

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Parameter]
    public string? Width { get; set; }

    [Parameter]
    public string? Height { get; set; }

    [Parameter]
    public bool FullScreen { get; set; }

    [Parameter]
    public bool ShowControls { get; set; }

    private void HandlePlay() => this.isPlaying = !this.isPlaying;

    [Inject]
    private StateManager sm { get; set; }

    public Video()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
      interpolatedStringHandler.AppendLiteral("video-");
      interpolatedStringHandler.AppendFormatted<Guid>(Guid.NewGuid());
      // ISSUE: reference to a compiler-generated field
      this.Id = interpolatedStringHandler.ToStringAndClear();
      // ISSUE: reference to a compiler-generated field
      this.Width = "300px";
      // ISSUE: reference to a compiler-generated field
      this.Height = "200px";
      // ISSUE: reference to a compiler-generated field
      this.sm = (StateManager) null;
      // ISSUE: explicit constructor call
      base.OnInitialized();
    }
  }
}
