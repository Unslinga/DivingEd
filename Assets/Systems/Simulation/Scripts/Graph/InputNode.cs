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
    public class InputNode : SimuationNode
    {
        #region Fields & Properties

        [field: SerializeField]
        public DoubleReference InputPressure { get; set; }

        [Output(ShowBackingValue.Never, ConnectionType.Override)] public double Out;

        #endregion

        #region Public Methods

        public override void UpdateValue()
        {
            Value = InputPressure.Value;
        }

        #endregion
    }
}