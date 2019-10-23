using Gameframe.ScriptableObjects.Events;
using UnityEngine;

namespace Gameframe.ScriptableObjects.Variables
{
  [CreateAssetMenu(menuName=MenuNames.Variables+"Color")]
  public class ColorVariable : BaseVariable, IVariable<Color>
  {
    [SerializeField]
    private Color value;
    public Color Value
    {
      get => value;
      set => SetProperty(ref this.value, value);
    }
  }
}