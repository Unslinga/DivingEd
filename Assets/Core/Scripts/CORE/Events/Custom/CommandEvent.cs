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
        public bool CommandOption { get; set; } = true;

        [field: SerializeField]
        public string CommandPattern { get; set; }

        [field: SerializeField]
        public List<SupportedParameter> SupportedParameters { get; set; }

        #endregion

        #region Public Methods

        public void Raise(params string[] data)
        {
            if (!CommandOption)
            {
                Debug.LogError("CommandOption false, cast to [BaseEvent]");
                return;
            }

            if (data.Length != SupportedParameters.Count)
            {
                Debug.LogError($"Command parameter count does not match pattern [{CommandPattern}]!");
                return;
            }

            if (data.Length == 0)
            {
                base.Raise();
            }

            List<(SupportedParameter, string)> parameters = 
                new List<(SupportedParameter, string)>();

            foreach ((SupportedParameter type, string value) in SupportedParameters.Zip(data, (f, s) => (f, s)))
            {
                parameters.Add((type, value));
            }

            Raise(new CommandData { Parameters = parameters });
        }

        #endregion

        #region Private Methods

        private new void Validate()
        {
            base.Validate();

            if (SupportedParameters != null)
            {
                CommandPattern = SupportedParameters.Aggregate($"{name}", (cur, nxt) => cur + " <" + nxt.ToString() + ">");
            }
        }

        #endregion

        #region Unity Methods

        void Awake()
        {
            Validate();
        }

        void OnEnable()
        {
           Validate();
        }

        void OnValidate()
        {
            Validate();
        }

        #endregion
    }

    
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
        public List<(SupportedParameter, string)> Parameters { get; set; }
    }

    public struct LogMessageData
    {
        public string Name { get; set; }
        public LogType Type { get; set; }
        public bool Command { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}
