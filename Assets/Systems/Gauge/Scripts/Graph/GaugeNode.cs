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

namespace Gauge
{
    public class GaugeNode : BaseNode, IControl
    {
        #region Fields & Properties

        [field: SerializeField]
        [field: ReadOnlyField]
        public double Value { get; set; }

        [Input(ShowBackingValue.Never, ConnectionType.Override)]
        public ControlFlow control;

        public ControlFlow Control { get { return control; } }

        #endregion

        #region Public Methods

        public void UpdateValue()
        {
            var controlNode = (IControl)GetPort("control").Connection?.node;
            Value = controlNode != null ? controlNode.Control.Value : 0;
            control.Value = Value;
        }

        #endregion
    }
}