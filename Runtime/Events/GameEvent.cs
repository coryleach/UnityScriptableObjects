using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameframe.ScriptableObjects.Events
{
  [CreateAssetMenu(menuName ="GameJam/Events/GameEvent")]
  public class GameEvent : ScriptableObject
  {
    private List<IGameEventListener> listeners = new List<IGameEventListener>();

    public void Raise()
    {
      for ( int i = listeners.Count-1; i >= 0; i-- )
      {
        listeners[i].OnEventRaised(this);
      }
    }

    public void AddListener(IGameEventListener listener)
    {
      listeners.Add(listener);
    }

    public void RemoveListener(IGameEventListener listener)
    {
      listeners.Remove(listener);
    }
  }
}
