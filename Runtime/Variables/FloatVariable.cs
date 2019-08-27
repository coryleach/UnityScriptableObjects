using System.Collections;
using System.Collections.Generic;
using Gameframe.ScriptableObjects.Events;
using UnityEngine;

namespace Gameframe.ScriptableObjects.Variables
{
  [CreateAssetMenu(menuName ="GameJam/Variables/Float")]
  public class FloatVariable : ScriptableObject, IVariable<float>
  {
    [SerializeField]
    float value;
    public float Value
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