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
    public class UIEvent : BaseEvent
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

    public struct UIData
    {

    }
}
