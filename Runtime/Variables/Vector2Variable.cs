using UnityEngine;

namespace Gameframe.ScriptableObjects.Variables
{
  [CreateAssetMenu(menuName = MenuNames.Variables+"Vector2")]
  public class Vector2Variable : BaseVariable, IVariable<Vector2>
  {
    [SerializeField]
    private Vector2 value;
    public Vector2 Value
    {
      get => value;
      set => SetProperty(ref this.value, value);
    }
  }
}