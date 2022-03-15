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
using XNodeEditor;

[CustomNodeEditor(typeof(BaseNode))]
public class BaseNodeEditor : NodeEditor
{
    #region Fields & Properties

    #endregion

    #region Public Methods

    public override void OnBodyGUI()
    {
        bool enabled = GUI.enabled;

        GUI.enabled = false;
        GUILayout.Label(target.GetType().Name);
        GUI.enabled = enabled;

        GUILayout.Space(8);

        base.OnBodyGUI();
    }

    #endregion
}