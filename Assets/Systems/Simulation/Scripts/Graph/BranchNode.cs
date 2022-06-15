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

namespace Simulation
{
    public class BranchNode : SimulationNode
    {
        #region Fields & Properties

        [Input(ShowBackingValue.Never, ConnectionType.Override)]
        public Flow In1;

        [Output(ShowBackingValue.Never, ConnectionType.Override)]
        public Flow Out1;

        [Input(ShowBackingValue.Never, ConnectionType.Override)]
        public Flow In2;

        [Output(ShowBackingValue.Never, ConnectionType.Override)]
        public Flow Out2;

        [Input(ShowBackingValue.Never, ConnectionType.Override)]
        public Flow In3;

        [Output(ShowBackingValue.Never, ConnectionType.Override)]
        public Flow Out3;

        [Input(ShowBackingValue.Never, ConnectionType.Override)]
        public Flow In4;

        [Output(ShowBackingValue.Never, ConnectionType.Override)]
        public Flow Out4;

        [Input(ShowBackingValue.Never, ConnectionType.Override)]
        public Flow In5;

        [Output(ShowBackingValue.Never, ConnectionType.Override)]
        public Flow Out5;

        #endregion

        #region Public Methods

        public override void ClearValue()
        {
            Value = 0;
        }

        public override double UpdateSource(double flow)
        {
            Value -= flow;
            var leftover = Value < 0 ? flow - Value : flow;

            Value = Math.Max(Value, 0);

            return leftover;
        }

        public override void UpdateValue(double maxFlow, int parent)
        {
            var connection = GetConnectedNodes(ID)
                .SingleOrDefault(c => c.ID == parent);
            Debug.Log($"{name} - {connection.name}");
            var diff = connection.Value - Value;

            Value += connection.UpdateSource(
                Math.Min(Math.Max(maxFlow * Math.Sign(diff), -diff), diff));

            Value = Math.Max(Value, 0);
        }

        #endregion
    }
}