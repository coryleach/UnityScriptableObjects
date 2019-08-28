using Gameframe.ScriptableObjects.Events;
using UnityEngine;
using UnityEngine.Events;

namespace Gameframe.ScriptableObjects.Variables
{
  [CreateAssetMenu(menuName=MenuNames.Variables+"GameObject")]
  public class GameObjectVariable : ScriptableObject, IVariable<GameObject>
  {
    [SerializeField]
    private bool clearOnEnable = false;

    [SerializeField]
    private GameObject gameObject = null;

    [SerializeField]
    private GameEvent onValueChanged = null;

    [SerializeField]
    private UnityEvent valueChanged = new UnityEvent();
    public UnityEvent OnValueChanged => valueChanged;

    public GameObject Value
    {
      get => gameObject;
      set
      {
        if (gameObject != value)
        {
          gameObject = value;
          valueChanged.Invoke();
          onValueChanged?.Raise();
        }
      }
    }

    private void OnEnable()
    {
      if (clearOnEnable)
      {
        Value = null;
      }
    }

    public void RaisedPropertyChanged()
    {
      onValueChanged.Raise();
    }

    public void Clear()
    {
      Value = null;
    }
  }
}