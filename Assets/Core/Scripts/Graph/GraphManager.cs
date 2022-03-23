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

namespace Core
{
    public class GraphManager : MonoBehaviour
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

        void Awake()
        {
            this.Instance<GraphManager>();
        }

        #endregion
    }
}