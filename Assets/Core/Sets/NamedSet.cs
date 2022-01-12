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
    public class NamedSet<T> : RuntimeSet<T> where T : UnityEngine.Object
    {
        #region Public Methods
        public T this[string name]
        {
            get { return Items?.SingleOrDefault(i => i.name == name); }
        }
        #endregion
    }    
}
