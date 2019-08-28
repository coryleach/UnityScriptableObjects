using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameframe.ScriptableObjects.Events
{
    [CreateAssetMenu(menuName = MenuNames.EventMenu+"EventManager")]
    public class GameEventManager : ScriptableObject
    {
        
#region Invokable Callback Wrappers
        /// <summary>
        /// Serves as a wrapper for an invokable callback
        /// </summary>
        private interface IInvokable
        {
            void Invoke(params object[] args);
        }

        /// <summary>
        /// Invokable wrapper for a simple action callback
        /// </summary>
        private class Invokable : IInvokable
        {
            public Invokable(Action callback)
            {
                Callback = callback;
            }
            
            public Action Callback { get; }

            public void Invoke(params object[] args)
            {
                Callback.Invoke();
            }
        }
        
        /// <summary>
        /// Invokable wrapper for a callback that takes a single arg
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private class Invokable<T> : IInvokable
        {
            public Invokable(Action<T> callback)
            {
                Callback = callback;
            }
            
            public Action<T> Callback { get; }

            public void Invoke(params object[] args)
            {
                Callback.Invoke((T)args[0]);
            }
        }
        
        /// <summary>
        /// Invokable wrapper for a callback that takes a single arg
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private class Invokable<T0,T1> : IInvokable
        {
            public Invokable(Action<T0,T1> callback)
            {
                Callback = callback;
            }
            
            public Action<T0,T1> Callback { get; }

            public void Invoke(params object[] args)
            {
                if ( args.Length < 2 )
                {
                    return;
                }

                if ( !(args[0] is T0) )
                {
                    return;
                }
                
                if ( !(args[1] is T1) )
                {
                    return;
                }
                
                var arg0 = (T0)args[0];
                var arg1 = (T1)args[1];
                Callback.Invoke(arg0,arg1);
            }
        }
        
        /// <summary>
        /// Internal representation of a single invokable event instance
        /// </summary>
        private class InternalEvent
        {
            private readonly List<IInvokable> _invokables = new List<IInvokable>();

            public void Raise(params object[] args)
            {
                foreach (var invokable in _invokables)
                {
                    invokable.Invoke(args);
                }
            }
            
            public void AddListener(Action callback)
            {
                _invokables.Add(new Invokable(callback));    
            }
            
            public void AddListener<T>(Action<T> callback)
            {
                _invokables.Add(new Invokable<T>(callback));    
            }
            
            public void AddListener<T0,T1>(Action<T0,T1> callback)
            {
                _invokables.Add(new Invokable<T0,T1>(callback));    
            }

            public void RemoveListener(Action callback)
            {
                for (var i = 0; i < _invokables.Count; i++)
                {
                    if (_invokables[i] is Invokable invokable && invokable.Callback == callback)
                    {
                        _invokables.RemoveAt(i);
                        return;
                    }
                }
            }
            
            public void RemoveListener<T>(Action<T> callback)
            {
                for (var i = 0; i < _invokables.Count; i++)
                {
                    if (_invokables[i] is Invokable<T> invokable && invokable.Callback == callback)
                    {
                        _invokables.RemoveAt(i);
                        return;
                    }
                }
            }
            
            public void RemoveListener<T0,T1>(Action<T0,T1> callback)
            {
                for (var i = 0; i < _invokables.Count; i++)
                {
                    if (_invokables[i] is Invokable<T0,T1> invokable && invokable.Callback == callback)
                    {
                        _invokables.RemoveAt(i);
                        return;
                    }
                }
            }
            
        }
#endregion

        private readonly Dictionary<string,InternalEvent> _eventDictionary = new Dictionary<string, InternalEvent>();

        private void OnEnable()
        {
            //Ensure that dictionary is cleaned up in editor
            _eventDictionary.Clear();
        }

        public void AddListener(string eventName, Action callback)
        {
            if (!_eventDictionary.TryGetValue(eventName, out var @event))
            {
                @event = new InternalEvent();
                _eventDictionary.Add(eventName,@event);
            }
            
            @event.AddListener(callback);
        }
        
        public void AddListener<T>(string eventName, Action<T> callback)
        {
            if (!_eventDictionary.TryGetValue(eventName, out var @event))
            {
                @event = new InternalEvent();
                _eventDictionary.Add(eventName,@event);
            }
            @event.AddListener(callback);
        }
        
        public void AddListener<T0,T1>(string eventName, Action<T0,T1> callback)
        {
            if (!_eventDictionary.TryGetValue(eventName, out var @event))
            {
                @event = new InternalEvent();
                _eventDictionary.Add(eventName,@event);
            }
            @event.AddListener(callback);
        }
        
        public void RemoveListener(string eventName, Action callback)
        {
            if (!_eventDictionary.TryGetValue(eventName, out var @event))
            {
                return;
            }
            @event.RemoveListener(callback);
        }
        
        public void RemoveListener<T>(string eventName, Action<T> callback)
        {
            if (!_eventDictionary.TryGetValue(eventName, out var @event))
            {
                return;
            }
            @event.RemoveListener(callback);
        }
        
        public void RemoveListener<T0,T1>(string eventName, Action<T0,T1> callback)
        {
            if (!_eventDictionary.TryGetValue(eventName, out var @event))
            {
                return;
            }
            @event.RemoveListener(callback);
        }
        
        public void Raise(string eventName)
        {
            if (!_eventDictionary.TryGetValue(eventName, out var @event))
            {
                return;
            }
            @event.Raise();
        }

        public void Raise<T>(string eventName, T payload)
        {
            if (!_eventDictionary.TryGetValue(eventName, out var @event))
            {
                return;
            }
            @event.Raise(payload);
        }
        
        public void Raise<T0,T1>(string eventName, T0 payload0, T1 payload1)
        {
            if (!_eventDictionary.TryGetValue(eventName, out var @event))
            {
                return;
            }
            @event.Raise(payload0,payload1);
        }
        
    }

}
