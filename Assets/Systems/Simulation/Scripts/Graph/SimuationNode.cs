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

        public double Value { get; protected set; }

        #endregion

        #region Public Methods

        public void CascadeValue(List<int> traversed)
        {
            UpdateValue();

            if (this is DiverNode) return;

            foreach (var node in GetConnectedSimulationNodes(traversed).Where(n => n.Value <= Value))
            {
                traversed.Add(ID);
                node.CascadeValue(traversed);
            }
        }

        public void ClearCascade(List<int> traversed)
        {
            ClearValue();

            if (this is DiverNode) return;

            foreach (var node in GetConnectedSimulationNodes(traversed))
            {
                traversed.Add(ID);
                node.ClearCascade(traversed);
            }
        }
        public abstract void ClearValue();

        public override object GetValue(NodePort port)
        {
            return Value;
        }

        public abstract void UpdateValue();

        #endregion

        #region Private Methods

        protected IEnumerable<SimulationNode> GetConnectedSimulationNodes(int ID)
        {
            return GetConnectedSimulationNodes(new List<int> { ID });
        }

        protected IEnumerable<SimulationNode> GetConnectedSimulationNodes(List<int> traversed)
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