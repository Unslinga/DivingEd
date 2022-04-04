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
    [Serializable]
    [NodeWidth(336)]
    public class InputEventSet : NamedSet<InputEvent>
    {
        #region Fields & Properties

        #endregion

        #region Public Methods

        public void Populate()
        {
            Items = GameManager.GetNodesByType<InputEvent>();
        }

        #endregion
    }
}
