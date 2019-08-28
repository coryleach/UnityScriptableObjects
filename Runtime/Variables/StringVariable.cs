using System.Collections;
using System.Collections.Generic;
using Gameframe.ScriptableObjects.Events;
using UnityEngine;

namespace Gameframe.ScriptableObjects.Variables
{
  [CreateAssetMenu(menuName = MenuNames.Variables+"String")]
  public class StringVariable : ScriptableObject, IVariable<string>
  {
    [SerializeField]
    private string value;
    public string Value
    {
      get => value;
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
    private GameEvent onValueChanged;
  }
}