using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameframe.ScriptableObjects.RuntimeSets
{
  public class RuntimeTable<TKey, TValue> : ScriptableObject
  {
    [SerializeField]
    bool allowOverwrite = true;

    [SerializeField]
    bool throwExceptions = false;

    Dictionary<TKey, TValue> items = new Dictionary<TKey, TValue>();

    public IReadOnlyDictionary<TKey, TValue> Items
    {
      get { return items; }
    }

    public TValue Get(TKey key)
    {
      if ( throwExceptions )
      {
        return items[key];
      }

      TValue val;
      if ( items.TryGetValue(key,out val))
      {
        return val;
      }
      else
      {
        return default(TValue);
      }
    }

    public void Add(TKey key, TValue val)
    {
      if ( allowOverwrite )
      {
        items[key] = val;
      }
      else
      {
        items.Add(key, val);
      }
    }

    public bool Remove(TKey key)
    {
      return items.Remove(key);
    }

    protected virtual void OnEnable()
    {
      items.Clear();
    }
  }
}