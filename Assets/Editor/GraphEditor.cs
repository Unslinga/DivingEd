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
using XNodeEditor;

[CustomEditor(typeof(Graph))]
public class GraphEditor : GlobalGraphEditor
{
    #region Fields & Properties

    #endregion

    #region Public Methods

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUILayout.Space(EditorGUIUtility.singleLineHeight);

        var graph = (Graph)target;

        if (GUILayout.Button("Create GameManager Singleton", GUILayout.Height(40)))
        {
            graph.CreateGameManager();
        }
    }

    #endregion
}