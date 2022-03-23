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
using XNode;
using XNodeEditor;

[CustomNodeEditor(typeof(SimuationNode))]
public class SimulationNodeEditor : BaseNodeEditor
{
    #region Fields & Properties

    private GUIStyle style = new GUIStyle();

    private SimuationNode simuationNode;

    private SerializedProperty flowIn;
    private SerializedProperty flowOut;

    #endregion

    #region Public Methods

    public override void OnBodyGUI()
    {
        if (simuationNode == null) simuationNode = target as SimuationNode;

        base.OnBodyGUI();

        EditorGUILayout.Space(8);

        EditorGUILayout.LabelField("Pressure");

        style.fontSize = 24;
        style.alignment = TextAnchor.MiddleCenter;
        style.normal.textColor = Color.white;

        EditorGUILayout.LabelField(simuationNode.Value.ToString(), style);

        EditorGUILayout.Space(8);

        if (GUILayout.Button("Update"))
        {
            simuationNode.UpdateValue();
        }
    }

    #endregion
}