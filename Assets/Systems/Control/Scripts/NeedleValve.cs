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

namespace Control.Valve
{
    [Serializable]
    [RequireComponent(typeof(HandleRotation))]
    public class NeedleValve : Control
    {
        #region Fields & Properties

        public override double Value
        {
            get => base.Value;
            set
            {

                base.Value = value.Clamp(0, 1);
                base.ControlValue = value.Clamp(0, 1);
            }
        }

        public override double ControlValue
        {
            get => base.ControlValue;
            set
            {
                base.Value = value.Clamp(0, 1);
                base.ControlValue = value.Clamp(0, 1);
            }
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion

        #region Unity Methods

        #endregion
    }
}