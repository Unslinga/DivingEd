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
    public class VoiceCommand : BaseEvent
    {
        #region Fields & Properties

        [field: SerializeField]
        public List<string> Keyword { get; set; }

        #endregion

        #region Public Methods

        #endregion
    }
}