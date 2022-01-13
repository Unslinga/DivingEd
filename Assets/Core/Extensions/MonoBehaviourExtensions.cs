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
using System.Linq;

namespace Core
{
    public static class MonoBehaviourExtensions
    {
        #region Public Static Methods

        public static void CheckNull(this MonoBehaviour monoBehaviour, object entity, bool critical)
        {
            string info = Environment.StackTrace.
                Split('\\').Reverse().First().Trim();

            if (critical)
            {
                if (entity == null)
                {
                    Debug.LogError($"Entity [{info}] cannot be null!");
                    Quit(monoBehaviour);
                }
                else
                {
                    Debug.LogWarning($"Entity [{info}] is null!");
                }
            }
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
                Debug.LogError($"Cannot have more than one instance of [{typeof(T).Name}].");
                Quit(monoBehaviour);
            }
        }

        /// <summary>
        /// Method to quit Unity or program without having to do this elsewhere
        /// </summary>
        /// <param name="monoBehaviour"></param>
        public static void Quit(this MonoBehaviour monoBehaviour)
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
        #endregion        
    } 
}