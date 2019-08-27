using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Gameframe.ScriptableObjects.Events
{

  public class StringGameEventListener : BaseGameEventListener<string>
  {

    [SerializeField]
    StringGameEvent stringGameEvent;

    [Serializable]
    public class StringEvent : UnityEvent<string> { }

    [SerializeField]
    StringEvent onEventRaised;

    protected override GameEvent InternalEvent
    {
      get { return stringGameEvent; }
    }

    public override void OnEventRaised(GameEvent gameEvent)
    {
      onEventRaised.Invoke(stringGameEvent.Value);
    }

  }

}