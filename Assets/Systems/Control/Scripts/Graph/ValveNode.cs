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

namespace Control.Valve
{
    public class ValveNode : BaseNode, IControl
    {
        #region Fields & Properties

        [field: SerializeField]
        public double Value { get; set; }

        [field: SerializeField]
        public double PressureLoss { get; set; } = 0.01;

        [Input(ShowBackingValue.Never, ConnectionType.Override)]
        public ControlFlow control;

        public ControlFlow Control { get { return control; } }

        #endregion

        #region Public Methods

        public void UpdateValue()
        {
            Value = Mathf.Clamp((float)Value, 0f, 1f);

            var controlNode = (IControl)GetPort("control").Connection?.node;

            control.Value = controlNode.Control.Value * Value * (1 - PressureLoss);
        }

        #endregion
    }
}