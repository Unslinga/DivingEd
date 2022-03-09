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

[CustomNodeEditor(typeof(KeyboardInputEvent))]
public class KeyboardInputEventEditor : BaseNodeEditor
{
    #region Fields & Properties

    private bool modifier = false;
    private bool search = false;

    #endregion

    #region Public Methods

    public override void OnBodyGUI()
    {
        base.OnBodyGUI();

        KeyboardInputEvent inputEvent = target as KeyboardInputEvent;

        if (search)
        {
            Search(inputEvent);
            return;
        }

        GUILayout.Space(8);

        GUILayout.BeginHorizontal();
        
        if (GUILayout.Button("Set Modifier"))
        {
            modifier = true;
            search = true;
        }
        if (GUILayout.Button("Set Key"))
        {
            search = true;
        }

        GUILayout.EndHorizontal();

        Search(inputEvent);
    }

    #endregion

    #region Private Methods

    private void Search(KeyboardInputEvent inputEvent)
    {
        if (!search) return;

        Event current = Event.current;

        if (current.isKey)
        {
            if (modifier)
            {
                inputEvent.Modifier = current.keyCode;
                Debug.Log($"Set [{inputEvent.name}] modifier to [{inputEvent.KeyCode}]");
            }
            else
            {
                inputEvent.KeyCode = current.keyCode;
                Debug.Log($"Set [{inputEvent.name}] key to [{inputEvent.KeyCode}]");
            }
            
            
            modifier = false;
            search = false;
        }
    }

    #endregion
}