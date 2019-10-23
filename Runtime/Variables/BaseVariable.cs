using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Gameframe.ScriptableObjects.Events;
using JetBrains.Annotations;
using UnityEngine;

namespace Gameframe.ScriptableObjects.Variables
{
    public class BaseVariable : ScriptableObject, INotifyPropertyChanged
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

        /// <summary>
        /// INotifyPropertyChanged interface implemented to support Gameframe.Bindings
        /// </summary>
#region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            try
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            catch (Exception e)
            {
                Debug.LogException(e,this);   
            }
            if (onValueChanged != null)
            {
                onValueChanged.Raise();
            }
        }

#endregion
        
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field,value))
            {
                field = value;
                OnPropertyChanged(propertyName);
                return true;
            }
            return false;
        }

    }
}

