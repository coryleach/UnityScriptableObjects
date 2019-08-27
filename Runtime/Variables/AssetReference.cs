using System.Threading.Tasks;

namespace Gameframe.ScriptableObjects.Variables
{
  using System;

  public enum AssetReferenceType : int
  {
    Direct = 0, //Maintain reference via Unity GUID
    Fetch = 1, //Fetch from disk using the path/asset name
    Variable = 2 //Link using a variable asset
  }

  [Serializable]
  public class AssetReference
  {
    public AssetReferenceType referenceType = AssetReferenceType.Direct;

    //Direct Reference
    //Indirect/Soft Reference (Save only asset name/path?)
    //TODO: Do we want to save off the path and not the actual asset reference?
    public UnityEngine.Object localValue;
    public string assetPath =  string.Empty;
    public string assetName = string.Empty;

    public AssetVariable variable;

    public virtual Task<UnityEngine.Object> FetchAsync()
    {
      if ( referenceType == AssetReferenceType.Direct )
      {
        return Task.FromResult(localValue); 
      }
      
      if ( referenceType == AssetReferenceType.Fetch )
      {
        //TODO: Fetch from someplace
        return null;
      }
      
      return variable.FetchAsync();
    }

    public Task<T> FetchAsync<T>() where T : UnityEngine.Object
    {
      if ( referenceType == AssetReferenceType.Direct )
      {
        return Task.FromResult(localValue as T);
      }
      
      if ( referenceType == AssetReferenceType.Fetch )
      {
        //TODO: Fetch from someplace
        return null;
      }
      
      return variable.FetchAsync<T>();
    }
  }

}