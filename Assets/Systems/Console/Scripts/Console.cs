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
    [RequireComponent(typeof(ConsoleUI))]
    public class Console : MonoBehaviour
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

        private void OnLogToConsole(object data)
        {
            var message = (LogMessageData)data;


        }    

        #endregion

        #region Unity Methods

        void Awake()
        {
            ConsoleCommands["LogToConsole"].CheckNull(true);
            ConsoleCommands["LogToConsole"].CreateListener(gameObject, OnLogToConsole);
        }

        void Update()
        {
            //
        }

        #endregion

    } 
}