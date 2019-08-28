using System.Collections;
using System.Collections.Generic;
using Gameframe.ScriptableObjects.Events;
using UnityEngine;

namespace Gameframe.ScriptableObjects.Variables
{
  [CreateAssetMenu(menuName = MenuNames.Variables+"Int")]
  public class IntVariable : ScriptableObject, IVariable<int>
  {
    [SerializeField]
    private int value;
    public int Value
    {
      get => value;
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
    private GameEvent onValueChanged;
  }
}
