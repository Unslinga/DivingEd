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

namespace Console
{
    [CustomEditor(typeof(ConsoleUIElements))]
    public class ConsoleUIElementsEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUILayout.Space(20);

            ConsoleUIElements console = (ConsoleUIElements)target;

            if (GUILayout.Button("Toggle Console"))
                console.ToggleConsoleWindowEnabled();

            if (GUILayout.Button("CommandLineFocus"))
            { }
                //console.CommandLineFocus();

            if (GUILayout.Button("CommandLineUnfocus"))
                console.CommandLineUnfocus();
        }
    } 
}