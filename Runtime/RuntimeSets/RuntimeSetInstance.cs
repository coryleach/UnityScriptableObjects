using UnityEngine;

namespace Gameframe.ScriptableObjects.RuntimeSets
{
  public class RuntimeSetInstance : MonoBehaviour
  {
    [SerializeField]
    private GameObjectRuntimeSet set = null;

    private void Awake()
    {
      set.Add(gameObject);
    }

    private void OnDestroy()
    {
      set.Remove(gameObject);
    }
  }
}
