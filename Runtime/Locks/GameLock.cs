using System;
using System.ComponentModel;
using Gameframe.ScriptableObjects.Events;
using UnityEngine;

namespace Gameframe.ScriptableObjects.Locks
{
    [CreateAssetMenu(menuName=MenuNames.LockMenu+"Lock")]
    public class GameLock : ScriptableObject, INotifyPropertyChanged
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
            OnPropertyChanged(nameof(Locked));
        }
        
        /// <summary>
        /// INotifyPropertyChanged interface implemented to support Gameframe.Bindings
        /// </summary>
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName = null)
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
            
            try
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            catch (Exception e)
            {
                Debug.LogException(e,this);   
            }
            
            try
            {
                OnValueChanged?.Invoke(value);
            }
            catch (Exception e)
            {
                Debug.LogException(e,this);   
            }
        }

        #endregion
        
    }
}


