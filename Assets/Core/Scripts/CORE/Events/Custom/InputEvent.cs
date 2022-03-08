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

namespace Core
{
    [Serializable]
    [CreateAssetMenu(menuName = "InputController/InputEvent", order = 0)]
    public class InputEvent : BaseEvent
    {

        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Public Methods

        #endregion

        #region Unity Methods

        void Awake()
        {
            Validate();
        }

        void OnValidate()
        {
            Validate();
        }

        #endregion

    }

    public struct InputData
    {
        //properties
        public KeyCode KeyCode  { get; set; }
        public bool Holding { get; set; }

    }
}
