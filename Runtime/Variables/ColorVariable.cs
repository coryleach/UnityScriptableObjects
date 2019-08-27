using System.Collections;
using System.Collections.Generic;
using Gameframe.ScriptableObjects.Events;
using UnityEngine;

namespace Gameframe.ScriptableObjects.Variables
{
  [CreateAssetMenu(menuName = "GameJam/Variables/Color")]
  public class ColorVariable : ScriptableObject, IVariable<Color>
  {
    [SerializeField]
    Color value;
    public Color Value
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