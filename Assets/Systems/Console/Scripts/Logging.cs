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

namespace Console
{
    public class ConsoleLogging : MonoBehaviour
    {
        #region Fields

        #endregion

        #region Properties

        [field: SerializeField]
        public CommandSet ConsoleCommands { get; set; }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        private void Application_logMessageReceived(string logString, string stackTrace, LogType type)
        {
            ConsoleCommands["LogToConsole"]?.Raise(new LogMessageData { Type = type, Message = logString, StackTrace = stackTrace });
        }

        #endregion

        #region Unity Methods

        void Awake()
        {
            ConsoleCommands["LogToConsole"].CheckNull(true);
        }

        void OnEnable()
        {
            Application.logMessageReceived += Application_logMessageReceived;
        }

        void OnDestroy()
        {
            Application.logMessageReceived -= Application_logMessageReceived;
        }

        #endregion
    } 
}