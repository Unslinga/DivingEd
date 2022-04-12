// ----------------------------------------------------------------------------
// Simulering av Dykkerpost
// Bachelor Oppgave våren 2022
// 
// Aahed Diyab, Olav Pete
// ----------------------------------------------------------------------------

using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Voice
{
    public class VoiceCommandSet : NamedSet<VoiceCommand>
    {
        #region Fields & Properties

        #endregion

        #region Public Methods

        public void Populate()
        {
            Items = GameManager.GetNodesByType<VoiceCommand>();
        }

        #endregion
    }
}