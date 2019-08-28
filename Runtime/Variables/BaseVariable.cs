using Gameframe.ScriptableObjects.Events;
using UnityEngine;

namespace Gameframe.ScriptableObjects.Variables
{
    public class BaseVariable : ScriptableObject
    {
        [SerializeField]
        protected GameEvent onValueChanged;

        public GameEvent OnValueChanged
        {
            get
            {
                if (onValueChanged == null)
                {
                    onValueChanged = CreateInstance<GameEvent>();
                }
                return onValueChanged;
            }
        }
    }
}

