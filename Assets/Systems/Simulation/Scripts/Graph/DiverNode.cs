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
    public class DiverNode : SimuationNode
    {
        #region Fields & Properties

        [Input(ShowBackingValue.Never, ConnectionType.Override)] public double In;

        #endregion

        #region Public Methods

        public override void UpdateValue()
        {
            
        }

        #endregion
    }
}