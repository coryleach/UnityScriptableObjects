using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameframe.ScriptableObjects.Events
{
  [CreateAssetMenu(menuName = "GameJam/Events/StringEvent")]
  public class StringGameEvent : BaseGameEvent<string>
  {
    [SerializeField]
    string _value;
    public override string Value
    {
      get { return _value; }
      set { _value = value; }
    }
  }

}