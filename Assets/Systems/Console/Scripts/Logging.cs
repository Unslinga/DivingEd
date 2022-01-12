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

namespace DEFAULT_REPLACE
{
    public class Logging : MonoBehaviour
    {
        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        private void Application_logMessageReceived(string condition, string stackTrace, LogType type)
        {
            
        }
        #endregion

        #region Unity Methods
        private void OnEnable()
        {
            Application.logMessageReceived += Application_logMessageReceived;
        }

        private void OnDestroy()
        {
            Application.logMessageReceived -= Application_logMessageReceived;
        }
        #endregion
        
    } 
}