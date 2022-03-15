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

[CustomNodeEditor(typeof(MouseInputEvent))]
public class MouseInputEventEditor : BaseNodeEditor
{
    #region Fields & Properties

    private bool search = false;

    #endregion

    #region Public Methods

    public override void OnBodyGUI()
    {
        base.OnBodyGUI();

        MouseInputEvent inputEvent = target as MouseInputEvent;

        if (search)
        {
            Search(inputEvent);
            return;
        }

        GUILayout.Space(8);

        if (GUILayout.Button("Set Button"))
        {
            search = true;
        }
    }

    #endregion

    #region Private Methods

    private void Search(MouseInputEvent inputEvent)
    {
        if (!search) return;

        Event current = Event.current;

        if (current.type == EventType.MouseDown)
        {
            inputEvent.Button = current.button;
            Debug.Log($"Set [{inputEvent.name}] key to [{inputEvent.Button}]");

            search = false;
        }
    }

    #endregion
}