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
    [Serializable]
    public class SimulationControlNode : SimulationNode
    {
        #region Fields & Properties

        private IControl Node;

        [Output(ShowBackingValue.Never, ConnectionType.Override)]
        public ControlFlow controlflow;

        [Input(ShowBackingValue.Never, ConnectionType.Override)]
        public Flow In;
        
        [Output(ShowBackingValue.Never, ConnectionType.Override)]
        public Flow Out;

        #endregion

        #region Public Methods

        public override void ClearValue()
        {
            Value = 0;
        }

        public override void UpdateValue(double maxFlow)
        {
            FetchControl();

            var inputNode = GetNode("In");

            var diff = (inputNode.Value - Value);

            var flowAmount = Math.Min(Math.Max(maxFlow * Math.Sign(diff), -diff), diff)/2;

            Value += inputNode.UpdateSource(Node.UpdateFlow(Value, flowAmount));

            Value = Math.Max(Value, 0);
        }

        public override double UpdateSource(double flow)
        {
            FetchControl();

            Value -= flow;

            var leftover = Value < 0 ? flow - Value : flow;

            Value = Math.Max(Value, 0);

            return leftover;
        }

        #endregion

        #region Private Methods

        private void FetchControl()
        {
            Node = (IControl)GetPort("controlflow").Connection.node;

            if (Node != null) return;

            Debug.Log($"Node {name} is null, missing ControlFlow");
        }

        #endregion
    }
}