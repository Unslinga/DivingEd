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
    [CreateAssetMenu(menuName = "Console/CommandEvent", order = 4)]
    public class CommandEvent : BaseEvent
    {
        #region Fields

        #endregion

        #region Properties

        [field: SerializeField]
        public string CommandPattern { get; set; }

        [field: SerializeField]
        public List<SupportedParameter> SupportedParameters { get; set; }

        [field: SerializeField]
        public bool DisplayInSuggestions { get; set; } = true;

        #endregion

        #region Public Methods

        #endregion

        #region Unity Methods
        
        private void OnValidate()
        {
            Name = name;

            if (SupportedParameters != null)
            {
                CommandPattern = SupportedParameters.Aggregate($"{name}", (cur, nxt) => cur + " <" + nxt.ToString() + ">");
            }
        }

        #endregion
    }

    [Flags]
    public enum SupportedParameter
    {
        String  = 0x1,
        Bool    = 0x2,
        Int     = 0x4,
        Float   = 0x8,
        Double  = 0x16
    }

    public struct CommandData
    {
        public (SupportedParameter, object[])[] Parameters { get; set; }
    }

    public struct LogMessageData
    {
        public string Name { get; set; }
        public LogType Type { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}
