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
    private StringGameEvent stringGameEvent = null;

    [Serializable]
    public class StringEvent : UnityEvent<string> { }

    [SerializeField] 
    private StringEvent onEventRaised = null;

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