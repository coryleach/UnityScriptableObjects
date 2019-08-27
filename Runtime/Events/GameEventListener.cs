using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Gameframe.ScriptableObjects.Events
{
  public class GameEventListener : MonoBehaviour, IGameEventListener
  {
    public GameEvent gameEvent;
    public UnityEvent action;

    private void OnEnable()
    {
      gameEvent.AddListener(this);
    }

    private void OnDisable()
    {
      gameEvent.RemoveListener(this);
    }

    public void OnEventRaised(GameEvent gameEvent)
    {
      action.Invoke();
    }
  }
}
