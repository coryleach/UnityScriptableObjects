using UnityEngine;

namespace Gameframe.ScriptableObjects.Variables
{
  [CreateAssetMenu(menuName=MenuNames.Variables+"Float")]
  public class FloatVariable : BaseVariable, IVariable<float>
  {
    [SerializeField]
    private float value;
    public float Value
    {
      get => value;
      set => SetProperty(ref this.value, value);
    }
  }
}