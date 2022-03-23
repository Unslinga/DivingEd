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
using UnityEditor;
using Simulation;

[CustomNodeEditor(typeof(InputNode))]
public class InputNodeEditor : SimulationNodeEditor
{
    #region Fields & Properties

    #endregion

    #region Public Methods

    public override void OnBodyGUI()
    {
        base.OnBodyGUI();
    }

    #endregion
}