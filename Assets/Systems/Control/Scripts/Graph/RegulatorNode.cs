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

namespace Control
{
    [Serializable]
    public class RegulatorNode : ControlNode
    {
        #region Fields & Properties

        [field: SerializeField]
        public double MaxRegulatorPressure { get; set; }

        #endregion

        #region Public Methods

        public override double UpdateFlow(double nodePressure, double flowRate)
        {
            if (Control == null) return 0;
            var diff = (MaxRegulatorPressure * Control.Value) - nodePressure;
            return Math.Max(Math.Min(flowRate, diff), 0);
        }
        #endregion
    }
}