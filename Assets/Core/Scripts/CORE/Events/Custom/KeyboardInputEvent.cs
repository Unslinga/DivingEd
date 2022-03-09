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
    public class KeyboardInputEvent : InputEvent
    {
        #region Fields & Properties

        [field: SerializeField]
        public KeyCode Modifier { get; set; }

        [field: SerializeField]
        public KeyCode KeyCode { get; set; }

        #endregion
    }

    [Serializable]
    public struct KeyboardInputData
    {
        public KeyCode KeyCode { get; set; }
        public bool Modifier { get; set; }
        public byte State { get; set; }
    }
}
