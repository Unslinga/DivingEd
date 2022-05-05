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
    public abstract class ControlNode : BaseNode, IControl
    {
        #region Fields & Properties

        [Input(ShowBackingValue.Never, ConnectionType.Override)]
        public ControlFlow controlflow;

        public Control Control { get; set; }

        #endregion

        #region Public Methods

        public abstract double UpdateFlow(double nodePressure, double flowRate);

        #endregion
    }
}