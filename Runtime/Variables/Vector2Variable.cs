using System.Collections;
using System.Collections.Generic;
using Gameframe.ScriptableObjects.Events;
using UnityEngine;

namespace Gameframe.ScriptableObjects.Variables
{
  [CreateAssetMenu(menuName = "GameJam/Variables/Vector2")]
  public class Vector2Variable : ScriptableObject, IVariable<Vector2>
  {
    [SerializeField]
    Vector2 value;
    public Vector2 Value
    {
      get { return value; }
      set
      {
        if (this.value != value)
        {
          this.value = value;
          if (onValueChanged != null)
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