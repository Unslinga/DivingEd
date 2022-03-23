// ----------------------------------------------------------------------------
// Simulering av Dykkerpost
// Bachelor Oppgave våren 2022
// 
// Aahed Diyab, Olav Pete
// ----------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core
{
    [Serializable]
    public abstract class NamedSet<T> : RuntimeSet<T> where T : UnityEngine.Object
    {
        #region Public Methods
        
        public T this[string name]
        {
            get
            {
                var item = Items?.SingleOrDefault(i => i.name == name);

                if (item == null || item == default)
                {
                    Debug.LogError($"[{name}] not found in {this.name}");
                }

                return item;
            }
        }

        public void AddFromList(List<T> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }
        #endregion
    }    
}
