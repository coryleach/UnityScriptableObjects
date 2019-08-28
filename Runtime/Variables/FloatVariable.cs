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
  }
}