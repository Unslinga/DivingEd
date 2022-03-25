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

namespace Core
{
    [NodeWidth(272)]
    public abstract class SimulationNode : BaseNode
    {
        #region Fields & Properties

        public GameObject GameObject { get; set; }

        public int ID => GetHashCode();

        public double Value { get; protected set; }

        #endregion

        #region Public Methods

        public void CascadeValue(int lastID)
        {
            UpdateValue();

            foreach (var node in GetConnectedSimulationNodes(lastID).Where(n => n.Value <= Value))
            {
                node.CascadeValue(ID);
            }
        }

        public void ClearCascade(int lastID)
        {
            ClearValue();

            foreach (var node in GetConnectedSimulationNodes(lastID))
            {
                node.ClearCascade(ID);
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

        protected IEnumerable<SimulationNode> GetConnectedSimulationNodes(int lastID)
        {
            foreach (SimulationNode node in Ports
                .SelectMany(p => p.GetConnections()
                    .Where(n => n.IsConnected && n.node is SimulationNode))
                .Select(p => (SimulationNode)p.node)
                .Where(n => n.ID != lastID))
            {
                yield return node;
            }
        }

        #endregion

        #region Unity Methods

        #endregion
    }
}