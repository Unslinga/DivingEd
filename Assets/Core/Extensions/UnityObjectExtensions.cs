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
using Object = UnityEngine.Object;


namespace Core
{
    public static class UnityObjectExtensions
    {
        #region Public Static Methods

        public static void CheckNull(this Object unityObject, object entity, bool critical)
        {
            string info = Environment.StackTrace.
                Split('\\').Reverse().First().Trim();

            if (entity == null)
            {
                if (critical)
                {
                    Debug.LogError($"Entity [{info}] cannot be null!");
                    Quit(unityObject);
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
        /// <param name="unityObject"></param>
        public static void Instance<T>(this Object unityObject)
        {
            if (UnityEngine.Object.FindObjectsOfType(typeof(T)).Length > 1)
            {
                Debug.LogError($"Cannot have more than one instance of [{typeof(T).Name}].");
                Quit(unityObject);
            }
        }

        /// <summary>
        /// Method to quit Unity or program without having to do this elsewhere
        /// </summary>
        /// <param name="unityObject"></param>
        public static void Quit(this Object unityObject)
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