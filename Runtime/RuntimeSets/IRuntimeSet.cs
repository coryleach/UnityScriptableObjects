using System.Collections.Generic;
using UnityEngine.Events;

namespace Gameframe.ScriptableObjects.RuntimeSets
{
    public interface IRuntimeSet<T>
    {
        IReadOnlyList<T> Items { get; }
        UnityEvent<T> OnAdded { get; }
        UnityEvent<T> OnRemoved { get; }
        void Add(T t);
        void Remove(T t);
    }
}