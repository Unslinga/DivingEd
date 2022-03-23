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

namespace Simulation
{
    public class BranchNode : SimuationNode
    {
        #region Fields & Properties

        [Input(ShowBackingValue.Never, ConnectionType.Override)]
        public double In1;

        [Output(ShowBackingValue.Never, ConnectionType.Override)]
        public double Out1;

        [Input(ShowBackingValue.Never, ConnectionType.Override)]
        public double In2;

        [Output(ShowBackingValue.Never, ConnectionType.Override)]
        public double Out2;

        [Input(ShowBackingValue.Never, ConnectionType.Override)]
        public double In3;

        [Output(ShowBackingValue.Never, ConnectionType.Override)]
        public double Out3;

        [Input(ShowBackingValue.Never, ConnectionType.Override)]
        public double In4;

        [Output(ShowBackingValue.Never, ConnectionType.Override)]
        public double Out4;

        [Input(ShowBackingValue.Never, ConnectionType.Override)]
        public double In5;

        [Output(ShowBackingValue.Never, ConnectionType.Override)]
        public double Out5;


        #endregion

        #region Public Methods

        public override void UpdateValue()
        {
            
        }

        #endregion
    }
}