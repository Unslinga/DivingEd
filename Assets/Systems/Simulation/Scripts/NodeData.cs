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

namespace Simulation
{
    [Serializable]
    public class NodeData
    {
        #region Fields & Properties
        [field: SerializeField]
        public DoubleReference Value { get; set; }

        #endregion

        #region Public Methods

        public static implicit operator double(NodeData data)
        {
            return data.Value;
        }

        #endregion

        #region Private Methods

        #endregion
    }
}