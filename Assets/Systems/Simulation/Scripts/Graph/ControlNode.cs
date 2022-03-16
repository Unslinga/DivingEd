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
using XNode;

namespace Simulation
{
    public class ControlNode : SimuationNode
    {
        #region Fields & Properties

        [Input] public Flow In;
        [Output] public Flow Out;

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion

        #region Unity Methods

        void Awake()
        {
            
        }

        void OnDestroy()
        {
            
        }

        void OnValidate()
        {
            
        }

        #endregion
    }
}