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

[CustomNodeEditor(typeof(InputEvent))]
public class InputEventEditor : BaseNodeEditor
{
    #region Fields & Properties

    private bool search = false;

    #endregion

    #region Public Methods

    public override void OnBodyGUI()
    {
        base.OnBodyGUI();

        GUILayout.Space(8);

        InputEvent inputEvent = target as InputEvent;

        if (GUILayout.Button("Set Key"))
        {
            search = true;
        }

        Search(inputEvent);
    }

    #endregion

    #region Private Methods

    private void Search(InputEvent inputEvent)
    {
        if (!search) return;

        Event current = Event.current;

        if (current.isKey)
        {
            inputEvent.KeyCode = current.keyCode;
            Debug.Log($"Set [{inputEvent.name}] key to [{inputEvent.KeyCode}]");
            search = false;
        }
    }

    #endregion
}