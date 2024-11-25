// Decompiled with JetBrains decompiler
// Type: Sysinfocus.AspNetCore.Components.StateManager
// Assembly: Sysinfocus.AspNetCore.Components, Version=0.0.1.9, Culture=neutral, PublicKeyToken=null
// MVID: 0600E25E-71A8-4862-A214-F603368A4A0E
// Assembly location: C:\Users\SyedShoaibAliShah\OneDrive - Axelliant, LLC\Documents\Sysinfocus.AspNetCore.Components.dll

using System.Collections.Concurrent;

#nullable enable
namespace Sysinfocus.AspNetCore.Components
{
  public class StateManager
  {
    private readonly ConcurrentDictionary<object, object>? _preservedState;

    public event NotifyStateChanged? StateChanged;

    public StateManager() => this._preservedState = new ConcurrentDictionary<object, object>();

    public void Publish(object sender, object state)
    {
      NotifyStateChanged stateChanged = this.StateChanged;
      if (stateChanged != null)
        stateChanged(sender, state);
      if (this._preservedState == null)
        return;
      this._preservedState.TryAdd(sender, state);
    }

    public object? GetFromState(object sender)
    {
      object obj;
      return this._preservedState == null || !this._preservedState.TryGetValue(sender, out obj) ? (object) null : obj;
    }

    public object? PopFromState(object sender)
    {
      object obj;
      if (this._preservedState == null || !this._preservedState.TryGetValue(sender, out obj))
        return (object) null;
      this._preservedState.TryRemove(sender, out object _);
      return obj;
    }

    public void ClearState() => this._preservedState?.Clear();
  }
}
