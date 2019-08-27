using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameframe.ScriptableObjects.Events
{

  public interface IGameEventListener
  {
    void OnEventRaised(GameEvent gameEvent);
  }

}
