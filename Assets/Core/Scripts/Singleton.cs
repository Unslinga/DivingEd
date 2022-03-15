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

namespace Core
{
    public class Singleton
    {
        #region Fields & Properties

        #endregion

        #region Public Methods

        public static T Create<T>() where T : MonoBehaviour
        {
            var single = UnityEngine.Object.FindObjectOfType<T>();

            if (single == null)
            {
                single = new GameObject(typeof(T).FullName).AddComponent<T>();
            }

            return single;
        }

        #endregion
    }
}