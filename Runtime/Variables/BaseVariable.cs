using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Gameframe.ScriptableObjects.BindingSupport;
using Gameframe.ScriptableObjects.Events;
using UnityEngine;

namespace Gameframe.ScriptableObjects.Variables
{
    public class BaseVariable : BindableScriptableObject
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
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (onValueChanged != null)
            {
                onValueChanged.Raise();
            }
        }
#endregion

    }
}

