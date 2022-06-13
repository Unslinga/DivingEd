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

namespace Simulation
{
    public class InputNode : SimulationNode
    {
        #region Fields & Properties

        [field: SerializeField]
        public DoubleReference InputPressure { get; set; }

        [Output(ShowBackingValue.Never, ConnectionType.Override)]
        public Flow Out;

        #endregion

        #region Public Methods

        public override void ClearValue()
        {
            Value = 0;
        }

        public override void UpdateValue(double maxFlow, int parent)
        {
            Value = InputPressure.Value;
        }

        public override double UpdateSource(double flow)
        {
            return flow;
        }

        #endregion
    }
}