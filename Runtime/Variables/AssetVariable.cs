using System.Threading.Tasks;
using UnityEngine;

namespace Gameframe.ScriptableObjects.Variables
{
  [CreateAssetMenu(menuName=MenuNames.Variables+"Asset")]
  public class AssetVariable : ScriptableObject
  {
    [SerializeField]
    private string assetName = "";
    public string AssetName => assetName;

#if UNITY_EDITOR
    [SerializeField]
    private string assetPath = "";
#endif

    public virtual Task<Object> FetchAsync()
    {
#if UNITY_EDITOR
      return Task.FromResult(UnityEditor.AssetDatabase.LoadAssetAtPath<Object>(assetPath));
#else
      //TODO: Need runtime asset loader. Should integrate with addressable assets in the future
      return null;
#endif
    }

    public virtual Task<T> FetchAsync<T>() where T : UnityEngine.Object
    {
#if UNITY_EDITOR
      return Task<T>.FromResult(UnityEditor.AssetDatabase.LoadAssetAtPath<T>(assetPath));
#else
      //TODO: Need runtime asset loader
      return null;
#endif
    }

  }
}
