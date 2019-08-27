using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameframe.ScriptableObjects.Variables
{
  public interface IVariable<T>
  {
    T Value { get; set; }
  }
}
