using Gameframe.ScriptableObjects.Events;
using UnityEngine;

namespace Gameframe.ScriptableObjects.Variables
{
  [CreateAssetMenu(menuName=MenuNames.Variables+"Vector3")]
  public class Vector3Variable : ScriptableObject, IVariable<Vector3>
  {
    [SerializeField]
    private Vector3 value;
    public Vector3 Value
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