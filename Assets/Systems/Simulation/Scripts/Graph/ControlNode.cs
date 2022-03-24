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
    public class ControlNode : SimulationNode
    {
        #region Fields & Properties

        

        [Output(ShowBackingValue.Never, ConnectionType.Override)] public DoubleVariable control;

        [Input(ShowBackingValue.Never, ConnectionType.Override)] public double In;
        [Output(ShowBackingValue.Never, ConnectionType.Override)] public double Out;

        #endregion

        #region Public Methods

        public override void UpdateValue()
        {
            //Value = GetConnectedNodePorts()
            //    .Where(n => n is SimulationNode)
            //    .Select(n => ((SimulationNode)n).Value)
            //    .Max();
        }

        #endregion
    }
}