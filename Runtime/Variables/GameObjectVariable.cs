using System.Collections;
using System.Collections.Generic;
using Gameframe.ScriptableObjects.Events;
using UnityEngine;
using UnityEngine.Events;

namespace Gameframe.ScriptableObjects.Variables
{

  [CreateAssetMenu(menuName = "GameJam/Variables/GameObject")]
  public class GameObjectVariable : ScriptableObject, IVariable<GameObject>
  {

    [SerializeField]
    bool clearOnEnable = false;

    [SerializeField]
    GameObject gameObject = null;

    [SerializeField]
    GameEvent onValueChanged = null;

    [SerializeField]
    UnityEvent valueChanged = new UnityEvent();
    public UnityEvent OnValueChanged
    {
      get { return valueChanged; }
    }

    public GameObject Value
    {
      get
      {
        return gameObject;
      }
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

    void OnEnable()
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