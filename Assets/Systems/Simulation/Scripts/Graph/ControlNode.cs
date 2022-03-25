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
    public class ControlNode : SimulationNode, IControl
    {
        #region Fields & Properties

        [Output(ShowBackingValue.Never, ConnectionType.Override)]
        public ControlFlow control;
        public ControlFlow Control { get { return control; } }

        [Input(ShowBackingValue.Never, ConnectionType.Override)]
        public Flow In;
        
        [Output(ShowBackingValue.Never, ConnectionType.Override)]
        public Flow Out;

        #endregion

        #region Public Methods

        public override void ClearValue()
        {
            Value = 0;
            control.Value = 0;
        }

        public override void UpdateValue()
        {
            control.Value = GetConnectedSimulationNodes(ID).Select(x => x.Value).Max();

            var controlNode = (IControl)GetPort("control").Connection?.node;
            controlNode?.UpdateValue();

            Value = controlNode != null ? controlNode.Control.Value : control.Value;
        }

        #endregion
    }
}