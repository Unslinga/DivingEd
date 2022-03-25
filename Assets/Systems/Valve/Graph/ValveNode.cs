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

namespace Valve
{
    public class ValveNode : BaseNode, IControl
    {
        #region Fields & Properties
        [field: SerializeField]
        public DoubleReference ValveOpen { get; set; }

        [Input(ShowBackingValue.Never, ConnectionType.Override)]
        public ControlFlow control;

        public ControlFlow Control { get { return control; } }

        #endregion

        #region Public Methods

        public void UpdateValue()
        {
            EvaluateValue();

            var controlNode = (IControl)GetPort("control").Connection?.node;
            control.Value = controlNode.Control.Value * ValveOpen.Value;
        }

        public void EvaluateValue()
        {
            if (ValveOpen.Value < 0)
                ValveOpen.Value = 0;
            if (ValveOpen.Value > 1)
                ValveOpen.Value = 1;
        }

        #endregion

        #region Unity Methods

        void OnValidate()
        {
            EvaluateValue();
        }

        #endregion
    }
}