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
using UnityEditor;

namespace Core
{
    public static class MonoBehaviourExtensions
    {
        #region Public Static Methods
        public static void Quit(this MonoBehaviour monoBehaviour)
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }

        /// <summary>
        /// This method ensures there is only one GameObject that has this script.
        /// Creates singleton without needing pattern.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="monoBehaviour"></param>
        public static void Instance<T>(this MonoBehaviour monoBehaviour)
        {
            if (MonoBehaviour.FindObjectsOfType(typeof(T)).Length > 1)
            {
                Debug.LogError($"Cannot have more than one instance of Server.");
                Quit(monoBehaviour);
            }
        }
        #endregion        
    } 
}