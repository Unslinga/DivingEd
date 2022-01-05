using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public abstract class RuntimeSet<T> : ScriptableObject
    {
        [field: SerializeField]
        public List<T> Items { get; set; } = new List<T>();
        
        public void Add(T item)
        {
            if (!Items.Contains(item))
                Items.Add(item);
        }

        public void Remove(T item)
        {
            if (Items.Contains(item))
                Items.Remove(item);
        }
    }
}