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

        public int ID => GetHashCode();

        public double Value { get; internal set; }
        public double PressureLoss { get; set; } = 0.01;

        public ControlFlow Control => throw new NotImplementedException();

        #endregion

        #region Public Methods

        public SimulationNode GetNode(string portName)
        {
            return GetPort(portName).Connection?.node as SimulationNode;
        }

        public void Cascade(List<int> traversed, double maxFlow)
        {
            UpdateValue(maxFlow);

            foreach (var node in GetConnectedNodes(traversed))
            {
                traversed.Add(ID);
                node.Cascade(traversed, maxFlow);
            }
        }

        public void Clear(List<int> traversed)
        {
            ClearValue();

            if (this is DiverNode) return;

            foreach (var node in GetConnectedNodes(traversed))
            {
                traversed.Add(ID);
                node.Clear(traversed);
            }
        }

        public abstract void ClearValue();

        public override object GetValue(NodePort port)
        {
            return Value;
        }

        public abstract double UpdateSource(double flow);

        public abstract void UpdateValue(double maxFlow);

        public void UpdateValue()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private Methods

        protected IEnumerable<SimulationNode> GetConnectedNodes(int ID)
        {
            return GetConnectedNodes(new List<int> { ID });
        }

        protected IEnumerable<SimulationNode> GetConnectedNodes(List<int> traversed)
        {
            foreach (SimulationNode node in Ports
                .SelectMany(p => p.GetConnections()
                    .Where(n => n.IsConnected && n.node is SimulationNode))
                .Select(p => (SimulationNode)p.node)
                .Where(n => !traversed.Contains(n.ID)))
            {
                yield return node;
            }
        }

        #endregion

        #region Unity Methods

        #endregion
    }
}