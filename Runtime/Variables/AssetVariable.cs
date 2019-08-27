using System.Threading.Tasks;

namespace Gameframe.ScriptableObjects.Variables
{
  using UnityEngine;

  [CreateAssetMenu( menuName = "Variables/Assets/AssetBundleAsset" )]
  public class AssetVariable : ScriptableObject
  {

    [SerializeField]
    string assetName = "";
    public string AssetName => assetName;

#if UNITY_EDITOR
    [SerializeField]
    string assetPath = "";
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
