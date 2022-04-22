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
    public interface ITimeAsset
    {
        #region Fields & Properties

        double Start { get; set; }
        double Duration { get; }

        int FrameStart { get; } 
        int FrameEnd { get; }

        #endregion

        #region Public Methods

        #endregion
    }
}