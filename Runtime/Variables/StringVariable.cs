using UnityEngine;

namespace Gameframe.ScriptableObjects.Variables
{
  [CreateAssetMenu(menuName = MenuNames.Variables+"String")]
  public class StringVariable : BaseVariable, IVariable<string>
  {
    [SerializeField]
    private string value;
    public string Value
    {
      get => value;
      set => SetProperty(ref this.value, value);
    }
  }
}