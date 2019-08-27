using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Gameframe.ScriptableObjects.Events
{
  public abstract class BaseGameEventListener<T> : MonoBehaviour, IGameEventListener
  {

    protected abstract GameEvent InternalEvent { get; }

    private void OnEnable()
    {
      InternalEvent.AddListener(this);
    }

    private void OnDisable()
    {
      InternalEvent.RemoveListener(this);
    }

    public virtual void OnEventRaised(GameEvent gameEvent)
    {
     
    }
  }
}
