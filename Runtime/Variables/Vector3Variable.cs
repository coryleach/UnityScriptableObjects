using System.Collections;
using System.Collections.Generic;
using Gameframe.ScriptableObjects.Events;
using UnityEngine;

namespace Gameframe.ScriptableObjects.Variables
{
  [CreateAssetMenu(menuName = "GameJam/Variables/Vector3")]
  public class Vector3Variable : ScriptableObject, IVariable<Vector3>
  {
    [SerializeField]
    Vector3 value;
    public Vector3 Value
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