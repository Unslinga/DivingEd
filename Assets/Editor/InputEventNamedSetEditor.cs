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

[CustomNodeEditor(typeof(InputEventNamedSet))]

public class InputEventNamedSetEditor : BaseNodeEditor
{
    #region Fields & Properties

    #endregion

    #region Public Methods

    public override void OnBodyGUI()
    {
        base.OnBodyGUI();

        GUILayout.Space(8);

        var set = target as InputEventNamedSet;

        if (GUILayout.Button("Update InputEvents"))
        {
            set.Items = GameManager.GetNodesByType<InputEvent>();
        }
    }

    #endregion
}