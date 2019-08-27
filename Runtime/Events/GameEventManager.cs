using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Gameframe.ScriptableObjects.Events
{
    
    [CreateAssetMenu(menuName = "GameJam/Events/EventManager")]
    public class GameEventManager : ScriptableObject
    {
        
        //Classes to wrap callbacks so they can be called generically
#region Invokable Callback Wrappers
        private abstract class BaseInvokable
        {
            public virtual void Invoke(params object[] args)
            {
            }
        }

        private class Invokable : BaseInvokable
        {
            public Invokable(Action callback)
            {
                Callback = callback;
            }
            
            public Action Callback { get; }

            public override void Invoke(params object[] args)
            {
                Callback.Invoke();
            }
        }
        
        private class Invokable<T> : BaseInvokable
        {
            public Invokable(Action<T> callback)
            {
                Callback = callback;
            }
            
            public Action<T> Callback { get; }

            public override void Invoke(params object[] args)
            {
                Callback.Invoke((T)args[0]);
            }
        }
        
        private class InternalEvent
        {
            private readonly List<BaseInvokable> _invokables = new List<BaseInvokable>();

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
            
            //Now how can I unsubscribe? -_-
            @event.AddListener(callback);
        }
        
        public void AddListener<T>(string eventName, Action<T> callback)
        {
            if (!_eventDictionary.TryGetValue(eventName, out var @event))
            {
                @event = new InternalEvent();
                _eventDictionary.Add(eventName,@event);
            }
            
            //Now how can I unsubscribe? -_-
            @event.AddListener(callback);
        }

        public void RemoveListener<T>(string eventName, Action<T> callback)
        {
            if (!_eventDictionary.TryGetValue(eventName, out var @event))
            {
                return;
            }
            @event.RemoveListener(callback);
        }
        
        public void RemoveListener(string eventName, Action callback)
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
        
    }

}
