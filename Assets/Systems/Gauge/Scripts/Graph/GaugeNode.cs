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

namespace Gauge
{
    public class GaugeNode : BaseNode
    {
        #region Fields & Properties
        [Input(ShowBackingValue.Never, ConnectionType.Override)]
        public DoubleVariable value; 
        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion

        #region Unity Methods
    
        void Start()
        {
        
        }

        void Update()
        {
        
        }

        #endregion
    }
}