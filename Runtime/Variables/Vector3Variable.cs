using UnityEngine;

namespace Gameframe.ScriptableObjects.Variables
{
  [CreateAssetMenu(menuName=MenuNames.Variables+"Vector3")]
  public class Vector3Variable : BaseVariable, IVariable<Vector3>
  {
    [SerializeField]
    private Vector3 value;
    public Vector3 Value
    {
      get => value;
      set => SetProperty(ref this.value, value);
    }
  }
}