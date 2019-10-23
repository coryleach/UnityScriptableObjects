using UnityEngine;

namespace Gameframe.ScriptableObjects.Variables
{
  [CreateAssetMenu(menuName = MenuNames.Variables+"Int")]
  public class IntVariable : BaseVariable, IVariable<int>
  {
    [SerializeField]
    private int value;
    public int Value
    {
      get => value;
      set => SetProperty(ref this.value, value);
    }
  }
}
