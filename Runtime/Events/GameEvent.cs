using System.Collections.Generic;
using UnityEngine;

namespace Gameframe.ScriptableObjects.Events
{  
  [CreateAssetMenu(menuName=MenuNames.EventMenu+"GameEvent")]
  public class GameEvent : ScriptableObject
  {
    private readonly List<IGameEventListener> _listeners = new List<IGameEventListener>();

    public void Raise()
    {
      for ( int i = _listeners.Count-1; i >= 0; i-- )
      {
        _listeners[i].OnEventRaised(this);
      }
    }

    public void AddListener(IGameEventListener listener)
    {
      _listeners.Add(listener);
    }

    public void RemoveListener(IGameEventListener listener)
    {
      _listeners.Remove(listener);
    }
  }
}
