// ----------------------------------------------------------------------------
// Simulering av Dykkerpost
// Bachelor Oppgave våren 2022
// 
// Aahed Diyab, Olav Pete
// ----------------------------------------------------------------------------

using Core;
using Simulation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XNode;

namespace Core
{
    [NodeWidth(272)]
    public abstract class SimulationNode : BaseNode
    {
        #region Fields & Properties


        public double Value { get; protected set; }
        public GameObject GameObject { get; set; }

        #endregion

        #region Public Methods

        public override object GetValue(NodePort port)
        {
            return Value;
        }

        public void Propagate(int last)
        {
            UpdateValue();

            //foreach (var port in GetConnectedNodePorts())
            //{
            //    Debug.Log($"Port: {port.node.name} {GetHashCode()} - {port.node.GetHashCode()}");

            //    if (last == port.node.GetHashCode()) continue;

            //    if (!(port.node is SimulationNode)) continue;

            //    if ((SimulationNode)port.node)

            //    Debug.Log("Propagate, not same");

            //    ((SimulationNode)port.node).Propagate(GetHashCode());
            //}
        }


        public abstract void UpdateValue();

        #endregion

        #region Private Methods

        #endregion

        #region Unity Methods

        #endregion
    }
}