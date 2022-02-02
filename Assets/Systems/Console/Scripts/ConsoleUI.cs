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
using TMPro;
using UnityEngine.UI;

namespace Console
{
    public class ConsoleUI : MonoBehaviour
    {
        #region Fields

        #endregion

        #region Properties

        [field: SerializeField]
        public CommandSet ConsoleCommands { get; set; }

        [field: Header("UI Elements")]
        [field: SerializeField]
        public TMP_InputField CommandLine { get; set; }

        [field: SerializeField]
        public Button Close { get; set; }

        [field: SerializeField]
        public Button Submit { get; set; }

        [field: SerializeField]
        public GameObject Content { get; set; }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion

        #region Unity Methods

        void Awake()
        {
        
        }

        #endregion
    }
}