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
    public class ControlNode : SimuationNode
    {
        #region Fields & Properties

        

        [Output(ShowBackingValue.Never, ConnectionType.Override)] public DoubleVariable control;

        [Input(ShowBackingValue.Never, ConnectionType.Override)] public double In;
        [Output(ShowBackingValue.Never, ConnectionType.Override)] public double Out;

        #endregion

        #region Public Methods

        public override void UpdateValue()
        {
            double output = GetOutputValue("Out", 0.0);

            var input = GetInputValue("In", 0.0);

            Value = Math.Max(output, input);
        }

        #endregion
    }
}