// ----------------------------------------------------------------------------
// Simulering av Dykkerpost
// Bachelor Oppgave våren 2022
// 
// Aahed Diyab, Olav Pete
// ----------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [Serializable, NodeWidth(256)]
    public abstract class BaseVariable<T> : BaseNode
    {
        #region Fields & Properties

        [field: SerializeField]
        public T Value { get; set; }

        public static implicit operator T(BaseVariable<T> variable)
        {
            return variable.Value;
        }

        #endregion

        #region Public Methods

        #endregion
    }
}
