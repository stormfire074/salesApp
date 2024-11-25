// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.AboutSysinfocus
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class AboutSysinfocus : ComponentBase
  {
    protected override void BuildRenderTree(
    #nullable disable
    RenderTreeBuilder __builder)
    {
      __builder.AddMarkupContent(0, "<style>\r\n    .sbc-about { text-decoration:none; width: fit-content; display: flex; gap: 0.5rem; align-items: center; font-size: 12px; background-color: var(--primary-fg); color: var(--primary-bg); padding: 0.5rem; border-radius: 6px; transition: all 300ms ease-in-out }\r\n    .sbc-about img { width: 24px; height: 24px; transition: all 300ms ease-in-out }\r\n    .sbc-about div { display: flex; flex-direction: column }\r\n    .sbc-about:hover { cursor: pointer }\r\n    .sbc-about:hover img { transform: scale(1.3) }\r\n</style>\r\n");
      __builder.AddMarkupContent(1, "<a class=\"sbc-about\" href=\"https://sysinfocus.com/simple-ui/\" target=\"_blank\"><img src=\"https://sysinfocus.github.io/shadcn-inspired/favicon.ico\">\r\n    <div><small>Built with ❤️</small>\r\n        <b>Sysinfocus</b></div></a>");
    }

    [Inject]
    private 
    #nullable enable
    StateManager sm { get; set; } = (StateManager) null;
  }
}
