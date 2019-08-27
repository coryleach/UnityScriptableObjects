using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameframe.ScriptableObjects.Events
{
  public abstract class BaseGameEvent<T> : GameEvent
  {
    public abstract T Value { get; set; }

    public void Raise(T value)
    {
      Value = value;
      Raise();
    }
  }
}
