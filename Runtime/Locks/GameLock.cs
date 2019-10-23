using System;
using System.ComponentModel;
using Gameframe.ScriptableObjects.Events;
using UnityEngine;

namespace Gameframe.ScriptableObjects.Locks
{
    
    /// <summary>
    /// GameLock maintains an internal count for the number of times it's been locked
    /// The Locked property will be true when the count is not equal to zero
    /// Events are generated on Lock and Unlock
    /// </summary>
    [CreateAssetMenu(menuName=MenuNames.LockMenu+"Lock")]
    public class GameLock : ScriptableObject, INotifyPropertyChanged
    {
        [NonSerialized]
        private int lockCount = 0;

        public bool Locked => lockCount != 0;
        
        /// <summary>
        /// OnValueChanged is raised when the state of the lock changes
        /// A value of True means the lock count is non-zero.
        /// </summary>
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

        /// <summary>
        /// Increment the internal counter which enables the lock
        /// </summary>
        public void Lock()
        {
            lockCount++;
            if (lockCount == 1)
            {
                RaiseValueChanged();
            }
        }

        /// <summary>
        /// Decrement the internal counter which disables the lock if it hits zero
        /// </summary>
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


