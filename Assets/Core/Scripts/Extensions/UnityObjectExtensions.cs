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
using UnityEngine.UI;

namespace Core
{
    public static class UnityObjectExtensions
    {
        #region Public Static Methods

        public static void CheckNull(this Object unityObject, bool critical)
        {
            string info = Environment.StackTrace.
                Split('\\').Reverse().First().Trim();

            if (unityObject == null)
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

        public static Vector2 GetVerticalSnapPositionOfChild(this ScrollRect scrollRect, RectTransform child)
        {
            Canvas.ForceUpdateCanvases();

            Vector2 viewportLocalPosition = scrollRect.viewport.localPosition;

            return new Vector2(
                0,
                0 - (viewportLocalPosition.y + child.localPosition.y));
        }

        /// <summary>
        /// This method ensures there is only one GameObject that has this script.
        /// Creates singleton without needing pattern.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="unityObject"></param>
        public static void Instance<T>(this Object unityObject) where T : Object
        {
            if (Object.FindObjectsOfType(typeof(T)).Length > 1)
            {
                Debug.LogError($"Cannot have more than one instance of [{typeof(T).Name}].");
                Quit(unityObject);
            }
        }

        public static IInstance GetInstance<T>(this GameObject unityObject) where T : IInstance
        {
            IInstance instance = Object.FindObjectsOfType<MonoBehaviour>().OfType<IInstance>().SingleOrDefault();

            try
            {


                if (instance != null)
                {
                    return (T)instance;
                }
                return null;
            }
            catch (InvalidCastException)
            {
                return null;
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