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
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    [Serializable]
    [CreateAssetMenu(menuName = "Console/ConsoleEvent", order = 4)]
    public class ConsoleEvent : BaseEvent
    {
        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Public Methods

        #endregion

    }

    public struct ConsoleMessage
    {
        public LogType Type { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}
