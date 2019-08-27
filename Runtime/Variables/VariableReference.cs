using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameframe.ScriptableObjects.Variables
{

  public abstract class VariableReference<T,V> where V : IVariable<T>
  {

    public bool useLocalValue;
    public T localValue;
    public V variable;

    public bool HasValue
    {
      get
      {
        if (useLocalValue || variable != null)
        {
          return true;
        }
        return false;
      }
    }

    public T Value
    {
      get
      {
        return useLocalValue ? localValue : variable.Value;
      }
      set
      {
        if (useLocalValue)
        {
          localValue = value;
        }
        else
        {
          variable.Value = value;
        }
      }
    }

  }

}