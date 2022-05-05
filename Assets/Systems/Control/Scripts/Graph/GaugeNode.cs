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
using XNode;

namespace Control
{
    [Serializable]
    public class GaugeNode : ControlNode
    {
        #region Fields & Properties

        #endregion

        #region Public Methods

        public override double UpdateFlow(double nodePressure, double flowRate)
        {
            Control.Value = nodePressure;
            return flowRate;
        }

        #endregion
    }
}