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
using System.Linq;
using UnityEngine;
using XNode;

namespace Simulation
{
    public class DiverNode : SimulationNode
    {
        #region Fields & Properties

        [Input(ShowBackingValue.Never, ConnectionType.Override)]
        public Flow AirIn;

        [Space(16)]

        [Input(ShowBackingValue.Never, ConnectionType.Override)]
        public Flow DepthPressureIn;

        [Space(16)]

        [Input(ShowBackingValue.Never, ConnectionType.Override)]
        public Flow DepthPressureOut;

        #endregion

        #region Public Methods

        public override void ClearValue()
        {
            Value = 0;
        }

        public override double UpdateSource(double flow)
        {
            return 0;
        }

        public override void UpdateValue(double maxFlow)
        {
            Debug.Log("Diver");
            //Value = GetInputValue("AirIn", 0.0);
        }

        #endregion
    }
}