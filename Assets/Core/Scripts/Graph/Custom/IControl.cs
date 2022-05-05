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
    public interface IControl
    {
        #region Fields & Properties

        #endregion

        #region Public Methods

        public double UpdateFlow(double nodePressure, double flowRate);

        #endregion

    }
}