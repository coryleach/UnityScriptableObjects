using System;
using Gameframe.ScriptableObjects.Events;
using UnityEngine;

namespace Gameframe.ScriptableObjects.Locks
{
    [CreateAssetMenu(menuName=MenuNames.LockMenu+"Lock")]
    public class GameLock : ScriptableObject
    {
        [NonSerialized]
        private int lockCount = 0;

        public bool Locked => lockCount != 0;
        public event Action<bool> OnValueChanged;

        [SerializeField]
        private GameEvent unlockedEvent;
        public GameEvent OnUnlocked
        {
            get
            {
                if (unlockedEvent == null)
                {
                    unlockedEvent = CreateInstance<GameEvent>();
                }
                return unlockedEvent;
            }
        }
        
        [SerializeField]
        private GameEvent lockedEvent;
        public GameEvent OnLocked
        {
            get
            {
                if (lockedEvent == null)
                {
                    lockedEvent = CreateInstance<GameEvent>();
                }
                return lockedEvent;
            }
        }
        
        private void OnEnable()
        {
            lockCount = 0;
        }

        public void Lock()
        {
            lockCount++;
            if (lockCount == 1)
            {
                RaiseValueChanged();
            }
        }

        public void Unlock()
        {
            lockCount--;
            if (lockCount == 0)
            {
                RaiseValueChanged();
            }
        }

        private void RaiseValueChanged()
        {
            var value = Locked;
            if (value)
            {
                if (lockedEvent != null)
                {
                    lockedEvent.Raise();
                }
            }
            else
            {
                if (unlockedEvent != null)
                {
                    unlockedEvent.Raise();
                }
            }
            OnValueChanged?.Invoke(value);
        }
        
    }
}


