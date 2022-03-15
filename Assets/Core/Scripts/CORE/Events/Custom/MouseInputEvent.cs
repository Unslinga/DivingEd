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
    public class MouseInputEvent : InputEvent
    {
        #region Fields & Properties

        [field: SerializeField]
        public int Button { get; set; }

        #endregion
    }

    [Serializable]
    public struct MouseInputData
    {
        public int Button { get; set; }
        public byte State { get; set; }
    }
}
