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
        public double Value { get; set; }

        [Input(ShowBackingValue.Never, ConnectionType.Override)]
        public ControlFlow control;

        public ControlFlow Control { get { return control; } }

        #endregion

        #region Public Methods

        public void UpdateValue()
        {
            Evaluate();

            var controlNode = (IControl)GetPort("control").Connection?.node;
            control.Value = controlNode.Control.Value * Value;
        }

        public void Evaluate()
        {
            if (Value < 0)
                Value = 0;
            if (Value > 1)
                Value = 1;
        }

        #endregion

        #region Unity Methods

        void OnValidate()
        {
            Evaluate();
        }

        #endregion
    }
}