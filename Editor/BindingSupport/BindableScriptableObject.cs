﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gameframe.ScriptableObjects.BindingSupport
{
    public class BindableScriptableObject : ScriptableObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        /// <summary>
        /// Use this inside property setters to raise property changed events which are needed by bindingssss
        /// </summary>
        /// <param name="storage">storage location where value will be set</param>
        /// <param name="value">value you want to assign to storage</param>
        /// <param name="propertyName">name of the property being set</param>
        /// <typeparam name="T">Type of the property being set</typeparam>
        /// <returns>True if property was set. False if it was already equal to the given value.</returns>
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null )
        {
            if (EqualityComparer<T>.Default.Equals(storage,value))
            {
                return false;
            }
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
