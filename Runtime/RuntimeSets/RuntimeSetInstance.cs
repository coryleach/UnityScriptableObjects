using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameframe.ScriptableObjects.RuntimeSets
{

  public class RuntimeSetInstance : MonoBehaviour
  {

    [SerializeField]
    GameObjectRuntimeSet set;

    void Awake()
    {
      set.Add(this.gameObject);
    }

    void OnDestroy()
    {
      set.Remove(this.gameObject);
    }

  }

}
