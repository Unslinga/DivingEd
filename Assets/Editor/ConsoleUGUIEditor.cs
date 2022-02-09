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
    [CustomEditor(typeof(Console_UGUI))]
    public class ConsoleUGUIEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUILayout.Space(20);

            Console_UGUI console = (Console_UGUI)target;
            if (GUILayout.Button("Toggle Console"))
                console.ToggleActive();
        }
    }
}