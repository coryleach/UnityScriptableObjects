using System.Collections;
using System.Collections.Generic;
using Gameframe.ScriptableObjects.Events;
using UnityEngine;

namespace Gameframe.ScriptableObjects.Variables
{
  [CreateAssetMenu(menuName = "GameJam/Variables/Int")]
  public class IntVariable : ScriptableObject, IVariable<int>
  {
    [SerializeField]
    int value;
    public int Value
    {
      get { return value; }
      set
      {
        if ( this.value != value )
        {
          this.value = value;
          if ( onValueChanged != null )
          {
            onValueChanged.Raise();
          }
        }
      }
    }

    [SerializeField]
    GameEvent onValueChanged;
  }
}
