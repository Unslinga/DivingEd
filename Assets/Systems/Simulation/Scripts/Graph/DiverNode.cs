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
        public Flow DepthPressureOut;

        #endregion

        #region Public Methods

        public override void ClearValue()
        {
            Value = 0;
        }

        public override void UpdateValue()
        {
            Value = GetConnectedSimulationNodes(ID).Select(x => x.Value).Max();
        }

        #endregion
    }
}