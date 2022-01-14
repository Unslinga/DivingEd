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
    [InitializeOnLoad]
    public abstract class RuntimeSet<T> : ScriptableObject
    {
        #region Properties

        [field: SerializeField]
        public List<T> Items { get; set; } = new List<T>();

        #endregion

        #region Public Methods

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

        #endregion
    }
}