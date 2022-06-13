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
using Simulation;

[CustomNodeEditor(typeof(SimulationNode))]
public class SimulationNodeEditor : BaseNodeEditor
{
    #region Fields & Properties

    private GUIStyle style = new GUIStyle();

    private SimulationNode simuationNode;

    private SerializedProperty flowIn;
    private SerializedProperty flowOut;

    #endregion

    #region Public Methods

    public override void OnBodyGUI()
    {
        if (simuationNode == null) simuationNode = target as SimulationNode;

        base.OnBodyGUI();

        EditorGUILayout.Space(8);

        EditorGUILayout.LabelField(simuationNode is DiverNode ? "Breathing" : "Pressure");

        style.fontSize = 24;
        style.alignment = TextAnchor.MiddleCenter;
        style.normal.textColor = Color.white;

        EditorGUILayout.LabelField(simuationNode.Value.ToString(), style);

        EditorGUILayout.Space(8);
        if (Simulation.Simulation.Instance.MaxFlowRate == null) return;

        if (simuationNode is InputNode)
        {
            if (GUILayout.Button("Cascade"))
            {
                simuationNode.Cascade(-1, new List<int> { simuationNode.ID }, Simulation.Simulation.Instance.MaxFlowRate);
            }

            EditorGUILayout.Space(8);

            if (GUILayout.Button("Clear All"))
            {
                simuationNode.Clear(new List<int> { simuationNode.ID });
            }
        }
    }

    #endregion
}