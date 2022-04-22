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
using UnityEditor;
using UnityEngine;

namespace Core
{
    [CustomEditor(typeof(CommandEvent))]
    public class CommandEventEditor : Editor
    {
        private string parameters = "";
        private bool enabled = true;

        public override void OnInspectorGUI()
        {
            CommandEvent commandEvent = (CommandEvent)target;
            base.OnInspectorGUI();

            if (!commandEvent.CommandOption)
                return;

            GUILayout.FlexibleSpace();

            enabled = GUI.enabled;
            GUI.enabled = Application.isPlaying;

            if (GUILayout.Button("Raise Event"))
            {
                commandEvent.Raise(parameters.Split(' '));
            }

            GUI.enabled = enabled;

            parameters = GUILayout.TextField(parameters, 50);

        }
    }
}