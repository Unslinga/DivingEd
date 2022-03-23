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
using UnityEngine;
using XNode;

namespace Core
{
    public abstract class SimuationNode : BaseNode
    {
        #region Fields & Properties
        public double Value { get; protected set; }
        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        public abstract void UpdateValue();

        public override object GetValue(NodePort port)
        {
            return Value;
        }

        #endregion
    }
}