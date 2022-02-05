// ----------------------------------------------------------------------------
// Simulering av Dykkerpost
// Bachelor Oppgave v�ren 2022
// 
// Aahed Diyab, Olav Pete
// ----------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Core
{
    [Serializable]
    public abstract class RuntimeSet<T> : ScriptableObject, ISet
    {
        #region Properties

        [field: SerializeField]
        public List<T> Items { get; set; } = new List<T>();

        public T this[int index]
        {
            get
            {
                return Items[index];
            }
        }

        public int Count { get { return Items.Count; } }

        public string Name { get { return name; } }

        #endregion

        #region Public Methods

        public void Add(T item)
        {
            if (!Items.Contains(item))
                Items.Add(item);
        }

        public void Clear()
        {
            Items.Clear();
        }

        public int IndexOf(T item)
        {
            return Items.IndexOf(item);
        }

        public void Remove(T item)
        {
            if (Items.Contains(item))
                Items.Remove(item);
        }

        #endregion
    }
}