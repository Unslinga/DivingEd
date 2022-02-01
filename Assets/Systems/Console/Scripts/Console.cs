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
using TMPro;
using UnityEngine.UI;

namespace Console
{
    [RequireComponent(typeof(Logging))]
    public class Console : MonoBehaviour
    {
        #region Fields
        #endregion

        #region Properties
        [field: SerializeField]
        public TMP_Text Log { get; set; }

        [field: SerializeField]
        public ConsoleRuntimeSet ConsoleSet { get; set; }

        [field: Header("Events")]
        [field: SerializeField]
        public ConsoleEvent LogToConsole { get; set; }
        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        private void OnLogToConsole(object message) => ConsoleSet?.Add((ConsoleMessage)message);

        private string ParseMessages() => ConsoleSet?.Items
            .Select(i => i.Message)
            .Aggregate((cur, item) => cur + "\n" + item);

        #endregion

        #region Unity Methods

        void Awake()
        {
            LogToConsole.CheckNull(true);
            LogToConsole.CreateListener(gameObject, OnLogToConsole);
        }

        void Update()
        {
            //Log.text = ParseMessages();
        }

        #endregion

    } 
}